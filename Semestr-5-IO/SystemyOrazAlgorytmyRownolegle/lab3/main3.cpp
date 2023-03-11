#include <iostream>
#include <mpi.h>
#include <chrono>
#include <unistd.h>

int main(int argc, char** argv)
{
    MPI_Init(&argc, &argv);
    int rank, size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    int n;
    if(rank == 0)
    {
        std::cout << "Podaj wielkosc : " << std::endl;
        int l;
        std::cin >> l;
        n = l;
        for(int i = 0; i < size; i++)
        {
            MPI_Send(&l,1,MPI_INT,i,100,MPI_COMM_WORLD);
        }
    }

    sleep(rank);
    srand(time(0));

    if(rank != 0)
    {
        MPI_Recv(&n,1,MPI_INT,0,100,MPI_COMM_WORLD,MPI_STATUS_IGNORE);
    }

    std::cout << "Rank " << rank << " l: " << n << std::endl;

    int* tab = new int[n];
    int max = 0;
    for(int i = 0; i < n; i++)
    {
        tab[i] = rand() % 11;
        if(tab[i] > max)
            max = tab[i];
        std::cout << "Rank " << rank << " wylosowal liczbe: " << tab[i] << std::endl;
    }
    int global_max;
    MPI_Reduce(&max, &global_max, 1, MPI_INT, MPI_MAX, 1, MPI_COMM_WORLD);

    if (rank == 1)
    {
        std::cout << "Max: " << max << std::endl;
    }


    MPI_Finalize();
    return 0;
}
