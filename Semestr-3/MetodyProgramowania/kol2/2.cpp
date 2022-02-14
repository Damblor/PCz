#include <iostream>
#include <string>

using namespace std;

class B
{
public:
    virtual ~B(){}
    virtual void wypisz(ostream& out) const = 0;
    virtual B* copy() const = 0;

    friend ostream& operator<< (ostream& out, const B& b);
};

ostream& operator<< (ostream& out, const B& b)
{
    b.wypisz(out);
    return out << '\n';
}

class P1 : public B
{
    string * st;
public:
    P1() : st(nullptr){}
    P1(const string& s) : st(nullptr)
    {
        st = new string(s);
    }
    P1(const P1& p): st(nullptr)
    {
        st = new string(*p.st);
    }
    ~P1(){delete st;}

    void wypisz(ostream& out) const override
    {
        out << *st;
    }

    P1* copy() const override
    {
        return new P1(*this);
    }

    P1& operator= (const P1& p)
    {
        if(this == &p) return *this;
        if(st != nullptr)
            delete st;
        st = new string(*p.st);
        return *this;
    }

    P1& operator+= (const string& s)
    {
        string t = *st + s;
        if(st != nullptr)
            delete st;
        st = new string(t);
        return *this;
    }

    friend P1 operator+ (const string& s, const P1& p);
};

P1 operator+ (const string& s, const P1& p)
{
    *p.st = s + ' ' + *p.st;
    return p;
}

class P2 : public B
{
protected:
    P1 * p1;
public:
    P2() : p1(nullptr){}
    P2(const string& s) : p1(nullptr)
    {
        p1 = new P1(s);
    }
    P2(const P2& p) : p1(nullptr)
    {
        p1 = new P1(*p.p1);
    }
    ~P2(){delete p1;}

    void wypisz(ostream& out) const override
    {
        p1->wypisz(out);
    }

    P2* copy() const override
    {
        return new P2(*this);
    }

    P2& operator= (const P2& p)
    {
        if(this == &p) return *this;
        if(p1 != nullptr)
            delete p1;
        p1 = new P1(*p.p1);
        return *this;
    }

    P2& operator+= (const string& s)
    {
        *p1 += s;
        return *this;
    }

};

class P3 : public P2
{
    int liczb;
public:
    P3() : P2(), liczb(0){}
    P3(const string& s, const int& l) : P2(s), liczb(l){}
    P3(const P3& p): P2(), liczb(p.liczb)
    {
        p1 = new P1(*p.p1);
    }
    ~P3(){}

    void wypisz(ostream& out) const override
    {
        p1->wypisz(out);
        out << ' ' << liczb;
    }

    P3* copy() const override
    {
        return new P3(*this);
    }

    P3& operator= (const P3& p)
    {
        if(this == &p) return *this;
        if(p1 != nullptr)
            delete p1;
        p1 = new P1(*p.p1);
        liczb = p.liczb;
        return *this;
    }
    P3& operator += (const int& i)
    {
        liczb += i;
        return *this;
    }
};

void kopia_danych(B** b1, B** b2, const int& n)
{
    for (int i = 0; i < n; i++)
    {
        b2[i] = b1[i]->copy();
    }
}

int main()
{
    const P1* wsk1 = new P1("Ala");
    const P2* wsk2 = new P2("koty");
    const P3* wsk3 = new P3("ma", 2);

    P1 x; x = *wsk1; delete wsk1;
    P2 y; y = *wsk2; delete wsk2;
    P3 z; z = *wsk3; delete wsk3;

    B * tab1[3];
    tab1[0] = new P1(x);
    tab1[1] = new P3(z);
    tab1[2] = new P2(y);

    for (int i = 0; i < 3; i++)
        cout << *tab1[i];

    for (int i = 0; i < 3; i++)
        delete tab1[i];
    
    cout << "****** 3 ******\n";

    x = "Mala" + x; // ta linijka
    z += 2;

    tab1[0] = new P1(x);
    tab1[1] = new P3(z);
    tab1[2] = new P2(y);

    for (int i = 0; i < 3; i++)
        cout << *tab1[i];
    
    cout << "****** 4 ******\n";

    B * tab2[3];

    kopia_danych(tab1, tab2, 3);

    *static_cast<P2*>(tab2[2]) += " i psa.";

    for (int i = 0; i < 3; i++)
        delete tab1[i];

    for (int i = 0; i < 3; i++)
        cout << *tab2[i];

    for (int i = 0; i < 3; i++)
        delete tab2[i];
    
    cout << "****** 5 ******\n";
    return 0;
}