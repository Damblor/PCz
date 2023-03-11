#include<iostream>
#include<string>

using namespace std;

class adres
{
    string m_miasto;
    string m_ulica;
    int m_nrBudynku;
public:
    adres(){}
    adres(const string& _miasto, const string& _ulica, const int& _nr):m_miasto(_miasto),m_ulica(_ulica),m_nrBudynku(_nr){}
    
    string& miasto(){return m_miasto; }
    
    ostream& view(ostream& out)const{
        return out << m_miasto << ", " << m_ulica << ", " << m_nrBudynku << '\n';
    }
    friend ostream& operator<< (ostream& out, const adres& r);
};
ostream& operator<< (ostream& out, const adres& r){
  return r.view(out);
}
class osoba
{
    string m_imie;
    int m_wiek;
    adres* m_adres;
public:
    osoba(){}
    osoba(const osoba& _osoba):m_imie(_osoba.m_imie),m_wiek(_osoba.m_wiek),m_adres(new adres(*_osoba.m_adres)){}
    osoba(const string& _imie, const int& _wiek, const adres& _adres):m_imie(_imie),m_wiek(_wiek),m_adres(new adres(_adres)){}
    ~osoba(){ u(); }
    string& miasto() {return m_adres->miasto();}
    friend ostream& operator<< (ostream& out, const osoba& r);
    osoba& operator= (const osoba& _osoba)
    {
        m_imie = _osoba.m_imie;
        m_wiek = _osoba.m_wiek;
        u();
        m_adres = new adres(*_osoba.m_adres);
        return *this;
    }
    ostream& view(ostream& out)const{
        if(m_adres != nullptr)
        {
            return out << m_imie << ", " << m_wiek << ", " << *m_adres << '\n';
        }
        else
        {
            return out << m_imie << ", " << m_wiek << '\n';
        }
    }

    void u()
    {
        if(m_adres != nullptr)
        {
            delete m_adres;
            m_adres = nullptr;
        }
    }
};

ostream& operator<< (ostream& out, const osoba& r){
    return r.view(out); 
}
int main()
{
    adres* wsk = new adres("Częstochowa", "Dąbrowskiego", 73);

    cout <<  wsk << '\n';
    cout << *wsk << '\n';

    adres a1(*wsk);
    delete wsk;
    wsk=nullptr;

    const adres* wsk1 = new adres("Łódź", "Piotrkowska", 33);

    cout << a1 << '\n';
    cout << *wsk1 << '\n';

    adres a2;
    cout << a2 << '\n';
    a2 = a1;
    cout << a2 << '\n';

    osoba os1("Ala", 25, *wsk1);
    delete wsk1;

    cout << os1 << '\n';
    osoba os2(os1);

    os1.miasto()="Zmieniono miasto osoby 1.";
    cout << os2 << '\n';

    osoba os3;
    cout << os3 << '\n';
    os3 = os2;

    os1.miasto()="Drugi raz zmieniono miasto osoby 1.";
    cout << os3 << '\n';
}