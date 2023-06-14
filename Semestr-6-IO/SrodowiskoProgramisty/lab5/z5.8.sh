#!/bin/bash

awk 'BEGIN { x = 0 } { for (i=1; i<=NF; i++) if ($i == "for" || $i == "while" || $i == "until") { print $i; x += 1 } } END { print x }' $1
