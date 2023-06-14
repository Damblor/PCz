#!/bin/bash

awk 'BEGIN { FS=";"; OFS="=" } { print "student", $1 } { print "nr indeksu", $2 } { print "ocena", $3 }' $1
