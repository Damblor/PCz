#!/usr/bin/python3

size = input('Podaj rozmiar:')

for i in range(1, int(size)):
	for j in range(1, int(size)):
		print(i, ' * ', j, ' = ', i * j)

