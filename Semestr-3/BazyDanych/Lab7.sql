--Zad 1-2
SELECT rejestry.id_wedkarza FROM rejestry JOIN gatunki USING(id_gatunku)
WHERE lower(gatunki.nazwa) LIKE 'sandacz' AND
EXTRACT(MONTH FROM rejestry.czas) BETWEEN 6 AND 9;

SELECT * FROM wedkarze WHERE id_wedkarza = ANY
(SELECT rejestry.id_wedkarza FROM rejestry JOIN gatunki USING(id_gatunku)
WHERE lower(gatunki.nazwa) LIKE 'sandacz' AND
EXTRACT(MONTH FROM rejestry.czas) BETWEEN 6 AND 9);

SELECT * FROM wedkarze we WHERE id_wedkarza = ANY
(SELECT id_wedkarza FROM rejestry JOIN gatunki USING(id_gatunku)
WHERE lower(gatunki.nazwa) LIKE 'sandacz' AND
EXTRACT(MONTH FROM czas) BETWEEN 6 AND 9) AND
60 <= ALL
(SELECT dlugosc FROM rejestry JOIN gatunki USING(id_gatunku)
WHERE lower(nazwa) LIKE 'sandacz' AND
EXTRACT(MONTH FROM czas) BETWEEN 6 AND 9 AND we.id_wedkarza = id_wedkarza);

--Zad 8
SELECT nr_indeksu, nazwisko, imiona, kierunek, rok FROM studenci st WHERE rok > 1 
AND 4.3 <= ALL
(SELECT avg(ocena) FROM oceny JOIN przedmioty using(id_przedmiotu)
WHERE nr_indeksu = st.nr_indeksu GROUP BY rok) AND
4.6 >= ALL
(SELECT avg(ocena) FROM oceny JOIN przedmioty using(id_przedmiotu)
WHERE nr_indeksu = st.nr_indeksu GROUP BY rok) AND
NOT EXISTS(SELECT * FROM oceny JOIN przedmioty using(id_przedmiotu)
WHERE nr_indeksu = st.nr_indeksu AND (oceny.ocena = 2.0 OR oceny.ocena IS NULL))
ORDER BY st.rok DESC, st.nr_indeksu ASC;

--Zad 10
SELECT * FROM wedkarze w1 WHERE 0 <ALL
(SELECT 
(SELECT count(*) FROM rejestry WHERE EXTRACT(YEAR FROM czas)=t1.rok AND id_wedkarza=we.id_wedkarza)
FROM 
(SELECT EXTRACT(YEAR FROM czas) rok FROM rejestry GROUP BY EXTRACT(YEAR FROM czas)) t1
CROSS JOIN wedkarze we WHERE id_wedkarza=w1.id_wedkarza);

--Zad 11
SELECT * FROM wedkarze we WHERE 0 < all
(SELECT count(*)- count(id_gatunku) fail FROM rejestry WHERE id_wedkarza=we.id_wedkarza
GROUP BY id_lowiska) AND EXISTS(SELECT * FROM rejestry WHERE id_wedkarza = we.id_wedkarza);

SELECT * FROM wedkarze we WHERE 0 < all
(SELECT count(*)- count(id_gatunku) fail FROM rejestry WHERE id_wedkarza=we.id_wedkarza
GROUP BY id_lowiska) AND EXISTS(SELECT * FROM rejestry WHERE id_wedkarza = we.id_wedkarza)
AND EXISTS(SELECT sum(waga) FROM rejestry WHERE id_wedkarza = we.id_wedkarza GROUP BY id_lowiska
HAVING sum(waga) >= 1);

--Zad 14
SELECT stopien, rok, gr_dziekan, count(*) liczba, ROUND(AVG(srednia),2) srednia,
LISTAGG(nazwisko||' '||imiona,', ') WITHIN GROUP (ORDER BY nazwisko) lista
FROM studenci WHERE kierunek LIKE 'INFORMATYKA'
AND tryb LIKE 'STACJONARNY' AND imiona LIKE '%a' GROUP BY stopien, rok, gr_dziekan;

SELECT stopien, rok, SUM(liczba), ROUND(AVG(srednia),2),
LISTAGG('gr.'||gr_dziekan||' liczba = '||liczba||' srednia = '||srednia||' ['||lista||']', '|') WITHIN GROUP(ORDER BY gr_dziekan) info
FROM
(SELECT stopien, rok, gr_dziekan, count(*) liczba, ROUND(AVG(srednia),2) srednia,
LISTAGG(nazwisko||' '||imiona,', ') WITHIN GROUP (ORDER BY nazwisko) lista
FROM studenci WHERE kierunek LIKE 'INFORMATYKA'
AND tryb LIKE 'STACJONARNY' AND imiona LIKE '%a' GROUP BY stopien, rok, gr_dziekan)GROUP BY stopien, rok;



