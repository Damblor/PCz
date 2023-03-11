#include<iostream>
#include<string>

using namespace std;

class pomiar
{
protected:
    string opis;
    size_t rozmiar;
    double * tab;
public:
    pomiar(): opis(""), rozmiar(0), tab(nullptr){}
    pomiar(const string& o, double * b = nullptr, double * e = nullptr): opis(o), rozmiar(e-b), tab(rozmiar ? new double[e-b] : nullptr)
    {
        for(size_t i = 0; i < rozmiar; i++)
        {
            tab[i] = b[i];
        }
    }
    pomiar(const pomiar& p): opis(p.opis), rozmiar(p.rozmiar), tab(rozmiar ? new double[rozmiar] : nullptr)
    {
        for(size_t i = 0; i < rozmiar; i++)
        {
            tab[i] = p.tab[i];
        }
    }

    virtual ~pomiar()
    {
        if(rozmiar)
            delete[] tab;
    }
    
    virtual string pokaz_opis() const = 0;
    virtual double oblicz_wynik() const = 0;

    pomiar& operator= (const pomiar& p)
    {
        if(this == &p) return *this;
        opis = p.opis;
        rozmiar = p.rozmiar;
        tab = rozmiar ? new double[rozmiar] : nullptr;
        for(size_t i = 0; i < rozmiar; i++)
        {
            tab[i] = p.tab[i];
        }
        return *this;
    }

    pomiar& operator+= (const string& s)
    {
        opis = opis + ' ' + s;
        return *this;
    }

    pomiar& operator+= (const double& d)
    {
        for(size_t i = 0; i < rozmiar; i++)
        {
            tab[i] += d;
        }
        return *this;
    }

    pomiar& operator*= (const double& d)
    {
        for(size_t i = 0; i < rozmiar; i++)
        {
            tab[i] *= d;
        }
        return *this;
    }


    friend ostream& operator<< (ostream& o, const pomiar& p);
    friend pomiar& operator+ (const string& sm, pomiar& p);
};

ostream& operator<< (ostream& o, const pomiar& p)
{
    return o << p.pokaz_opis();
}

pomiar& operator+ (const string& sm, pomiar& p)
{
    p.opis = sm + p.opis;
    return p;
}

class ciezar : public pomiar
{

public:
    ciezar(): pomiar(){}
    ciezar(const string& o,double * b = nullptr, double * e = nullptr): pomiar(o,b,e){}

    string pokaz_opis() const override
    {
        return "Ciezar - \"" + opis + "\"";
    }

    double oblicz_wynik() const override
    {
        double result = 0;
        if(rozmiar == 0) throw string("Brak Danych");
        for(size_t i = 0; i < rozmiar; i++)
        {
            result += tab[i];
        }
        return result;
    }
};

class temp : public pomiar
{

public:
    temp():pomiar(){}
    temp(const string& o,double * b = nullptr, double * e = nullptr): pomiar(o,b,e){}

    string pokaz_opis() const override
    {
        return "Temperatura - \"" + opis + "\"";
    }

    double oblicz_wynik() const override
    {
        double result = 0;
        if(rozmiar == 0) throw string("Brak Danych");
        for(size_t i = 0; i < rozmiar; i++)
        {
            result += tab[i];
        }
        return result / rozmiar;
    }
};

void pokaz_wszystko(ostream& o, const pomiar& p)
{
    try
    {    
        o << p << ", WYNIK : " << p.oblicz_wynik() << endl ;
    }
    catch (const string& a)
    {
        o << a << endl;
    }
}

int main()
{
    //...

    double dane[] = { 0.0, 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.8 };

    //... zdefiniuj tablicę tab
    pomiar * tab[5];

    tab[0] = new ciezar("cytryny") ;
    tab[1] = new temp("poranki", dane+3, dane+6);
    tab[2] = new ciezar("jabłka", dane+1, dane+3) ;
    tab[3] = new temp("wieczory", dane+1, dane+9);
    tab[4] = new ciezar;

    cout << "********** 1 **********" << endl;
    for (int i=0; i<5; ++i)
        cout << *tab[i] << endl ;


    cout << "\n********** 2 **********" << endl;

    for (int i=0; i<5; ++i)
    {
        try
        {    
            cout << *tab[i] << ", WYNIK : " << tab[i]->oblicz_wynik() << endl ;
        }
        catch (const string& a)
        {
            cout << a << endl;
        }
    }


    cout << "\n********** 2a *********" << endl;
    *tab[0] = ciezar("cytryny", dane, dane+1);
    *tab[0] = ("[kg] " + *tab[0]) += "po wyprzedaży";
    *tab[1]  = "Wiosenne " + *tab[1];
    *tab[2] += "ANTONÓWKI suszone";
    *tab[2] *= 0.1;
    *tab[3] += "po korekcie odczytu";
    *tab[3] += 0.1;

    for (int i=0; i<5; ++i)
    {
        try
        {    
            cout << *tab[i] << ", WYNIK : " << tab[i]->oblicz_wynik() << endl ;
        }
        catch (const string& a)
        {
            cout << a << endl;
        }
    }

    for (int i=0; i<5; ++i)
        delete tab[i];


    cout << "\n********** 3 **********" << endl;  
    const ciezar test1("gruszki", dane, dane+9);
    const temp test2;

    //w odpowiednim miejscu zdefiniuj funkcję pokaz_wszystko(...)

    pokaz_wszystko(cout, test1);
    pokaz_wszystko(cout, test2);
    pokaz_wszystko(cout, ciezar());
    pokaz_wszystko(cout, temp("Jakaś tam", dane+8, dane+9));
}