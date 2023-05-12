#!/usr/bin/python3

import csv, sys, xml.etree.ElementTree as ET

class Osoba:
	def __init__(self, nr, email, rok, imie):
		self.nr = nr
		self.email = email
		self.rok = rok
		self.imie = imie
	def wypisz(self):
		print('Nr: ', self.nr)
		print('Email: ', self.email)
		print('Rok: ', self.rok)
		print('Imie: ', self.imie)
		print('========================')

class Osoby:
	def __init__(self, listaOsob):
		self.listaOsob = listaOsob
	def wypisz(self):
		for osoba in self.listaOsob:
			osoba.wypisz()
			
	def sort(self, key=lambda o: o.nr):
		self.listaOsob.sort(key=key)
		
	def index(self, p):
		return next((i for i in range(len(self.listaOsob)) if p(self.listaOsob[i])), None)
	
	def find(self, p):
		return self.listaOsob[self.index(p)]
		
	def add(self, nr, email, rok, imie):
		self.listaOsob.append(Osoba(int(nr),email,int(rok),imie))
		

class FileIO:
	def wczytajDane(plik):
		dane = list(csv.reader(open(plik), delimiter=';'))
		listaOsob = []
		for osoba in dane:
			listaOsob.append(Osoba(int(osoba[0]),osoba[1],int(osoba[2]),osoba[3]))
		return listaOsob
	def save_file_as_csv(osoby, plik):
		writer = csv.writer(open(plik, 'w'), delimiter=';')
		for o in osoby.listaOsob:
			writer.writerow([o.nr,o.email,o.rok,o.imie])
			
	def save_file_as_xml(osoby, plik):
		data = ET.Element('osoby')
		for o in osoby.listaOsob:
			so = ET.SubElement(data, 'osoba')
			ET.SubElement(so, 'nr').text = str(o.nr)
			ET.SubElement(so, 'email').text = o.email
			ET.SubElement(so, 'rok').text = str(o.rok)
			ET.SubElement(so, 'imie').text = o.imie
		o_xml = ET.tostring(data)
		with open(plik, "wb") as p:
			p.write(o_xml)
		
		
#Read data	
try:
	osoby = Osoby(FileIO.wczytajDane(sys.argv[1]))
except ex:
	print('Exception: ', ex)
	
#Sort data
try:
	osoby.sort(key=lambda o: o.imie)
except ex:
	print('Exception: ', ex)

osoby.wypisz()

#Find data
print('\n-------------Search-------------')
try:
	osoba = osoby.find(lambda o: o.imie == "Olga" and o.nr == 766892)
except ex:
	print('Exception: ', ex)

osoba.wypisz()

#Add data
print('\n-------------Add-------------')
try:
	osoby.add(1337,"marta@example.com",1892,"Marta")
except ex:
	print('Exception: ', ex)

osoby.wypisz()

#Save data as CSV
try:
	FileIO.save_file_as_csv(osoby, f"new_csv_{sys.argv[1]}")
except ex:
	print('Exception: ', ex)

#Save data as XML
try:
	FileIO.save_file_as_xml(osoby, f"new_xml_{sys.argv[1]}")
except ex:
	print('Exception: ', ex)
