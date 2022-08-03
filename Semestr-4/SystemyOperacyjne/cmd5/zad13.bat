@ECHO off
set /P dzialanie="podaj dzialanie "
set /P x="podaj x "
set /P y="podaj y "
if /I %dzialanie%==1 (goto dodaj)
if /I %dzialanie%==2 (goto od1)
if /I %dzialanie%==3 (goto od2)
if /I %dzialanie%==4 (goto mn)
:dodaj
set /A wynik=%x%+%y%
goto koniec
:od1
set /A wynik=%x%-%y%
goto koniec
:od2
set /A wynik=%y%-%x%
goto koniec
:mn
set /A wynik=%x%*%y%
goto koniec

:koniec
echo Wynik=%wynik%