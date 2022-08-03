#!/bin/bash

if [ "$#" -ne 2 ]; then
	echo "bledna ilosc parametrow"
	exit 0
fi
if [ -f $1 ]; then
	cp $1 $2
	rm $1
else
	echo "plik nie istnieje"
fi
