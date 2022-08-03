.CODE

PUBLIC suma32
suma32 PROC
	push rsi
	xor rax, rax
petlaM:
	mov rsi, [rcx + 8*rdx - 8]
	mov r10, r8
petlaN:
	movsxd r11, dword ptr[rsi + 4*r10 - 4]
	add rax, r11
	dec r10
	jnz petlaN
	dec rdx
	jnz petlaM

	pop rsi
	ret
suma32 ENDP

PUBLIC suma64 
suma64 PROC uses rsi
	xor rax, rax
petlaM:
	mov rsi, [rcx + 8*rdx - 8]
	mov r10, r8
petlaN:
	add rax, [rsi + 8*r10 - 8]
	dec r10
	jnz petlaN
	dec rdx
	jnz petlaM

	ret
suma64 ENDP

PUBLIC uemxv 
uemxv PROC uses rbx rsi, mm:ptr, v:ptr, u:ptr, m:qword, n:qword
	mov r11, n
petlaM:
	mov rsi, [rcx + 8*r9 - 8]
	mov rbx, r11
	xor r10, r10
petlaN:
	mov rax, [rsi + 8*rbx - 8]
	imul rax, [rdx + 8*rbx - 8]

	add r10, rax
	dec rbx
	jnz petlaN

	mov [r8 + 8*r9 - 8], r10
	dec r9
	jnz petlaM

	ret
uemxv ENDP

PUBLIC minM3 
minM3 PROC uses rsi rdi
	mov rdi, [rcx]
	mov rsi, [rdi]
	mov rax, [rsi]
petlaM:
	mov rdi, [rcx + 8*rdx - 8]
	mov r10, r8
petlaN:
	mov rsi, [rdi + 8*r10 - 8]
	mov r11, r9
petlaK:
	cmp rax, [rsi + 8*r11 - 8]
	cmovg rax, [rsi + 8*r11 - 8]

	dec r11
	jnz petlaK
	dec r10
	jnz petlaN
	dec rdx
	jnz petlaM

	ret
minM3 ENDP

PUBLIC iloczynMeUxV 
iloczynMeUxV PROC uses rbx rsi rdi, mm:ptr, uu:ptr, vv:ptr, w:qword, k:qword, n:qword

petlaW:
	mov rsi, [rdx + 8*r9 - 8]
	mov rdi, [rcx + 8*r9 - 8]
	mov r10, k
petlaK:
	mov rax, 0
	mov r11, n
petlaN:
	mov rbx, [r8 + 8*r11 - 8]
	mov rbx, [rbx + 8*r10 - 8]
	imul rbx, [rsi + 8*r11 - 8]
	add rax, rbx
	dec r11
	jnz petlaN

	mov [rdi +8*r10 - 8], rax
	dec r10
	jnz petlaK
	dec r9
	jnz petlaW

	ret
iloczynMeUxV ENDP

END