#!/usr/bin/python3
import sys

if len(sys.argv) < 3:
	print("Podaj nazwe pliku tekstowego wejscowego i wyjsciowego")
	sys.exit(1)

w = b'\r\n'
u = b'\n'

with open(sys.argv[1], 'rb') as open_file:
    content = open_file.read()
    
content = content.replace(w, u)


with open(sys.argv[2], 'wb') as open_file:
    open_file.write(content)
