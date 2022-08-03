.CODE

PUBLIC kwadrat
kwadrat PROC uses rbx rsi rdi, a:qword, b:qword, c:qword, x1:ptr, x2:ptr

	fld b;//b
	fld st;//b,b
	fmul;//b^2
	fld a;//a,b^2
	fmul c;//ca,b^2
	fadd st, st;//2ca,b^2
	fadd st, st;//4ca,b^2
	fsub;//b^2 - 4ca
	ftst;
	fstsw ax;
	sahf;
	xor rax, rax;

	jz rowne;
	jc mniejsze;

		fldz;//0, b^2 - 4ca
		fsub b;//0-b, b^2 - 4ca
		fld a;//a,0-b, b^2 - 4ca
		fadd st,st;//2a, 0-b, b^2 - 4ca
		fdiv;//0-b / 2a, b^2 - 4ca
		mov r10, x2;
		fst qword ptr[r9];
		fstp qword ptr[r10];
		mov rax, 2;
		ret;
	
		mov rax, 0;
		ret;
	rowne:
		fld b;//b
		fld st;//b,b
		fmul;//b^2
		fld a;//a,b^2
		fmul c;//ca,b^2
		fadd st, st;//2ca,b^2
		fadd st, st;//4ca,b^2
		fsub;//b^2 - 4ca

		fld b;//0, b^2 - 4ca
		mov r10, x2;
		fst qword ptr[r9];
		fstp qword ptr[r10];
		mov rax, 1;
		ret;
	mniejsze:
		mov rax, 0;
		ret;
kwadrat ENDP

PUBLIC summw
summw PROC uses rbx rsi rdi, mm:ptr, uu:ptr, vv:ptr, m:qword, n:qword
	mov r11,n
petlaM:
	mov rdi, [rcx + 8*r9 - 8]
	mov rsi, [rdx + 8*r9 - 8]
	mov rbx, [r8 + 8*r9 - 8]
	mov r10, r11
petlaN:
	fld qword ptr[rsi + 8*r10 - 8]
	fadd qword ptr[rbx + 8*r10 - 8]
	fstp qword ptr[rdi + 8*r10 - 8]
	dec r10
	jnz petlaN
	dec r9
	jnz petlaM
	ret
summw ENDP

PUBLIC mulmw
mulmw PROC uses rbx rsi rdi, mm:ptr, uu:ptr, vv:ptr, w:qword, k:qword, n:qword
petlaw:
	mov rsi, [rdx + 8*r9 - 8]
	mov rdi, [rcx + 8*r9 - 8]
	mov r10, k
petlak:
	mov rax, 0
	mov r11, n
	fldz
petlan:
	mov rbx, [r8 + 8*r11 - 8] ;nty wiersz
	fld dword ptr[rbx + 4*r10 - 4] ;kta kolumna
	fmul dword ptr[rsi + 4*r11 - 4] ;x nty element wtego wiersza
	fadd
	dec r11
	jnz petlan
	fstp dword ptr[rdi + 4 * r10 -4]
	dec r10 ;k
	jnz petlak
	dec r9 ;w
	jnz petlaw
	ret
mulmw endp

END