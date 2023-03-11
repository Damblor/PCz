#!/bin/bash

echo podaj nazwe
read nazwa

select i in .old _bak .--001
do
	case $i in
		.old) 
			mv $nazwa $nazwa".old"
			break ;;
		*)
			echo zlee wybrales
			break ;;
	esac
done
