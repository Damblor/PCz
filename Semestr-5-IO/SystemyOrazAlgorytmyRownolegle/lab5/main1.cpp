#include <iostream>
#include <mpi.h>
#include <cmath>

double f(double x)
{
    return std::sqrt(1 - (x * x));
}

int main(int argc, char** argv) {
    MPI_Init(&argc, &argv);
    int rank, size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    float xp, xk, h, calka;
    int n;
    if(rank == 0)
    {
        std:: cin >> n;
    }
    MPI_Bcast(&n,1,MPI_INT,0,MPI_COMM_WORLD);
    // przedzialy
    xp = -1;
    xk = 1;

    h = (xk - xp) / (float)n;

    std::cout << "krok: h=" << h << std::endl;

    calka = 0;
    if(rank == 0)
    {

    }
    else
    {
        for (int i=1; i<n; i++)
        {
            calka += f(xp + i * h);
        }
        calka += f(xp) / 2;
        calka += f(xk) / 2;
        calka *= h;
    }

    std::cout << "Wynik calkowania: " <<  2.0 * calka << std::endl;
    return 0;
}
