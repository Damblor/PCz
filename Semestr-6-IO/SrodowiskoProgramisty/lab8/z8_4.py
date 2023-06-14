#!/usr/bin/python3
from z8_3 import zliczLinie
import sys
	
if __name__ == '__main__':
	if len(sys.argv) < 2:
		print("Podaj nazwe pliku tekstowego wejscowego")
		sys.exit(1)
	
	print(f"Liczba lini {zliczLinie(sys.argv[1])}")
	with open(sys.argv[1], 'r') as plik:
		max_line = 0
		for count, line in enumerate(plik):
			if max_line < len(line):
				max_line = len(line)
				number = count
				content = line
	print(f"Numer lini:{number}")
	print(f"Zawartosc: {content}")
			
