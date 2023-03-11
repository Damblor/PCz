@ECHO OFF
for /L %%i in (1,1,6) do (mkdir %1\%%i)
dir /A:D %1