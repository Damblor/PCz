#!/bin/bash
if [ "$#" -ne 4 ]; then
	echo "bladna liczba parametrow"
	exit 0
fi
let suma=$1+$2+$3+$4
echo "Suma: $suma " 

