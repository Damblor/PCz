#include <iostream>
#include <ctime>
#include <chrono>
#include <omp.h>

using namespace std;

double sek(double* tab, int n)
{
    double s = 0.0;
    for(int i = 0; i < n; i++)
    {
        s += tab[i];
    }
    return s / (double)n;
}

double rown_w_crit(double* tab, int n)
{
    double s = 0.0;
    #pragma omp parallel
    {
        #pragma omp for
        for(int i = 0; i < n; i++)
        {
            s += tab[i];
        }
    }
    return s / (double)n;
}

double rown_z_crit(double* tab, int n)
{
    double s = 0.0;
    #pragma omp parallel
    {
        #pragma omp for
        for(int i = 0; i < n; i++)
        {
            #pragma omp critical
            s += tab[i];
        }
    }
    return s / (double)n;
}

double rown_z_crit_i_local(double* tab, int n)
{
    double s = 0.0;
    #pragma omp parallel
    {
        double sl = 0.0;
        #pragma omp for
        for(int i = 0; i < n; i++)
        {
            sl += tab[i];
        }
        #pragma omp critical
        s += sl;
    }
    return s / (double)n;
}

double rown_red(double* tab, int n)
{
    double s = 0.0;
    #pragma omp parallel
    #pragma omp reduction(+: s)
    for(int i = 0; i < n; i++)
    {
        s += tab[i];
    }

    return s / (double)n;
}

int main()
{
    int n;
    cout << "Podaj wielkosc" << endl;
    cin >> n;
    double* tab = new double[n];
    srand(time(0));
    for(int i = 0; i < n; i++)
    {
        tab[i] = i;
    }

    double tBegin, tEnd;

    //1. Sekwencyjnie
    tBegin = omp_get_wtime();
    cout << "Sekw: " << sek(tab, n) << endl;
    tEnd = omp_get_wtime();
    cout << "T Sekw: " << tEnd - tBegin << endl;

    //2. Rownolegle bez sekcji krytycznej
    tBegin = omp_get_wtime();
    cout << "Row_w_crit: " << rown_w_crit(tab, n) << endl;
    tEnd = omp_get_wtime();
    cout << "T Row_w_crit: " << tEnd - tBegin << endl;

    //3. Rownolegle z sekcja krytyczna
    tBegin = omp_get_wtime();
    cout << "Row_z_crit: " << rown_z_crit(tab, n) << endl;
    tEnd = omp_get_wtime();
    cout << "T Row_z_crit: " << tEnd - tBegin << endl;

    //4. Rownolegle z sekcja krytyczna i suma localna
    tBegin = omp_get_wtime();
    cout << "Row_z_crit_i_loc: " << rown_z_crit_i_local(tab, n) << endl;
    tEnd = omp_get_wtime();
    cout << "T Row_z_crit_i_loc: " << tEnd - tBegin << endl;

    //5. Rownolegle z redukcja
    tBegin = omp_get_wtime();
    cout << "Row_redu " << rown_red(tab, n) << endl;
    tEnd = omp_get_wtime();
    cout << "T Row_redu: " << tEnd - tBegin << endl;

    delete[] tab;

}