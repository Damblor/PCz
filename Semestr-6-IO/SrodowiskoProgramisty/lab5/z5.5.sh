#!/bin/bash

awk 'BEGIN { FS="[\n=]"; RS="\nstudent"; } { print $2";"$4";"$6 }' $1
