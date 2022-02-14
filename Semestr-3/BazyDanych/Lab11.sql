--D1
DROP TABLE DRIVERS CASCADE CONSTRAINTS;
DROP TABLE CARS CASCADE CONSTRAINTS;
DROP TABLE wykroczenia CASCADE CONSTRAINTS;
DROP SEQUENCE seq_id_wyk;

CREATE TABLE DRIVERS
( PESEL VARCHAR2(11) constraint drivers_pk PRIMARY KEY,
  NAZWISKO Varchar2(25) constraint drivers_naz_nn not null,
  IMIE Varchar2(15) constraint drivers_imie_nn not null,
  DATA_URODZENIA DATE constraint drivers_data_ur_ch check( (Extract(Year from data_urodzenia))<= 2001),
  MIEJSCOWOSC Varchar2(30)
);

--D2 
CREATE TABLE CARS
(  NUMER_REJESTRACYJNY Varchar2(8) constraint cars_pk PRIMARY KEY,
   WLASCICIEL VARCHAR2(11),
   MARKA Varchar2(20) constraint cars_marka_ch check(marka in ('AUDI', 'BMW', 'FORD', 'MERCEDES', 'OPEL', 'VW')),
   MODELL Varchar2(20) constraint cars_mod_nn not null, 
   KOLOR varchar2(20) constraint cars_kol_ch check(kolor in ('CZERWONY', 'ZIELONY', 'NIEBIESKI', 'CZARNY', 'BIALY', 'ZOLTY')),
   ROK_PRODUKCJI Number(4) constraint cars_rok_ch check(rok_produkcji between 1980 and 2020),
   constraint cars_wla_fk FOREIGN KEY (wlasciciel) references drivers(pesel) ON DELETE SET NULL
);

--D3
insert into drivers values ('89010301212', 'WOLSKA', 'DOROTA', to_date('2000-03-19','YYYY-MM-DD'), 'CZESTOCHOWA');
insert into drivers values ('87010313219', 'NOWAK', 'ADAM', to_date('2001-10-09','YYYY-MM-DD'), 'OPOLE');
insert into drivers values ('85010313219', 'PIECH', 'ROMAN', to_date('1984-12-12','YYYY-MM-DD'), 'OPOLE');
insert into drivers values ('89110301244', 'KOWALSKI', 'ANDRZEJ', to_date('1992-04-12','YYYY-MM-DD'), 'CZESTOCHOWA');
insert into drivers values('88110301255', 'NOWAK', 'ANNA', to_date('1982-04-22','YYYY-MM-DD'), 'CZESTOCHOWA');
insert into drivers values ('87110301266', 'ZAJAC', 'EDWARD', to_date('1991-05-12','YYYY-MM-DD'), 'OPOLE');
insert into drivers values ('86110301277', 'MAJ', 'JOANNA', to_date('1992-02-02','YYYY-MM-DD'), 'OPOLE');
insert into drivers values ('85110301288', 'WOLSKI', 'PIOTR', to_date('1989-06-27','YYYY-MM-DD'), 'KATOWICE');
insert into drivers values ('84110301299', 'ADAMSKI', 'ROMAN', to_date('1982-09-18','YYYY-MM-DD'), 'KATOWICE');
insert into drivers values ('84110301211', 'POLAK', 'EWA', to_date('1978-03-19','YYYY-MM-DD'), 'CZESTOCHOWA');
insert into drivers values ('85123012323', 'BUDZIAK', 'ANGELIKA', to_date('1995-07-04','YYYY-MM-DD'), 'WARSZAWA');
insert into drivers values ('88100301222', 'ZALAS', 'TOMASZ', to_date('1998-04-06','YYYY-MM-DD'), 'WARSZAWA');
insert into drivers values ('89010301211', 'WITOS', 'JAN', to_date('1995-01-17','YYYY-MM-DD'), 'SZCZECIN');


--Realizacja Zad 1
COMMIT;
ROLLBACK;
SELECT * FROM drivers;

select * from drivers ;
update drivers set pesel = case when extract(year from data_urodzenia) between
2000 and 2099 then to_char(data_urodzenia,'yy') 
||to_char(extract(month from data_urodzenia)+20)||to_char(data_urodzenia,'dd')
else to_char(data_urodzenia,'yymmdd')
end ||substr(pesel,-5);

--D4
insert into cars values ('SC12311', '92041201244', 'AUDI', 'A4', 'CZARNY', 2006 );
insert into cars values ('SC32326', '92041201244', 'FORD', 'MONDEO', 'ZIELONY', 2010 );
insert into cars values ('SC32312', '82042201255', 'AUDI', 'A8', 'CZERWONY', 2011 );
insert into cars values ('O165112', '91051201266', 'AUDI', 'A4', 'CZARNY', 2004 );
insert into cars values ('O200022', '92020201277', 'OPEL', 'ASTRA', 'NIEBIESKI', 1996 );
insert into cars values ('K012311', '89062701288', 'MERCEDES', '190', 'BIALY', 1992 );
insert into cars values ('K212111', '82091801299', 'FORD', 'FIESTA', 'ZIELONY', 2009 );
insert into cars values ('SC98123', '78031901211', 'FORD', 'MONDEO', 'BIALY', 2012 );
insert into cars values ('WB23414', '95070412323', 'AUDI', 'A4', 'BIALY', 2016 );
insert into cars values ('WE90012', '98040601222', 'FORD', 'FOCUS', 'ZIELONY', 2012 );
insert into cars values ('ZS03452', '95011701211', 'AUDI', 'A3', 'CZARNY', 2013 );
insert into cars values ('SCZ3422', '00231901212', 'OPEL', 'ASTRA', 'CZARNY', 2018 );
insert into cars values ('SK02226', '84121213219', 'OPEL', 'ASTRA', 'CZERWONY', 2019 );
insert into cars values ('SK02227', '84121213219', 'OPEL', 'ASTRA', 'ZIELONY', 2019 );

select * from cars;


--D5
CREATE TABLE WYKROCZENIA
(  ID_WYKROCZENIA NUMBER(5) constraint wykroczenia_pk PRIMARY KEY,
   DATA_ZDARZENIA DATE,
   ID_SAMOCHODU Varchar2(8),
   Vz NUMBER(3) constraint wykroczenia_VZ_NN not null,
   Vdop NUMBER(3) constraint wykroczenia_Vdop_NN not null,
   MANDAT NUMBER(6,2) default 0,
   constraint wykroczenia_sam_fk FOREIGN KEY (id_samochodu) REFERENCES cars(numer_rejestracyjny)
);


-- Realizacja  zad 2 - 3

COMMIT;
ROLLBACK;

ALTER TABLE wykroczenia ADD CONSTRAINT vz_chk CHECK (Vz > Vdop AND Vz > 20);

--Zad3
CREATE SEQUENCE seq_id_wyk
MINVALUE 10000
MAXVALUE 99999
START WITH 10000
INCREMENT BY 123
CYCLE;


--D6 
  
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-810, 'SC12311', 132, 70, 0 );  
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-420, 'SC12311', 92, 60, 0 );  
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-650, 'SC32326', 101, 60, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-550, 'SC32326', 85, 60, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-384, 'SC32326', 112, 50, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-573, 'K012311', 145, 110, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-34, 'O165112', 98, 50, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-289, 'O165112', 142, 100, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-453, 'K012311', 149, 110, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-511, 'O200022', 121, 90, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-478, 'K212111', 114, 50, 0 );   
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-950, 'WE90012', 211, 130, 0 );
  
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-10, 'SC12311', 102, 70, 0 );  
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-20, 'SC12311', 82, 70, 0 );  
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-50, 'SC32326', 112, 60, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-150, 'SC32326', 85, 50, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-84, 'SC32326', 122, 50, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-73, 'K012311', 135, 130, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate, 'O165112', 78, 60, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-189, 'O165112', 146, 110, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-253, 'K012311', 189, 130, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-311, 'O200022', 101, 50, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-178, 'K212111', 104, 70, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate, 'O165112', 98, 90, 0 ); 
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-3, 'WB23414', 92, 50, 0 );  
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-121, 'WE90012', 135, 50, 0 );  
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-250, 'WE90012', 185, 130, 0 );
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-21, 'SCZ3422', 109, 50, 0 );  
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-50, 'SK02227', 175, 140, 0 );
insert into wykroczenia values (seq_id_wyk.nextval, sysdate-interval '3' year, 'SC32312', 61, 50, 0 );


select * from wykroczenia;

--Realizacja  zad 4 - 5 

CREATE TABLE wykroczenia_temp AS SELECT * FROM wykroczenia;

--Zad 5
UPDATE wykroczenia SET mandat=TRUNC((Vz-Vdop)/10)*500 + 
CASE 
WHEN Vdop = 50 AND Vz-Vdop > 50 THEN 5000
ELSE 0
END
WHERE Vz-Vdop >=10;

SELECT * FROM wykroczenia;

--D7

insert into Wykroczenia values (seq_id_wyk.nextval, sysdate-3, 'O200022', 71, 50, 0 ); 
insert into Wykroczenia values (seq_id_wyk.nextval, sysdate-19, 'O165112', 151, 90, 0 ); 
insert into Wykroczenia values (seq_id_wyk.nextval, sysdate-453, 'K012311', 137, 50, 0 ); 

SELECT * FROM Rejestr_Mandatow;
SELECT * FROM Wykroczenia;

--Zad 7

UPDATE wykroczenia SET mandat=TRUNC((Vz-Vdop)/10)*500 + 
CASE 
WHEN Vdop = 50 AND Vz-Vdop > 50 THEN 5000
ELSE 0
END
WHERE Vz-Vdop >=10 AND mandat = 0;

SELECT * FROM Wykroczenia;
SELECT * FROM wykroczenia_temp;

--Zad 8
ALTER TABLE wykroczenia_temp ADD komentarz VARCHAR(20);
MERGE INTO wykroczenia_temp t1 USING
(
    SELECT * FROM wykroczenia
) t2
ON (t1.id_wykroczenia=t2.id_wykroczenia)
WHEN MATCHED THEN
UPDATE SET mandat = t2.mandat, komentarz = 'stare wykroczenia'
WHEN NOT MATCHED THEN
INSERT VALUES (t2.id_wykroczenia,t2.data_zdarzenia,t2.id_samochodu,t2.vz,t2.vdop,t2.mandat,'nowe wykroczenie');

SELECT * FROM wykroczenia_temp;
--Zad 9
CREATE OR REPLACE VIEW Bilans_Roczny_Kar AS
SELECT EXTRACT(YEAR FROM data_zdarzenia) as rok, pesel, nazwisko, imie, sum(mandat) as kwota, count(*) as liczba_wykroczen
FROM drivers JOIN cars ON (pesel=wlasciciel) JOIN wykroczenia ON(numer_rejestracyjny=id_samochodu)
WHERE mandat>0
GROUP BY EXTRACT(YEAR FROM data_zdarzenia), nazwisko, imie
ORDER BY 1,4 DESC;

--Zad 11
create or replace view Lista_Piratow_Drogowych as
select t1.rok,nazwisko,imie,pesel,miejscowosc, kwota, liczba from 
(select extract(year from data_zdarzenia) rok,imie,nazwisko, 
pesel,miejscowosc,  
sum(mandat) kwota, count(*) liczba
from drivers join cars on(pesel = wlasciciel)
join wykroczenia on(numer_rejestracyjny=id_samochodu)
where mandat>0 
group by extract(year from data_zdarzenia),imie,nazwisko, pesel,miejscowosc) t1 join(
select rok, avg(kwota) srednia from 
(select extract(year from data_zdarzenia) rok, pesel,  sum(mandat) kwota
from drivers join cars on(pesel = wlasciciel)
join wykroczenia on(numer_rejestracyjny=id_samochodu)
where mandat>0 
group by extract(year from data_zdarzenia), pesel) group by rok) t2
on(t1.rok=t2.rok and kwota>srednia);

--Zad 13
COMMIT;
UPDATE wykroczenia SET vz = vz + 150
WHERE id_wykroczenia=
(
    SELECT MIN(id_wykroczenia) FROM wykroczenia
);
SELECT * FROM wykroczenia;
SAVEPOINT S1;
UPDATE wykroczenia SET vz = vz + 55, mandat = 999
WHERE mandat = 0;

-- zad 14
SAVEPOINT S2;
DELETE FROM wykroczenia WHERE mandat < 1200;


SAVEPOINT S3;
UPDATE wykroczenia SET mandat=1;
SELECT * FROM wykroczenia;
ROLLBACK TO SAVEPOINT S3;
SELECT * FROM wykroczenia;

ROLLBACK TO SAVEPOINT S2;
SELECT * FROM wykroczenia;
ROLLBACK TO SAVEPOINT S1;
SELECT * FROM wykroczenia;
ROLLBACK;
SELECT * FROM wykroczenia;

ROLLBACK TO SAVEPOINT S3;




drop view BRK;
drop view Rejestr_Mandatow;
drop view Bilans_Roczny_Kar;
drop view Bilans_Mandatow_Sam;
drop view Lista_Piratow_Drogowych;
drop view Lista_Wzorowych_Kierowcow;
drop table cars cascade constraints; 
drop table drivers cascade constraints; 
drop table wykroczenia cascade constraints; 
drop table wykroczenia_temp cascade constraints; 
drop sequence seq_id_wyk;