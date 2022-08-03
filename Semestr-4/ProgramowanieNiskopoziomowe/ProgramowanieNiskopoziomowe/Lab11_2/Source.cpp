#include <iostream>
#include <chrono>

using namespace std;

int kwadrat(double a, double b, double c, double* x1, double* x2)
{
    int wynik = 0;
    __asm
    {
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



		jz rowne;
		jc mniejsze;
		fldz;//0,delta
		fld b;//b,0,delta
		fsub;//-b,delta
		fld st;//-b,-b,delta
		fsub st, st(2);//-b-delta,-b,delta
		fld a;//a,-b-delta,-b,delta
		fld st;//a,a,-b-delta,-b,delta
		fadd;//2a,-b-delta,-b,delta
		fdiv;
		mov ecx, x1;
		fstp qword ptr[ecx];


		fadd st, st(1);//-b-delta,-b,delta
		fld a;//a,-b-delta,-b,delta
		fld st;//a,a,-b-delta,-b,delta
		fadd;//2a,-b-delta,-b,delta
		fdiv;
		mov ecx, x2;
		fstp qword ptr[ecx];


		mov wynik, 2;
		jmp koniec;
	rowne:
		fldz;//0,delta
		fld b;//b,0,delta
		fsub;//-b,delta
		fld a;
		fld st;
		fadd;
		fdiv;
		mov ecx, x1;
		fst qword ptr[ecx];
		mov ecx, x2;
		fstp qword ptr[ecx];
		mov wynik, 1;
		jmp koniec;
	mniejsze:


		fldz;//0,delta
		fld b;//b,0,delta
		fsub;//-b,delta
		fld a;
		fld st;
		fadd;
		fdiv;//-b/2a,delta
		mov ecx, x1;
		fstp qword ptr[ecx];
		fsqrt;
		fld a;
		fld st;
		fadd;
		fdiv;
		mov ecx, x2;
		fstp qword ptr[ecx];

		mov wynik, 0;
	koniec:
    }
    return wynik;
}


int main()
{

	double x1 = 0, x2 = 0;
    cout << kwadrat(2, 4, 5, &x1, &x2) << endl;
    cout << x1 << " " << x2 << endl;
}
