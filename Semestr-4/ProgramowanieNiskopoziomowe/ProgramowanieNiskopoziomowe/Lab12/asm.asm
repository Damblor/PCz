.CODE

PUBLIC sortint
sortint PROC uses rsi rdi, tab:ptr, n:qword

xor rax, rax;
	mov r9, tab;
	petlad:

		xor rax, rax;
		mov r8, n;
		dec r8;
		petlaf:
			mov rsi, qword ptr[r9 + 4*r8 - 4]
			mov rdi, qword ptr[r9 + 4*r8 - 8]

			cmp rsi, rdi
			jle pomin;

			mov qword ptr[r9 + 4*r8 - 4], rdi;
			mov qword ptr[r9 + 4*r8 - 8], rsi;
			inc rax;
			pomin:
		dec r8;
		jnz petlaf;
		



	cmp rax, 0
	jg petlad;
	ret;

sortint ENDP


END