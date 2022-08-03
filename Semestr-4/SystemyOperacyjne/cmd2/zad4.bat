@ECHO off
dir %1 /A:R 
:w
set /P o="Opcja:"
if %o%==0 (attrib -r %1/*.*)
if %o%==1 (robocopy /IA:R %1 kopia)
if %o%==2 (goto koniec)
goto w
:koniec