

### Capitolul 1. Prezentarea proiectului

#### 1.1. Descrierea proiectului

Tema proiectului este rezervarea biletelor de avion.Utilizatorul poate vedea
toate zborurile disponibile și își poate alege zborul pentru care dorește sa
 facă rezervarea. Apoi își introduce datele de contact și își poate rezerva 
biletul dorit. Folosind o parola (pentru admin), utilizatorul poate accesa 
toți clientii și poate sterge biletele pe care le dorește (cei care vor sa 
anuleze rezervarea).

#### 1.2.Continut si descrierea tabelelor

```
Tabele: psbd_flights, psbd_flights_details, psbd_airports, psbd_customers, psbd_tickets.
```
- psbd_flights – contine zborurile disponibile
- psbd_flights_details – con ine detaliile despre zboruri
- psbd_airports – con ine aeroporturile de decolare
- psbd_customers – con ine datele clientilor
- psbd_tickets – con ine biletele pentru zboruri


**Diagrame ER:**


#### 1.3. Tehnologii folosite

```
Pe partea de front-end : C#.
Pe partea de back-end :
    - Oracle Database 11g Express Edition Release 11.2.0.2.0 - 64bit
    - Production
    - PL/SQL Release 11.2.0.2.0 - Production
    - Oracle Data Provider for .NET (ODP.NET).
    - NET, C#
```

#### 1.4. Conectarea la baza de date

    using Oracle.ManagedDataAccess.Client;
    private OracleConnection con;
    private string connectionString = "User Id=system;Password=root;Data
    Source=localhost:1521/xe";
    private void ConectareBazaDeDate()
    {
        this.con = new OracleConnection();
        this.con.ConnectionString = connectionString;
        this.con.Open();
    }

    public void DeconectareBazaDeDate()
    {
        con.Close();
    }

#### 1.5. Package-uri si Proceduri folosite

- PACKAGE FLIGHTS_PACKAGE (con ine procedurile care lucrează cu tablea deț
    zboruri)
    ◦ PROCEDURE USP_FLIGHTSEARCH (cauta în baza de date zborurile după ora deș
       plecare i ora de sosire) șș
    ◦ PROCEDURE usp_flightinfoprint (afiseaza toate zborurile din tablea
       PSBD_FLIGHTS)
- PACKAGE customers_package (con ine procedurile care lucrează cu tabela de clien i)țț
    ◦ PROCEDURE usp_insertcustomer (insreaza în baza de date un client nou)
    ◦ PROCEDURE usp_deletecustomer (sterge din baza de date un client)
    ◦ PROCEDURE usp_printcustomers (afiseaza clientii)
- PACKAGE tickets_package (con ine procedurile care lucrează cu tabela de bilete)ț
    ◦ PROCEDURE usp_searchtickets (cauta biletele după CNP-ul clientului)
    ◦ PROCEDURE usp_deleteticket (sterge un bilet din tabela)


#### 1.6. Triggere folosite (fără autoincrement)

- TRIGGER insert_city_trg (actualizeaza ora ul de plecare i ora ul de sosire când seșșș
    introduce un nou zbor)
- TRIGGER seats_update_trigger (actualizeaza locurile valabile când se adauga un client
    nou)
- TRIGGER delete_ticket_trigger (actualizeaza locurile valabile când se sterge un client)


