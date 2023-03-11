#include<iostream>
#include <bitset>
#include <limits>
#include <iomanip>

using namespace std;

template<typename T>
void show_32_bits(T tmp) {
 const unsigned int tmpSize =32;
 unsigned long int bits = *(unsigned long int*) (&tmp);
 std::bitset<(tmpSize)> tmpBits(bits);
 std::cout<<tmpBits <<"\t"<<tmpSize <<" bits"<<"\t"<<std::fixed<<std::setprecision(20)<<tmp<<std::endl;
}
template<typename T>
void show_64_bits(T tmp) {
 const unsigned int tmpSize = 64;
 unsigned long long int bits = *(unsigned long long int*) (&tmp);
 std::bitset<(tmpSize)> tmpBits(bits);
 std::cout<<tmpBits <<"\t"<<tmpSize <<" bits"<<"\t"<<std::fixed<<std::setprecision(20)<<tmp<<std::endl;
}



int main()
{
    show_64_bits(-91.0);
    show_64_bits(91.0);
    show_32_bits(-91.0f);
    show_32_bits(91.0f);
    float a = std::numeric_limits<float>::max();
    show_32_bits(a);
    float b = std::numeric_limits<float>::min();
    show_32_bits(b);
    int c = -91;
    show_32_bits(c);
    int d = 91;
    show_32_bits(d);
    int e = std::numeric_limits<int>::max();
    show_32_bits(e);
    int f = std::numeric_limits<int>::min();
    show_32_bits(f);
}