#!/usr/bin/python3
import sys
import random

word_counts = dict()

def count_words(file_name: str) -> None:
	with open(file_name, 'r') as f:
		data = f.read().lower().strip().split()
		for line in data:
			if line in word_counts:
				word_counts[line] += 1
			else:
				word_counts[line] = 1
	
if __name__ == '__main__':
	if len(sys.argv) < 2:
		print("Podaj nazwe pliku")
		sys.exit(1)
		
	count_words(sys.argv[1])
	print(word_counts)
