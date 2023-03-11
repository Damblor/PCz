@ECHO off
tasklist /FI "MEMUSAGE ge 1024" /NH | sort /+64 >> procesy%date%.txt