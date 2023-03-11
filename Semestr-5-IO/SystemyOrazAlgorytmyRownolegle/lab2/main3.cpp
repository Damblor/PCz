#include <iostream>
#include <mpi.h>
#include <fstream>

using namespace std;

int main (int argc, char *argv[])
{
	MPI_Init(&argc, &argv);
	int rank, size;
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Comm_size(MPI_COMM_WORLD, &size);

	

	if (rank == 0)
	{
		std::ifstream file("file.txt");
		int l;
		file >> l;
		double* tab = new double[l];
		for(int i = 0; i < l; i++)
		{
			file >> tab[i];
		}
		double suma;
		MPI_Send(&l, 1, MPI_INT, 1, 102, MPI_COMM_WORLD);
		MPI_Send(tab, l, MPI_DOUBLE, 1, 100, MPI_COMM_WORLD);
		MPI_Recv(&suma, 1, MPI_DOUBLE, 1, 101, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
		std::cout << "Odebrano: " << suma << '\n';
		delete[] tab;
	}
	else if (rank == 1)
	{
		int l;
		double* tab;
		double suma = 0;
		MPI_Recv(&l, 1, MPI_INT, 0, 102, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
		tab = new double[l];
		MPI_Recv(tab, l, MPI_DOUBLE, 0, 100, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
		for(int i = 0; i < l; i++)
		{
			suma += tab[i];
		}
		MPI_Send(&suma, 1, MPI_DOUBLE, 0, 101, MPI_COMM_WORLD);
		delete[] tab;
	}

	MPI_Finalize();
	return 0;
}
