--Zad 1
CREATE GLOBAL TEMPORARY TABLE min_ryby_wedkarzy(
id_wedkarza NUMBER(5),
nazwisko VARCHAR2(30 byte),
id_gatunku NUMBER(2),
nazwa VARCHAR2(30 byte),
wartosc NUMBER(5,2),
komentarz VARCHAR2(30 byte)
)
ON COMMIT DELETE ROWS;

CREATE GLOBAL TEMPORARY TABLE max_ryby_wedkarzy(
id_wedkarza NUMBER(5),
nazwisko VARCHAR2(30 byte),
id_gatunku NUMBER(2),
nazwa VARCHAR2(30 byte),
wartosc NUMBER(5,2),
komentarz VARCHAR2(30 byte)
)
ON COMMIT DELETE ROWS;

SELECT id_wedkarza,nazwisko,id_gatunku,nazwa,
(SELECT NVL(MIN(waga),0) FROM rejestry WHERE 
id_wedkarza=we.id_wedkarza AND id_gatunku=ga.id_gatunku) najlzejsza,
(SELECT NVL(MAX(waga),0) FROM rejestry WHERE 
id_wedkarza=we.id_wedkarza AND id_gatunku=ga.id_gatunku) najciezsza
FROM wedkarze we CROSS JOIN gatunki ga;


INSERT ALL 
INTO min_ryby_wedkarzy VALUES 
(id_wedkarza,nazwisko,id_gatunku,nazwa,najlzejsza,'najlzejsza')
INTO max_ryby_wedkarzy VALUES 
(id_wedkarza,nazwisko,id_gatunku,nazwa,najciezsza,'najciezsza')
SELECT id_wedkarza,nazwisko,id_gatunku,nazwa,
(SELECT nvl(MIN(waga),0) FROM rejestry WHERE 
id_wedkarza=we.id_wedkarza AND id_gatunku=ga.id_gatunku) najlzejsza,
(SELECT nvl(MAX(waga),0) FROM rejestry WHERE 
id_wedkarza=we.id_wedkarza AND id_gatunku=ga.id_gatunku) najciezsza
FROM wedkarze we CROSS JOIN gatunki ga;

SELECT * FROM max_ryby_wedkarzy;
COMMIT;

INSERT ALL 
WHEN najkrutsza > 0 AND najkrutsza < 35 THEN INTO min_ryby_wedkarzy VALUES 
(id_wedkarza,nazwisko,id_gatunku,nazwa,najkrutsza,'najkrutsza')
WHEN najdluzsza > 60 THEN INTO max_ryby_wedkarzy VALUES 
(id_wedkarza,nazwisko,id_gatunku,nazwa,najdluzsza,'najdluzsza')
SELECT id_wedkarza,nazwisko,id_gatunku,nazwa,
(SELECT nvl(MIN(dlugosc),0) FROM rejestry WHERE 
id_wedkarza=we.id_wedkarza AND id_gatunku=ga.id_gatunku) najkrutsza,
(SELECT nvl(MAX(dlugosc),0) FROM rejestry WHERE 
id_wedkarza=we.id_wedkarza AND id_gatunku=ga.id_gatunku) najdluzsza
FROM wedkarze we CROSS JOIN gatunki ga;

SELECT id_wedkarza,nazwisko,id_gatunku,nazwa,
(SELECT nvl(MIN(dlugosc),0) FROM rejestry WHERE 
id_wedkarza=we.id_wedkarza AND id_gatunku=ga.id_gatunku) najkrutsza,
(SELECT nvl(MAX(dlugosc),0) FROM rejestry WHERE 
id_wedkarza=we.id_wedkarza AND id_gatunku=ga.id_gatunku) najdluzsza
FROM wedkarze we CROSS JOIN gatunki ga;

SELECT * FROM max_ryby_wedkarzy;
SELECT * FROM min_ryby_wedkarzy;
COMMIT;
DROP TABLE max_ryby_wedkarzy;
DROP TABLE min_ryby_wedkarzy;

--Zad 3
CREATE TABLE Zak(
id_studenta NUMBER(6) PRIMARY KEY,
nazwisko VARCHAR2(20 byte) NOT NULL,
imie VARCHAR2(15 byte) NOT NULL,
pseudonim VARCHAR2(30 byte) NOT NULL,
kierunek VARCHAR2(20 byte) DEFAULT 'INFORMATYKA',
stopien NUMBER CHECK(stopien IN(1,2,3)),
semestr NUMBER CHECK(semestr BETWEEN 1 AND 8)
);

CREATE SEQUENCE zak_id_seq
START WITH 99985
MINVALUE 10000
MAXVALUE 99999
INCREMENT BY 10
CYCLE;

SELECT * FROM zak;

insert into zak values(Zak_id_seq.nextval, 'KOWALSKI', 'ROMAN', 'KOWAL',  'INFORMATYKA', 1, 2);
insert into zak values(Zak_id_seq.nextval, 'NOWAK', 'ANNA', 'NOWA', 'INFORMATYKA',  1, 3);
insert into zak values(Zak_id_seq.nextval, 'PIECH', 'EWA', 'PEWA',  'MECHANIKA', 1, 2);
insert into zak values(Zak_id_seq.nextval, 'POLAK', 'IZABELA', 'IZA',  'MECHANIKA', 2, 4);

SELECT * FROM zak;
DROP TABLE Zak CASCADE CONSTRAINTS;
DROP SEQUENCE zak_id_seq;
COMMIT;

--Zad 4
ALTER SEQUENCE zak_id_seq INCREMENT BY 5;

insert into zak values(Zak_id_seq.nextval, 'WAWRZYNIEC', 'DAMIAN','WAWRZYN',  'INFORMATYKA',  2, 3);
insert into zak values(Zak_id_seq.nextval, 'KOSSAK', 'KATARZYNA', 'KOSA', 'INFORMATYKA',  1, 2);

SELECT * FROM zak;
COMMIT;
--Zad 5

CREATE INDEX ind_kierunek ON Zak(kierunek);
CREATE INDEX ind_stopien_semestr ON Zak(stopien,semestr);
CREATE UNIQUE INDEX ind_pseudonim ON Zak(pseudonim);
COMMIT;
insert into zak values((select max(id_studenta) from zak)+1, 'WAWRZYNIEC', 'JAN','WAWRZYN2',  'MATEMATYKA',  1, 2);
insert into zak values((select max(id_studenta) from zak)+1, 'WAWRZYNIEC', 'ADAM','WAWRZYN2',  'MATEMATYKA',  1, 2);
insert into zak values((select max(id_studenta) from zak)+1, 'WAWRZYNIEC', 'ADAM','WAWRZYN22',  'MATEMATYKA',  1, 2);

DROP INDEX ind_pseudonim;

DROP INDEX ind_kierunek;
DROP INDEX ind_stopien_semestr;
DROP SEQUENCE zak_id_seq;
DROP TABLE Zak CASCADE CONSTRAINTS;

--Zad 6

CREATE TABLE studencibis as SELECT * FROM studenci;
SELECT * FROM studencibis;

CREATE OR REPLACE VIEW studentki as SELECT * FROM studencibis
WHERE imiona LIKE '%a' ORDER BY nazwisko, imiona;

CREATE OR REPLACE VIEW Zacy as SELECT * FROM studencibis
WHERE imiona NOT LIKE '%a' ORDER BY nazwisko, imiona WITH READ ONLY;

SELECT * FROM studentki;
SELECT * FROM zacy;

--Zad 7

CREATE OR REPLACE VIEW S1R1 as SELECT
nr_indeksu, nazwisko, imiona, rok, SUBSTR(nazwisko,1,1)||SUBSTR(imiona,1,1)||nr_indeksu as pseudonim
FROM zacy
WHERE rok = 1 AND stopien = 1 WITH CHECK OPTION;
SELECT * FROM S1R1;
DROP VIEW S1R1;
DROP VIEW zacy;
DROP VIEW studentki;
DROP TABLE studencibis;

--Zad 8
CREATE TABLE pracownicybis as SELECT
*
FROM pracownicy;

SELECT nr_akt, nazwisko, id_dzialu, stanowisko, (NVL(placa,0) + NVL(dod_funkcyjny,0) + NVL(dod_staz,0) - NVL(koszt_ubezpieczenia,0)) AS pensja
FROM pracownicy;

SELECT * FROM pracownicy;
SELECT * FROM pracownicybis;

CREATE OR REPLACE VIEW Lista_plac AS SELECT
nr_akt, nazwisko, id_dzialu, stanowisko, (NVL(placa,0) + NVL(dod_funkcyjny,0) + NVL(dod_staz,0) - NVL(koszt_ubezpieczenia,0)) AS pensja
FROM pracownicybis
WHERE nr_akt >=1000 AND (data_zwol > sysdate OR data_zwol IS NULL)
ORDER BY id_dzialu, nazwisko ASC
WITH CHECK OPTION;

INSERT INTO Lista_Plac VALUES(1222, 'TESTOWSKI', 10, 'INFORMATYK', 5000);
UPDATE lista_plac SET nazwisko = 'Adamski'
WHERE nr_akt LIKE 1234;
SELECT * FROM Lista_plac;

DROP VIEW Lista_plac;

--Zad 9
CREATE OR REPLACE VIEW Szefowie AS SELECT
nr_akt, nazwisko, stanowisko, 
(
    SELECT count(*) FROM pracownicybis
    WHERE przelozony = pr.nr_akt
) as "liczba podwladnych", data_zatr, placa, id_dzialu
FROM pracownicybis pr
WHERE przelozony IS NOT NULL 
AND (data_zwol > sysdate OR data_zwol IS NULL)
AND 
(
    SELECT count(*) FROM pracownicybis
    WHERE przelozony = pr.nr_akt
) > 0;

SELECT * FROM pracownicy;

SELECT
nr_akt, nazwisko, stanowisko, 
(
    SELECT count(*) FROM pracownicybis
    WHERE przelozony = pr.nr_akt
), data_zatr, placa, id_dzialu
FROM pracownicybis pr
WHERE przelozony IS NOT NULL 
AND (data_zwol > sysdate OR data_zwol IS NULL)
AND 
(
    SELECT count(*) FROM pracownicybis
    WHERE przelozony = pr.nr_akt
) > 0;

SELECT * FROM szefowie;
DROP TABLE pracownicybis;
DROP VIEW Szefowie;











