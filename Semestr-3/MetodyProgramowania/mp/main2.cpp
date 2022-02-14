#include<iostream>

using namespace std;

class robot
{
public:
    static int liczba_obiektow;
public:
    virtual ~robot(){}
    virtual void praca() const = 0;
    virtual void wypisz(ostream& out) const = 0;
    virtual robot& operator-= (const int& l) = 0;
    friend ostream& operator<< (ostream& out, const robot& r);
};

ostream& operator<< (ostream& out, const robot& r)
{
    r.wypisz(out);
    return out;
}

class rt1 : public robot
{
    string * wsk;
public:
    rt1(): wsk(nullptr){liczba_obiektow++;}
    rt1(const string& s): wsk(new string(s)){liczba_obiektow++;}
    rt1(const rt1& rt): wsk(nullptr)
    {
        if(wsk != nullptr)
        {
            delete wsk;
            wsk = nullptr;
        }
        wsk = new string(*rt.wsk);
        liczba_obiektow++;
    }
    ~rt1()
    {
        delete wsk;
        liczba_obiektow--;
    }

    void praca() const override
    {
        cout << *wsk << '\n';
    }

    void wypisz(ostream& out) const override
    {
        if(wsk == nullptr) throw string("Robot  niezaprogramowany");
        out << *wsk << '\n';
    }

    rt1& operator-= (const int& l) override
    {
        return *this;
    }

    rt1& operator= (const rt1& rt)
    {
        if(this == &rt) return *this;
        if(wsk != nullptr)
        {
            delete wsk;
            wsk = nullptr;
        }
        wsk = new string(*rt.wsk);
        return *this;
    }
};

class rt2 : public robot
{
    string * wsk;
    int liczb;
public:
    rt2(): wsk(nullptr), liczb(0){liczba_obiektow++;}
    rt2(const string& s, const int& l): wsk(new string(s)), liczb(l){liczba_obiektow++;}
    rt2(const rt2& rt): wsk(nullptr)
    {
        if(wsk != nullptr)
        {
            delete wsk;
            wsk = nullptr;
        }
        wsk = new string(*rt.wsk);
        liczb = rt.liczb;
        liczba_obiektow++;
    }
    ~rt2()
    {
        delete wsk;
        liczba_obiektow--;
    }

    void praca() const override
    {
        cout << *wsk << ' ' << liczb << '\n';
    }

    void wypisz(ostream& out) const override
    {
        if(wsk == nullptr) throw string("Robot  niezaprogramowany");
        out << *wsk << ' ' << liczb << '\n';
    }

    rt2& operator-= (const int& l) override
    {
        liczb -= l;
        return *this;
    }

    rt2& operator= (const rt2& rt)
    {
        if(this == &rt) return *this;
        if(wsk != nullptr)
        {
            delete wsk;
            wsk = nullptr;
        }
        wsk = new string(*rt.wsk);
        liczb = rt.liczb;
        return *this;
    }
};

int robot::liczba_obiektow = 0;

int main()
{
    robot * linia[5];
    const rt1 odbior("odebrano gotowy produkt");
    linia[0] = new rt1("polozono");
    linia[1] = new rt2("uderzono",5);
    linia[2] = new rt2("prawo",4);
    linia[3] = new rt2("uderzono",7);
    linia[4] = new rt1(odbior);

    for(int i = 0; i < 5; i++)
    {
        linia[i]->praca();
    }

    cout << "************* 3 ************\n";
    
    *linia[3] -= 5;
    for(int i = 0; i < 5; i++)
    {
        cout << *linia[i];
        delete linia[i];
    }
    cout << "************* 4 ************\n";

    cout << "Liczba robotow: " << robot::liczba_obiektow << '\n';
    linia[0] = new rt1("polozono");
    linia[1] = new rt2;
    linia[2] = new rt1("polozono");
    linia[3] = new rt2;
    linia[4] = new rt1(odbior);
    for(int i = 0; i < 5; i++)
    {
        try
        { 
            cout << *linia[i];
        }
        catch(const string& e)
        {
            cout << e << '\n';
        }
        
    }
    for(int i = 0; i < 5; i++)
    {
        delete linia[i];
    }
    cout << "************* 5 ************\n";
}