#!/bin/bash
for f in "$@"; do
	if [ -f $f ]; then
		printf "Plik: $f\n"
		cat $f
	fi
done
