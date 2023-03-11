#include <iostream>
#include <omp.h>
#include <cmath>

int main(int argc, char **argv)
{
    double tBegin, tEnd;

    int n;
    std::cout << "Podaj n: ";
    std::cin >> n;

    double alpha = 0;
    double beta = 0;

    double *a = new double[n];
    double *d = new double[n];
    double *u = new double[n];
    double *v = new double[n];

    double **B = new double *[n];
    double **G = new double *[n];

    for (int i = 0; i < n; i++)
    {
        B[i] = new double[n];
        G[i] = new double[n];
    }

    tBegin = omp_get_wtime();

    #pragma omp parallel
    for (int k = 0; k < 5; k++)
    {
        // B = Beta * B - A
        #pragma omp for nowait
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                B[i][j] = beta * B[i][j] + G[i][j];
            }
        }

        // Alpha = a * d
        #pragma omp single
        alpha = 0;
        #pragma omp barrier
        #pragma omp for reduction(+: alpha)
        for (int i = 0; i < n; i++)
        {
            alpha += a[i] * d[i];
        }

        // v = Alpha * u + a
        #pragma omp for
        for (int i = 0; i < n; i++)
        {
            v[i] = alpha * u[i] + a[i];
        }

        // d = B * v
        #pragma omp for
        for (int i = 0; i < n; i++)
        {
            double sum = 0;
            for (int j = 0; j < n; j++)
            {
                sum += B[i][j] * v[i];
            }
            d[i] = sum;
        }

        // Beta += d * v
        #pragma omp for reduction(+: beta)
        for (int i = 0; i < n; i++)
        {
            beta += d[i] * v[i];
        }
    }

    tEnd = omp_get_wtime();
    std::cout << "T sek: " << (tEnd - tBegin) << std::endl;

    // Delete
    for (int i = 0; i < n; i++)
    {
        delete[] B[i];
        delete[] G[i];
    }

    delete[] a;
    delete[] d;
    delete[] u;
    delete[] v;

    delete[] B;
    delete[] G;

    return 0;
}
