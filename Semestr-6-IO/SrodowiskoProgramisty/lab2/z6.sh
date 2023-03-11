#!/bin/bash
if [ $# -ne 2 ]; then
        echo "Podaj argumenty"
	echo "$0 <tryb> <plik>"
	echo "tryb: 0 - normalna kolejnosc, 1 - odwrotna kolejnosc"
elif [ -f $2 ]; then
	if [ $1 -eq 0 ]; then
		cat -n $2
	elif [ $1 -eq 1 ]; then
		cat -n $2 | tac
	else
		echo "Zostal podany zly tryb"
	fi
else
	echo "Podany plik nie istnieje"
fi

