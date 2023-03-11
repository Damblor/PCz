#!/bin/bash
if [ "$#" -lt 2 ]; then
	printf "Podano za malo argumentow\n"
else
	if [ -f $1 ]; then
		for i in "$@"; do
			if [ -f $i ]; then
				printf "$i Plik juz istnieje\n"
			else
				cp $1 $i
			fi
		done
	else
		printf "Podany plik nie istnieje\n"
	fi
fi
