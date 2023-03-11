.CODE

PUBLIC if_1
if_1 PROC
	xor rax, rax
	movsxd rcx, ecx
	movsxd rdx, edx
	cmp rcx, rdx
	jnl skok
	mov rax, rdx
	sub rax, rcx
skok:
	ret
if_1 ENDP

PUBLIC if_1_better
if_1_better PROC
	xor rax, rax
	movsxd rcx, ecx
	movsxd rdx, edx
	sub rdx, rcx
	cmovg rax, rdx
	ret
if_1_better ENDP

PUBLIC if_2
if_2 PROC
	movsxd rcx, ecx
	movsxd rdx, edx
	cmp rcx, rdx
	jl true
	jmp false
true:
	mov rax, rdx
	sub rax, rcx
	ret
false:
	mov rax, rcx
	sub rax, rdx
	ret
if_2 ENDP

PUBLIC if_2_better
if_2_better PROC
	movsxd rcx, ecx
	movsxd rdx, edx
	mov rax, rcx
	sub rax, rdx
	sub rdx, rcx
	cmovg rax, rdx
	ret
if_2_better ENDP

PUBLIC if_3
if_3 PROC
	xor rax, rax
	movsxd rcx, ecx
	movsxd rdx, edx
	cmp rcx, rdx
	jge false
	mov rax, rdx
	imul rax, rdx
	sub rax, rcx
false:
	ret
if_3 ENDP

PUBLIC if_3_better
if_3_better PROC
	xor rax, rax
	movsxd rcx, ecx
	movsxd rdx, edx

	mov rbx, rdx
	imul rbx, rdx
	sub rbx, rcx

	cmp rdx, rcx
	cmovg rax, rbx

	ret
if_3_better ENDP

PUBLIC if_4
if_4 PROC
	xor rax, rax
	movsxd rcx, ecx
	movsxd rdx, edx
	cmp rcx, rdx
	jl true
	jmp false
true:
	mov rax,rcx
	imul rax, rcx
	add rax, rdx
	ret
false:
	mov rax,rcx
	imul rax, rcx
	sub rax, rdx
	ret
if_4 ENDP


PUBLIC if_4_better
if_4_better PROC
	xor rax, rax
	movsxd rcx, ecx
	movsxd rdx, edx

	mov rax, rcx
	imul rax, rcx
	sub rax, rdx

	mov rbx, rcx
	imul rbx, rcx
	add rbx, rdx

	cmp rdx, rcx
	cmovg rax, rbx

	ret

if_4_better ENDP

PUBLIC case_1
case_1 PROC
	cmp edx, 3
	je case3
	cmp edx, 5
	je case5
	cmp edx, 7
	je case7
	jmp default
case3:
	mov eax, ecx
	add eax, 7
	jmp exit
case5:
	mov eax, ecx
	sub eax, 7
	imul eax, ecx
	jmp exit
case7:
	mov eax, ecx
	imul eax, ecx
	jmp exit
default:
	xor eax, eax
exit:
	ret
case_1 ENDP

PUBLIC case_2
case_2 PROC
	cmp edx, 0
	je case0
	cmp edx, 1
	je case1
	cmp edx, 2
	je case2
	cmp edx, 3
	je case3
	jmp default
case0:
	mov eax, ecx
	add eax, 7
	jmp exit
case1:
	mov eax, ecx
	add eax, 3
	imul eax, ecx
	jmp exit
case2:
	mov eax, ecx
	imul eax, 2
	mov ebx, ecx
	imul ebx, ecx
	add eax, ebx
	jmp exit
case3:
	mov eax, ecx
	imul eax, ecx
	sub eax, 12
	jmp exit
default:
	xor eax, eax
exit:
	ret
case_2 ENDP

PUBLIC suma
suma PROC
	xor eax, eax
petla:
	add eax, ecx
	dec ecx
	jnz petla
	ret
suma ENDP

PUBLIC suma_better
suma_better PROC
	xor eax, eax
petla:
	add eax, ecx
	loop petla
	ret
suma_better ENDP

PUBLIC silnia
silnia PROC
	mov eax, 1
	cmp ecx, 0
	jne petla
	ret
petla:
	imul eax, ecx
	dec ecx
	jnz petla
	ret
silnia ENDP

PUBLIC suma_2
suma_2 PROC
	xor eax, eax
petla:
	add eax, ecx
	inc ecx
	cmp ecx, edx
	jle petla
	ret
suma_2 ENDP

END