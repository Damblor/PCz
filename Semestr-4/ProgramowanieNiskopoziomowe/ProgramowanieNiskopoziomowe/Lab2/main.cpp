#include<iostream>
#include<iomanip>

using namespace std;

extern "C" int if_1(int a, int b);
extern "C" int if_2(int a, int b);
extern "C" int if_3(int a, int b);
extern "C" int if_4(int a, int b);

extern "C" int case_1(int x, int op);
extern "C" int case_2(int x, int op);

extern "C" int for_1(int n);
extern "C" int silnia_1(int n);

extern "C" int while_1(int a, int r, int max);
extern "C" int silnia_2(int n);

extern "C" int zad_1(int a, int b);
extern "C" int zad_2(int a, int b);

extern "C" int64_t zad_3(int64_t a, int64_t b);
extern "C" int64_t zad_4(int64_t n);
extern "C" int64_t zad_5(int64_t n);
extern "C" int64_t zad_6(int64_t a);
extern "C" int64_t zad_7(int64_t a);
extern "C" int64_t zad_8(int64_t n);

int main()
{
	cout << if_1(2, 4) << endl;
	cout << if_2(4, 3) << endl;
	cout << if_3(3, 4) << endl;
	cout << if_4(3, 2) << endl;
	cout << case_1(3, 3) << endl;
	cout << case_2(3, 2) << endl;
	cout << for_1(4) << endl;
	cout << silnia_1(5) << endl;
	cout << while_1(2,1,4) << endl;
	cout << silnia_2(5) << endl;

	cout << "===================" << endl;
	cout << zad_1(4,2) << endl;
	cout << zad_2(2,2) << endl;
	cout << zad_3(0, 6) << endl;

	cout << zad_6(4) << endl;


}