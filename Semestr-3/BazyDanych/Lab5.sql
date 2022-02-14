-- Zad X
/*
Najstarszy pojazd nalezacy do osoby fizycznej, wyprodukowany w 21 wieku
*/
SELECT * FROM pojazdy JOIN wlasciciele USING (id_wlasciciela)
WHERE wlasciciele.status_wlasciciela LIKE 'osoba_fizyczna'
AND pojazdy.data_produkcji = 
(SELECT MIN(pojazdy.data_produkcji) FROM pojazdy
JOIN wlasciciele USING (id_wlasciciela)
WHERE wlasciciele.status_wlasciciela LIKE 'osoba_fizyczna'
AND to_number(to_char(pojazdy.data_produkcji, 'CC')) = 21);
-----
SELECT * FROM 
(SELECT * FROM pojazdy JOIN wlasciciele USING (id_wlasciciela)
WHERE wlasciciele.status_wlasciciela LIKE 'osoba_fizyczna') T1 JOIN
(SELECT MIN(pojazdy.data_produkcji) najstarszy FROM pojazdy
JOIN wlasciciele USING (id_wlasciciela)
WHERE wlasciciele.status_wlasciciela LIKE 'osoba_fizyczna'
AND to_number(to_char(pojazdy.data_produkcji, 'CC')) = 21) T2
ON (data_produkcji=najstarszy);

-- Zad 6
SELECT MAX(liczba) FROM 
(SELECT id_wlasciciela, count(*) liczba FROM pojazdy 
WHERE pojazdy.typ in ('SAM_OSOBOWY','MOTOCYKL') GROUP BY id_wlasciciela);

SELECT MAX(count(*)) maxliczba FROM pojazdy 
WHERE pojazdy.typ in ('SAM_OSOBOWY','MOTOCYKL') GROUP BY id_wlasciciela;

SELECT id_wlasciciela, wlasciciel, adres, count(*) liczba FROM pojazdy JOIN wlasciciele USING (id_wlasciciela)
WHERE pojazdy.typ in ('SAM_OSOBOWY','MOTOCYKL') GROUP BY id_wlasciciela, wlasciciel, adres;

SELECT id_wlasciciela, wlasciciel, adres, count(*) liczba FROM pojazdy JOIN wlasciciele USING (id_wlasciciela)
WHERE pojazdy.typ in ('SAM_OSOBOWY','MOTOCYKL') GROUP BY id_wlasciciela, wlasciciel, adres
HAVING count(*) =
(SELECT MAX(count(*)) maxliczba FROM pojazdy 
WHERE pojazdy.typ in ('SAM_OSOBOWY','MOTOCYKL') GROUP BY id_wlasciciela);

SELECT id_wlasciciela, wlasciciel, adres, count(*) liczba FROM pojazdy JOIN wlasciciele USING (id_wlasciciela)
WHERE pojazdy.typ in ('SAM_OSOBOWY','MOTOCYKL') GROUP BY id_wlasciciela, wlasciciel, adres
HAVING count(*) >=
(SELECT MAX(count(*)) maxliczba FROM pojazdy 
WHERE pojazdy.typ in ('SAM_OSOBOWY','MOTOCYKL') GROUP BY id_wlasciciela) * 0.5;

-- Zad 7
SELECT wl.id_wlasciciela, wlasciciel, adres, count(*) liczba,
(SELECT count(*) from pojazdy where typ like 'SAM_OSOBOWY'
AND id_wlasciciela = wl.id_wlasciciela) liczsam,
(SELECT count(*) from pojazdy where typ like 'MOTOCYKL'
AND id_wlasciciela = wl.id_wlasciciela) liczmot
FROM pojazdy po JOIN wlasciciele wl ON (po.id_wlasciciela = wl.id_wlasciciela)
WHERE po.typ in ('SAM_OSOBOWY','MOTOCYKL') GROUP BY wl.id_wlasciciela, wlasciciel, adres
HAVING count(*) =
(SELECT MAX(count(*)) maxliczba FROM pojazdy 
WHERE pojazdy.typ in ('SAM_OSOBOWY','MOTOCYKL') GROUP BY id_wlasciciela);

-- Zad X
/*
Wyswietl informacje ile pojazdow z danym rodzajem napedu posiada dany wlasciciel, 
uwzglednij wszystkich wlascicieli i wszystkie notowane rodzaje napedu
*/
SELECT rodzaj_paliwa, id_wlasciciela, wlasciciel,
(SELECT  count(vin) FROM pojazdy WHERE rodzaj_paliwa = t1.rodzaj_paliwa AND id_wlasciciela = t2.id_wlasciciela ) liczba
FROM (SELECT DISTINCT rodzaj_paliwa FROM pojazdy) T1 
CROSS JOIN wlasciciele T2 ORDER BY 2;

SELECT t1.rodzaj_paliwa, t2.id_wlasciciela, t2.wlasciciel, count (vin)
FROM (SELECT DISTINCT rodzaj_paliwa FROM pojazdy) T1 
CROSS JOIN wlasciciele T2 LEFT JOIN pojazdy T3 ON (t3.rodzaj_paliwa = t1.rodzaj_paliwa AND t3.id_wlasciciela = t2.id_wlasciciela) 
GROUP BY t1.rodzaj_paliwa, t2.id_wlasciciela, t2.wlasciciel ORDER BY 2;

-- Zad 17
SELECT decode(grouping(tryb), 1 ,'podsumowanie',tryb) tryb, stopien, kierunek ,rok, count(*),
grouping_id (tryb, stopien, kierunek ,rok) liczba
FROM studenci
GROUP BY rollup (tryb, stopien, kierunek ,rok);

SELECT decode(grouping(tryb), 1 ,'podsumowanie',tryb) tryb, stopien, kierunek ,rok, count(*),
grouping_id (tryb, stopien, kierunek ,rok) liczba
FROM studenci
GROUP BY cube (tryb, stopien, kierunek ,rok);

SELECT decode(grouping(tryb), 1 ,'podsumowanie',tryb) tryb, stopien, kierunek ,rok, count(*),
grouping_id (tryb, stopien, kierunek ,rok) liczba
FROM studenci
GROUP BY grouping sets ((tryb, stopien, kierunek ,rok),(tryb, stopien, kierunek),(tryb, rok),(rok),());