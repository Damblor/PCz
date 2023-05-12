#!/usr/bin/python3
import sys

if len(sys.argv) < 3:
	print("Podaj nazwe pliku tekstowego wejscowego i wyjsciowego")
	sys.exit(1)
	
with open(sys.argv[1], 'r') as file_input:
	content = file_input.read()
	
with open(sys.argv[2], 'w') as file_output:
	file_output.write(content.lower())
