#include <iostream>

void vec_avx_add_int(int* t1, int* t2, int* t3, int n)
{
    __asm
    {
        push esi;
        push edi;
        mov ecx, n;
        shl ecx, 2;
        mov esi, t1;
        mov edx, t2;
        mov edi, t3;

    petla:
        sub ecx, 32;
        vmovdqu ymm0, ymmword ptr[esi + ecx];
        vmovdqu ymm1, ymmword ptr[edx + ecx];
        vpaddd ymm2, ymm1, ymm0;
        vmovdqu ymmword ptr[edi + ecx], ymm2;
        jnz petla;
        pop edi;
        pop esi;
    }
}

void vec_avx_sub_int(int* t1, int* t2, int* t3, int n)
{
    __asm
    {
        push esi;
        push edi;
        mov ecx, n;
        shl ecx, 2;
        mov esi, t1;
        mov edx, t2;
        mov edi, t3;

    petla:
        sub ecx, 32;
        vmovdqu ymm0, ymmword ptr[esi + ecx];
        vmovdqu ymm1, ymmword ptr[edx + ecx];
        vpsubd ymm2, ymm1, ymm0;
        vmovdqu ymmword ptr[edi + ecx], ymm2;
        jnz petla;
        pop edi;
        pop esi;
    }
}

void vec_avx_mul_int(int* t1, int* t2, int* t3, int n)
{
    __asm
    {
        push esi;
        push edi;
        mov ecx, n;
        shl ecx, 2;
        mov esi, t1;
        mov edx, t2;
        mov edi, t3;

    petla:
        sub ecx, 32;
        vmovdqu ymm0, ymmword ptr[esi + ecx];
        vmovdqu ymm1, ymmword ptr[edx + ecx];
        vpmulld ymm2, ymm1, ymm0;
        vmovdqu ymmword ptr[edi + ecx], ymm2;
        jnz petla;
        pop edi;
        pop esi;
    }
}

void mtx2_avx_add_int(int** t1, int** t2, int** t3, int n, int m)
{
    __asm
    {
        push esi;
        push edi;
        mov eax, n;
    petlaN:
        mov esi, t1;
        mov esi, dword ptr[esi + eax * 4 - 4];
        mov edx, t2;
        mov edx, dword ptr[edx + eax * 4 - 4];
        mov edi, t3;
        mov edi, dword ptr[edi + eax * 4 - 4];

        mov ecx, m;
        shl ecx, 2;
    petlaM:
        sub ecx, 32;
        vmovdqu ymm0, ymmword ptr[esi + ecx];
        vmovdqu ymm1, ymmword ptr[edx + ecx];
        vpaddd ymm2, ymm1, ymm0;
        vmovdqu ymmword ptr[edi + ecx], ymm2;
        jnz petlaM;

        dec eax;
        jnz petlaN;
        pop edi;
        pop esi;
    }
}

void mtx2_avx_sub_int(int** t1, int** t2, int** t3, int n, int m)
{
    __asm
    {
        push esi;
        push edi;
        mov eax, n;
    petlaN:
        mov esi, t1;
        mov esi, dword ptr[esi + eax * 4 - 4];
        mov edx, t2;
        mov edx, dword ptr[edx + eax * 4 - 4];
        mov edi, t3;
        mov edi, dword ptr[edi + eax * 4 - 4];

        mov ecx, m;
        shl ecx, 2;
    petlaM:
        sub ecx, 32;
        vmovdqu ymm0, ymmword ptr[esi + ecx];
        vmovdqu ymm1, ymmword ptr[edx + ecx];
        vpsubd ymm2, ymm1, ymm0;
        vmovdqu ymmword ptr[edi + ecx], ymm2;
        jnz petlaM;

        dec eax;
        jnz petlaN;
        pop edi;
        pop esi;
    }
}

void mtx2_avx_mul_int(int** t1, int** t2, int** t3, int n, int m)
{
    __asm
    {
        push esi;
        push edi;
        mov eax, n;
    petlaN:
        mov esi, t1;
        mov esi, dword ptr[esi + eax * 4 - 4];
        mov edx, t2;
        mov edx, dword ptr[edx + eax * 4 - 4];
        mov edi, t3;
        mov edi, dword ptr[edi + eax * 4 - 4];

        mov ecx, m;
        shl ecx, 2;
    petlaM:
        sub ecx, 32;
        vmovdqu ymm0, ymmword ptr[esi + ecx];
        vmovdqu ymm1, ymmword ptr[edx + ecx];
        vpmulld ymm2, ymm1, ymm0;
        vmovdqu ymmword ptr[edi + ecx], ymm2;
        jnz petlaM;

        dec eax;
        jnz petlaN;
        pop edi;
        pop esi;
    }
}

void vec_avx_sub_float(float* t1, float* t2, float* t3, int n)
{
    __asm
    {
        push esi;
        push edi;
        mov ecx, n;
        shl ecx, 2;
        mov esi, t1;
        mov edx, t2;
        mov edi, t3;

    petla:
        sub ecx, 32;
        vmovups ymm0, ymmword ptr[esi + ecx];
        vmovups ymm1, ymmword ptr[edx + ecx];
        vsubps ymm2, ymm1, ymm0;
        vmovups ymmword ptr[edi + ecx], ymm2;
        jnz petla;
        pop edi;
        pop esi;
    }
}

void mtx2_avx_sub_float(float** t1, float** t2, float** t3, int n, int m)
{
    __asm
    {
        push esi;
        push edi;
        mov eax, n;
    petlaN:
        mov esi, t1;
        mov esi, dword ptr[esi + eax * 4 - 4];
        mov edx, t2;
        mov edx, dword ptr[edx + eax * 4 - 4];
        mov edi, t3;
        mov edi, dword ptr[edi + eax * 4 - 4];
        mov ecx, m;
        shl ecx, 2;
    petlaM:
        sub ecx, 32;
        vmovups ymm0, ymmword ptr[esi + ecx];
        vmovups ymm1, ymmword ptr[edx + ecx];
        vsubps ymm2, ymm1, ymm0;
        vmovups ymmword ptr[edi + ecx], ymm2;
        jnz petlaM;
        dec eax;
        jnz petlaN;
        pop edi;
        pop esi;
    }
}

double wielomian_v5(double a, double b, double c, double d, double x)
{
    double wynik = 0;
    __asm
    {
        vmovsd xmm0, x;
        vmovsd xmm1, a;
        vmovsd xmm2, b;
        vmovsd xmm3, c;
        vmovsd xmm4, d;
        vfmadd213sd xmm1, xmm0, xmm2; ax + b
            vfmadd213sd xmm1, xmm0, xmm3; (ax + b)x + c
            vfmadd213sd xmm0, xmm1, xmm4; ((ax + b)x + c)c + d
            vmovsd wynik, xmm0;
    }
    return wynik;
}


int main()
{
    /*const int n = 8;
    int t1[n] = { 1,2,3,4,5,6,7,8 };
    int t2[n] = { 1,2,3,4,5,6,7,8 };
    int t3[n];

    vec_avx_add_int(t1, t2, t3, n);

    for (int i = 0; i < n; i++)
    {
        std::cout << t3[i] << " ";
    }
    std::cout << std::endl;

    vec_avx_sub_int(t1, t2, t3, n);

    for (int i = 0; i < n; i++)
    {
        std::cout << t3[i] << " ";
    }
    std::cout << std::endl;

    vec_avx_mul_int(t1, t2, t3, n);

    for (int i = 0; i < n; i++)
    {
        std::cout << t3[i] << " ";
    }
    std::cout << std::endl;*/

    /*const int n = 2;
    const int m = 8;

    int* t1[n] =
    {
        new int[m] {1,2,3,4,5,6,7,8},
        new int[m] {9,10,11,12,13,14,15,16},
    };
    int* t2[n] =
    {
        new int[m] {1,2,3,4,5,6,7,8},
        new int[m] {9,10,11,12,13,14,15,16},
    };
    int* t3[n] =
    {
        new int[m],
        new int[m]
    };

    mtx2_avx_add_int(t1, t2, t3, n, m);
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            std::cout << t3[i][j] << " ";
        }
        std::cout << std::endl;
    }
    std::cout << std::endl;

    mtx2_avx_sub_int(t1, t2, t3, n, m);
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            std::cout << t3[i][j] << " ";
        }
        std::cout << std::endl;
    }
    std::cout << std::endl;

    mtx2_avx_mul_int(t1, t2, t3, n, m);
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            std::cout << t3[i][j] << " ";
        }
        std::cout << std::endl;
    }
    std::cout << std::endl;*/

    /*const int n = 8;
    float t1[n] = { 1.1,2.2,3.3,4.4,5.5,6.6,7.7,8.8 };
    float t2[n] = { 1.1,2.2,3.3,4.4,5.5,6.6,7.7,8.8 };
    float t3[n];

    vec_avx_sub_float(t1, t2, t3, n);
    for (int i = 0; i < n; i++)
    {
        std::cout << t3[i] << " ";
    }
    std::cout << std::endl;*/

    /*const int n = 2;
    const int m = 8;
    float* t1[n] =
    {
        new float[m] { 1.1,2.2,3.3,4.4,5.5,6.6,7.7,8.8 },
        new float[m] { 1.1,2.2,3.3,4.4,5.5,6.6,7.7,8.8 }
    };
    float* t2[n] =
    {
        new float[m] { 1,2,3,4,5,6,7,8 },
        new float[m] { 1,2,3,4,5,6,7,8 }
    };
    float* t3[n] =
    {
        new float[m],
        new float[m]
    };
    mtx2_avx_sub_float(t1, t2, t3, n, m);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            std::cout << t3[i][j] << " ";
        }
        std::cout << std::endl;
    }
    std::cout << std::endl;*/

    std::cout << wielomian_v5(2,3,4,5,1) << std::endl;
}
