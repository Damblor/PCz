#include <iostream>
#include <emmintrin.h>
#include <immintrin.h>

using namespace std;

template<typename T>
void CheckAdress()
{
    T tmp;
    for(int i = 0; i<8; ++i) {
        int granica = 1<<i;
        long long adres = (long long)&tmp;
        std::cout<<"Czy adres: ";
        std::cout<<adres;
        std::cout<<" jest dopasowany do granicy ";
        std::cout<<granica;
        std::cout<<" bajtow? ";
        std::cout<<std::endl;
        if(adres % granica)
        {
            std::cout<<"Adres nie jest dopasowany do badanej granicy "<<granica<<" bajtow.";
        }
        else
        {
            std::cout<<"Adres jest dopasowany do badanej granicy "<<granica<<" bajtow.";
        }
        std::cout<<std::endl;
        std::cout<<std::endl;
    }
}

struct tmpData1
{
    int a;
    double b;
    int c;
};

struct tmpData2
{
    int a;
    int c;
    double b;
};

template<typename T>
void Zad2()
{
    T tmp;
    cout << "Zajmowany rozmiar " << sizeof(tmp) << " B\n";
}

struct tmpData
{
    char a;
    char e;
    int c;
    double b;
    double d;
};

template<typename T>
void Zad3()
{
    T tmp;
    cout << "Najmniejszy rozmiar " << sizeof(tmp) << " B\n";
}

int main()
{
    CheckAdress<float>();
    CheckAdress<char>();
    CheckAdress<int>();
    CheckAdress<double>();
    CheckAdress<__m128i>();
    CheckAdress<__m256i>();
    cout << "\n****************\n";
    cout << "Struktura powinna zajmowac " << 4 + 8 + 4 << "B\n";
    Zad2<tmpData1>();
    Zad2<tmpData2>();
    cout << "\n****************\n";
    Zad3<tmpData>();
}