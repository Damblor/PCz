
--Zad 1
SELECT id_dzialu, nazwa, adres,nr_akt, nazwisko, imiona  FROM Pracownicy JOIN dzialy USING(id_dzialu);

SELECT id_dzialu, nazwa, adres,nr_akt, nazwisko, imiona  FROM Pracownicy pr JOIN dzialy dz USING(id_dzialu);

--Zad 2
SELECT avg(pojemnosc), 'sred. poj. poj. marki FORD' FROM Pojazdy Where marka like 'FORD' and typ like 'SAM_OSOBOWY';
SELECT avg(pojemnosc), 'sred. poj. poj. marki OPEL'  FROM Pojazdy Where marka like 'OPEL' and typ like 'SAM_OSOBOWY';
SELECT avg(pojemnosc), 'sred. poj. poj. marki BMW'  FROM Pojazdy Where marka like 'BMW' and typ like 'SAM_OSOBOWY';

SELECT 
AVG(CASE WHEN marka LIKE 'FORD' AND typ LIKE 'SAM_OSOBOWY' THEN pojemnosc ELSE NULL END) as FORD,
AVG(CASE WHEN marka LIKE 'OPEL' AND typ LIKE 'SAM_OSOBOWY' THEN pojemnosc ELSE NULL END) as OPEL,
AVG(CASE WHEN marka LIKE 'BMW' AND typ LIKE 'SAM_OSOBOWY' THEN pojemnosc ELSE NULL END) as BMW
FROM pojazdy;


--Zad 3
SELECT id_wedkarza, id_gatunku, id_lowiska FROM Rejestry 
WHERE Extract(Year from czas)=2019 and id_gatunku is not NULL
GROUP BY id_wedkarza, id_gatunku, id_lowiska HAVING id_lowiska like 'C%';

SELECT id_wedkarza, id_gatunku, id_lowiska FROM Rejestry 
WHERE Extract(Year from czas)=2019 and id_gatunku is not NULL AND id_lowiska like 'C%'
GROUP BY id_wedkarza, id_gatunku, id_lowiska;


--Zad 4
SELECT DISTINCT id_wlasciciela, wlasciciel FROM Wlasciciele JOIN Pojazdy USING(id_wlasciciela)
WHERE status_wlasciciela like 'osoba_fizyczna' and id_wlasciciela IN (SELECT id_wlasciciela FROM Pojazdy WHERE typ like 'MOTOCYKL')
ORDER BY 1;

SELECT DISTINCT id_wlasciciela, wlasciciel FROM Wlasciciele wl 
WHERE EXISTS(SELECT id_wlasciciela FROM pojazdy po WHERE po.id_wlasciciela=wl.id_wlasciciela AND
status_wlasciciela like 'osoba_fizyczna' and wl.id_wlasciciela IN (SELECT id_wlasciciela FROM Pojazdy WHERE typ like 'MOTOCYKL'))
ORDER BY 1;


-- Zad 5

SELECT DISTINCT id_wlasciciela, T1.wlasciciel FROM
( SELECT id_wlasciciela, wlasciciel, vin, nr_rejestracyjny FROM Wlasciciele JOIN Pojazdy USING(id_wlasciciela)
 WHERE marka like 'OPEL' 
) T1
JOIN 
( SELECT id_wlasciciela, wlasciciel, vin, nr_rejestracyjny FROM Wlasciciele JOIN Pojazdy USING(id_wlasciciela)
 WHERE marka like 'FORD' 
)T2 USING(id_wlasciciela);

SELECT id_wlasciciela, wlasciciel FROM Wlasciciele JOIN Pojazdy USING(id_wlasciciela)
 WHERE marka like 'OPEL' 
INTERSECT
SELECT id_wlasciciela, wlasciciel FROM Wlasciciele JOIN Pojazdy USING(id_wlasciciela)
 WHERE marka like 'FORD';
  

--Zad 6

SELECT id_wedkarza, nazwisko, id_gatunku, nazwa, count(id_gatunku) Liczba_ryb, count(distinct trunc(czas)) Liczba_dni 
FROM Rejestry JOIN Gatunki USING(id_gatunku) JOIN Wedkarze USING(id_wedkarza)
WHERE id_gatunku is not NULL
GROUP BY id_wedkarza, nazwisko, id_gatunku, nazwa 
HAVING (id_gatunku, count(id_gatunku))  IN
(  SELECT id_gatunku, max(liczba_ryb) FROM
    (  SELECT id_gatunku, count(id_gatunku) liczba_ryb FROM Rejestry 
       WHERE id_gatunku is not NULL
       GROUP BY id_wedkarza, id_gatunku
    ) GROUP BY  id_gatunku 
)
ORDER BY id_gatunku;

SELECT * FROM
(SELECT id_wedkarza, nazwisko, id_gatunku, nazwa, count(id_gatunku) Liczba_ryb, count(distinct trunc(czas)) Liczba_dni 
FROM Rejestry JOIN Gatunki USING(id_gatunku) JOIN Wedkarze USING(id_wedkarza)
WHERE id_gatunku is not NULL
GROUP BY id_wedkarza, nazwisko, id_gatunku, nazwa) T1
JOIN
(SELECT id_gatunku, max(liczba_ryb) maks FROM
    (  SELECT id_gatunku, count(id_gatunku) liczba_ryb FROM Rejestry 
       WHERE id_gatunku is not NULL
       GROUP BY id_wedkarza, id_gatunku
    ) GROUP BY  id_gatunku) T2 ON (t1.id_gatunku=t2.id_gatunku AND t1.Liczba_ryb=t2.maks);


-- Zad 7

CREATE TABLE osoby
( 
    id_osoby NUMBER(7) CONSTRAINT id_osoby_pk PRIMARY KEY,
    nazwisko VARCHAR(30) CONSTRAINT nazw_nn NOT NULL,
    nazwisko_rodowe VARCHAR(30),
    imiona VARCHAR(30) CONSTRAINT imi_nn NOT NULL,
    data_urodzenia DATE,
    data_zgonu DATE,
    ojciec NUMBER(7),
    matka NUMBER(7),
    CONSTRAINT ojciec_fk FOREIGN KEY (ojciec) REFERENCES osoby(id_osoby),
    CONSTRAINT matka_fk FOREIGN KEY (matka) REFERENCES osoby(id_osoby)
);

--Dane

 INSERT INTO OSOBY VALUES(101, 'Nowak', NULL, 'Jozef', To_date('13.04.1931', 'dd.mm.yyyy'), To_date('27.05.2002', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(102, 'Nowak', 'Zatorska', 'Antonina', To_date('23.05.1935', 'dd.mm.yyyy'), To_date('17.02.2006', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(1002, 'Nowak', NULL, 'Roman', To_date('23.07.1957', 'dd.mm.yyyy'), To_date('17.02.2018', 'dd.mm.yyyy'), 101, 102);
 INSERT INTO OSOBY VALUES(103, 'Andrysiak', NULL, 'Stanislaw', To_date('03.11.1929', 'dd.mm.yyyy'), To_date('17.02.1996', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(104, 'Andrysiak', 'Czech', 'Anna', To_date('27.08.1936', 'dd.mm.yyyy'), To_date('21.12.2011', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(1006, 'Andrysiak', NULL, 'Stanislaw', To_date('03.11.1958', 'dd.mm.yyyy'), To_date('17.02.1996', 'dd.mm.yyyy'), 103, 104);
 INSERT INTO OSOBY VALUES(105, 'Zalas', NULL, 'Zdzislaw', To_date('13.12.1934', 'dd.mm.yyyy'), NULL, NULL, NULL);
 INSERT INTO OSOBY VALUES(106, 'Zalas', 'Wolska', 'Helena', To_date('31.07.1937', 'dd.mm.yyyy'), NULL, NULL, NULL); 
 INSERT INTO OSOBY VALUES(1010, 'Zalas', NULL, 'Stanislaw', To_date('21.02.1963', 'dd.mm.yyyy'), NULL, 105, 106);
 INSERT INTO OSOBY VALUES(107, 'Wolski', NULL, 'Andrzej', To_date('13.09.1933', 'dd.mm.yyyy'), To_date('22.01.2015', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(108, 'Wolska', 'Romanczuk', 'Janina', To_date('29.01.1938', 'dd.mm.yyyy'), NULL, NULL, NULL);
 INSERT INTO OSOBY VALUES(1011, 'Wolski', NULL, 'Roman', To_date('11.09.1957', 'dd.mm.yyyy'), NULL, 107, 108);
 INSERT INTO OSOBY VALUES(109, 'Jakubik', NULL, 'Waclaw', To_date('09.10.1932', 'dd.mm.yyyy'), NULL, NULL, NULL);
 INSERT INTO OSOBY VALUES(110, 'Jakubik', 'Rasiak', 'Dorota', To_date('30.04.1932', 'dd.mm.yyyy'), To_date('07.02.2013', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(1016, 'Jakubik', NULL, 'Jan', To_date('09.10.1955', 'dd.mm.yyyy'), NULL, 109, 110);
 INSERT INTO OSOBY VALUES(1018, 'Jakubik', NULL, 'Jerzy', To_date('09.10.1960', 'dd.mm.yyyy'), NULL, 109, 110);
 INSERT INTO OSOBY VALUES(111, 'Lach', NULL, 'Jan', To_date('11.11.1930', 'dd.mm.yyyy'), To_date('11.10.2011', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(112, 'Lach', 'Podgorska', 'Wiktoria', To_date('06.06.1936', 'dd.mm.yyyy'), To_date('27.03.2008', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(1021, 'Lach', NULL, 'Kacper', To_date('11.11.1959', 'dd.mm.yyyy'), NULL, 111, 112);
 INSERT INTO OSOBY VALUES(113, 'Operacz', NULL, 'Jerzy', To_date('23.02.1932', 'dd.mm.yyyy'), To_date('27.07.2004', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(114, 'Operacz', 'Nowakowska', 'Antonina', To_date('17.02.1933', 'dd.mm.yyyy'), To_date('01.03.2009', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(1024, 'Operacz', NULL, 'Boleslaw', To_date('23.02.1958', 'dd.mm.yyyy'), NULL, 113, 114);
 INSERT INTO OSOBY VALUES(115, 'Kowalski', NULL, 'Jan', To_date('13.03.1931', 'dd.mm.yyyy'), To_date('07.05.1991', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(116, 'Kowalska', 'Zator', 'Maria', To_date('23.08.1938', 'dd.mm.yyyy'), To_date('02.12.2002', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(1025, 'Kowalski', NULL, 'Jozef', To_date('31.01.1956', 'dd.mm.yyyy'), NULL, 115, 116);
 INSERT INTO OSOBY VALUES(1028, 'Kowalski', NULL, 'Hubert', To_date('04.04.1961', 'dd.mm.yyyy'), NULL, 115, 116);
 INSERT INTO OSOBY VALUES(117, 'Drozda', NULL, 'Julian', To_date('13.05.1935', 'dd.mm.yyyy'), To_date('07.08.1999', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(118, 'Drozda', 'Zietara', 'Benedykta', To_date('23.09.1936', 'dd.mm.yyyy'), To_date('04.11.2008', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(119, 'Kaleta', NULL, 'Witold', To_date('03.11.1934', 'dd.mm.yyyy'), To_date('07.06.2006', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(120, 'Kaleta', 'Fialkowska', 'Anna', To_date('15.02.1933', 'dd.mm.yyyy'), To_date('12.10.2018', 'dd.mm.yyyy'), NULL, NULL);
 INSERT INTO OSOBY VALUES(1004, 'Andrysiak', NULL, 'Stanislaw', To_date('07.10.1954', 'dd.mm.yyyy'), To_date('10.05.2019', 'dd.mm.yyyy'), 103, 104);
 INSERT INTO OSOBY VALUES(1003, 'Andrysiak', 'Nowak', 'Anna', To_date('17.11.1959', 'dd.mm.yyyy'), NULL, 101, 102); 
 INSERT INTO OSOBY VALUES(10002, 'Andrysiak', NULL, 'Piotr', To_date('12.08.1983', 'dd.mm.yyyy'), NULL, 1004, 1003);
 INSERT INTO OSOBY VALUES(10003, 'Andrysiak', NULL, 'Robert', To_date('03.07.1986', 'dd.mm.yyyy'), NULL, 1004, 1003);
 INSERT INTO OSOBY VALUES(1008, 'Zalas', NULL, 'Jan', To_date('11.10.1958', 'dd.mm.yyyy'), NULL, 105, 106);
 INSERT INTO OSOBY VALUES(1013, 'Zalas', 'Wolska', 'Irena', To_date('19.03.1961', 'dd.mm.yyyy'), NULL, 107, 108);
 INSERT INTO OSOBY VALUES(10005, 'Zalas', NULL, 'Pawel', To_date('01.06.1981', 'dd.mm.yyyy'), NULL, 1008, 1013);
 INSERT INTO OSOBY VALUES(1014, 'Jakubik', NULL, 'Czeslaw', To_date('09.10.1951', 'dd.mm.yyyy'), To_date('19.07.2020', 'dd.mm.yyyy'), 109, 110);
 INSERT INTO OSOBY VALUES(1019, 'Jakubik', 'Lach', 'Helena', To_date('10.03.1954', 'dd.mm.yyyy'), NULL, 111, 112);
 INSERT INTO OSOBY VALUES(10009, 'Jakubik', NULL, 'Piotr', To_date('06.02.1978', 'dd.mm.yyyy'), NULL, 1014, 1019);
 INSERT INTO OSOBY VALUES(10011, 'Jakubik', NULL, 'Mariusz', To_date('28.04.1983', 'dd.mm.yyyy'), NULL,  1014, 1019);
 INSERT INTO OSOBY VALUES(1022, 'Operacz', NULL, 'Ryszard', To_date('03.01.1952', 'dd.mm.yyyy'), To_date('17.09.2018', 'dd.mm.yyyy'), 113, 114);
 INSERT INTO OSOBY VALUES(1026, 'Operacz', 'Kowalska', 'Anna', To_date('12.06.1957', 'dd.mm.yyyy'), NULL, 115, 116);
 INSERT INTO OSOBY VALUES(10012, 'Operacz', NULL, 'Pawel', To_date('03.03.1981', 'dd.mm.yyyy'), NULL, 1022, 1026);
 INSERT INTO OSOBY VALUES(1001, 'Nowak', NULL, 'Stanislaw', To_date('11.04.1955', 'dd.mm.yyyy'), NULL, 101, 102);
 INSERT INTO OSOBY VALUES(1029, 'Nowak', 'Drozda', 'Janina', To_date('13.05.1956', 'dd.mm.yyyy'), NULL, 117, 118);
 INSERT INTO OSOBY VALUES(10014, 'Nowak', NULL, 'Karol', To_date('21.08.1981', 'dd.mm.yyyy'), NULL, 1001, 1029);
 INSERT INTO OSOBY VALUES(10016, 'Nowak', 'Nowak', 'Katarzyna', To_date('08.10.1987', 'dd.mm.yyyy'), NULL,  1001, 1029);
 INSERT INTO OSOBY VALUES(1030, 'Kaleta', NULL, 'Andrzej', To_date('09.02.1955', 'dd.mm.yyyy'), NULL, 119, 120);
 INSERT INTO OSOBY VALUES(1017, 'Kaleta', 'Jakubik', 'Krystyna', To_date('09.10.1958', 'dd.mm.yyyy'), NULL, 109, 110);
 INSERT INTO OSOBY VALUES(10018, 'Kaleta', NULL, 'Tomasz', To_date('04.08.1982', 'dd.mm.yyyy'), NULL, 1030, 1017);
 INSERT INTO OSOBY VALUES(10004, 'Zalas', NULL, 'Lukasz', To_date('11.10.1979', 'dd.mm.yyyy'), NULL, 1008, 1013);
 INSERT INTO OSOBY VALUES(10001, 'Andrysiak-Zalas', 'Andrysiak', 'Agata', To_date('17.10.1980', 'dd.mm.yyyy'), NULL, 1004, 1003);    
 INSERT INTO OSOBY VALUES(100002, 'Zalas', 'Zalas', 'Angelika', To_date('13.01.2001', 'dd.mm.yyyy'), NULL, 10004, 10001);
 INSERT INTO OSOBY VALUES(100003, 'Zalas', 'Zalas', 'Martyna', To_date('19.05.2004', 'dd.mm.yyyy'), NULL, 10004, 10001);
 INSERT INTO OSOBY VALUES(10008, 'Jakubik', NULL, 'Krystian', To_date('19.12.1975', 'dd.mm.yyyy'), NULL, 1014, 1019);
 INSERT INTO OSOBY VALUES(10013, 'Jakubik', 'Operacz', 'Agnieszka', To_date('03.03.1981', 'dd.mm.yyyy'), NULL, 1022, 1026);
 INSERT INTO OSOBY VALUES(100005, 'Jakubik', NULL, 'Kornel', To_date('06.03.2006', 'dd.mm.yyyy'), NULL,  10008, 10013);
 INSERT INTO OSOBY VALUES(100006, 'Jakubik', 'Jakubik', 'Julia', To_date('23.07.2009', 'dd.mm.yyyy'), NULL,  10008, 10013);
 INSERT INTO OSOBY VALUES(10022, 'Nowak', NULL, 'Pawel', To_date('13.02.1978', 'dd.mm.yyyy'), NULL,  1001, 1029);  
 INSERT INTO OSOBY VALUES(10017, 'Kaleta-Nowak', 'Kaleta', 'Monika', To_date('09.04.1978', 'dd.mm.yyyy'), NULL, 1030, 1017);
 INSERT INTO OSOBY VALUES(100001, 'Zalas', NULL, 'Kamil', To_date('21.12.1998', 'dd.mm.yyyy'), NULL, 10004, 10001);
 INSERT INTO OSOBY VALUES(100004, 'Jakubik-Zalas', 'Jakubik', 'Julia', To_date('29.12.1999', 'dd.mm.yyyy'), NULL, 10008, 10013);
 INSERT INTO OSOBY VALUES(100007, 'Nowak', NULL, 'Michal', To_date('29.11.1999', 'dd.mm.yyyy'), NULL,  10022, 10017);
 INSERT INTO OSOBY VALUES(100008, 'Nowak', NULL, 'Oskar', To_date('18.05.2020', 'dd.mm.yyyy'), NULL,  10022, 10017);
 INSERT INTO OSOBY VALUES(1000001, 'Zalas', NULL, 'Szymon', To_date('31.08.2018', 'dd.mm.yyyy'), NULL, 100001, 100004);
 INSERT INTO OSOBY VALUES(1000002, 'Zalas', 'Zalas', 'Zofia', To_date('31.10.2020', 'dd.mm.yyyy'), NULL, 100001, 100004);
 
SELECT * FROM Osoby;


SELECT id_osoby, nazwisko, nazwisko_rodowe, imiona, data_urodzenia, data_zgonu, ojciec, matka, level
FROM osoby
START WITH id_osoby = 100008
CONNECT BY PRIOR ojciec = id_osoby;

SELECT id_osoby, nazwisko, nazwisko_rodowe, imiona, data_urodzenia, data_zgonu, ojciec, matka, level
FROM osoby
START WITH id_osoby = 
(
    SELECT id_osoby FROM osoby
    WHERE data_urodzenia = 
    (
        SELECT MAX(data_urodzenia) FROM osoby
        WHERE imiona NOT LIKE '%a'
    )
    AND ROWNUM = 1
)
CONNECT BY PRIOR ojciec = id_osoby;

--Zad 8

SELECT id_osoby, nazwisko, nazwisko_rodowe, imiona, data_urodzenia, data_zgonu, ojciec, matka, level
FROM osoby
START WITH id_osoby = 101
CONNECT BY PRIOR id_osoby = ojciec OR id_osoby = matka
ORDER BY level;

--Zad 10

WITH drzewo(id_osoby, nazwisko, nazwisko_rodowe, imiona, data_urodzenia, data_zgonu, ojciec, matka, poziom)
AS
(
    SELECT id_osoby, nazwisko, nazwisko_rodowe, imiona, data_urodzenia, data_zgonu, ojciec, matka, 100 poziom
    FROM osoby WHERE id_osoby = 101
    UNION ALL
    SELECT os.id_osoby, os.nazwisko, os.nazwisko_rodowe, os.imiona, os.data_urodzenia, os.data_zgonu, os.ojciec,
    os.matka, poziom + 100
    FROM osoby os JOIN drzewo dr ON (dr.id_osoby = os.ojciec OR dr.id_osoby = os.matka)
)
SEARCH BREADTH FIRST BY id_osoby SET kolejka
SELECT id_osoby, nazwisko, imiona, data_urodzenia, ojciec, matka,
RANK () OVER (PARTITION BY DECODE(SUBSTR(imiona,-1),'a',1,2) ORDER BY data_urodzenia)||
DECODE(SUBSTR(imiona,-1),'a','k','m')as Rank FROM drzewo;

WITH drzewo(id_osoby, nazwisko, nazwisko_rodowe, imiona, data_urodzenia, data_zgonu, ojciec, matka, poziom)
AS
(
    SELECT id_osoby, nazwisko, nazwisko_rodowe, imiona, data_urodzenia, data_zgonu, ojciec, matka, 100 poziom
    FROM osoby WHERE id_osoby = 101
    UNION ALL
    SELECT os.id_osoby, os.nazwisko, os.nazwisko_rodowe, os.imiona, os.data_urodzenia, os.data_zgonu, os.ojciec,
    os.matka, poziom + 100
    FROM osoby os JOIN drzewo dr ON (dr.id_osoby = os.ojciec OR dr.id_osoby = os.matka)
)
SEARCH DEPTH FIRST BY id_osoby SET kolejka
SELECT id_osoby, nazwisko, imiona, data_urodzenia, ojciec, matka, poziom,
RANK () OVER (PARTITION BY DECODE(SUBSTR(imiona,-1),'a',1,2) ORDER BY data_urodzenia)||
DECODE(SUBSTR(imiona,-1),'a','k','m')as Rank,
TRUNC(MONTHS_BETWEEN(SYSDATE,data_urodzenia)/12) as Wiek,
'SQLDEV:GAUGE:0:100:35:60:'||TO_CHAR(TRUNC(MONTHS_BETWEEN(SYSDATE,data_urodzenia)/12)) "        Zycie        "
FROM drzewo;





drop table osoby cascade constraints;