--Nie wiem co jest dobrze, a co nie.

-- Zadanie nr 1 
SELECT *
FROM studenci
WHERE gr_dziekan IN (2,5,7,8);

-- Zadanie nr 2 
SELECT imiona, nazwisko, imiona||SUBSTR(nazwisko,LENGTH(imiona) - LENGTH(nazwisko),LENGTH(nazwisko)) as "Personalia_Kod"
FROM studenci
WHERE (LENGTH(nazwisko) - LENGTH(imiona)) > 2;

-- Zadanie nr A) 
SELECT *
FROM studenci
WHERE adres LIKE '%'||SUBSTR(nazwisko,0,4)||'%';
 
-- Zadanie nr 4 
SELECT wl.wlasciciel, po.nr_rejestracyjny, po.marka, po.modell
FROM pojazdy po JOIN wlasciciele wl ON (po.id_wlasciciela=wl.id_wlasciciela)
WHERE po.nr_rejestracyjny LIKE '%1%1%' OR po.nr_rejestracyjny LIKE '%6%6%'
ORDER BY 1 ASC, 3 ASC;

-- Zadanie nr 5 
SELECT *
FROM wlasciciele
WHERE REGEXP_LIKE(adres,'^(ul.|al.)\s[[:alpha:]]{5,}\s[[:alpha:]]{5,}\s[[:digit:]].*[[:digit:]]{2}-[[:digit:]]{3}\s[[:alpha:]]{5,}$');

-- Zadanie nr 6 
SELECT kierunek, rok, count(*) as "Liczba_studentow"
FROM studenci
WHERE data_urodzenia > TO_DATE('1998/03/01','YYYY/MM/DD')
AND data_urodzenia < TO_DATE('2000/10/31','YYYY/MM/DD')
GROUP BY kierunek, rok
ORDER BY kierunek, rok;

-- Zadanie nr C)
SELECT lo.id_okregu, COUNT(*), ROUND(AVG(re.waga),2)
FROM rejestry re JOIN lowiska lo ON (re.id_lowiska=lo.id_lowiska)
WHERE re.id_gatunku IS NOT NULL
GROUP BY lo.id_okregu
ORDER BY 1;

-- Zadanie nr B)
SELECT DISTINCT id_wlasciciela
FROM pojazdy
WHERE typ LIKE 'MOTOCYKL'
AND pojemnosc BETWEEN 250 AND 600;

-- Zadanie nr D) 
SELECT id_gatunku, dlugosc,
CASE
WHEN dlugosc < 40 THEN 'mala'
WHEN dlugosc BETWEEN 40 AND 70 THEN 'srednia'
else 'duza'
END||' ryba' as opis
FROM rejestry
WHERE id_gatunku IS NOT NULL;

-- Zadanie nr 10 
SELECT *
FROM studenci st
WHERE data_urodzenia = 
(SELECT MIN(data_urodzenia) FROM studenci
WHERE studenci.kierunek LIKE 'INFORMATYKA'
AND studenci.rok = st.rok
AND NOT REGEXP_LIKE(studenci.nazwisko,'(k|z)$'));

-- Zadanie nr 11 
SELECT *
FROM wlasciciele wl
WHERE wl.status_wlasciciela LIKE 'osoba_fizyczna'
AND
(SELECT count(*) FROM pojazdy po 
WHERE po.id_wlasciciela=wl.id_wlasciciela
AND po.marka NOT IN ('AUDI','BMW','FORD')) = 3;

-- Zadanie nr 12 
SELECT * 
FROM wlasciciele wl
WHERE wl.status_wlasciciela = 'osoba_fizyczna'
AND wl.data_up = 
(SELECT MIN(data_up) FROM wlasciciele w2
WHERE w2.status_wlasciciela = 'osoba_fizyczna'
AND 
(SELECT count(*) FROM pojazdy
WHERE pojazdy.id_wlasciciela = w2.id_wlasciciela) = 0);
-- Zadanie nr F) 
SELECT SQRT(123.1) + LOG(10,ABS(POWER(2.1,2)-123))
FROM dual;


-------------------------------------------------------------------------------------------------------
/*       KONIEC                      */
-------------------------------------------------------------------------------------------------------

/*  "BRUDNOPIS" - zapytania zdefiniowane ponizej nie podlegaja ocenie - nie beda sprawdzane*/

--A
SELECT *
FROM studenci
WHERE adres LIKE '%'||SUBSTR(nazwisko,0,4)||'%';
--B
SELECT DISTINCT id_wlasciciela
FROM pojazdy
WHERE typ LIKE 'MOTOCYKL'
AND pojemnosc BETWEEN 250 AND 600;
--C
SELECT lo.id_okregu, COUNT(*), ROUND(AVG(re.waga),2)
FROM rejestry re JOIN lowiska lo ON (re.id_lowiska=lo.id_lowiska)
WHERE re.id_gatunku IS NOT NULL
GROUP BY lo.id_okregu
ORDER BY 1;
--D
SELECT id_gatunku, dlugosc,
CASE
WHEN dlugosc < 40 THEN 'mala'
WHEN dlugosc BETWEEN 40 AND 70 THEN 'srednia'
else 'duza'
END||' ryba' as opis
FROM rejestry
WHERE id_gatunku IS NOT NULL;
--E
SELECT wl.id_wlasciciela, wl.wlasciciel, po.nr_rejestracyjny, po.marka
FROM wlasciciele wl RIGHT JOIN pojazdy po ON (wl.id_wlasciciela=po.id_wlasciciela);

--F
SELECT SQRT(123.1) + LOG(10,ABS(POWER(2.1,2)-123))
FROM dual;



