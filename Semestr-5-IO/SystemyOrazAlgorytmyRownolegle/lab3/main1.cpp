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

    sleep(rank);
    srand(time(0));

    int random = rand() % 10 + 1;
    std::cout << "Rank " << rank << " wylosowal liczbe: " << random << std::endl;
    int max;
    MPI_Reduce(&random, &max, 1, MPI_INT, MPI_MAX, 1, MPI_COMM_WORLD);


    if (rank == 1)
    {
        std::cout << "Max: " << max << std::endl;
    }

    MPI_Finalize();
    return 0;
}
