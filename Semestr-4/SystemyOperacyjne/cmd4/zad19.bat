@ECHO OFF
cd /d C:\
dir /s /b *.txt
dir /s /b Readme.* > stare.txt
sort /+2 stare.txt /o stare.txt
call zad3.bat
date /t >> stare.txt