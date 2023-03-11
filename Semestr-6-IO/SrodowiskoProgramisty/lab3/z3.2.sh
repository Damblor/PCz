#!/bin/bash
for f in *.sh; do	
	printf "Plik $f\n"
	l=$(head -n 1 $f)
	if echo "$l" | grep "#!"; then
		printf "Zawiera odwolanie do interpretatora\n"
		path=${l#\#\!}
		if [ -f $path ]; then
			printf "Interpretator istnieje\n"
		fi
	fi
done
