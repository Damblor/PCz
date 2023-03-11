setlocal EnableDelayedExpansion 
@echo off 
set suma=0 
for /L %%i in (1,1,5) do ( 
 set /A suma=!suma!+%%i 
 echo Wartosc: !suma! 
) 
echo Suma: %suma% 