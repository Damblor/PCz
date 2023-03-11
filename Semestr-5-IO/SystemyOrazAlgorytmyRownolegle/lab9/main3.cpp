#include <iostream>
#include <omp.h>
#include <cmath>

double f(double x)
{
    return std::sqrt(1 - (x * x));
}

double calkaSek(int n)
{
    double tBegin, tEnd;
    tBegin = omp_get_wtime();
    double xp, xk, h, calka;
    xp = -1;
    xk = 1;

    h = (xk - xp) / (double)n;

    calka = 0;
    for (int i=1; i<n; i++)
    {
        calka += f(xp + i * h);
    }
    calka += f(xp) / 2;
    calka += f(xk) / 2;
    calka *= h;
    calka *= 2;

    tEnd = omp_get_wtime();
    std::cout << "T sek: " << (tEnd - tBegin) * 1000 << std::endl;
    std::cout << "Wynik calkowania sek: " << calka << std::endl;

    return calka;
}

double calkaRow(int n)
{
    double tBegin, tEnd;
    tBegin = omp_get_wtime();
    double xp, xk, h, calka;
    xp = -1;
    xk = 1;

    h = (xk - xp) / (double)n;

    calka = 0;
    #pragma omp parallel
    #pragma omp for reduction(+: calka)
    for (int i=1; i<n; i++)
    {

        calka += f(xp + i * h);
    }
    calka += f(xp) / 2;
    calka += f(xk) / 2;
    calka *= h;
    calka *= 2;

    tEnd = omp_get_wtime();
    std::cout << "T rown: " << (tEnd - tBegin) * 1000 << std::endl;
    std::cout << "Wynik calkowania row: " << calka << std::endl;
    return calka;
}

int main(int argc, char** argv) {
    
    int n = 1000000;

    calkaSek(n);
    calkaRow(n);

    return 0;
}
