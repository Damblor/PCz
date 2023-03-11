#include <iostream>
#include <ctime>
#include <chrono>

using namespace std;

int main()
{
    int n;
    cout << "Podaj wielkosc" << endl;
    cin >> n;
    double* a = new double[n];
    double* b = new double[n];
    double* c = new double[n];
    srand(time(0));
    for(int i = 0; i < n; i++)
    {
        a[i] = rand() % 11;
        b[i] = rand() % 11;
        c[i] = rand() % 11;
    }

    //Sekwencyjnie
    auto start = std::chrono::high_resolution_clock::now();
    for(int i = 0; i < n; i++)
    {
        a[i] = c[i] + c[i];
        b[i] = b[i] + c[i];
    }
    auto stop = std::chrono::high_resolution_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::microseconds>(stop - start);
    cout << "Sekwencyjnie: " << duration.count() << endl;

    //Rownolegle sections
    start = std::chrono::high_resolution_clock::now();
    #pragma omp parallel
    #pragma omp sections
    {
        #pragma omp section
        for(int i = 0; i < n; i++)
        {
            a[i] = c[i] + c[i];
        }
        #pragma omp section
        for(int i = 0; i < n; i++)
        {
            b[i] = b[i] + c[i];
        }
    }
    stop = std::chrono::high_resolution_clock::now();
    duration = std::chrono::duration_cast<std::chrono::microseconds>(stop - start);
    cout << "Rownolegle section: " << duration.count() << endl;

    //Rownolegle for
    start = std::chrono::high_resolution_clock::now();
    #pragma omp parallel
    #pragma omp for
    for(int i = 0; i < n; i++)
    {
        a[i] = c[i] + c[i];
        b[i] = b[i] + c[i];
    }
    stop = std::chrono::high_resolution_clock::now();
    duration = std::chrono::duration_cast<std::chrono::microseconds>(stop - start);
    cout << "Rownolegle for: " << duration.count() << endl;

    delete[] a;
    delete[] b;
    delete[] c;

}