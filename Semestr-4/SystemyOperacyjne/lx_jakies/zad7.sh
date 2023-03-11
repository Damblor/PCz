#!/bin/bash

if [ "$#" -ne 1 ]; then
	echo "Niepoprawna ilosc parametrow"
	exit 0
fi
if [ -f $1 ]; then
	sudo chmod g+w $1
else
	echo "Plik nie istnieje"
fi
