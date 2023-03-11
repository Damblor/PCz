#!/bin/bash
if [ "$#" -ne 2 ]; then
	printf "Podano zla liczbe argumentow\n"
elif [ $1 -gt $2 ]; then
	printf "Nie mozna wydac reszty gdy kwota jest na minusie\n"
elif [ $1 -eq $2 ]; then
	printf "Brak reszty\n"
else
	l=$(($2 - $1))
	while [ $l != 0 ]; do
		if  [ $(($l - 5)) -ge 0 ]; then
			l=$(($l - 5))
			printf "5 "
		elif [ $(($l - 2)) -ge 0 ]; then
			l=$(($l - 2))
			printf "2 "
		elif [ $(($l - 1)) -ge 0 ]; then
			l=$(($l - 1))
			printf "1 "
		fi
	done
	printf "\n"
fi
