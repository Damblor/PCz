#include <iostream>
#include <mpi.h>

int main(int argc, char** argv) {
    MPI_Init(&argc, &argv);
    int rank, size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    int n = 0;
    double * v1,* v2,* v3;
    if(rank == 0)
    {
        std::cout << "Podaj wielkosc wektorow\n";
        std::cin >> n;
    }
    MPI_Bcast(&n,1,MPI_INT,0,MPI_COMM_WORLD);
    v1 = new double [n];
    v2 = new double [n];
    v3 = new double [n];
    double * vv1 = new double [n];
    double * vv2 = new double [n];
    double * vv3 = new double [n];
    if(rank == 0)
    {
        std::srand(time(0));
        for(int i = 0; i < n; i++)
        {
            v1[i] = ((double)rand() / RAND_MAX) * 10.0 + 10.0;
            v2[i] = ((double)rand() / RAND_MAX) * 100.0 + 100.0;
        }
        for(int i = 0; i < n; i++)
        {
            std::cout << "V1:" << v1[i] << " V2:" << v2[i] << "V3 should be:" << v1[i] + v2[i] <<"\n";
        }
    }
    int count = n / size;
    MPI_Scatter(v1, count, MPI_DOUBLE, vv1, count, MPI_DOUBLE, 0, MPI_COMM_WORLD );
    MPI_Scatter(v2, count, MPI_DOUBLE, vv2, count, MPI_DOUBLE, 0, MPI_COMM_WORLD );
    for(int i = 0; i < n; i++)
    {
        vv3[i] = vv1[i] + vv2[i];
    }
    MPI_Gather(vv3,count,MPI_DOUBLE,v3,count,MPI_DOUBLE,0,MPI_COMM_WORLD);

    if(rank == 0)
    {
        for(int i = 0; i < n; i++)
        {
            std::cout << "V3:" << v3[i] << "\n";
        }
    }



    delete[] v1;
    delete[] v2;
    delete[] v3;
    MPI_Finalize();
    return 0;
}
