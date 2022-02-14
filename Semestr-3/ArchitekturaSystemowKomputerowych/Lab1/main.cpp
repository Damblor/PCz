#include <iostream>
#include <bitset>
#include <limits>
#include <iomanip>

using namespace std;

template<typename T>
void show_32_bits(T tmp)
{
	const unsigned int tmpSize =32;
	unsigned long int bits = *(unsigned long int*) (&tmp);
	std::bitset<(tmpSize)> tmpBits(bits);
	std::cout<<tmpBits <<"\t"<<tmpSize <<" bits"<<"\t"<<std::fixed<<std::setprecision(20)<<tmp<<std::endl;
}

template<typename T>
void show_64_bits(T tmp)
{
	const unsigned int tmpSize = 64;
	unsigned long long int bits = *(unsigned long long int*) (&tmp);
	std::bitset<(tmpSize)> tmpBits(bits);
	std::cout<<tmpBits <<"\t"<<tmpSize <<" bits"<<"\t"<<std::fixed<<std::setprecision(20)<<tmp<<std::endl;
}

void Zad1()
{
    int a = -91;
	show_32_bits(a);

	int b = 91;
	show_32_bits(b);

	int c = std::numeric_limits<int>::min();
	show_32_bits(c);

	int d = std::numeric_limits<int>::max();
	show_32_bits(d);

	double e = -100;
	show_64_bits(e);

	double f = std::numeric_limits<double>::max();
	show_64_bits(f);
}

void Zad2()
{

	cout << "Zad2\n";

	int x;
	x = 91;
	show_32_bits(x);
	x = -100;
	show_32_bits(x);
	x = 60;
	show_32_bits(x);
}

void Zad3()
{
	cout << "Zad3\n";

	double a = 0.1;
	double b = 0.2;
	double c = a + b;

    auto toleranceValue = std::numeric_limits<double>::epsilon();
	if(fabs(c - 0.3) < toleranceValue)
    {
		std::cout << std::setprecision(23)<<"suma="<<c<<std::endl;
	}
}

void Zad4()
{
	cout << "Zad4\n";

	float suma = 0.0;

	for(int i=0; i<100; ++i)
        suma+=0.1f;

	std::cout <<std::fixed<<std::setprecision(20);
	std::cout <<"suma="<<suma<<std::endl;
    float wynik = 0.1f * 100;
	cout << "Wynik powinien wynosic " << wynik << ", a wyswietla " << suma << '\n';

}

void Zad5()
{
	cout << "Zad4\n";

    double x1 = 1.00E+21;
    double x2 = 17.0;
    double x3 = -10.0;
    double x4 = 130.0;
    double x5 = -1.00E+21;

    std::cout << std::setprecision(23) << "wynik(x1+x2+x3+x4+x5/setprecision(23)) = " << (x1 + x2 + x3 + x4 + x5) << '\n';
    std::cout << std::setprecision(23) << "wynik(x1+x5+x2+x3+x4/setprecision(23)) = " << (x1 + x5 + x2 + x3 + x4) << '\n';
}

int main()
{
	return 0;
}