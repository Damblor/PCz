--zad 1.3
SELECT COUNT(*), COUNT(DISTINCT imiona)
FROM studenci WHERE imiona NOT LIKE '%a' AND imiona LIKE 'M%';
--zad 1.6
SELECT Substr(imiona, 0 ,1) ||'.'|| Substr(nazwisko, 0 ,1) ||'.' as Inicjaly, imiona, nazwisko, length(concat(nazwisko,imiona)) as "Liczba liter"  FROM studenci
WHERE length(concat(nazwisko,imiona)) in (9,11,13);
--zad 1.11
--Upper(nazwisko) like ('%A%A%');
SELECT Lpad(Rpad(nazwisko,length(nazwisko) + 4,'+'),length(nazwisko) + 7,'*') FROM studenci WHERE instr(substr(nazwisko, instr(Lower(nazwisko),'a',1) + 1),'a',1) > 0;
--zad 2.1
SELECT * FROM pojazdy WHERE Substr(nr_rejestracyjny,1,3) like 'SC ' AND pojemnosc BETWEEN 1000 AND 2000 AND
Substr(Trim(nr_rejestracyjny),-1,1) --IN ('1','2','3','4','5','6','7','8','9','0');
BETWEEN '0' AND '9';
--zad 2.5
SELECT nr_rejestracyjny, modell, marka, pojemnosc,
Decode(Substr(nr_rejestracyjny,1,2),'SC','slaskie','PO','woelkopolskie','EL','lodzkie','GD','pomorskie','niezidentifiko0wane') as wojewodztwo
FROM pojazdy WHERE pojemnosc NOT BETWEEN 1600 AND 2000 AND marka='OPEL'
AND Mod(Mod(pojemnosc,1000),16) = 0;
--zad 3.1
SELECT 'Od ' || Trunc(Min(czas)) || ' Do ' || Trunc(Max(czas)) || ' odnotowano ' || count(*) || ' polowow w tym udanych ' || count(id_gatunku) || ' na wodach ' || count(DISTINCT(Substr(id_lowiska,1,1))) || ' zarzadcow, laczna waga ' || Sum(waga) || ' srednai dlugosc ' || Round(avg(dlugosc),2) as Informacja
FROM rejestry;