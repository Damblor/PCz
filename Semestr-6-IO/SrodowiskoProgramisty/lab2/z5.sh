#!/bin/bash
if [ $# -ne 1 ]; then
        echo "Podaj katalog do kompresji jako pierwszy agrument"
	echo "$0 <katalog>"
elif [ -d $1 ]; then
	tar -czvf "backup_$(date +"%d.%m.%Y_%H-%M").tar" $1
elif [ -f $1 ]; then
	echo "$1 nie jest katalogiem"
else
	echo "Podany katalog nie istnieje"
fi

