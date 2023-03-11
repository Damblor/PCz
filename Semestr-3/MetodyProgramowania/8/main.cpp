#include<iostream>
#include<string>
#include<vector>

using namespace std;

class robot;
using wsk = robot*;

class robot
{
protected:
    static int l_ob;
public:
    virtual ~robot() {cout << "~robot()\n";}

    static int l_obiektow() {return l_ob;}

    virtual void praca() const = 0;
    virtual robot* clone() const = 0;
};

class r1 : public robot
{
public:
    r1(){l_ob++;}
    r1(const r1& r){l_ob++;}
    ~r1(){cout << "~r1()\n"; l_ob--;}

    void praca() const override
    {
        cout << "r1\n";
    }
    r1* clone() const override
    {
        return new r1(*this);
    }

};

class r2 : public robot
{
public:
    r2(){l_ob++;}
    r2(const r2& r){l_ob++;}
    ~r2(){cout << "~r2()\n"; l_ob--;}

    void praca() const override
    {
        cout << "r2\n";
    }

    r2* clone() const override
    {
        return new r2(*this);
    }
};

class line
{
vector<wsk> ve;
public:
    line(){}
    line(const int& r): ve(r)
    {
        cout << "Wartosci wektora ve: ";
        for(size_t i = 0; i < ve.size(); i++)
        {
            cout << ve[i] << ", ";
        }
        cout << '\n';
    }
    line(const line& l): ve(l.ve.size())
    {
        for(size_t i = 0; i < ve.size(); i++)
        {
            ve[i] = l.ve[i]->clone();
        }
    }
    line(const wsk* b, const wsk* e): ve(e-b)
    {
        for(size_t i = 0; i < ve.size(); i++)
        {
            ve[i] = b[i]->clone();
        }
    }
    ~line()
    {
        for(size_t i = 0; i < ve.size(); i++)
        {
            delete ve[i];
        }
        cout << "~line()\n";
    }

    line& operator= (const line& l)
    {
        if(this == &l) return *this;
        for(size_t i = 0; i < ve.size(); i++)
        {
            delete ve[i];
        }
        ve.clear();
        for(size_t i = 0; i < l.ve.size(); i++)
        {
            ve.push_back(l.ve[i]->clone());
        }
        return *this;
    }


    void dodaj_ostatni(const wsk& arg)
    {
        ve.push_back(arg);
    }
    void usun_ostatni()
    {
        delete ve[ve.size() - 1];
        ve.pop_back();
    }
    void usun_wszystkie()
    {
        for(size_t i = 0; i < ve.size(); i++)
        {
            delete ve[i];
        }
        ve.clear();
    }
    void dodaj_ity(int i, const wsk& arg)
    {
        ve.insert(ve.begin() + i, arg);
    }
    void usun_ity(int i)
    {
        delete ve[i];
        ve.erase(ve.begin() + i);
    }
    void do_roboty()
    {
        for (size_t i = 0; i < ve.size(); i++)
        {
            ve[i]->praca();
        }
    }
};

int robot::l_ob = 0;
void liczba_obiektow()
{
    cout << "liczba_obiektów = " << robot::l_obiektow() << endl;
}

int main()
{
    try
    {
        {
            liczba_obiektow();
            { line l1 ;    }
            { line l2(5) ; }
            liczba_obiektow();
            cout << "--==**1**==--" << endl;
            line lp1, lp2;
            //liczba_obiektow();
            lp1.dodaj_ostatni(new r1);
            lp1.dodaj_ostatni(new r1);
            lp1.dodaj_ostatni(new r2);
            lp1.dodaj_ostatni(new r2);
            //liczba_obiektow();
            lp2=lp1;
            //liczba_obiektow();
            {
                line lp3;
                //liczba_obiektow();
                lp3.dodaj_ostatni(new r1);
                lp3.dodaj_ostatni(new r2);
                lp3.dodaj_ostatni(new r1);
                lp3.dodaj_ostatni(new r2);
                //liczba_obiektow();
                lp3.usun_ostatni();     
                //liczba_obiektow();
                cout << "--==**2**==--" << endl;
                //liczba_obiektow();
                lp3.do_roboty();       
                //liczba_obiektow();
                lp1 = lp3;
                cout << "--==**2a**==--" << endl;      
                liczba_obiektow();
            }
            liczba_obiektow();
            cout << "--==**3**==--" << endl;
            lp1.do_roboty();     
            cout << "--==**4**==--" << endl;

            wsk TabAdrRob[] = {new r2, new r2};
            //liczba_obiektow();
            line lp4(TabAdrRob, TabAdrRob+2 );
            lp4.dodaj_ity(1, new r1);
            //liczba_obiektow();
            lp4.do_roboty();
            cout << "--==**5**==--" << endl;
            //liczba_obiektow();
            lp4 = lp2;
            lp4.do_roboty();
            cout << "--==**6**==--" << endl;
            line lp6(lp1);
            lp6.usun_ity(1);        
            //Usuń robot na pozycji o indeksie 1
            lp6.do_roboty();
            cout << "--==**7**==--" << endl;
    
            //liczba_obiektow();
            delete TabAdrRob[0];
            delete TabAdrRob[1];
        }
        liczba_obiektow();
    }
    catch(...)
    {
        cout << "Ooooops!\nCoś poszło nie tak.\n";
    }
    
}
