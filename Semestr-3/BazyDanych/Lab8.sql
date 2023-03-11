--Zad1
CREATE TABLE Zawodnicy
(
id_zawodnika NUMBER(4) CONSTRAINT id_zaw_PK PRIMARY KEY,
nazwisko VARCHAR(30) CONSTRAINT nazw_zaw NOT NULL,
imie VARCHAR(30) CONSTRAINT imie_zaw NOT NULL,
data_ur DATE CONSTRAINT data_chk CHECK(EXTRACT( YEAR FROM data_ur) >= 1940),
wzrost NUMBER(3) CONSTRAINT wzr_chk CHECK(wzrost BETWEEN 100 AND 220),
waga NUMBER(4,1) CONSTRAINT waga_chk CHECK(waga BETWEEN 15 AND 150),
pozycja VARCHAR(20) CONSTRAINT poz_chk CHECK(pozycja IN ('bramkarz','obronca','pomocnik','napastnik')),
klub VARCHAR(50) DEFAULT 'wolny zawodnik',
liczba_minut NUMBER(4) DEFAULT 0,
placa NUMBER(10,2) CONSTRAINT placa_chk CHECK (NVL(placa,0)>=0) 
);

---------------------------
INSERT INTO zawodnicy VALUES
(1001,'Nowak','Piotr',TO_DATE('10-01-1990','DD-MM-YYYY'),192,81.5,'bramkarz','Warta Czestochowa',360,4000);

INSERT INTO zawodnicy VALUES
(1007,'Oleksy','Robert',TO_DATE('12-08-1996','DD-MM-YYYY'),185,85,'obronca',NULL,NULL,NULL);


INSERT INTO zawodnicy VALUES
(1999,'Kowalski','Jan',TO_DATE('12-08-1998','DD-MM-YYYY'),197,100,'obronca',NULL,NULL,NULL);
---------------------------
INSERT INTO Zawodnicy VALUES (1002, 'Kowalski', 'Adam', To_date('15-04-1992', 'DD-MM-YYYY'), 194, 83, 'bramkarz', 'Odra Wroclaw', 270, 3500);
INSERT INTO Zawodnicy VALUES (1003, 'Polak', 'Dariusz', To_date('11-06-1998', 'DD-MM-YYYY'), 189, 79.5, 'bramkarz', 'Wisla Warszawa', 450, 5000);
INSERT INTO Zawodnicy VALUES (1004, 'Malinowski', 'Adrian', To_date('21-11-1987', 'DD-MM-YYYY'), 190, 85, 'obronca', 'Warta Czestochowa', 300, 3000);
INSERT INTO Zawodnicy VALUES (1005, 'Czech', 'Piotr', To_date('04-12-1989', 'DD-MM-YYYY'), 187, 83, 'obronca', 'Odra Wroclaw', 200, 2600);
INSERT INTO Zawodnicy VALUES (1006, 'Podolski', 'Krystian', To_date('26-02-1997', 'DD-MM-YYYY'), 186, 89, 'obronca', 'Wisla Warszawa', 350, 3500);
INSERT INTO Zawodnicy VALUES (1008, 'Grzyb', 'Krzysztof', To_date('17-09-1995', 'DD-MM-YYYY'), 173, 75, 'pomocnik', 'Warta Czestochowa', 400, 3200);
INSERT INTO Zawodnicy VALUES (1009, 'Kwasek', 'Artur', To_date('30-10-1991', 'DD-MM-YYYY'), 180, 75, 'pomocnik', 'Odra Wroclaw', 370, 3300);
INSERT INTO Zawodnicy VALUES (1010, 'Kukla', 'Kamil', To_date('01-02-1993', 'DD-MM-YYYY'), 179, 75, 'pomocnik', 'Wisla Warszawa', 250, 3000);
INSERT INTO Zawodnicy (id_zawodnika, nazwisko, imie, data_ur, wzrost, waga, pozycja) VALUES 
(1011, 'Drozd', 'Adam', To_date('19-03-1995', 'DD-MM-YYYY'), 182, 77, 'pomocnik');
INSERT INTO Zawodnicy VALUES (1012, 'Jankowski', 'Marek', To_date('23-09-1999', 'DD-MM-YYYY'), 185, 80, 'napastnik', 'Warta Czestochowa', 60, 2000);
INSERT INTO Zawodnicy VALUES (1013, 'Knysak', 'Fabian', To_date('10-10-1994', 'DD-MM-YYYY'), 175, 73, 'napastnik', 'Odra Wroclaw', 250, 4000);
INSERT INTO Zawodnicy VALUES (1014, 'Tyrek', 'Tomasz', To_date('31-01-1998', 'DD-MM-YYYY'), 179, 74, 'napastnik', 'Wisla Warszawa', 200, 6000);
INSERT INTO Zawodnicy VALUES (1015, 'Zachara', 'Mateusz', To_date('09-09-2000', 'DD-MM-YYYY'), 181, 73, 'napastnik', NULL, NULL, NULL);
INSERT INTO Zawodnicy VALUES (1016, 'Jaskola', 'Milosz', To_date('13-09-1997', 'DD-MM-YYYY'), 187, 81, 'napastnik', 'Warta Czestochowa', 160, 2300);
INSERT INTO Zawodnicy VALUES (1017, 'Knus', 'Franciszek', To_date('10-03-1984', 'DD-MM-YYYY'), 177, 71, 'napastnik', 'Odra Wroclaw', NULL, 3700);
INSERT INTO Zawodnicy VALUES (1018, 'Toborek', 'Tomasz', To_date('31-03-1997', 'DD-MM-YYYY'), 183, 72, 'napastnik', 'Wisla Warszawa', 230, 6200);
INSERT INTO Zawodnicy VALUES (1019, 'Zasepa', 'Michal', To_date('19-09-2001', 'DD-MM-YYYY'), 180, 76, 'napastnik', NULL, NULL, NULL);
INSERT INTO Zawodnicy VALUES (1020, 'Borel', 'Jan', To_date('11-02-2002', 'DD-MM-YYYY'), 179, 75, 'pomocnik', 'Warta Czestochowa', NULL, NULL);
INSERT INTO Zawodnicy VALUES (1021, 'Czok', 'Damian', To_date('28-08-1995', 'DD-MM-YYYY'), 190, 82, 'obronca', 'Odra Wroclaw', NULL, NULL);

SELECT * FROM zawodnicy;
COMMIT;
---------------------------
--Zad2
--(a
DELETE FROM zawodnicy WHERE data_ur > sysdate - INTERVAL '21' YEAR(2);
--(b
DELETE FROM zawodnicy;
--(c
SELECT * FROM zawodnicy;
--(d
ROLLBACK;
--(e
SELECT * FROM zawodnicy;
--(f
DROP TABLE zawodnicy CASCADE CONSTRAINTS;
--(g
ROLLBACK;
--(h
SELECT * FROM zawodnicy;
--Zad3
UPDATE zawodnicy
SET klub = 'wolny zawodnik' WHERE klub IS NULL;
UPDATE zawodnicy
SET liczba_minut = 0 WHERE liczba_minut IS NULL;
UPDATE zawodnicy
SET placa = 0 WHERE placa IS NULL;
--Zad4
UPDATE zawodnicy
SET liczba_minut = NVL(liczba_minut,0) + 
CASE
WHEN liczba_minut > 100 THEN 90
WHEN liczba_minut BETWEEN 1 AND 100 THEN 45
ELSE 15
END
WHERE klub IN ('Warta Czestochowa','Odra Wroclaw');

COMMIT;
----------
--Zad9
UPDATE zawodnicy za
SET za.klub = 'wolny zawodnik',
za.placa = 0
WHERE klub NOT LIKE 'wolny zawodnik'AND
klub IS NOT NULL AND 
za.data_ur = 
(SELECT MAX(data_ur) FROM zawodnicy WHERE klub NOT LIKE 'wolny zawodnik'AND
klub IS NOT NULL)
AND za.liczba_minut <
(SELECT MAX(liczba_minut) FROM zawodnicy
WHERE klub = za.klub);

COMMIT;
ROLLBACK;

--Zad 7
UPDATE zawodnicy
SET klub = 'Warta Czestochowa',
placa = NVL(placa,0) + 2500
WHERE id_zawodnika =
(
SELECT id_zawodnika FROM zawodnicy
WHERE klub = 'Odra Wroclaw' AND
data_ur = (
SELECT MAX(data_ur) FROM zawodnicy
WHERE klub = 'Odra Wroclaw') AND
ROWNUM = 1);

SELECT * FROM zawodnicy WHERE ROWNUM < 5;
SELECT * FROM zawodnicy WHERE ROWNUM = 1;
SELECT * FROM zawodnicy;
--Zad 5
COMMIT;
ROLLBACK;
UPDATE zawodnicy za
SET placa = placa *
CASE
WHEN liczba_minut =
(SELECT MAX(liczba_minut) FROM zawodnicy WHERE klub = za.klub) THEN 1.25
WHEN liczba_minut = 
(SELECT MIN(liczba_minut) FROM zawodnicy WHERE klub = za.klub) THEN 0.9
ELSE 1
END
WHERE za.klub IS NOT NULL AND klub NOT LIKE ('wolny zawodnik');