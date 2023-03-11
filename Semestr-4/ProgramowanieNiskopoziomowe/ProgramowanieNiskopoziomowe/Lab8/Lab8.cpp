#include <iostream>

using namespace std;

float fun_w1(float a, float b, float c, float d, float x)
{
    float y;

    __asm
    {
        fld d;
        fld x;
        fld st;
        fmul st, st(1);
        fld st(1);
        fmul st, st(1);
        fmul a;
        faddp st(3), st;
        fmul b;
        faddp st(2), st;
        fmul c;
        fadd;
        fstp y;
    }

    return y;
}

float zad2(float a, float b, float c, float x)
{
    float y;

    __asm
    {
        fld a; //a;
        fld x; //x; a;
        fld st; //x; x; a;
        fmul st, st(1); //xx; x; a;
        fmul; //xxx; a;
        fmul;  //xxxa;
        fld c; //c; xxxa;
        fld b; //b; c; xxxa;
        fld a; //a; b; c; xxxa;
        fsub; //b-a; c; xxxa;
        fmul; //c(b-a); xxxa;
        fadd; //c(b-a) + xxxa;
        fld a;
        fld c;
        fld b;
        fsub;
        fmul;
        fadd;
        fstp y;
    }

    return y;
}

float zad2_b(float a, float b, float c, float x)
{
    float y;

    __asm
    {
        fld x; //x;
        fld st; //x; x;
        fmul st, st(1); //xx; x;
        fmul; //xxx;
        fmul a;  //a * xxx;

        fld b; //b; xxxa;
        fsub a; //b-a; xxxa;
        fmul c; //c(b-a); xxxa;

        fld c; //c; c(b-a); xxxa;
        fsub b; //c-b; c(b-a); xxxa;
        fmul a; //a(c-b); c(b-a); xxxa;
        fadd; //a(c-b) + c(b-a); xxxa;
        fadd; //a(c-b) + c(b-a) + xxxa;
        fstp y;
    }

    return y;
}

float pole(float a, float b, float c)
{
    float y;

    __asm
    {
        fld a; //;
        fld b; //b; a;
        fmul; // ba;
        fld a; //a; ba;
        fld c; //a; c; ba;
        fmul; //ac; ba;
        fld b; //b; ac; ba;
        fld c; //b; c; ac; ba;
        fmul; //bc; ac; ba;
        fadd; //bc + ac; ba;
        fadd; //bc +ac + ba;
        fadd st, st; // 2*(bc +ac + ba);
        fstp y;
    }

    return y;
}

float objetosc(float a, float b, float c)
{
    float y;

    __asm
    {
        fld a; //;
        fld b; //b; a;
        fmul; // ba;
        fld c; // c; ba;
        fmul; // cba;
        fstp y;
    }

    return y;
}

double fun_w2(double* x, double* z, int N)
{
    double wynik;

    __asm
    {
        mov ecx, N;
        mov esi, x;
        mov edi, z;
        fld qword ptr [esi];
        fmul qword ptr [edi];
        dec ecx;
        jz koniec;
    label1:
        add esi, 8;
        add edi, 8;
        fld qword ptr [esi];
        fmul qword ptr [edi];
        fadd;
        dec ecx;
        jnz label1;
    koniec:
        fstp wynik;
    }

    return wynik;
}

float zad2_n(float r)
{
    float v;
    float a = 4;
    float b = 3;
    __asm
    {
        fld r;//r
        fld st; //r, r
        fmul st, st(1);//rr, r
        fmul;//rrr
        fldpi;//pi, rrr
        fmul;//pi*rrr
        fmul a;
        fdiv b;
        fstp v;
    }

    return v;

}

float zad3_n(float r)
{
    float a = 4;
    float p;
    __asm
    {
        fld r;
        fmul r;
        fldpi;
        fmul;
        fmul a;
        fstp p;
    }
    return p;
}

float zad4_n(float a, float b, float c, float x)
{
    float y;
    __asm
    {
        fld a;//a
        fld1;//1, a
        fsub;//a -1
        fld st; //a-1,a-1
        fmul st, st(1);//a-1,(a-1)^2
        fmul;
        fmul x;//(a-1)^3 * x
        fld b;//b,(a-1)^3 * x
        fld a;//a,b,(a-1)^3 * x
        fsub;//b-a(a-1)^3 * x
        fld c;//c,b-a(a-1)^3 * x
        fmul;//c(b-a),(a-1)^3 * x
        fadd;//c(b-a) + (a-1)^3 * x
        fld c;
        fld b;
        fsub;
        fld a;
        fmul;
        fadd;
        fstp y;
    }
    return y;
}

int main()
{
    /*float a, b, c, d, x, y;
    cout << "Podaj a: ";
    cin >> a;
    cout << "Podaj b: ";
    cin >> b;
    cout << "Podaj c: ";
    cin >> c;
    cout << "Podaj x: ";
    cin >> x;*/
    /*cout << "Podaj d: ";
    cin >> d;
    cout << a << ' ' << b << ' ' << c << ' ' << d << ' ' << x << endl;
    y = fun_w1(a, b, c, d, x);
    cout << "Wynik = " << y << endl;*/
    /*y = pole(a, b, c);
    cout << "Pole = " << y << endl;
    y = objetosc(a, b, c);
    cout << "Objetosc = " << y << endl;*/
    /*y = zad2(a, b, c, x);
    cout << "Wynik = " << y << endl;
    float y1 = zad2_b(a, b, c, x);
    cout << "Wynik = " << y1 << endl;*/

   /* int N;
    cout << "Podaj N: ";
    cin >> N;

    double* x = new double[N];
    double* z = new double[N];

    for (int i = 0; i < N; i++)
    {
        cout << "Podaj x[" << i << "]: ";
        cin >> x[i];
    }

    for (int i = 0; i < N; i++)
    {
        cout << "Podaj z[" << i << "]: ";
        cin >> z[i];
    }

    for (int i = 0; i < N; i++)
    {
        cout << x[i] << ' ' << z[i] << endl;
    }
    double w = fun_w2(x, z, N);
    cout << "Wynik = " << w << endl;*/

    cout << zad2_n(2) << endl;
    cout << zad3_n(2) << endl;
    cout << zad4_n(4,3,2,1) << endl;
}