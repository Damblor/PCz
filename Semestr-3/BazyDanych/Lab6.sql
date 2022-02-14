SELECT imiona from studenci WHERE stopien=1
INTERSECT
SELECT imiona from studenci WHERE stopien=2;

SELECT imiona from studenci WHERE stopien=1
MINUS
SELECT imiona from studenci WHERE stopien=2;

SELECT imiona from studenci WHERE stopien=1
UNION
SELECT imiona from studenci WHERE stopien=2;

SELECT imiona from studenci WHERE stopien=1
UNION ALL
SELECT imiona from studenci WHERE stopien=2;

SELECT imiona from studenci WHERE rok=1
UNION
SELECT imiona from studenci WHERE rok=2;

SELECT imiona from studenci WHERE rok=1
UNION ALL
SELECT imiona from studenci WHERE rok=2;

SELECT imiona, nazwisko from studenci WHERE rok=1
UNION ALL
SELECT imiona, 'Kowalski' from studenci WHERE rok=2;

SELECT imiona, nazwisko from studenci WHERE rok=1
INTERSECT
SELECT imiona, 'Kowalski' from studenci WHERE rok=2;

SELECT imiona, nazwisko from studenci WHERE rok=1
INTERSECT
SELECT imiona, nazwisko from studenci WHERE rok=2;

SELECT INITCAP(nazwa) FROM gatunki
INTERSECT
SELECT nazwisko from studenci;

------------
--Zad 2
SELECT to_char(re.czas,'YYYY-MM-DD HH24:MI') czas, re.dlugosc,
CASE
WHEN re.dlugosc > (SELECT round(avg(dlugosc)) FROM rejestry WHERE id_gatunku=re.id_gatunku)
THEN 'wieksza'
when dlugosc = (SELECT round(avg(dlugosc)) FROM rejestry WHERE id_gatunku=re.id_gatunku)
then 'rowna'
else 'mniejsza'
end opis
FROM rejestry re JOIN gatunki ga ON (re.id_gatunku=ga.id_gatunku)
WHERE lower(ga.nazwa) LIKE 'szczupak';

--Kazda ryba dla swojego gatunku
SELECT to_char(re.czas,'YYYY-MM-DD HH24:MI') czas, nazwa, re.dlugosc,
CASE
WHEN re.dlugosc > (SELECT round(avg(dlugosc)) FROM rejestry WHERE id_gatunku=re.id_gatunku)
THEN 'wieksza'
when dlugosc = (SELECT round(avg(dlugosc)) FROM rejestry WHERE id_gatunku=re.id_gatunku)
then 'rowna'
else 'mniejsza'
end opis
FROM rejestry re JOIN gatunki ga ON (re.id_gatunku=ga.id_gatunku)
WHERE re.id_gatunku is not null;

SELECT t1.id_gatunku ,srednia ,czas, dlugosc, re.id_gatunku,
case
when dlugosc > srednia then 'wieksza'
when dlugosc = srednia then 'rowna'
else 'mniejsza' end opis
FROM
(SELECT id_gatunku, round(avg(dlugosc)) srednia FROM rejestry Group BY id_gatunku) t1
join rejestry re on (t1.id_gatunku=re.id_gatunku) join gatunki ga on (t1.id_gatunku=ga.id_gatunku);

--Zad 6
SELECT * FROM
(SELECT id_wedkarza, rok, id_okregu FROM licencje
where od_dnia like '01-01' and do_dnia like '31-12' AND id_okregu like 'PZW%'
MINUS
SELECT id_wedkarza, extract(year from czas) rok, id_okregu
FROM rejestry JOIN lowiska using (id_lowiska)
WHERE id_okregu like 'PZW%') t1 join wedkarze we
on (t1.id_wedkarza = we.id_wedkarza);

SELECT rok, t1.id_wedkarza, we.nazwisko , t1.id_okregu, count(*) polowy FROM rejestry re join lowiska lw on (re.id_lowiska = lw.id_lowiska) join
(SELECT id_wedkarza, rok, id_okregu FROM licencje
where od_dnia like '01-01' and do_dnia like '31-12' AND id_okregu like 'PZW%'
intersect
SELECT id_wedkarza, extract(year from czas) rok, id_okregu
FROM rejestry JOIN lowiska using (id_lowiska)
WHERE id_okregu like 'PZW%') t1 on (re.id_wedkarza = t1.id_wedkarza
and t1.id_okregu = lw.id_okregu and t1.rok = extract(year from re.czas))
join wedkarze we on (t1.id_wedkarza = we.id_wedkarza)
GROUP BY rok, t1.id_wedkarza, we.nazwisko, t1.id_okregu;

--Zad 13
SELECT t1.typ||' jednej marki najwiecej w '||t1.dzien||'('||marka||' '||liczba||')' info
from
(select typ, dzien, max(liczba) maxliczba FROM
(SELECT typ, marka, trim(to_char(data_produkcji, 'day')) dzien, count(*) liczba FROM pojazdy
GROUP by typ, marka, trim(to_char(data_produkcji, 'day')))
group by typ, dzien) t1 JOIN
(SELECT typ, marka, trim(to_char(data_produkcji, 'day')) dzien, count(*) liczba FROM pojazdy
GROUP by typ, marka, trim(to_char(data_produkcji, 'day'))) t2
on (t1.typ=t2.typ and t1.dzien = t2.dzien and maxliczba = liczba)
UNION
SELECT t1.typ||' jednej marki najmniej w '||t1.dzien||'('||marka||' '||liczba||')' info
from
(select typ, dzien, min(liczba) minliczba FROM
(SELECT typ, marka, trim(to_char(data_produkcji, 'day')) dzien, count(*) liczba FROM pojazdy
GROUP by typ, marka, trim(to_char(data_produkcji, 'day')))
group by typ, dzien) t1 JOIN
(SELECT typ, marka, trim(to_char(data_produkcji, 'day')) dzien, count(*) liczba FROM pojazdy
GROUP by typ, marka, trim(to_char(data_produkcji, 'day'))) t2
on (t1.typ=t2.typ and t1.dzien = t2.dzien and minliczba = liczba)
order by 1;

--Zad 16
SELECT g1.id_gatunku, g1.nazwa, g1.wymiar,
case
when g1.wymiar > g2.wymiar then 'wiekszy'
when g1.wymiar < g2.wymiar then 'mniejszy'
else 'rowny' end opis
, g2.id_gatunku, g2.nazwa, g2.wymiar, abs(g1.wymiar-g2.wymiar) roznica
FROM gatunki g1 JOIN gatunki g2 on(g1.id_gatunku<g2.id_gatunku
and abs(g1.wymiar-g2.wymiar)<=10);