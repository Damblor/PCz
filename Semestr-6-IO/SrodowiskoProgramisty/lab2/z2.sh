#!/bin/bash
if [ $# -ne 1 ]; then
	echo "Podaj nazwe"
	echo "$0 <nazwa>"
else
        echo "Witaj $1"
fi

