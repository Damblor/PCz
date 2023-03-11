#include<iostream>
#include <iomanip>

using namespace std;

void z1()
{
    float a = 0.2;
    float b = 0.2;
    float c = 0.3;
    
    float s1 = a + (b+c);
    float s2 = (a + b) +c;

    std::cout<<std::fixed<<std::setprecision(20);
    std::cout<<s1<<std::endl;
    std::cout<<s2<<std::endl;
}

void z2()
{
    float suma = 0.0;
    for(int i=0; i<100; ++i)
        suma+=0.1f;
    std::cout <<std::fixed<<std::setprecision(20);
    std::cout <<"suma="<<suma<<std::endl;
}

void z3()
{
    float a = 0.2;
    float b = 0.2;
    float c = 0.3;

    float i1 = a* (b+c);
    float i2 = a*b + a*c;

    std::cout<<std::fixed<<std::setprecision(20);
    std::cout<<i1<<std::endl;
    std::cout<<i2<<std::endl;
}

void z4()
{
    double a = 0.1;
    double b = 0.2;
    double c = a + b;

    std::cout<<std::fixed<<std::setprecision(40);
    std::cout<<"suma a+b="<<c<<std::endl;
}

void z5()
{
    double x1 = 1.00E+21;
    double x2 = 17.0;
    double x3 = -10.0;
    double x4 = 130.0;
    double x5 = -1.00E+21;

    double s1 =  (((x1 + x5) + x3) + x4) + x2;

    std::cout<<"s1 "<<s1<<std::endl;
}

void z6()
{
    float a = 0.5;
    float b = 0.5;
    float c = 0.5;

    float s1 = a + (b+c);
    float s2 = (a + b) +c;

    std::cout<<std::fixed<<std::setprecision(20);
    std::cout<<s1<<std::endl;
    std::cout<<s2<<std::endl;
}

void z7()
{
    float suma = 0.0;
    for(int i=0; i<100; ++i)
        suma+=0.5f;
    std::cout <<std::fixed<<std::setprecision(20);
    std::cout <<"suma="<<suma<<std::endl;
}

void z8()
{
    float a = 0.5;
    float b = 0.5;
    float c = 0.5;

    float i1 = a* (b+c);
    float i2 = a*b + a*c;

    std::cout<<std::fixed<<std::setprecision(20);
    std::cout<<i1<<std::endl;
    std::cout<<i2<<std::endl;
}

void z9()
{
    double a = 0.5;
    double b = 0.5;
    double c = a + b;

    std::cout<<std::fixed<<std::setprecision(50);
    std::cout<<"suma a+b="<<c<<std::endl;
}

int main()
{
    z9();
}