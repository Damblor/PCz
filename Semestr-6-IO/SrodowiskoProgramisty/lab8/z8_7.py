#!/usr/bin/python3
import sys

def process_people(file_name: str) -> None:
	with open(file_name, 'r') as f:
		data = f.readlines()
		data.sort(key=lambda s: s.split()[2])
		for p in data:
			print(p.strip())
		
	
if __name__ == '__main__':
	if len(sys.argv) < 2:
		print("Podaj nazwe pliku")
		sys.exit(1)
		
	process_people(sys.argv[1])
