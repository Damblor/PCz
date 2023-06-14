#!/bin/bash
if [ "$#" -ne 2 ]; then
	printf "Podano zla liczbe argumentow\n"
else
	a=$1
	b=$2
	while [ $b != "0" ]; do
		((c = a % b))
		a=$b
		b=$c
	done
	printf "$a\n"
fi
