#!/usr/bin/python3

import random

r = random.randint(0,10)

for _ in range(5):
	l = input('Podaj liczbe:')
	if r == int(l):
		print('Wygrales, prawidlowa liczba to:', int(l))
		exit()

print('Przegrales, prawidlowa liczba to:', r)
