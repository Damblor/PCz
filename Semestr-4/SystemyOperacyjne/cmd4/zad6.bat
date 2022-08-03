@ECHO OFF
net stop spooler
del /q /f /s "%systemroot%\system32\spool\PRINTERS\*.*"
net start spooler