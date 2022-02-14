-- Zad 4
SELECT TRUNC(czas), nazwisko, imiona, gatunki.nazwa as Gatunek, lowiska.nazwa as Lowiska, waga, dlugosc
FROM rejestry LEFT JOIN wedkarze USING(id_wedkarza)
RIGHT JOIN gatunki USING (id_gatunku) LEFT JOIN lowiska USING (id_lowiska) ORDER BY czas;
-- Zad 8
SELECT id_wedkarza, nazwisko, id_okregu, id_licencji, od_dnia||'-'||rok as poczatek, do_dnia||'-'||rok as koniec,
TO_DATE(do_dnia||'-'||rok,'DD-MM-YYYY') - TO_DATE(od_dnia||'-'||rok,'DD-MM-YYYY') + 1 as dni,
(TO_DATE(do_dnia||'-'||rok,'DD-MM-YYYY') - TO_DATE(od_dnia||'-'||rok,'DD-MM-YYYY') + 1)*dzienna_oplata as oplaty
FROM licencje JOIN wedkarze USING (id_wedkarza) JOIN oplaty USING (rok, id_okregu)
WHERE NOT (od_dnia LIKE '01-01' AND do_dnia LIKE '31-12');
-- Zad 10
SELECT p1.nr_akt, p1.nazwisko, p1.imiona, p1.przelozony, p2.nazwisko||' '||p2.imiona as szef
FROM pracownicy p1 LEFT JOIN pracownicy p2 ON (p1.przelozony = p2.nr_akt);
-- Zad 13
SELECT rok, stopien, gr_dziekan, count(*), Round(avg(srednia),2) FROM studenci
WHERE kierunek LIKE 'MAT%' AND imiona LIKE '%a' GROUP BY rok ,stopien, gr_dziekan;
-- Zad 21
SELECT id_lowiska, nazwa, count(*) as polowy, count(id_gatunku) as ryby, count(distinct id_wedkarza) as wedkarze
FROM rejestry JOIN lowiska USING (id_lowiska)
WHERE czas BETWEEN TIMESTAMP'2018-07-14 07:05:00' AND TIMESTAMP'2018-07-14 07:05:00' +
INTERVAL'2'YEAR+INTERVAL'21 19:00:28'DAY(2) TO SECOND GROUP BY id_lowiska, nazwa
HAVING count(id_gatunku) >=6 AND count(*) - count(id_gatunku) >=2;
-- Zad 17
SELECT id_dzialu, nazwa, ROUND(avg(placa),2) as placa
FROM pracownicy LEFT JOIN dzialy USING(id_dzialu)
GROUP BY id_dzialu, nazwa ORDER BY placa;
-- Zad 25
SELECT id_przedmiotu, nazwa, id_kierunku, stopien, semestr, count(distinct nr_indeksu),
count (ocena), Count(*) - count(ocena)
FROM przedmioty JOIN oceny USING (id_przedmiotu)
GROUP BY id_przedmiotu, nazwa, id_kierunku, stopien, semestr
HAVING Count(*) - count(ocena) BETWEEN 3 AND 6;