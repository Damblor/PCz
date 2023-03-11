.CODE

Ify1 proc uses rsi rdi, tab1:ptr, tab2:ptr, tab3:ptr, n:dword, m:dword, x:qword
	local m1:qword
	mov m1, -1;
	movsxd r11, m;
	vbroadcastsd ymm0, x;
	vbroadcastsd ymm5, m1;
	petlaN:
		mov rsi, [rcx+8*r9-8];
		mov rdi, [rdx+8*r9-8];
		mov rax, [r8+8*r9-8];
		mov r10, r11;
		sal r10, 3;
		petlaM:
			sub r10, 32; -32
			vmovupd ymm1, ymmword ptr[rsi + r10];
			vmovupd ymm2, ymmword ptr[rdi + r10];
			vcmpgtpd ymm3, ymm1, ymm2;
			vpxor ymm4, ymm3, ymm5;
			vandpd ymm1, ymm1, ymm3;
			vandpd ymm2, ymm2, ymm4;
			vaddpd ymm3, ymm1, ymm2;
			vmulpd ymm3, ymm3, ymm0;
			vmovupd ymmword ptr[rsi + r10], ymm1;
			vmovupd ymmword ptr[rdi + r10], ymm2;
			vmovupd ymmword ptr[rax + r10], ymm3;
		jns petlaM;
		dec r9;
	jnz petlaN;
	ret;
Ify1 endp

END