#!/usr/bin/python3
import sys

def zliczLinie(nazwa_pliku: str) -> int:
	with open(nazwa_pliku, 'r') as plik:
		count = plik.readlines()
	return len(count)
	
def zliczZnaki(nazwa_pliku: str) -> int:
	with open(nazwa_pliku, 'r') as plik:
		data = plik.read()
		count = len(data)
	return count
	
if __name__ == '__main__':
	if len(sys.argv) < 2:
		print("Podaj nazwe pliku tekstowego wejscowego")
		sys.exit(1)
	
	print(f"Liczba lini {zliczLinie(sys.argv[1])}")
	print(f"Liczba znakow {zliczZnaki(sys.argv[1])}")
	

