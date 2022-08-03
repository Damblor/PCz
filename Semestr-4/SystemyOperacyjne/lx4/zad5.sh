#!/bin/bash

select i in Dodaj Odejmij Pomnoz
do
	case $i in
		Dodaj) 
			let wynik=$1+$2
			echo $wynik
			break ;;
		Odejmij) break ;;
		*) echo nic nie wybrales ;; 
	esac
done
