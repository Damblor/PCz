.CODE

szescian PROC
	mov eax, ecx
	imul eax
	imul ecx
	ret
szescian ENDP

kwadratowe PROC
	mov eax, r8d
	
	imul ecx, r9d
	imul ecx, r9d

	imul edx, r9d

	add eax, edx
	add eax, ecx
	

	ret
kwadratowe ENDP

zamiana PROC
	mov eax, ecx
	bswap eax
	ret
zamiana ENDP

END