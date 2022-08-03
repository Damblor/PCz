#include<iostream>

using namespace std;

extern "C" void sortint(int*, int);

int main()
{
	const int N = 10;

	int tab[N] = { 8,3,6,5,1,10,4,9,2,7 };
	sortint(tab, N);
	for (int i = 0; i < N; i++)
	{
		cout << tab[i] << " ";
	}
}