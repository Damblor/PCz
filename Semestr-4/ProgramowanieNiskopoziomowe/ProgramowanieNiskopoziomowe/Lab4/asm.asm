.CODE

PUBLIC pole1
pole1 PROC
	mov rax, 0
petla:
	movsxd r8, dword ptr [rcx+4*rdx-4]
	imul r8, r8
	add rax, r8
	dec rdx
	jnz petla
	ret
pole1 ENDP

PUBLIC suma
suma PROC
petla:
	mov eax, [rdx+4*r8-4]
	add [rcx+4*r8-4], eax
	dec r8
	jnz petla
	ret
suma ENDP

PUBLIC skalarny
skalarny PROC
	xor eax, eax
petla:
	mov r9d, [rcx+4*r8-4]
	imul r9d,[rdx+4*r8-4]
	add eax, r9d
	dec r8
	jnz petla
	movsxd rax, eax
	ret
skalarny ENDP

PUBLIC zad1
zad1 PROC
petla:
	mov eax, [rcx+4*rdx-4]
	imul eax,[rcx+4*rdx-4]
	mov [rcx+4*rdx-4], eax
	dec edx
	jnz petla
	ret
zad1 ENDP

PUBLIC zad2
zad2 PROC
petla:
	mov r8d, dword ptr [rcx+4*rdx-4]
	test r8d, 1
	jnz dalej
	imul r8d,r8d
	mov dword ptr [rcx+4*rdx-4], r8d
dalej:
	dec edx
	jnz petla
	ret
zad2 ENDP

PUBLIC zad3
zad3 PROC
petla:
	test rdx, 1
	jnz dalej
	mov dword ptr [rcx+4*rdx-4], 0
dalej:
	dec rdx
	jnz petla
	ret
zad3 ENDP

END