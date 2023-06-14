#!/usr/bin/python3

text = input('Podaj ciag znakow:')
lista = []

print('\nznak -> ASCII\n')
for c in text:
	asc = ord(c)
	print(c, '->', asc)
	lista.append(asc)
print('\nLista kodow ASCII\n', lista)
