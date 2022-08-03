#include <iostream>

extern "C" void Ify1(double**, double**, double**, int, int, double);

int main()
{
    std::cout << "Hello World!\n";

    const int n = 4;
    double* m1[n] =
    {
        new double[n] {1,2,3,4},
        new double[n] {5,6,7,8},
        new double[n] {9,10,11,12},
        new double[n] {13,14,15,16}
    };
    double* m2[n] =
    {
        new double[n] {13,14,15,16},
        new double[n] {9,10,11,12},
        new double[n] {5,6,7,8},
        new double[n] {1,2,3,4}
    };
    double* m3[n] =
    {
        new double[n],
        new double[n],
        new double[n],
        new double[n]
    };

    Ify1(m1, m2, m3, n, n, 2);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            std::cout << m3[i][j] << " ";
        }
        std::cout << std::endl;
    }
}
