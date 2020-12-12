--psbd_flights
CREATE TABLE psbd_flights (
    flight_id        NUMBER(5) NOT NULL,
    from_location    CHAR(30) NOT NULL,
    to_location      CHAR(30) NOT NULL,
    departure_time   DATE NOT NULL,
    arrival_time     DATE NOT NULL
);

ALTER TABLE psbd_flights ADD CONSTRAINT arrival_time_ck CHECK ( arrival_time > departure_time );

ALTER TABLE psbd_flights ADD CONSTRAINT psbd_flights_pk PRIMARY KEY ( flight_id );

CREATE SEQUENCE psbd_flights_flight_id_seq START WITH 1 NOCACHE ORDER;

ALTER TABLE psbd_flights MODIFY (from_location NULL);
ALTER TABLE psbd_flights MODIFY (to_location NULL);
ALTER TABLE psbd_flights MODIFY (from_location varchar2(50));
ALTER TABLE psbd_flights MODIFY (to_location varchar2(50));

CREATE OR REPLACE TRIGGER psbd_flights_flight_id_trg BEFORE
    INSERT ON psbd_flights
    FOR EACH ROW
    WHEN ( new.flight_id IS NULL )
BEGIN
    :new.flight_id := psbd_flights_flight_id_seq.nextval;
END;
/

INSERT INTO psbd_flights VALUES (10000, null, null, TO_DATE('5-1-2020 9:15'), TO_DATE('5-1-2020 10:07'));
INSERT INTO psbd_flights_details values (10000, 1000, 1002, 89.99, 32, 32);

INSERT INTO psbd_flights VALUES (10001, null, null, TO_DATE('6-1-2020 17:00'), TO_DATE('6-1-2020 17:38'));
INSERT INTO psbd_flights_details values (10001, 1001, 1003, 49.99, 25, 25);

INSERT INTO psbd_flights VALUES (10002, null, null, TO_DATE('7-1-2020 13:10'), TO_DATE('7-1-2020 15:21'));
INSERT INTO psbd_flights_details values (10002, 1004, 1005, 149.99, 25, 25);

INSERT INTO psbd_flights VALUES (10003, null, null, TO_DATE('8-1-2020 15:21'), TO_DATE('8-1-2020 17:00'));
INSERT INTO psbd_flights_details values (10003, 1006, 1007, 119.99, 28, 28);

INSERT INTO psbd_flights VALUES (10004, null, null, TO_DATE('9-1-2020 4:11'), TO_DATE('9-1-2020 5:24'));
INSERT INTO psbd_flights_details values (10004, 1008, 1009, 200.99, 19, 19);

INSERT INTO psbd_flights VALUES (10005, null, null, TO_DATE('12-1-2020 9:15'), TO_DATE('12-1-2020 10:07'));
INSERT INTO psbd_flights_details values (10005, 1000, 1002, 89.99, 32, 32);

INSERT INTO psbd_flights VALUES (10006, null, null, TO_DATE('13-1-2020 17:00'), TO_DATE('13-1-2020 17:38'));
INSERT INTO psbd_flights_details values (10006, 1001, 1003, 49.99, 25, 25);

INSERT INTO psbd_flights VALUES (10007, null, null, TO_DATE('14-1-2020 13:10'), TO_DATE('14-1-2020 15:21'));
INSERT INTO psbd_flights_details values (10007, 1004, 1005, 149.99, 25, 25);

INSERT INTO psbd_flights VALUES (10008, null, null, TO_DATE('15-1-2020 15:21'), TO_DATE('15-1-2020 17:00'));
INSERT INTO psbd_flights_details values (10008, 1006, 1007, 119.99, 28, 28);

INSERT INTO psbd_flights VALUES (10009, null, null, TO_DATE('16-1-2020 4:11'), TO_DATE('16-1-2020 5:24'));
INSERT INTO psbd_flights_details values (10009, 1008, 1009, 200.99, 19, 19);

--psbd_flight_details
CREATE TABLE psbd_flights_details (
    flight_id              NUMBER(5) NOT NULL,
    departure_airport_id   NUMBER(4) NOT NULL,
    arrival_airport_id     NUMBER(4) NOT NULL,
    price                  NUMBER(6, 2) NOT NULL,
    seat_capacity          NUMBER(2) NOT NULL,
    available_seats        NUMBER(2) NOT NULL
);

ALTER TABLE psbd_flights_details ADD CONSTRAINT price_ck CHECK ( price > 0 );

ALTER TABLE psbd_flights_details ADD CONSTRAINT available_seats_ck CHECK ( available_seats <= seat_capacity );


ALTER TABLE psbd_flights_details
    ADD CONSTRAINT flights_details_airports_fk FOREIGN KEY ( departure_airport_id )
        REFERENCES psbd_airports ( airport_id );

ALTER TABLE psbd_flights_details
    ADD CONSTRAINT flights_details_airports_fkv2 FOREIGN KEY ( arrival_airport_id )
        REFERENCES psbd_airports ( airport_id );


ALTER TABLE psbd_flights_details
    ADD CONSTRAINT flights_details_flights_fk FOREIGN KEY ( flight_id )
        REFERENCES psbd_flights ( flight_id );

--psbd_airports
CREATE TABLE psbd_airports (
    airport_id     NUMBER(4) NOT NULL,
    airport_name   CHAR(50) NOT NULL,
    address        CHAR(50) NOT NULL,
    city           CHAR(50) NOT NULL,
    country        CHAR(50) NOT NULL,
    contact        NUMBER(13) NOT NULL
);

ALTER TABLE psbd_airports
    ADD CONSTRAINT airport_phone_number_ck CHECK ( REGEXP_LIKE ( phonenumber,
                                                                 '[0-9%]{13}' ) );

ALTER TABLE psbd_airports ADD CONSTRAINT airports_pk PRIMARY KEY ( airport_id );

CREATE SEQUENCE psbd_airports_airport_id_seq START WITH 1 NOCACHE ORDER;

CREATE OR REPLACE TRIGGER psbd_airports_airport_id_trg BEFORE
    INSERT ON psbd_airports
    FOR EACH ROW
    WHEN ( new.airport_id IS NULL )
BEGIN
    :new.airport_id := psbd_airports_airport_id_seq.nextval;
END;
/

insert into PSBD_AIRPORTS values (1000, 'Henri Coandă International Airport', 'Calea Bucurestilor 224E, Otopeni 075150', 'Bucuresti', 'Romania', '0040212041000');
insert into PSBD_AIRPORTS values (1001, 'Cluj Avram Iancu International Airport', 'Strada Traian Vuia 149-151, Cluj-Napoca 400397', 'Cluj-Napoca', 'Romania', '0040212041001');
insert into PSBD_AIRPORTS values (1002, 'Aeroportul Internațional Traian Vuia', 'Strada Aeroportului 2, Ghiroda 307200', 'Timisoara', 'Romania', '0040212041502');
insert into PSBD_AIRPORTS values (1003, 'Aeroportul Internațional Iași', 'Strada Moara de Vânt nr. 34, Iași 700750', 'Iasi', 'Romania', '0040212041502');
insert into PSBD_AIRPORTS values (1004, 'Aeroportul Internațional Ștefan cel Mare Suceava', 'Orașul Salcea 727475', 'Suceava', 'Romania', '0040212045302');
insert into PSBD_AIRPORTS values (1005, 'Aeroportul Torino', 'Strada Aeroporto, 12, 10072 Caselle Torinese TO', 'Torino', 'Italia', '0039212045302');
insert into PSBD_AIRPORTS values (1006, 'Aeroportul Internațional Milano-Malpensa', '21010 Ferno, Province of Varese', 'Milano', 'Italia', '0039285045302');
insert into PSBD_AIRPORTS values (1007, 'Aeroportul Londra City', 'Hartmann Rd, Royal Docks, London E16 2PX', 'Londra', 'Regatul Unit', '0442076460000');
insert into PSBD_AIRPORTS values (1008, 'Aeroportul Internațional Charles de Gaulle', '95700 Roissy-en-France', 'Paris', 'Franta', '0148622801');
insert into PSBD_AIRPORTS values (1009, 'Aeroportul Berlin Tegel', ' Saatwinkler Damm, 13405 Berlin', 'Berlin', 'Germania', '0493060911150');


--psbd_customers
CREATE TABLE psbd_customers (
    customer_id        NUMBER(5) NOT NULL,
    first_name         CHAR(50) NOT NULL,
    last_name          CHAR(50) NOT NULL,
    nationality        CHAR(20) NOT NULL,
    id_code            CHAR(15) NOT NULL,
    telephone_number   CHAR(13) NOT NULL,
    address            CHAR(50),
    email              CHAR(50) NOT NULL
);

ALTER TABLE psbd_customers
    ADD CONSTRAINT customer_telephone_number_ck CHECK ( REGEXP_LIKE ( phonenumber,
                                                                      '[0-9%]{13}' ) );

ALTER TABLE psbd_customers
    ADD CONSTRAINT email_customers_ck CHECK ( REGEXP_LIKE ( email,
                                                            '[a-z0-9._%]+@[a-z0-9._%]+\.[a-z]{2,4}' ) );

ALTER TABLE psbd_customers ADD CONSTRAINT customers_pk PRIMARY KEY ( customer_id );

CREATE SEQUENCE psbd_customers_customer_id_seq START WITH 1 NOCACHE ORDER;

CREATE OR REPLACE TRIGGER psbd_customers_customer_id_trg BEFORE
    INSERT ON psbd_customers
    FOR EACH ROW
    WHEN ( new.customer_id IS NULL )
BEGIN
    :new.customer_id := psbd_customers_customer_id_seq.nextval;
END;
/

--psbd_tickets
CREATE TABLE psbd_tickets (
    ticket_id     NUMBER(5) NOT NULL,
    customer_id   NUMBER(5) NOT NULL,
    flight_id     NUMBER(5) NOT NULL,
    total_price   NUMBER(7, 2) NOT NULL
);

ALTER TABLE psbd_tickets ADD CONSTRAINT total_price_ck CHECK ( total_price > 0 );

ALTER TABLE psbd_tickets ADD CONSTRAINT tickets_pk PRIMARY KEY ( ticket_id );

ALTER TABLE psbd_tickets
    ADD CONSTRAINT tickets_customers_fk FOREIGN KEY ( customer_id )
        REFERENCES psbd_customers ( customer_id );

ALTER TABLE psbd_tickets
    ADD CONSTRAINT tickets_psbd_flights_fk FOREIGN KEY ( flight_id )
        REFERENCES psbd_flights ( flight_id );

CREATE SEQUENCE psbd_tickets_ticket_id_seq START WITH 1 NOCACHE ORDER;

CREATE OR REPLACE TRIGGER psbd_tickets_ticket_id_trg BEFORE
    INSERT ON psbd_tickets
    FOR EACH ROW
    WHEN ( new.ticket_id IS NULL )
BEGIN
    :new.ticket_id := psbd_tickets_ticket_id_seq.nextval;
END;
/
