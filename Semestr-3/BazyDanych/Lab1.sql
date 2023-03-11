--zapytanie 1
SELECT nr_indeksu, nazwisko, imiona, data_urodzenia, gr_dziekan, rok
FROM studenci
WHERE (imiona = 'Piotr' OR imiona LIKE 'Adam') AND rok LIKE '2';

--zapytanie 2
SELECT nr_indeksu, nazwisko, imiona, data_urodzenia, gr_dziekan, rok
FROM studenci
WHERE imiona IN('Piotr','Adam','Ewa','Anna') AND rok LIKE '2' AND nazwisko
BETWEEN 'B%' AND 'Kz%';

--zapytanie 3
SELECT nr_indeksu, nazwisko||' '||imiona||' '||adres AS "Personalia Studentow", data_urodzenia, gr_dziekan, rok
FROM studenci
WHERE imiona NOT LIKE '%a';

--zapytanie 4
SELECT nr_indeksu, nazwisko, imiona, data_urodzenia, gr_dziekan, rok, zakres
FROM studenci
ORDER BY imiona, zakres, 5;

--zapytanie 5
SELECT DISTINCT imiona, rok
FROM studenci
WHERE imiona LIKE '_r%' ORDER BY 1, 2;

--zapytanie 5
SELECT nr_akt, placa+nvl(dod_funkcyjny,0) pensja, data_zwol
FROM pracownicy
WHERE data_zwol IS NOT NULL;