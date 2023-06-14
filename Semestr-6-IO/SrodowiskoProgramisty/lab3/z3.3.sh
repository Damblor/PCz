#!/bin/bash
if [ "$#" -ne 0 ]; then
	for i in $(seq 1 $1); do
		for j in $(seq 1 $1); do
			echo "$i * $j = " $(($i * $j))
		done
	done
else
	printf "Nie podano rozmiaru tabliczki mnozenia\n"
fi

