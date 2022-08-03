#include<iostream>

using namespace std;

void addBDC(char* numberIN1, char* numberIN2, char* numberOUT, int s)
{
	__asm {
		push ebx
		mov ecx, s
		mov esi, numberIN1
		mov edi, numberIN2
		mov ebx, numberOUT
		clc
	petla:
		mov al, [esi + ecx - 1]
		adc al, [edi + ecx - 1]
		aaa
		mov[ebx + ecx - 1], al
		dec ecx
		jnz petla
		pop ebx
	}
}

void subBDC(char* numberIN1, char* numberIN2, char* numberOUT, int s)
{
	__asm {
		push ebx
		mov ecx, s
		mov esi, numberIN1
		mov edi, numberIN2
		mov ebx, numberOUT
		clc
	petla:
		mov al, [esi + ecx - 1]
		sbb al, [edi + ecx - 1]
		aas
		mov[ebx + ecx - 1], al
		dec ecx
		jnz petla
		pop ebx
	}
}

void mulBCD(char* a, char* b, int n, int m, char* w) {
	__asm {
		pushad
		pushf
		mov ecx, m 
		mov edi, b 
		add edi, ecx
		mov edx, w
		add edx, ecx
	po_m:
		push ecx 
		dec edx 
		dec edi 
		mov bl, [edi] 
		mov ecx, n 
		mov esi, a 
	iloczyn:
		mov al, [esi] 
		mul bl 
		aam 
		push ax
		inc esi
		loop iloczyn
		mov ecx, n
		pop ax
		add al, [edx + ecx] 
		aaa 
		mov[edx + ecx], al
		dec ecx
		jz one_n 
	SumaBCD:
		mov bl, ah 
		pop ax 
		add al, [edx + ecx] 
		aaa
		add al, bl 
		aaa
		mov[edx + ecx], al 
		loop SumaBCD
	one_n:
		mov[edx], ah 
		pop ecx 
		loop po_m
		popf
		popad
	}
}

void dot(char* number, int d, int max, int l)
{
	for (int i = d; i < max - 1; i++)
	{
		number[i] = number[i + 1];
	}

	for (int i = 0; i < max - l - 2; i++)
	{
		number[i] = number[i + l];
	}

	/*for (int i = max - 1; i > d - l + 2; i--)
	{
		number[i] = '0';
	}*/
}

int main()
{
	int maxSize = 30;
	int actualSize1 = 0;
	int actualSize2 = 0;
	int actualSizeOUT = 0;
	int actualSizeOUT_ = 0;
	char* numberIN1 = new char[maxSize];
	char* numberIN2 = new char[maxSize];
	char* numberIN1_ = new char[maxSize];
	char* numberIN2_ = new char[maxSize];
	char* numberOUT = new char[maxSize];
	char* numberOUT_ = new char[maxSize];

	int dot1 = 0;
	int dot2 = 0;

	char c;
	puts("Podaj liczbe 1:");
	do {
		c = (char)getchar();
		numberIN1[actualSize1] = c;
		numberIN1_[actualSize1] = c;
		actualSize1++;
	} while (!((c == '\n') || (actualSize1 >= maxSize)));
	actualSize1--;
	for (int i = maxSize - 1, j = 0; i >= 0; --i, ++j)
	{
		if (j < actualSize1)
			numberIN1[i] = numberIN1[actualSize1 - j - 1];
		else
			numberIN1[i] = '0';
	}
	puts("Podaj liczbe 2:");
	do {
		c = (char)getchar();
		numberIN2[actualSize2] = c;
		numberIN2_[actualSize2] = c;
		actualSize2++;
	} while (!((c == '\n') || (actualSize2 >= maxSize)));
	actualSize2--;
	for (int i = maxSize - 1, j = 0; i >= 0; --i, ++j)
	{
		if (j < actualSize2)
			numberIN2[i] = numberIN2[actualSize2 - j - 1];
		else
			numberIN2[i] = '0';
	}

	for (int i = 0; i < maxSize; i++)
	{
		if (numberIN1[i] == '.')
			dot1 = i;
	}

	for (int i = 0; i < maxSize; i++)
	{
		if (numberIN2[i] == '.')
			dot2 = i;
	}

	cout << numberIN1 << endl;

	dot(numberIN1, dot1, maxSize, 5);
	cout << numberIN1 << endl;

	if (dot1 < dot2)
	{

	}
	else if (dot1 > dot2)
	{
		
	}
	else
	{

	}
	

	printf("\nPierwsza liczba do dodawania/odejmowania to: %.*s\n", maxSize, numberIN1);
	printf("Druga liczba do dodawania/odejmowania to: %.*s\n", maxSize, numberIN2);
	printf("\nPierwsza liczba do mnozenia to: %.*s\n", actualSize1, numberIN1_);
	printf("Druga liczba do mnozenia to: %.*s\n", actualSize2, numberIN2_);
	for (int i = 0; i < maxSize; ++i) numberIN1[i] &= 15;
	for (int i = 0; i < maxSize; ++i) numberIN2[i] &= 15;
	for (int i = 0; i < maxSize; ++i) numberIN1_[i] &= 15;
	for (int i = 0; i < maxSize; ++i) numberIN2_[i] &= 15;
	for (int i = 0; i < maxSize; ++i) numberOUT[i] = '0';
	for (int i = 0; i < maxSize; ++i) numberOUT_[i] = '0';
	addBDC(numberIN1, numberIN2, numberOUT, maxSize);
	mulBCD(numberIN1_, numberIN2_, actualSize1, actualSize2, numberOUT_);
	for (int i = 0; i < maxSize; ++i) numberOUT[i] |= 48;
	for (int i = 0; i < maxSize; ++i) numberOUT_[i] |= 48;
	printf("\nWynikowa liczba z dodawania/odejmowania to: %.*s\n", maxSize, numberOUT);
	printf("Wynikowa liczba z mnozenia to: %.*s\n", maxSize, numberOUT_);
	for (int i = 0; i < maxSize; ++i, actualSizeOUT++) if ((char)numberOUT[i] != '0') break;

	for (int i = 0; i < maxSize; ++i)
	{
		if (i + actualSizeOUT < maxSize)
			numberOUT[i] = numberOUT[i + actualSizeOUT];
		else
			numberOUT[i] = ' ';
	}
	actualSizeOUT = maxSize - actualSizeOUT;
	actualSizeOUT_ = actualSize1 + actualSize2;
	if (numberOUT_[0] == '0')
	{
		for (int i = 0; i < maxSize; ++i)
		{
			if (i + 1 < maxSize)
				numberOUT_[i] = numberOUT_[i + 1];
			else
				numberOUT_[i] = ' ';
		}
		actualSizeOUT_--;
	}
	printf("\nWynik dodawania/odejmowania to: %.*s", actualSizeOUT, numberOUT);
	printf("\nWynik mnozenia to: %.*s\n\n", actualSizeOUT_, numberOUT_);
	delete[] numberIN1;
	delete[] numberIN2;
	delete[] numberOUT;
	delete[] numberOUT_;

}