#!/bin/bash
if [ $# -eq 0 ]; then
	printf "Nie podano nazwy katalogu\n"
else
	if [ -d $1 ]; then
        	for f in $1*.sh; do
                	bash "$f"
        	done
	else
        	printf "Podany katalog nie istnieje\n"
	fi
fi
