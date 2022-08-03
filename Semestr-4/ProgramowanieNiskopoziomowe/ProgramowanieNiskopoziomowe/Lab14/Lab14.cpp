#include <iostream>

void Transponuj4x4(double** tab)
{
    __asm
    {
        push esi;
        mov esi, tab
        mov eax, [esi]
        mov ecx, [esi + 8]
        mov edx, [esi + 12]
        mov esi, [esi + 4]
        vmovdqu ymm0, ymmword ptr[eax]
        vmovdqu ymm1, ymmword ptr[ecx]
        vperm2i128 ymm2, ymm0, ymm1, 20h
        vperm2i128 ymm4, ymm0, ymm1, 31h
        vmovdqu ymm0, ymmword ptr[esi]
        vmovdqu ymm1, ymmword ptr[edx]
        vperm2i128 ymm3, ymm0, ymm1, 20h
        vperm2i128 ymm5, ymm0, ymm1, 31h
        vpunpcklqdq ymm0, ymm2, ymm3
        vpunpckhqdq ymm1, ymm2, ymm3
        vpunpcklqdq ymm2, ymm4, ymm5
        vpunpckhqdq ymm3, ymm4, ymm5
        vmovdqu ymmword ptr[eax], ymm0
        vmovdqu ymmword ptr[esi], ymm1
        vmovdqu ymmword ptr[ecx], ymm2
        vmovdqu ymmword ptr[edx], ymm3
        pop esi;
    }

}

int main()
{
    std::cout << "Hello World!\n";
    const int n = 4;
    double* m[n] =
    {
        new double[n] {1,2,3,4},
        new double[n] {5,6,7,8},
        new double[n] {9,10,11,12},
        new double[n] {13,14,15,16}
    };

    Transponuj4x4(m);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            std::cout << m[i][j] << " ";
        }
        std::cout << std::endl;
    }

    for (int i = 0; i < n; i++)
    {
        delete[] m[i];
    }

}
