#include <iostream>

__global__ void add(int *a, int *b, int *c)
{
    c[blockIdx.x] = a[blockIdx.x] + b[blockIdx.x];
}

int main()
{
    int n;
    std::cout << "Podaj rozmiar: ";
    std::cin >> n;
    int* a_h = (int*) malloc(n * sizeof(int));
    int* b_h = (int*) malloc(n * sizeof(int));
    int* c_h = (int*) malloc(n * sizeof(int));

    for(size_t i = 0; i < n; i++)
    {
        a_h[i] = i;
        b_h[i] = 10;
    }

    for(size_t i = 0; i < n; i++)
    {
        c_h[i] = a_h[i] + b_h[i];
    }

    int *a_d = 0, *b_d, *c_d;
    //size_t size = n * sizeof(int);
    
    cudaError_t rc = cudaMalloc(&a_d, n * sizeof(int));
    cudaMalloc(&b_d, n * sizeof(int));
    cudaMalloc(&c_d, n * sizeof(int));

    cudaMemcpy(a_d, a_h, n * sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(b_d, b_h, n * sizeof(int), cudaMemcpyHostToDevice);

    add<<<n, 1>>>(a_d, b_d, c_d);

    int* result = (int*) malloc(n * sizeof(int));
    cudaMemcpy(result, c_d, n * sizeof(int), cudaMemcpyDeviceToHost);

    if (rc != cudaSuccess)
        std::cout << cudaGetErrorString(rc) << std::endl;

    bool ok = true;
    for (size_t i = 0; i < n; i++)
    {
        //std::cout << c_h[i] << " " << result[i] << std::endl;
    		if(c_h[i] != result[i])
		{
			ok = false;
			break;
		}
	}
    
    std::cout << (ok ? "OK" : "ERROR") << std::endl;

    cudaFree(a_d);
    cudaFree(b_d);
    cudaFree(c_d);

    delete[] a_h;
    delete[] b_h;
    delete[] c_h;

    return 0;
}
