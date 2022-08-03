#include <iostream>
#include <chrono>

using namespace std;

extern "C" int kwadrat(double a, double b, double c, double* x1, double* x2);

extern "C" void summw(double**, double**, double**, int, int);
extern "C" void mulmw(float**, float**, float**, int, int, int);



void summwc(double** uu, double** mm, double** ww, int x, int y)
{
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            uu[i][j] = mm[i][j] + ww[i][j];
        }
    }
}

void mulmwc(float** U, float** M, float** W, int a, int b, int c)
{
    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < c; j++)
        {
            float w = 0;
            for (int k = 0; k < b; k++)
            {
                w += M[i][k] * W[k][j];
            }
            U[i][j] = w;
        }
    }
}


int main()
{
    /*const int x = 3;
    const int y = 2;
    double* mm[x] =
    {
        new double[y] {1,2},
        new double[y] {3,4},
        new double[y] {5,6}
    };
    double* ww[x] =
    {
        new double[y] {1,2},
        new double[y] {3,4},
        new double[y] {5,6}
    };
    double* uu[x] =
    {
        new double[y],
        new double[y],
        new double[y]
    };



    auto t1 = std::chrono::system_clock::now();
    for (int i = 0; i < 10000000; i++)
    {
        summwc(uu, mm, ww, x, y);
    }
    auto t2 = std::chrono::system_clock::now();

    std::cout << "CTime = " << (t2 - t1).count() << std::endl;


    t1 = std::chrono::system_clock::now();
    for (int i = 0; i < 10000000; i++)
    {
        summw(uu, mm, ww, x, y);
    }
    t2 = std::chrono::system_clock::now();

    std::cout << "ATime = " << (t2 - t1).count() << std::endl;

    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            std::cout << uu[i][j] << " ";
        }
        std::cout << std::endl;
    }
    
    delete[] mm[0];
    delete[] mm[1];
    delete[] mm[2];

    delete[] ww[0];
    delete[] ww[1];
    delete[] ww[2];

    delete[] uu[0];
    delete[] uu[1];
    delete[] uu[2];*/


    /*const int a = 2;//i
    const int b = 2;//j
    const int c = 2;//l

    float** M = new float* [a];
    float** W = new float* [b];
    float** U = new float* [a];

    for (int i = 0; i < a; i++)
    {
        M[i] = new float[b];
        for (int j = 0; j < b; j++)
        {
            M[i][j] = i + j;
        }
    }

    for (int i = 0; i < b; i++)
    {
        W[i] = new float[c];
        for (int j = 0; j < c; j++)
        {
            W[i][j] = i + j;
        }
    }

    for (int i = 0; i < a; i++)
    {
        U[i] = new float[c];
    }

    //----------------------
    auto t1 = std::chrono::system_clock::now();
    for (int i = 0; i < 1000000; i++)
    {
        mulmwc(U, M, W, a, b, c);
    }
    auto t2 = std::chrono::system_clock::now();

    std::cout << "CTime = " << (t2 - t1).count() << std::endl;


    t1 = std::chrono::system_clock::now();
    for (int i = 0; i < 1000000; i++)
    {
        mulmw(U, M, W, a, b, c);
    }
    t2 = std::chrono::system_clock::now();

    std::cout << "ATime = " << (t2 - t1).count() << std::endl;
    //-----------------------------

    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < c; j++)
        {
            std::cout << U[i][j] << " ";
        }
        std::cout << std::endl;
    }


    for (int i = 0; i < a; i++)
    {
        delete[] M[i];
    }
    delete[] M;

    for (int i = 0; i < b; i++)
    {
        delete[] W[i];
    }
    delete[] W;

    for (int i = 0; i < a; i++)
    {
        delete[] U[i];
    }
    delete[] U;*/

    double x1 = 0, x2 = 0;
    cout << kwadrat(2, 4, 2, &x1, &x2) << endl;
    cout << x1 << " " << x2 << endl;
}
