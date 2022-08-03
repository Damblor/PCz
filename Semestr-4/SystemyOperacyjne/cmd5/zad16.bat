@ECHO off
set suma=0
for %%i in (%*) do (
    set /A suma+=1
)
echo %suma%