#include<iostream>

using namespace std;

class komunikator
{
protected:
    static int l_ob;
public:
    virtual ~komunikator(){}
    static int liczba_obiektow() {return l_ob;}

    virtual void wypis(ostream& out) const = 0;
    friend ostream& operator<< (ostream& out, const komunikator& k);
};

ostream& operator<< (ostream& out, const komunikator& k)
{
    k.wypis(out);
    return out;
}

class k1 : public komunikator
{
    string * wsk;
public:
    k1():wsk(nullptr){l_ob++;}
    k1(const string& s): wsk(new string(s)){l_ob++;}
    k1(const k1& k)
    {
        if(wsk != nullptr)
        {
            delete wsk;
            wsk = nullptr;
        }
        wsk = new string(*k.wsk);
        l_ob++;
    }
    ~k1() override
    {
        delete wsk;
        l_ob--;
    }
    k1& operator= (const k1& k)
    {
        if(this == &k) return *this;
        if(wsk != nullptr)
        {
            delete wsk;
            wsk = nullptr;
        }
        wsk = new string(*k.wsk);
        return *this;
    }
    void wypis(ostream& out) const override
    {
        if(wsk == nullptr) throw string("Brak Danych");
        out << *wsk << '\n';
    }
};

class k2 : public komunikator
{
    string * wsk;
    int liczb;
public:
    k2(): wsk(nullptr), liczb(0){l_ob++;}
    k2(const string& s, const int& i): wsk(new string(s)), liczb(i){l_ob++;}
    k2(const k2& k)
    {
        if(wsk != nullptr)
        {
            delete wsk;
            wsk = nullptr;
        }
        wsk = new string(*k.wsk);
        liczb = k.liczb;
        l_ob++;
    }
    ~k2() override
    {
        delete wsk;
        l_ob--;
    }
    k2& operator= (const k2& k)
    {
        if(this == &k) return *this;
        if(wsk != nullptr)
        {
            delete wsk;
            wsk = nullptr;
        }
        wsk = new string(*k.wsk);
        liczb = k.liczb;
        return *this;
    }
    k2& operator+= (const int& l)
    {
        liczb += l;
        return *this;
    }
    void wypis(ostream& out) const override
    {
        if(wsk == nullptr) throw string("Brak Danych");
        out << *wsk << ' ' << liczb << '\n';
    }
};
int komunikator::l_ob = 0;
int main()
{
    komunikator * linia[5];
    const k1 koniec("Koniec komunikatorow");
    linia[0] = new k1("Temperatura powietrza: ");
    linia[1] = new k2("Czestochowa",-5);
    linia[2] = new k1("Opady sniegu (cm): ");
    linia[3] = new k2("Katowice",10);
    linia[4] = new k1(koniec);
    
    for(int i = 0; i < 5; i++)
    {
        cout << *linia[i];
    }
    cout << "************* 3 ************\n";
    
    *(static_cast<k2*>(linia[1])) += 2;
    *(static_cast<k2*>(linia[3])) += 2;
    for(int i = 0; i < 5; i++)
    {
        cout << *linia[i];
        delete linia[i];
    }
    cout << "************* 4 ************\n";

    cout << "Liczba: " << komunikator::liczba_obiektow() << '\n';
    linia[0] = new k1("Temperatura powietrza: ");
    linia[1] = new k2;
    linia[2] = new k1("Opady sniegu (cm): ");
    linia[3] = new k2;
    linia[4] = new k1(koniec);
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