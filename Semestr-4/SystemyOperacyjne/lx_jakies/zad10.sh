#!/bin/bash

echo "Zapis: "
for line in $(ls -A1)
do
	if [ -r $line ]; then
		echo $line
	fi
done
echo "Odczyt: "
for line in $(ls -A1)
do
        if [ -w $line ]; then
                echo $line
        fi
done
echo "Wykonanie: "
for line in $(ls -A1)
do
        if [ -x $line ]; then
                echo $line
        fi
done

