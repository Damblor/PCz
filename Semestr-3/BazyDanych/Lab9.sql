
drop table transakcje CASCADE CONSTRAINTS;
drop table produkty CASCADE CONSTRAINTS;
drop table kasjerzy CASCADE CONSTRAINTS;


---zad 1 
CREATE TABLE produkty
(
    id_produktu NUMBER(4) CONSTRAINT id_produktu_un UNIQUE,
    nazwa VARCHAR(40) CONSTRAINT nazwa_nn NOT NULL,
    stan NUMBER(6,2) DEFAULT 0,
    cena NUMBER(6,2) DEFAULT 1.23,
    wartosc as (stan * cena)
);

CREATE TABLE kasjerzy
(  id_kasjera NUMBER(5) CONSTRAINT id_kasjera_pk PRIMARY KEY,
    nazwisko VARCHAR(20),
    data_zatrudnienia DATE CONSTRAINT data_zat_nn NOT NULL,
    placa NUMBER(7,2)
);

-- zad 3
create table Transakcje
( id_transakcji number(8) CONSTRAINT id_transakcje_pk PRIMARY KEY,
id_produktu number(4) CONSTRAINT id_produktu_nn not null,
id_sprzedawcy number(5) CONSTRAINT id_sprzedawcy_nn not null,
miara number(6,2) DEFAULT 1,
czas_transakcji TIMESTAMP,
CONSTRAINT id_produktu_fk FOREIGN key(id_produktu) 
REFERENCES produkty(id_produktu),
CONSTRAINT id_sprzedawcy_fk FOREIGN key(id_sprzedawcy) 
REFERENCES kasjerzy(id_kasjera)
);

-- zad 4
--a 
alter table kasjerzy modify(placa default 3200);
--b
alter table transakcje modify(czas_transakcji default systimestamp);
--c
alter table kasjerzy add constraint id_kasjera_ch check(id_kasjera>=100);
--d
alter table transakcje drop constraint id_produktu_fk;
alter table produkty drop constraint id_produktu_un;
alter table produkty add constraint id_produktu_pk primary key(id_produktu);
alter table transakcje add CONSTRAINT id_produktu_fk FOREIGN key(id_produktu) 
REFERENCES produkty(id_produktu) on delete cascade;
--e
alter table transakcje drop constraint id_sprzedawcy_nn;
alter table transakcje drop constraint id_sprzedawcy_fk;
alter table transakcje add CONSTRAINT id_sprzedawcy_fk FOREIGN key(id_sprzedawcy) 
REFERENCES kasjerzy(id_kasjera) on delete set null;
--f
alter table kasjerzy RENAME COLUMN placa TO pensja;
--g
alter table kasjerzy add(data_urodzenia date CONSTRAINT data_ur_ch 
CHECK(data_urodzenia>=to_date('1960-01-01','YYYY-MM-DD')), 
data_zwolnienia date DEFAULT null);
--h
alter table kasjerzy add CONSTRAINT data_zwol_ch 
check(nvl(data_zwolnienia,data_zatrudnienia+1) >= data_zatrudnienia and
nvl(data_zwolnienia,data_urodzenia+1) >= data_urodzenia);
--i
alter table produkty MODIFY(wartosc number(8,2));


-- Po zadaniu 4
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(1, 'cukier', 100, 2.95);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(2, 'chleb', 50, 3.7);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(3, 'jogurt', 20, 1.15);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(4, 'schab', 6.5, 15.2);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(5, 'piwo', 200, 3.1);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(6, 'cukierki', 10, 23);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(7, 'kurczak', 10, 12.35);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(8, 'banan', 6.5, 5.20);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(9, 'mydlo', 40, 2.5);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(10, 'pomidory', 8.5, 8.5);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(11, 'olej', 20, 6.95);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(12, 'kisiel', 150, 1.15);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(13, 'ciastka', 25, 4.80);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(14, 'plyn do naczyn', 15, 8.20);
INSERT INTO Produkty (id_produktu, nazwa, stan, cena) VALUES(15, 'pieprz', 30, 3.15);


INSERT INTO Kasjerzy (id_kasjera, nazwisko, data_zatrudnienia, data_urodzenia) VALUES
(100, 'Kowalski', To_date('01-01-2010', 'DD-MM-YYYY'), To_date('11-03-1990', 'DD-MM-YYYY'));
INSERT INTO Kasjerzy (id_kasjera, nazwisko, data_zatrudnienia, data_urodzenia) VALUES
(101, 'Nowak', To_date('01-03-2012', 'DD-MM-YYYY'), To_date('21-10-1992', 'DD-MM-YYYY'));
INSERT INTO Kasjerzy (id_kasjera, nazwisko, data_zatrudnienia, data_urodzenia) VALUES
(102, 'Polak', To_date('01-10-2013', 'DD-MM-YYYY'), To_date('18-09-1983', 'DD-MM-YYYY'));
INSERT INTO Kasjerzy (id_kasjera, nazwisko, data_zatrudnienia, data_urodzenia) VALUES
(103, 'Zalas', To_date('01-01-2019', 'DD-MM-YYYY'), To_date('14-12-1985', 'DD-MM-YYYY'));
INSERT INTO Kasjerzy (id_kasjera, nazwisko, data_zatrudnienia, data_urodzenia) VALUES
(104, 'Pogonowska', To_date('01-11-2018', 'DD-MM-YYYY'), To_date('28-03-1993', 'DD-MM-YYYY'));

INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (1, 1, 100, 2);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (2, 1, 101, 1);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (3, 2, 100, 1);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (4, 3, 102, 5);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (5, 4, 100, 1.35);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (6, 5, 101, 4);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (7, 6, 100, 0.45);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (8, 7, 102, 1.84);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (9, 4, 101, 1.05);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (10, 6, 102, 1.55);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (11, 6, 102, 0.8);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (12, 7, 102, 2.5);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (13, 7, 103, 1.95);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (14, 11, 100, 2);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (15, 11, 104, 1);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (16, 12, 102, 8);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (17, 12, 103, 4);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (18, 12, 104, 5);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (19, 12, 103, 11);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (20, 13, 104, 2);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (21, 14, 102, 1);
INSERT INTO Transakcje (id_transakcji, id_produktu, id_sprzedawcy, miara) VALUES (22, 14, 101, 2);

commit;
ROLLBACK;

--zad 5
select * from transakcje;
select * from produkty;

ALTER TABLE Transakcje ADD rachunek NUMBER(8,2);
UPDATE Produkty pr SET Stan =Stan-(SELECT SUM(miara) FROM Transakcje 
WHERE id_produktu =pr.id_produktu AND Rachunek IS NULL) WHERE 
EXISTS(SELECT* FROM Transakcje 
WHERE id_produktu =pr.id_produktu AND Rachunek IS NULL);




UPDATE Transakcje tr SET Rachunek =miara*(SELECT cena FROM Produkty WHERE
id_produktu=tr.id_produktu) WHERE rachunek IS NULL;

--zad 6
ALTER TABLE Kasjerzy disable CONSTRAINT id_kasjera_ch;
ALTER TABLE Kasjerzy disable CONSTRAINT data_ur_ch;
INSERT INTO Kasjerzy (id_kasjera, nazwisko, data_zatrudnienia, data_urodzenia) 
VALUES (10, 'Malinowska', sysdate, To_date('13-05-1958', 'DD-MM-YYYY'));
ALTER TABLE Kasjerzy ENABLE CONSTRAINT id_kasjera_ch;
ALTER TABLE Kasjerzy ENABLE CONSTRAINT data_ur_ch;
UPDATE kasjerzy SET id_kasjera = 
DECODE(
(SELECT MAX(id_kasjera) + 1 FROM kasjerzy),11,100,
(SELECT MAX(id_kasjera) + 1 FROM kasjerzy))
WHERE id_kasjera = 10;
SELECT * FROM kasjerzy;
ALTER TABLE Kasjerzy ENABLE CONSTRAINT id_kasjera_ch;
ALTER TABLE Kasjerzy ENABLE NOVALIDATE CONSTRAINT data_ur_ch;
INSERT INTO Kasjerzy (id_kasjera, nazwisko, data_zatrudnienia, data_urodzenia) 
VALUES (200, 'Malinowska', sysdate, To_date('13-05-1958', 'DD-MM-YYYY'));