#include <iostream>
#include <cmath>

__global__ void calkaRowKernel(double* calk_d, int n)
{
    double xp, xk, h;
    xp = -1;
    xk = 1;

    h = (xk - xp) / (double)n;
    calk_d[blockIdx.x] = std::sqrt(1 - ((xp + blockIdx.x * h) *(xp + blockIdx.x * >
}


double f(double x)
{
    return std::sqrt(1 - (x * x));
}

double calkaSek(int n)
{
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

    std::cout << "Wynik calkowania sek: " << calka << std::endl;

    return calka;
}

double calkaRow(int n)
{
    int n_w = 100;
    double xp, xk, h, calka;
    xp = -1;
    xk = 1;

    h = (xk - xp) / (double)n;

    double* calk_h = (double*) malloc(n * sizeof(double));
    for(int i = 0; i < n; i++)
    {
        calk_h[i] = 0;
    }
    double* calk_d;
    cudaError_t rc = cudaMalloc(&calk_d, n * sizeof(double));
    cudaMemcpy(calk_d, calk_h, n * sizeof(double), cudaMemcpyHostToDevice);
    if (rc != cudaSuccess)
        std::cout << cudaGetErrorString(rc) << std::endl;
    calkaRowKernel<<<n_w, 1>>>(calk_d, n);


    cudaMemcpy(calk_h, calk_d, n * sizeof(double), cudaMemcpyDeviceToHost);
    calka = 0;

    for (size_t i = 0; i < n; i++)
    {
        calka += calk_h[i];
    }

    calka += f(xp) / 2;
    calka += f(xk) / 2;
    calka *= h;
    calka *= 2;

    std::cout << "Wynik calkowania row: " << calka << std::endl;
    return calka;
}

int main(int argc, char** argv) {
    
    int n = 1000000;

    calkaSek(n);
    calkaRow(n);

    return 0;
}
