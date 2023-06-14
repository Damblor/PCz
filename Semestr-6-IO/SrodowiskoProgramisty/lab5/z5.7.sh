#!/bin/bash

awk '{ for (i=NF; i>=1; i--) printf $i" "; print "" }' $1
