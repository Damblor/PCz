.CODE

if_1 PROC
	xor eax, eax;
	cmp edx, ecx;
	jg skokjprawda;
skokjprawda:
	mov eax, edx;
	sub eax, ecx;
	ret;
if_1 ENDP

if_2 PROC
	xor eax, eax;
	cmp edx, ecx;
	jg skokjprawda;
	jmp pomin;
skokjprawda:
	mov eax, edx;
	sub eax, ecx;
	ret;
pomin:
	mov eax, edx;
	sub eax, ecx;
	ret;
if_2 ENDP

if_3 PROC
	xor eax, eax;
	cmp edx, ecx;
	jg skokjprawda;
skokjprawda:
	mov eax, edx;
	imul eax;
	sub eax, ecx;
	ret;
if_3 ENDP

if_4 PROC
	xor eax, eax;
	cmp edx, ecx;
	jg prawda;
	jmp pomin;
prawda:
	mov eax, ecx;
	imul eax, eax;
	add eax, edx;
	ret;
pomin:
	mov eax, ecx;
	imul eax, eax;
	sub eax, edx;
	ret;
if_4 ENDP

case_1 PROC
	mov eax, edx;
	cmp eax, 3;
	je case3;
	cmp eax, 5;
	je case5;
	cmp eax, 7;
	je case7;
	jmp default;
exit:
	ret;
case3:
	mov eax, ecx;
	add eax, 7;
	jmp exit;
case5:
	mov eax, ecx;
	sub eax, 7;
	imul eax, ecx;
	jmp exit;
case7:
	mov eax, ecx;
	imul eax, eax;
	jmp exit;
default:
	xor eax, eax;
	jmp exit;
case_1 ENDP

case_2 PROC
	mov eax, edx;
	cmp eax, 0;
	je case0;
	cmp eax, 1;
	je case1;
	cmp eax, 2;
	je case2;
	cmp eax, 3;
	je case3;
	jmp default;
exit:
	ret;
case0:
	mov eax, ecx;
	add eax, 7;
	jmp exit;
case1:
	mov eax, ecx;
	add eax, 3;
	imul eax, ecx;
	jmp exit;
case2:
	mov eax, ecx;
	imul eax, 2
	imul ecx, ecx;
	add eax, ecx;
	jmp exit;
case3:
	mov eax, ecx;
	imul eax, eax;
	sub eax, 12;
	jmp exit;
default:
	xor eax, eax;
	jmp exit;
case_2 ENDP

for_1 PROC
	xor eax, eax;
	xor ebx, ebx;
	cmp ecx, ebx;
	jl pomin;
petla:
	mov edx, ebx;
	imul edx, 2;
	add eax, edx;
	inc ebx;
	cmp ecx, ebx;
	jg petla;
	ret;
pomin:
	ret;
for_1 ENDP

silnia_1 PROC
	mov eax, 1;
	mov ebx, 1;
	cmp ecx, ebx;
	jl pomin;
petla:
	imul eax, ebx;
	inc ebx;
	cmp ecx, ebx;
	jge petla;
	ret;
pomin:
	ret;
silnia_1 ENDP

while_1 PROC
	xor eax, eax;
	xor ebx, ebx;
	mov eax, ecx;
	mov ebx, ecx;
	add ebx, edx;
	cmp ebx, r8d
	jge pomin;
petla:
	add eax, ebx;
	add ebx, edx;
	cmp ebx, r8d;
	jl petla;
	ret;
pomin:
	ret;
while_1 ENDP

silnia_2 PROC
	mov eax, 1;
	xor ebx, ebx;
	cmp ebx, ecx;
	jge pomin;
petla:
	inc ebx;
	imul eax, ebx;
	cmp ebx, ecx;
	jl petla;
	ret;
pomin:
	ret;
silnia_2 ENDP

zad_1 PROC
	xor eax, eax;
	cmp ecx, edx;
	jge prawda;
	ret;
prawda:
	mov eax, 10;
	ret;
zad_1 ENDP

zad_2 PROC
	xor eax, eax;
	cmp ecx, edx;
	jne prawda;
	ret;
prawda:
	mov eax, edx;
	imul eax, ecx
	ret;
zad_2 ENDP

zad_3 PROC
	xor rax, rax;
	cmp rcx, 0;
	jne prawdaa;
	cmp rdx, 0;
	jne prawdab;
	ret;

prawdaa:
	mov rax, rdx;
	xor rdx, rdx;
	idiv rcx;
	ret;
prawdab:
	mov rax, rcx;
	mov rbx, rdx;
	xor rdx, rdx;
	idiv rbx;
	ret;
zad_3 ENDP

zad_4 PROC

zad_4 ENDP

zad_5 PROC

zad_5 ENDP

zad_6 PROC
	xor rax, rax;
	mov rbx, rcx;
	cmp rcx, 0
	jle pomin;
petla:
	add rax, rbx;
	dec rcx;
	cmp rcx, 0;
	jg petla;
pomin:
	ret;
zad_6 ENDP

zad_7 PROC

zad_7 ENDP

zad_8 PROC

zad_8 ENDP

END