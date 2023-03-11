#!/bin/bash
printf "Lista kont z bash jaok domyslna powloka\n"
while IFS='$\n' read -r line; do
	l=$(grep '/bin/bash' | cut -d: -f1)
	printf "$l\n"
done
