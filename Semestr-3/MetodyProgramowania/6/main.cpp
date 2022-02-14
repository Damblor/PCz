#include<iostream>

using namespace std;

class osoba
{
string nazwisko;
int wiek;
public:
    osoba(): nazwisko(""), wiek(0){}
    osoba(const string& n, const int& w): nazwisko(n), wiek(w){}
    
    string& Nazwisko() {return nazwisko; }
    int& Wiek() {return wiek;}

    const string& Nazwisko() const {return nazwisko; }
    const int& Wiek() const {return wiek;}

    void pokaz()
    {
        cout << nazwisko << ' ' << wiek << '\n';
    }
};

class pracownik : public osoba
{
string st;
double pl;
public:
    pracownik(): osoba(), st(""), pl(0){}
    pracownik(const string& n, const int& w, const string& s, const int& p): osoba(n,w), st(s), pl(p){}\
    pracownik(const pracownik& pr): osoba(pr.Nazwisko(),pr.Wiek()),st(pr.st),pl(pr.pl){}

    pracownik& operator= (const pracownik& pr)
    {
        osoba(pr.Nazwisko(), pr.Wiek());
        st = pr.st;
        pl = pr.pl;
        return *this;
    }


    string& nazwisko() {return Nazwisko(); }
    int& liczba_lat() {return Wiek(); }
    string& stanowisko() {return st; }
    double& placa() {return pl; }

    const string& nazwisko() const {return Nazwisko(); }
    const int& liczba_lat() const {return Wiek(); }
    const string& stanowisko() const {return st; }
    const double& placa() const {return pl; }

    void pokaz()
    {
        cout << Nazwisko() << ' ' << Wiek() << ' ' << st << ' ' << pl << '\n';
    }
};

int main()
{
    osoba os("Dolas", 26);
    os.pokaz();

    const pracownik pr1("Dyzma", 35, "mistrz", 1250.0);      
    cout << pr1.nazwisko() << pr1.liczba_lat();
    cout << pr1.stanowisko() << pr1.placa();

    pracownik pr2(pr1);
    pr2.pokaz();

    pracownik pr3("Kos", 45, "kierownik", 2999.0);
    pr3.pokaz();
    pr3 = pr2;
    pr3.pokaz();

    osoba* w = &os;
    w->pokaz();
    w = &pr3;
    w->pokaz();

    static_cast<pracownik*>(w)->pokaz();
}