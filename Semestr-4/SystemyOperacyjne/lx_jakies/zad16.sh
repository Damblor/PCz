#!/bin/bash

case $1 in
	"pomoc")
		echo "p" ;;
	"usun") echo "u"
		;;
	"kopiuj") echo "k" ;;
	*)
		echo $1
		;;
esac
