#!/bin/bash
if [ $# -ne 1 ]; then
	echo "Podaj argument plik do wypisania"
	echo "$0 <plik>"
elif [ -f $1 ]; then
	tac $1
else
	echo "Podany plik nie istnieje"
fi
