.CODE

PUBLIC pierwiastek32
pierwiastek32 PROC
	push rcx
	push rbx
	mov ebx, eax
	mov ecx, 32768
	xor rax, rax
sqrt_loop:
	xor rax, rcx
	push rax
	mul eax
	cmp eax, ebx
	pop rax
	jbe keep_bit
	xor eax, ecx
	keep_bit:
	shr ecx, 1
	jnz sqrt_loop
	pop rbx
	pop rcx
	ret
pierwiastek32 ENDP

PUBLIC pierwiastek64
pierwiastek64 proc
	push rcx
	push rbx
	mov rbx, rax
	mov rcx, 2147483648
	xor rax, rax
sqrt_loop:
	xor rax, rcx
	push rax
	mul rax
	cmp rax, rbx
	pop rax
	jbe keep_bit
	xor rax, rcx
keep_bit:
	shr rcx, 1
	jnz sqrt_loop
	pop rbx
	pop rcx
	ret
pierwiastek64 endp

PUBLIC dlugosc32
dlugosc32 proc
	push rsi
	push rdi
	push rbx
	mov rdi, rcx
	mov rbx, rdx
p1: 
	mov rsi, [rdi + 8*r8 - 8]
	mov r10, r9
p2: 
	movsxd rax, dword ptr[rsi + 4*r10 - 4]
	imul rax, rax
	movsxd rcx, dword ptr[rbx + 4*r10 - 4]
	imul rcx, rcx
	add rax, rcx
	call pierwiastek64
	mov dword ptr[rsi + 4*r10 - 4], eax
	dec r10
	jnz p2
	dec r8
	jnz p1
	pop rbx
	pop rdi
	pop rsi
	ret
dlugosc32 endp

PUBLIC dlugosc
dlugosc proc
	push rsi
	push rdi
	push rbx
	mov rdi, rcx
	mov rbx, rdx
p1: 
	mov rsi, [rdi + 8*r8 - 8]
	mov r10, r9
p2: 
	movsxd rax, dword ptr[rsi + 4*r10 - 4]
	movsxd rcx, dword ptr[rbx + 4*r10 - 4]
	call pitagoras
	mov dword ptr[rsi + 4*r10 - 4], eax
	dec r10
	jnz p2
	dec r8
	jnz p1
	pop rbx
	pop rdi
	pop rsi
	ret
dlugosc endp

PUBLIC pitagoras
pitagoras proc
	imul rax, rax
	imul rcx, rcx
	add rax, rcx
	call pierwiastek64
	ret
pitagoras endp

PUBLIC pierwiastek
pierwiastek proc
	xor rax, rax
	bsr rdx, rcx
	jz koniec
	xor r8, r8
	shr rdx, 1
	bts r8, rdx
@@:
	mov r9, rax
	xor rax, r8
	mov rdx, rax
	imul rdx, rdx
	cmp rdx, rcx
	jz koniec
	cmovg rax, r9
	shr r8, 1
	jnz @B

	mov rdx, rax
	imul rdx, rdx
	sub rcx, rdx
	cmp rax, rcx
	adc rax, 0

koniec:
	ret
pierwiastek endp

END