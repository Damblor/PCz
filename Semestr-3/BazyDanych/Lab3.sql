-- Zad 4
--SELECT interval '101-11' year(3) to month,
--interval '25 03:05:36.6' day to second,
--TIMESTAMP '101-11-25 03:05:36.6',
--to_char(sysdate + 7, 'D DD DD MM W WW CC day month year') FROM dual;

-- Zad 7
--SELECT TIMESTAMP '2021-02-11 7:17:00' - TIMESTAMP '2013-12-15 21:14:09' as "1",
--trunc(MONTHS_BETWEEN(TIMESTAMP '2021-02-11 7:17:00', TIMESTAMP '2013-12-15 21:14:09')/12) as "2",
--mod(trunc(MONTHS_BETWEEN(TIMESTAMP '2021-02-11 7:17:00', TIMESTAMP '2013-12-15 21:14:09')),12) as "3",
--(TIMESTAMP '2021-02-11 7:17:00' - TIMESTAMP '2013-12-15 21:14:09') year to month as "4"
--FROM dual;

-- Zad 9
--SELECT * FROM studenci WHERE
--extract(month from data_urodzenia) = extract(month from sysdate) AND
--extract(day from data_urodzenia) = extract(day from sysdate) AND
--to_number(to_char(data_urodzenia, 'D')) IN (1,3,5,7);

-- Zad 12
--SELECT  sysdate, round(sysdate, 'MM') as Miesiac,
--trunc(sysdate, 'YYYY') as Rok,
--to_char(trunc(sysdate, 'CC'), 'YYYY-MM-DD') as Wiek,
--to_char(to_number(to_char(sysdate, 'CC')), 'RN') as Rzymskie
--FROM dual;

-- Zad 21
--SELECT nazwisko, stanowisko, data_zatr, data_zwol, placa + nvl(dod_funkcyjny, 0) + (nvl(dod_staz, 0)*0.01) - nvl(koszt_ubezpieczenia, 0) as Wynagrodzenie
--FROM pracownicy
--WHERE data_zatr < date'2018-05-01' and nvl(data_zwol, sysdate) > date'2018-05-31';

-- Zad 23
--SELECT imiona, nazwisko, adres FROM studenci
--WHERE (regexp_count(imiona, '[[:alpha:]]')>=5 and regexp_like(nazwisko, '^(Ko)[[:alpha:]]{0,}(\s|-)?([[:alpha:]]{0,})?(ski)$'))

-- Zad 26
SELECT adres FROM studenci WHERE regexp_like(adres, '(ul.|al.)\s[[:alpha:]]{5,}\s[[:alpha:]]{5,}\s[[:digit:]].*[[:digit:]]{2}-[[:digit:]]{3}\s[[:alpha:]]{5,}\s[[:alpha:]]{5,}$')
