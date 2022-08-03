#include<iostream>

using namespace std;

extern "C" int if_1(int a, int b);
extern "C" int if_1_better(int a, int b);
extern "C" int if_2(int a, int b);
extern "C" int if_2_better(int a, int b);
extern "C" int if_3(int a, int b);
extern "C" int if_3_better(int a, int b);
extern "C" int if_4(int a, int b);
extern "C" int if_4_better(int a, int b);

extern "C" int case_1(int x, int op);
extern "C" int case_2(int x, int op);

extern "C" int suma(int n);
extern "C" int suma_better(int n);
extern "C" int silnia(int n);
extern "C" int suma_2(int n1, int n2);

int main()
{
	cout << if_1(2, 5) << ' ' << if_1(5, 2) << endl;
	cout << if_1_better(2, 5) << ' ' << if_1_better(5, 2) << endl;
	cout << if_2(2, 6) << ' ' << if_2(7, 2) << endl;
	cout << if_2_better(2, 6) << ' ' << if_2_better(7, 2) << endl;
	cout << if_3(2, 6) << ' ' << if_3(5, 4) << endl;
	cout << if_3_better(2, 6) << ' ' << if_3_better(5, 4) << endl;
	cout << if_4(2, 6) << ' ' << if_4(6, 3) << endl;
	cout << if_4_better(2, 6) << ' ' << if_4_better(6, 3) << endl;

	cout << case_1(1, 3) << ' '
		<< case_1(1, 5) << ' '
		<< case_1(1, 7) << ' '
		<< case_1(1, 0) << endl;
	cout << case_2(1, 0) << ' '
		<< case_2(1, 1) << ' '
		<< case_2(1, 2) << ' '
		<< case_2(1, 3) << ' '
		<< case_2(1, 4) << endl;

	int n = 4;
	cout << "ASM = " << suma(n) << endl;
	cout << "ASM2 = " << suma_better(n) << endl;
	cout << "Sinia = " << silnia(n) << endl;
	cout << "Sinia 0 = " << silnia(0) << endl;
	cout << "Suma 2 = " << suma_2(2,5) << endl;
}