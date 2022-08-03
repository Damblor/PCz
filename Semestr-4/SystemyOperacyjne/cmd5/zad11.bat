@ECHO off
for /F "delims=%TAB%" %%i in ('tasklist') do echo %%i