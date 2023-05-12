#!/usr/bin/python3
import sys
import random

def losuj_zdanie(n: int) -> str:
	with open("/usr/share/dict/words", 'r') as f:
		data = f.readlines()
		txt = ''
		for i in range(n):
			txt += random.choice(data) + ' '
		txt = txt[:-1] + '.'
		return txt.lower().capitalize().replace('\n', '')
	
if __name__ == '__main__':
	if len(sys.argv) < 2:
		print("Podaj liczbe slow")
		sys.exit(1)
		
	print(losuj_zdanie(int(sys.argv[1])))
			
