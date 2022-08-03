#include <iostream>
#include <time.h>

using namespace std;

extern "C" int64_t suma32(int**, int, int);
extern "C" int64_t suma64(int64_t**, int64_t, int64_t);
extern "C" int64_t uemxv(int64_t**, int64_t*, int64_t*, int64_t, int64_t);
extern "C" int64_t minM3(int64_t***, int64_t, int64_t, int64_t);

extern "C" int64_t iloczynMeUxV(int64_t**, int64_t**, int64_t**, int64_t, int64_t, int64_t);

int main()
{

	/*int** t1 = new int*[2];
	t1[0] = new int[3]{ 1, 2, 3 };
	t1[1] = new int[3]{ 4, 5, 6 };

	int64_t** t2 = new int64_t * [2];
	t2[0] = new int64_t[3]{ 1, 2, 3 };
	t2[1] = new int64_t[3]{ 4, 5, 6 };

	int64_t** m = new int64_t * [3];
	m[0] = new int64_t[4]{ 1, 1, 1, 1 };
	m[1] = new int64_t[4]{ 2, 2, 2, 2 };
	m[2] = new int64_t[4]{ 3, 3, 3, 3 };

	int64_t* v1 = new int64_t[4]{ 1,2,3,4 };
	int64_t* v2 = new int64_t[3];

	cout << "Suma32: " << suma32(t1, 2, 3) << endl;
	cout << "Suma64: " << suma64(t2, 2, 3) << endl;
	uemxv(m, v1, v2, 3, 4);
	cout << "Zadanie 2:" << endl;
	for (int i = 0; i < 3; i++)
	{
		cout << v2[i] << ' ';
	}
	cout << endl;*/


	/*
	//Zadanie 4
	srand(time(0));
	int64_t*** tm = new int64_t** [3];

	for (int i = 0; i < 3; i++)
	{
		tm[i] = new int64_t* [3];
		for (int j = 0; j < 3; j++)
		{
			tm[i][j] = new int64_t[3];
			for (int k = 0; k < 3; k++)
			{
				tm[i][j][k] = rand();
				cout << tm[i][j][k] << endl;
			}
		}
	}
	cout << "Minimalna: " << minM3(tm, 3, 3, 3) << endl;

	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			delete[] tm[i][j];
		}
		delete[] tm[i];
	}
	delete[] tm;*/

	/*delete[] t1[0];
	delete[] t1[1];
	delete[] t1;

	delete[] t2[0];
	delete[] t2[1];
	delete[] t2;

	delete[] m[0];
	delete[] m[1];
	delete[] m[2];
	delete[] m;

	delete[] v1;
	delete[] v2;*/

	//Zadanie 5
	srand(time(0));
	int64_t** m = new int64_t* [4];
	int64_t** u = new int64_t* [4];
	int64_t** v = new int64_t* [3];
	
	for (int i = 0; i < 4; i++)
	{
		m[i] = new int64_t[5];
		u[i] = new int64_t[3];
		for (int j = 0; j < 3; j++)
		{
			u[i][j] = (int64_t)rand() % 10 + 1;
			cout << u[i][j] << " ";
		}
		cout << endl;
	}
	cout << endl;

	for (int i = 0; i < 3; i++)
	{
		v[i] = new int64_t[5];
		for (int j = 0; j < 5; j++)
		{
			v[i][j] = (int64_t)rand() % 10 + 1;
			cout << v[i][j] << " ";
		}
		cout << endl;
	}
	cout << endl << "Wynik:" << endl;
	iloczynMeUxV(m, u, v, 4, 5, 3);
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			cout << m[i][j] << " ";
		}
		cout << endl;
	}

	for (int i = 0; i < 4; i++)
	{
		delete[] u[i];
		delete[] m[i];
	}
	for (int i = 0; i < 3; i++)
	{
		delete[] v[i];
	}
	delete[] u;
	delete[] m;
	delete[] v;
}