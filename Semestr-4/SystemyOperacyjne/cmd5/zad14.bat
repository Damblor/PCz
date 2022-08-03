setlocal EnableDelayedExpansion 
@ECHO off
for /L %%i in (1,1,%1) do (
    set /A result=!RANDOM!*%2/32768+0
    echo !result!
    )