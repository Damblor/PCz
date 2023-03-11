#!/bin/bash
MAX=0
LINE=""
while IFS='$\n' read -r line; do
	if [ ${#line} -gt $MAX ]; then
		MAX=${#line};
		LINE=$line
        fi
done
printf "$MAX\n"
printf "$LINE\n"

