#include <iostream>
#include <mpi.h>

using namespace std;

int main (int argc, char *argv[])
{
	MPI_Init(&argc, &argv);
	int rank, size;
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Comm_size(MPI_COMM_WORLD, &size);

	if (rank == 0)
	{
		int a;
		std::cin >> a;
		MPI_Send(&a, 1, MPI_INT, 1, 102, MPI_COMM_WORLD);
		MPI_Recv(&a, 1, MPI_INT, size - 1, 100, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
		std::cout << "Odebrano: " << a << '\n';
	}
	else if (rank != size - 1)
	{
		int b;
		MPI_Recv(&b, 1, MPI_INT, rank - 1, 102, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
		std::cout << "Odebrano: " << b << ", w watku: " << rank << '\n';
		++b;
		MPI_Send(&b, 1, MPI_INT, rank + 1, 102, MPI_COMM_WORLD);
	}
	else
	{
		int c;
		MPI_Recv(&c, 1, MPI_INT, rank - 1, 102, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
		++c;
		MPI_Send(&c, 1, MPI_INT, 0, 100, MPI_COMM_WORLD);

	}

	MPI_Finalize();
	return 0;
}
