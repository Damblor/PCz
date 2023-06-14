#!/usr/bin/python3

import random
import string
	
def gen_random_char_N(n):
	return ''.join(random.choice(string.ascii_uppercase + string.ascii_lowercase + string.digits) for _ in range(n))

l = input("Podaj ilosc: ")
size = input("Podaj wielkosc: ")

for _ in range(int(l)):
	print(gen_random_char_N(int(size)))
