@echo off 
set suma=0 
:powrot 
set /P dodaj="Podaj wartosc: " 
if %dodaj%==0 goto koniec 
set /A suma=%suma%+dodaj 
echo Wynik=%suma% 
goto powrot 
:koniec