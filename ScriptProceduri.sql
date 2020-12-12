--triggers
create or replace trigger delete_ticket_trigger
    after delete 
    on psbd_tickets
    for each row
begin
    update psbd_flights_details 
        set AVAILABLE_SEATS = (AVAILABLE_SEATS + 1)
        where flight_id = :old.flight_id;
end;

create or replace TRIGGER  insert_city_trg
    AFTER INSERT
    ON PSBD_FLIGHTS_DETAILS
    FOR EACH ROW
DECLARE
    v_departure_city      PSBD_AIRPORTS.city%TYPE;
    v_arrival_city        PSBD_AIRPORTS.city%TYPE;
    v_departure_aiport_id PSBD_AIRPORTS.airport_id%TYPE;
    v_arrival_aiport_id PSBD_AIRPORTS.airport_id%TYPE;
    v_fl_id PSBD_FLIGHTS.FLIGHT_ID%TYPE;
BEGIN
    v_departure_aiport_id := :new.departure_airport_id;
    v_arrival_aiport_id := :new.ARRIVAL_AIRPORT_ID;
    v_fl_id := :new.FLIGHT_ID;

    SELECT
        a.city
    INTO v_departure_city
    FROM PSBD_AIRPORTS a
    WHERE v_departure_aiport_id = a.AIRPORT_ID;

    SELECT
        a.city
    INTO v_arrival_city
    FROM PSBD_AIRPORTS a
    WHERE v_arrival_aiport_id = a.AIRPORT_ID;

    UPDATE PSBD_FLIGHTS
    SET FROM_LOCATION = v_departure_city,
        TO_LOCATION = v_arrival_city
    WHERE FLIGHT_ID = v_fl_id;
END;

create or replace trigger seats_update_trigger 
    after insert
    on psbd_tickets
    for each row
begin 
        update psbd_flights_details 
        set AVAILABLE_SEATS = (AVAILABLE_SEATS - 1)
        where flight_id = :new.flight_id;
end;

--packages and procedures
--flights package
create or replace PACKAGE flights_package AS
    PROCEDURE usp_flightsearch (
        search_departure_city   IN    psbd_flights.from_location%TYPE,
        search_arrival_city     IN    psbd_flights.to_location%TYPE,
        flight_info_cursor      OUT   SYS_REFCURSOR
    );

    PROCEDURE usp_flightinfoprint (
        flight_info_cursor OUT SYS_REFCURSOR
    );

END flights_package;

create or replace package body flights_package as
    PROCEDURE usp_flightsearch (
        search_departure_city   IN    psbd_flights.from_location%TYPE,
        search_arrival_city     IN    psbd_flights.to_location%TYPE,
        flight_info_cursor      OUT   SYS_REFCURSOR
    ) IS
    BEGIN
        OPEN flight_info_cursor FOR SELECT
                                        f.from_location,
                                        f.to_location,
                                        f.departure_time,
                                        f.arrival_time,
                                        fd.price,
                                        f.flight_id, 
                                        fd.available_seats
                                    FROM
                                        psbd_flights f
                                        JOIN psbd_flights_details   fd ON f.flight_id = fd.flight_id
                                    WHERE
                                        REGEXP_LIKE ( f.from_location,
                                                      concat(search_departure_city, '+[a-zA-Z0-9 .]') )
                                        AND REGEXP_LIKE ( f.to_location, CONCAT(search_arrival_city, '+[a-zA-Z0-9 .]'))
                                    ORDER BY f.flight_id;

    END;

    PROCEDURE usp_flightinfoprint (
        flight_info_cursor OUT SYS_REFCURSOR
    ) IS
    BEGIN
        OPEN flight_info_cursor FOR SELECT
                                        f.from_location,
                                        f.to_location,
                                        f.departure_time,
                                        f.arrival_time,
                                        fd.price,
                                        f.flight_id, 
                                        fd.available_seats
                                    FROM
                                        psbd_flights f
                                        JOIN psbd_flights_details   fd ON f.flight_id = fd.flight_id
                                    ORDER BY f.flight_id;

        end;
    END;

--customers package
create or replace PACKAGE customers_package AS
    PROCEDURE usp_insertcustomer (
        cust_first_name   IN    psbd_customers.first_name%TYPE,
        cust_last_name     IN    psbd_customers.last_name%TYPE,
        cust_nationality IN psbd_customers.NATIONALITY%TYPE,
        cust_ID_CODE IN psbd_customers.id_code%type,
        cust_TELEPHONE_NUMBER IN psbd_customers.TELEPHONE_NUMBER%type,
        cust_ADDRESS IN psbd_customers.ADDRESS%type,
        cust_EMAIL IN psbd_customers.EMAIL%type,
        ticket_flight_id IN psbd_flights.FLIGHT_ID%type,
        ticket_total_price IN psbd_flights_details.price%type
    );

    PROCEDURE usp_deletecustomer (
        cust_id in psbd_customers.customer_id%type
    );

    procedure usp_printcustomers (
        customers_info_cursor      OUT   SYS_REFCURSOR    
    );

END customers_package;
/

create or replace PACKAGE BODY customers_package AS
 PROCEDURE usp_insertcustomer (
        cust_first_name   IN    psbd_customers.first_name%TYPE,
        cust_last_name     IN    psbd_customers.last_name%TYPE,
        cust_nationality IN psbd_customers.NATIONALITY%TYPE,
        cust_ID_CODE IN psbd_customers.id_code%type,
        cust_TELEPHONE_NUMBER IN psbd_customers.TELEPHONE_NUMBER%type,
        cust_ADDRESS IN psbd_customers.ADDRESS%type,
        cust_EMAIL IN psbd_customers.EMAIL%type,
        ticket_flight_id IN psbd_flights.FLIGHT_ID%type,
        ticket_total_price IN psbd_flights_details.price%type
    ) IS
        v_customer_id psbd_customers.CUSTOMER_ID%type;
        any_rows_found number;
        nr_rows number;
    BEGIN 
        select count(*) into any_rows_found from psbd_customers where id_code = cust_id_code;
        select count(*) into nr_rows from psbd_customers;
        if nr_rows = 0 then 
            v_customer_id := 0;
        else 
            SELECT max(CUSTOMER_ID)  INTO v_customer_id FROM psbd_customers;
        end if;
        if any_rows_found = 0  then
            v_customer_id := v_customer_id + 1;
            INSERT INTO psbd_customers VALUES 
                (v_customer_id, cust_first_name, cust_last_name, cust_nationality, cust_ID_CODE, cust_TELEPHONE_NUMBER, cust_ADDRESS,
                cust_EMAIL);
        else 
            select customer_id into v_customer_id from psbd_customers where cust_id_code = id_code;
        end if;
        INSERT INTO psbd_tickets VALUES 
            (null, v_customer_id, ticket_flight_id, ticket_total_price);
    END usp_insertcustomer;

    PROCEDURE usp_deletecustomer (
        cust_id in psbd_customers.customer_id%type
    ) is
    begin
        delete from psbd_tickets where customer_id = cust_id;
        delete from psbd_customers where customer_id = cust_id;
    end usp_deletecustomer;

    procedure usp_printcustomers (
        customers_info_cursor      OUT   SYS_REFCURSOR    
    ) is
    begin
        open customers_info_cursor for
            select customer_id, first_name, last_name, TELEPHONE_NUMBER, email
            from psbd_customers;
    end usp_printcustomers;
end;
/

--tickets_package
create or replace package tickets_package as
    procedure usp_searchtickets (
        cust_id_code IN psbd_customers.id_code%TYPE, 
        ticket_info_cursor OUT SYS_REFCURSOR
    );
    procedure usp_deleteticket (
        ticket_id_del IN psbd_tickets.ticket_id%TYPE
    );
end tickets_package;
/

create or replace package body tickets_package as
    procedure usp_searchtickets (
        cust_id_code IN psbd_customers.id_code%TYPE, 
        ticket_info_cursor OUT SYS_REFCURSOR
    ) is
    begin
    open ticket_info_cursor for
        select t.ticket_id, c.first_name, c.last_name, f.from_location, f.to_location, f.departure_time
        from psbd_tickets t 
        join psbd_customers c on t.customer_id = c.customer_id
        join psbd_flights f on t.flight_id = f.flight_id
        where cust_id_code = c.id_code;
    end usp_searchtickets;

     procedure usp_deleteticket (
        ticket_id_del IN psbd_tickets.ticket_id%TYPE
    ) is
    begin
        delete from psbd_tickets where ticket_id_del = ticket_id;
    end;
end tickets_package;
/