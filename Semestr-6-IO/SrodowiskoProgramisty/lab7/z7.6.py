#!/usr/bin/python3

import random

def check_pesel(p):

	wagi = [1,3,7,9,1,3,7,9,1,3]
	control = 0

	if len(p) != 11:
		return False

	for i in range(10):
		control += wagi[i] * int(p[i])
		
	control = control % 10
	if control != 0:
		control = 10 - control
		
	if int(p[10]) != control:
		return False
		
	return True
	
def random_N(n):
	rs = 10 ** (n - 1)
	re = (10 ** n) - 1
	return random.randint(rs, re)
	
for _ in range(10):
	pesel = random_N(11)
	if check_pesel(str(pesel)):
		print("Pesel: ", pesel, " jest poprawny")
	else:
		print("Pesel: ", pesel, " nie jest poprawny")
