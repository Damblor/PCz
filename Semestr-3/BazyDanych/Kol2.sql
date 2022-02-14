--Nie wiem co jest dobrze, a co nie.

--Zad 1 
   
CREATE TABLE Dzieci
(
    id_dziecka NUMBER(5),
    personalia VARCHAR(40) CONSTRAINT personalia_nn NOT NULL,
    data_urodzenia DATE CONSTRAINT data_urodzenia_chk CHECK
    (
        TO_CHAR(data_urodzenia,'CC') = 21
    ),
    kod AS (SUBSTR(personalia,0,1)||
    SUBSTR(SUBSTR(personalia,Instr(personalia,' ') + 1),0,1)||
    TO_CHAR(data_urodzenia,'DDMM'))
);
 --Zad 2 
CREATE TABLE Posilki
(
    dzien DATE CONSTRAINT dzien_un UNIQUE,
    sniadanie VARCHAR(50) DEFAULT 'kanapka z szynka' CONSTRAINT sniadanie_nn NOT NULL,
    cena_sniadania NUMBER(4,2) DEFAULT 6.5 CONSTRAINT cena_sniadania_nn NOT NULL,
    obiad VARCHAR(50),
    cena_obiadu NUMBER(4,2) CONSTRAINT cena_obiadu_nn NOT NULL,
    deser VARCHAR(50),
    cena_deseru NUMBER(3,2)
);

 --Zad 3
ALTER TABLE Dzieci ADD CONSTRAINT id_dziecka_pk PRIMARY KEY(id_dziecka);

 --Zad 4 
CREATE TABLE Dziennik
(
    id_dziennika NUMBER(7) CONSTRAINT id_dziennika_pk PRIMARY KEY,
    dzien DATE,
    id_dziecka NUMBER(5),
    godz_przyjscia NUMBER(2),
    godz_wyjscia NUMBER(2),
    CONSTRAINT dzien_fk FOREIGN KEY(dzien)REFERENCES Posilki(dzien) ON DELETE CASCADE,
    CONSTRAINT id_dziecka_fk FOREIGN KEY (id_dziecka) REFERENCES Dzieci(id_dziecka) ON DELETE SET NULL
);
  
 --Zad 5
ALTER TABLE Posilki DROP COLUMN deser;
ALTER TABLE Posilki DROP COLUMN cena_deseru;
  
 --Zad 6 
ALTER TABLE Dzieci ADD
(
    grupa VARCHAR(30) DEFAULT 'Skrzaty'
);

 --Zad 7 
ALTER TABLE Dzieci MODIFY 
(
    data_urodzenia DATE DEFAULT (sysdate - INTERVAL '3' YEAR)
);
ALTER TABLE Dzieci ADD CONSTRAINT data_urodzenia_chk2 
CHECK(data_urodzenia >= TO_DATE('01.01.2016','DD.MM.YYYY')
AND data_urodzenia <= TO_DATE('31.12.2019','DD.MM.YYYY'));
 --Zad 8 
ALTER TABLE Dziennik DROP CONSTRAINT dzien_fk;
ALTER TABLE Posilki DROP CONSTRAINT dzien_un;
ALTER TABLE Posilki ADD CONSTRAINT dzien_pk PRIMARY KEY(dzien);  
ALTER TABLE Dziennik ADD CONSTRAINT dzien_fk FOREIGN KEY(dzien)REFERENCES Posilki(dzien) ON DELETE CASCADE;
 --Zad 9 
ALTER TABLE Posilki ADD CONSTRAINT dzien_chk CHECK
(
    TO_CHAR(dzien,'D') IN (1,2,3,4,5)
);
  
 --Zad 10 
  
ALTER TABLE Dziennik ADD CONSTRAINT godz_pobytu_chk CHECK
(
    godz_przyjscia >= 7 AND godz_wyjscia <= 18 AND godz_wyjscia > godz_przyjscia
);

 --Zad 11 
CREATE SEQUENCE Seq_id_dziennika
INCREMENT BY 2
START WITH 100
MAXVALUE 9999999
NOCYCLE;

COMMIT;
--DANE
insert into dzieci (id_dziecka, personalia, data_urodzenia, grupa) values(1, 'Kowalski Jan', to_date('12.04.2018', 'dd.mm.yyyy'), 'Skrzaty');
insert into dzieci (id_dziecka, personalia, data_urodzenia, grupa) values(2, 'Nowakowska Anna', to_date('17.08.2018', 'dd.mm.yyyy'), 'Skrzaty');
insert into dzieci (id_dziecka, personalia, data_urodzenia, grupa) values(3, 'Piech Kacper', to_date('11.01.2018', 'dd.mm.yyyy'), 'Skrzaty');
insert into dzieci (id_dziecka, personalia, data_urodzenia, grupa) values(4, 'Bugaj Joanna', to_date('06.12.2017', 'dd.mm.yyyy'), 'Skrzaty');
insert into dzieci (id_dziecka, personalia, data_urodzenia, grupa) values(5, 'Kowalski Piotr', to_date('02.03.2019', 'dd.mm.yyyy'), 'Smerfy');
insert into dzieci (id_dziecka, personalia, data_urodzenia, grupa) values(6, 'Andrysiak Karolia', to_date('23.01.2019', 'dd.mm.yyyy'), 'Smerfy');
insert into dzieci (id_dziecka, personalia, data_urodzenia, grupa) values(7, 'Wolska Maria', to_date('19.07.2017', 'dd.mm.yyyy'), 'Smerfy');
insert into dzieci (id_dziecka, personalia, data_urodzenia, grupa) values(8, 'Kowalski Jan', to_date('11.09.2018', 'dd.mm.yyyy'), 'Smerfy');

SELECT * FROM Dzieci;
insert into posilki values (to_date('01.04.2021', 'dd.mm.yyyy'), 'Kanapka z serem', 5.2, 'Zupa pomidorowa', 7.6);
insert into posilki values (to_date('04.04.2021', 'dd.mm.yyyy'), 'Kanapka z serem', 5.2, 'Zupa pomidorowa', 7.6);
insert into posilki values (to_date('05.04.2021', 'dd.mm.yyyy'), 'Kanapka z szynka', 5.2, 'Zupa ogorkowa', 6.2);
insert into posilki values (to_date('08.04.2021', 'dd.mm.yyyy'), 'Kanapka z serem', 5.2, 'Zupa warzywana', 5.5);
insert into posilki values (to_date('11.04.2021', 'dd.mm.yyyy'), 'Kanapka z pomidorem', 4.6, 'Kapusniak', 6.5);
insert into posilki values (to_date('12.04.2021', 'dd.mm.yyyy'), 'Kanapka z szynka', 5.2, 'Zupa ogorkowa', 6.2);
insert into posilki values (to_date('13.04.2021', 'dd.mm.yyyy'), 'Kanapka z serem', 5.2, 'Zupa warzywana', 5.5);
insert into posilki values (to_date('19.04.2021', 'dd.mm.yyyy'), 'Kanapka z dzemem', 4.8, 'Zupa pomidorowa', 7.6);
insert into posilki values (to_date('20.04.2021', 'dd.mm.yyyy'), 'Kanapka z szynka', 5.2, 'Zupa ogorkowa', 6.2);
insert into posilki values (to_date('22.04.2021', 'dd.mm.yyyy'), 'Kanapka z szynka', 5.2, 'Zupa ogorkowa', 6.2);
insert into posilki values (to_date('09.05.2021', 'dd.mm.yyyy'), 'Kanapka z pomidorem', 4.6, 'Kapusniak', 6.5);
insert into posilki values (to_date('10.05.2021', 'dd.mm.yyyy'), 'Kanapka z dzemem', 4.8, 'Zupa ogorkowa', 6.2);
insert into posilki values (to_date('16.05.2021', 'dd.mm.yyyy'), 'Kanapka z ogorkiem', 4.8, 'Zupa owocowa', 5.1);
insert into posilki values (to_date('17.05.2021', 'dd.mm.yyyy'), 'Kanapka z dzemem', 4.8, 'Zupa pomidorowa', 7.6);
insert into posilki values (to_date('18.05.2021', 'dd.mm.yyyy'), 'Kanapka z szynka', 5.2, 'Zupa warzywna', 6.1);
SELECT * FROM Posilki;
insert into dziennik values(Seq_id_dziennika.nextval, to_date('01.04.2021', 'dd.mm.yyyy'), 1, 8, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('01.04.2021', 'dd.mm.yyyy'), 2, 7, 8);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('01.04.2021', 'dd.mm.yyyy'), 3, 9, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('01.04.2021', 'dd.mm.yyyy'), 4, 9, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('01.04.2021', 'dd.mm.yyyy'), 5, 7, 11);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('01.04.2021', 'dd.mm.yyyy'), 6, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('01.04.2021', 'dd.mm.yyyy'), 7, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('04.04.2021', 'dd.mm.yyyy'), 1, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('04.04.2021', 'dd.mm.yyyy'), 2, 7, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('04.04.2021', 'dd.mm.yyyy'), 3, 9, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('04.04.2021', 'dd.mm.yyyy'), 6, 8, 17);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('04.04.2021', 'dd.mm.yyyy'), 7, 7, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('05.04.2021', 'dd.mm.yyyy'), 1, 9, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('05.04.2021', 'dd.mm.yyyy'), 3, 8, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('05.04.2021', 'dd.mm.yyyy'), 6, 8, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('05.04.2021', 'dd.mm.yyyy'), 7, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('08.04.2021', 'dd.mm.yyyy'), 2, 7, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('08.04.2021', 'dd.mm.yyyy'), 3, 9, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('08.04.2021', 'dd.mm.yyyy'), 4, 9, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('08.04.2021', 'dd.mm.yyyy'), 5, 9, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('08.04.2021', 'dd.mm.yyyy'), 6, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('11.04.2021', 'dd.mm.yyyy'), 1, 8, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('11.04.2021', 'dd.mm.yyyy'), 6, 10, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('11.04.2021', 'dd.mm.yyyy'), 7, 8, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('11.04.2021', 'dd.mm.yyyy'), 8, 8, 11);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('12.04.2021', 'dd.mm.yyyy'), 1, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('12.04.2021', 'dd.mm.yyyy'), 3, 8, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('12.04.2021', 'dd.mm.yyyy'), 4, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('12.04.2021', 'dd.mm.yyyy'), 7, 8, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('12.04.2021', 'dd.mm.yyyy'), 8, 10, 11);

insert into dziennik values(Seq_id_dziennika.nextval, to_date('13.04.2021', 'dd.mm.yyyy'), 1, 8, 12);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('13.04.2021', 'dd.mm.yyyy'), 2, 7, 10);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('13.04.2021', 'dd.mm.yyyy'), 3, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('13.04.2021', 'dd.mm.yyyy'), 4, 8, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('13.04.2021', 'dd.mm.yyyy'), 5, 8, 12);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('13.04.2021', 'dd.mm.yyyy'), 6, 7, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('13.04.2021', 'dd.mm.yyyy'), 7, 8, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('19.04.2021', 'dd.mm.yyyy'), 1, 7, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('19.04.2021', 'dd.mm.yyyy'), 2, 7, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('19.04.2021', 'dd.mm.yyyy'), 3, 9, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('19.04.2021', 'dd.mm.yyyy'), 4, 9, 11);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('19.04.2021', 'dd.mm.yyyy'), 5, 7, 11);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('19.04.2021', 'dd.mm.yyyy'), 6, 10, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('19.04.2021', 'dd.mm.yyyy'), 7, 8, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('20.04.2021', 'dd.mm.yyyy'), 1, 8, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('20.04.2021', 'dd.mm.yyyy'), 3, 10, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('20.04.2021', 'dd.mm.yyyy'), 6, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('20.04.2021', 'dd.mm.yyyy'), 7, 10, 17);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('22.04.2021', 'dd.mm.yyyy'), 1, 8, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('22.04.2021', 'dd.mm.yyyy'), 2, 11, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('22.04.2021', 'dd.mm.yyyy'), 3, 8, 12);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('22.04.2021', 'dd.mm.yyyy'), 4, 9, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('22.04.2021', 'dd.mm.yyyy'), 5, 9, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('22.04.2021', 'dd.mm.yyyy'), 6, 8, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('22.04.2021', 'dd.mm.yyyy'), 7, 7, 17);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('06.05.2021', 'dd.mm.yyyy'), 1, 10,11);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('06.05.2021', 'dd.mm.yyyy'), 7, 11,17);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('09.05.2021', 'dd.mm.yyyy'), 1, 8, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('09.05.2021', 'dd.mm.yyyy'), 2, 10, 17);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('09.05.2021', 'dd.mm.yyyy'), 3, 8, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('09.05.2021', 'dd.mm.yyyy'), 4, 13, 17);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('09.05.2021', 'dd.mm.yyyy'), 5, 7, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('09.05.2021', 'dd.mm.yyyy'), 6, 8, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('10.05.2021', 'dd.mm.yyyy'), 1, 8, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('10.05.2021', 'dd.mm.yyyy'), 2, 7, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('10.05.2021', 'dd.mm.yyyy'), 3, 10,16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('10.05.2021', 'dd.mm.yyyy'), 4, 7, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('10.05.2021', 'dd.mm.yyyy'), 5, 7, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('10.05.2021', 'dd.mm.yyyy'), 6, 9, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('10.05.2021', 'dd.mm.yyyy'), 7, 7,16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('17.05.2021', 'dd.mm.yyyy'), 1, 7, 17);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('17.05.2021', 'dd.mm.yyyy'), 3, 8, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('17.05.2021', 'dd.mm.yyyy'), 6, 8, 15);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('17.05.2021', 'dd.mm.yyyy'), 7, 8, 16);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('18.05.2021', 'dd.mm.yyyy'), 1, 8, 13);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('18.05.2021', 'dd.mm.yyyy'), 3, 9, 14);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('18.05.2021', 'dd.mm.yyyy'), 5, 7, 11);
insert into dziennik values(Seq_id_dziennika.nextval, to_date('18.05.2021', 'dd.mm.yyyy'), 7, 8, 16);

 --Zad 12 
  
ALTER TABLE Dziennik ADD
(
    koszt_pobytu NUMBER(5,2) DEFAULT 20 CONSTRAINT koszt_pobytu_chk
    CHECK(koszt_pobytu>=5)
);
  
 --Zad 13 
UPDATE dziennik dz SET koszt_pobytu =
(
    SELECT 
    CASE 
    WHEN dz.godz_przyjscia >= 9 THEN po.cena_sniadania
    ELSE 0
    END
    +
    CASE
    WHEN dz.godz_wyjscia <=18 THEN po.cena_obiadu
    ELSE 0
    END
    +
    CASE
    WHEN ((dz.godz_wyjscia - dz.godz_przyjscia) * 5) >= 20 THEN ((dz.godz_wyjscia - dz.godz_przyjscia) * 5)
    ELSE 20
    END
    FROM Posilki po WHERE po.dzien = dz.dzien
);
 --Zad 14 

CREATE OR REPLACE VIEW Grupa_Skrzatow AS
SELECT * FROM Dzieci WHERE grupa LIKE 'Skrzaty' WITH CHECK OPTION;
insert into Grupa_Skrzatow (id_dziecka, personalia, data_urodzenia, grupa) values(30, 'Frank Maciek', to_date('11.07.2017', 'dd.mm.yyyy'), 'Smerfy');
insert into Grupa_Skrzatow (id_dziecka, personalia, data_urodzenia, grupa) values(31, 'Frank Antoni', to_date('11.07.2018', 'dd.mm.yyyy'), 'Skrzaty');
SELECT * FROM grupa_skrzatow;

 --Zad 15 
CREATE OR REPLACE VIEW Lista_Oplat AS;

SELECT * FROM Dziennik dz JOIN Dzieci di ON (dz.id_dziecka = di.id_dziecka);
 
SELECT TO_CHAR(dz.dzien,'YYYY month') as okres, di.personalia,
COUNT(*) as liczba_pobytow, SUM(dz.godz_wyjscia - godz_przyjscia) as liczba_godzin,
COUNT
(
 SELECT * FROM Dziennik WHERE godz_przyjscia < 13 AND godz_wyjscia >13 AND id_dziecka = dz.id_dziecka
) as liczba_obiadow
FROM Dziennik dz JOIN Dzieci di ON (dz.id_dziecka = di.id_dziecka)
GROUP BY TO_CHAR(dz.dzien,'YYYY month'), di.personalia
ORDER BY 1, 2;
  
 --Zad 16 
 
 
  
 --Zad 17 
ALTER TABLE Dziennik DISABLE CONSTRAINT godz_pobytu_chk;
insert into dziennik values(Seq_id_dziennika.nextval, to_date('18.05.2021', 'dd.mm.yyyy'), 4, 11, 19,NULL);
ALTER TABLE Dziennik ENABLE NOVALIDATE CONSTRAINT godz_pobytu_chk;
 --Zad 18 
DELETE FROM Dzieci dz WHERE
id_dziecka = 
(
    SELECT id_dziecka FROM Dzieci
    WHERE SUBSTR(personalia,Instr(personalia,' ') + 1) NOT LIKE '%a'
    AND data_urodzenia =
    (
        SELECT MIN(data_urodzenia) FROM Dzieci
        WHERE SUBSTR(personalia,Instr(personalia,' ') + 1) NOT LIKE '%a'
        GROUP BY grupa
    )
);
 
SELECT * FROM Dzieci;
 --Zad 19 
 
DROP TABLE Dzieci CASCADE CONSTRAINTS;
DROP TABLE Posilki CASCADE CONSTRAINTS;
DROP TABLE Dziennik CASCADE CONSTRAINTS;
DROP SEQUENCE Seq_id_dziennika;
DROP VIEW Grupa_Skrzatow;
DROP VIEW Lista_Oplat;

DROP TABLE Kierowcy_Bez_Samochodu CASCADE CONSTRAINTS;
DROP TABLE Kierowcy_Z_Samochodem CASCADE CONSTRAINTS;
DROP TABLE Kierowcy_Z_Samochodami CASCADE CONSTRAINTS;
 
 --******************************** 
 -- Pamietaj o ostatnim zadaniu (INSTRUKCJE USUWAJACE UTWORZONE ELEMENTY)
 --******************************** 
 

-------------------------------------------------------------------------------------------------------
/*       KONIEC                      */
-------------------------------------------------------------------------------------------------------

/*  "BRUDNOPIS" - zapytania zdefiniowane ponizej nie podlegajace ocenie */
  
  