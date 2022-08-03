#include <iostream>

using namespace std;

extern "C" int64_t pole1(int* v, int n);
extern "C" int suma(int* v1, int* v2, int n);
extern "C" int64_t skalarny(int* v1, int* v2, int n);
extern "C" int zad1(int* v, int n);
extern "C" int zad2(int* v, int n);
extern "C" int zad3(int* v, int n);

int main()
{
	int n = 4;
	int v1[4] = { 1,2,3,4 };
	int v2[4] = { 5,6,7,8 };

	/*cout << "Pole1 = " << pole1(v1, 4) << endl;
	suma(v1, v2, n);
	cout << "Skalarny = " << skalarny(v1, v2, 4) << endl;
	zad1(v1, n);
	zad2(v1, n);*/
	zad3(v1, n);
	for (int i = 0; i < n; i++)
	{
		cout << "Element " << i << " = " << v1[i] << endl;
	}
}