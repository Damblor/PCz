#!/usr/bin/python3

pesel = input('Podaj pesel:')

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

def get_sex(p):
	plec = int(p[9]) % 2
	if plec == 0:
		return 'Kobieta'
	else:
		return 'Mezczyzna'
		
def get_year(p):
	if p[2] in ['8','9']:
		return "18"
	elif p[2] in ['0','1']:
		return "19"
	elif p[2] in ['2','3']:
		return "20"
	elif p[2] in ['4','5']:
		return "21"
	elif p[2] in ['6','7']:
		return "22"
		
def get_month(p):
	if int(p[2]) % 2 == 1: 
		return "1" + p[3]
	else:
		return "0" + p[3]

def get_bdate(p):
	year = get_year(p) + p[0] + p[1]
	month = get_month(p)
	return year + '-' + month + '-' + p[4] + p[5]
					
if check_pesel(pesel):
	print("Nr pesel jest poprawny")
	sex = get_sex(pesel)
	bdate = get_bdate(pesel)
	print("Plec: ", sex)
	print("Data urodzenia: ", bdate)
else:
	print("Nr pesel jest niepoprawny")



	
