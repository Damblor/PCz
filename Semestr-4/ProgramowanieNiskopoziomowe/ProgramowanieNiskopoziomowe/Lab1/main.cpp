#include<iostream>
#include<iomanip>

using namespace std;

extern "C" int szescian(int a);
extern "C" int kwadratowe(int a,int b, int c, int x);
extern "C" int zamiana(int a);

int main()
{
	int a = 0xab00ff11;
	cout << szescian(3) << endl;
	cout << kwadratowe(1, 2, 3, 4) << endl;
	cout << hex << a << endl << zamiana(a) << endl;
}