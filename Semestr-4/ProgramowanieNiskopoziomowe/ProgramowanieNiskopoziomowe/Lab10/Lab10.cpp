#include <iostream>

using namespace std;

double zad1(double a, double b, double c, double d, double x)
{
	double wynik;

	__asm
	{
		jmp dalej

	dxtoy:
		fyl2x;
		fld st; //p, p
		frndint; //c, p
		fsub st(1), st; //c, m
		fxch; //m, c
		f2xm1; //2^m -1, c
		fld1; //1, 2^m -1, c
		fadd; //2^m, c
		fscale; //2^c * 2^m, c
		fstp st(1); //2^p
		ret;

	dalej:
		fld x; //x
		fld c; //c, x
		fmul; // cx
		fld d; // d, cx
		fadd; //cx + d

		fld c; //c, cx + d
		fld x; //x, c, cx + d
		call dxtoy; //x^c, cx + d
		fld b;//b, x^c, cx + d
		fmul;//b(x^c), cx + d

		fld b;//b, b(x^c), cx + d
		fld x;//x, b, b(x^c), cx + d
		call dxtoy; //(x^b), b(x^c), cx + d
		fld a;//a, (x^b), b(x^c), cx + d
		fmul; //a(x^b), b(x^c), cx + d

		fxch;//b(x^c), a(x^b), cx + d
		fsub;//a(x^b) - b(x^c), cx + d
		fadd;//a(x^b) - b(x^c) + cx + d

		fstp wynik;
	}

	return wynik;
}

void zad2(double* x, double* y, int k, double a, double b, double p1, double p2, double xmin, double xmax)
{
	double buf = 180;
	__asm
	{

		mov esi, x;
		mov edi, y;
		mov ecx, k;

		fld xmin;//xmin
		fld xmax;//xmax, xmin
		fsubrp st(1), st;//xmax - xmin
		fild k; //k, xmax - xmin
		fld1;
		fsub;
		fdivp st(1), st; //(xmax - xmin) /k - 1 = krok

		fld b;//b, krok
		fld p1;//p1, b, krok
		fld p2;//p2, p1, b, krok
		fld buf;//buf, p2, p1, b, krok
		fld xmax;//x, buf, p2, p1, b, krok
	loopko:
		fldpi;//pi,x, buf, p2, p1, b, krok
		fmul st, st(3);//pi * p2, x, buf, p2, p1, b, krok
		fmul st, st(1);//pi * p2 * x, x, buf, p2, p1, b, krok
		fdiv st, st(2);//(pi * p2 * x)/buf, x, buf, p2, p1, b, krok
		fcos;//cos((pi * p2 * x)/buf), x, buf, p2, p1, b, krok
		fmul st, st(5);//b * cos((pi * p2 * x)/buf), x, buf, p2, p1, b, krok

		fldpi;//pi, b * cos((pi * p2 * x)/buf), x, buf, p2, p1, b, krok
		fmul st, st(5);//pi * p1, b * cos((pi * p2 * x)/buf), x, buf, p2, p1, b, krok
		fmul st, st(2);//pi * p1 * x, b * cos((pi * p2 * x)/buf), x, buf, p2, p1, b, krok
		fdiv st, st(3);//(pi * p1 * x)/buf, b * cos((pi * p2 * x)/buf), x, buf, p2, p1, b, krok
		fsin;//sin((pi * p1 * x)/buf), b * cos((pi * p2 * x)/buf), x, buf, p2, p1, b, krok
		fmul a;//a * sin((pi * p1 * x)/buf), b * cos((pi * p2 * x)/buf), x, buf, p2, p1, b, krok

		fadd;//a * sin((pi * p1 * x)/buf) + b * cos((pi * p2 * x)/buf), x, buf, p2, p1, b, krok
		fstp qword ptr[edi + 8 * ecx - 8]; //a * sin((pi * p1 * x)/buf) + b * cos((pi * p2 * x)/buf) => y[i], x, buf, p2, p1, b, krok
		fst qword ptr[esi + 8 * ecx - 8];//x => x[i], buf, p2, p1, b, krok
		fsub st, st(5);//x - krok, buf, p2, p1, b, krok

		dec ecx;
		jnz loopko;

		//x, buf, p2, p1, b, krok
	}
}

int main()
{
	int k = 8;
	double* x = new double[k];
	double* y = new double[k];

	double a = 4;
	double b = 5;
	double p1 = 2;
	double p2 = 3;
	double xmin = 7;
	double xmax = 13;
	//cout << zad1(1.0, 1.0, 3.5, 1.0, 2.0) << endl;

	zad2(x, y, k, a, b, p1, p2, xmin, xmax);
	for (int i = 0; i < k; i++)
	{
		cout << x[i] << " = " << y[i] << endl;
	}
}
