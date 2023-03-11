#include<iostream>
#include<cmath>

using namespace std;

class punkt
{
    double m_x, m_y;
public:
    punkt() : m_x(0), m_y(0){}
    punkt(const double& _x, const double& _y) : m_x(_x), m_y(_y){}
    double& x(){return m_x; }
    double& y(){return m_y; }

    double odleglosc(const punkt& _p)
    {
        double x = m_x - _p.m_x;
        double y = m_y - _p.m_y;
        return sqrt(x*x + y*y);
    }
    friend ostream& operator<< (ostream& out, const punkt& r);
};
ostream& operator<< (ostream& out, const punkt& r)
{
    return out << "(" << r.m_x << "," << r.m_y << ")";
}
class wielobok
{
    size_t m_rozmiar;
    punkt* m_punkty;
public:
    wielobok() : m_rozmiar(0), m_punkty(new punkt[0]){}
    wielobok(const punkt* _p, const punkt* _r) : m_rozmiar(_r-_p), m_punkty(new punkt[_r-_p])
    {
        for (size_t i = 0; i < m_rozmiar; i++)
        {
            m_punkty[i] = _p[i];
        }
    }
    wielobok(const wielobok& _r) : m_rozmiar(_r.m_rozmiar), m_punkty(new punkt[_r.m_rozmiar])
    {
        for (size_t i = 0; i < m_rozmiar; i++)
        {
            m_punkty[i] = _r.m_punkty[i];
        }
    }
    ~wielobok() {delete[] m_punkty; }
    wielobok& operator= (const wielobok& _r)
    {
        m_rozmiar = _r.m_rozmiar;
        if(m_punkty != nullptr)
        {
            delete[] m_punkty;
            m_punkty = nullptr;
        }
        m_punkty = new punkt[m_rozmiar];
        for (size_t i = 0; i < m_rozmiar; i++)
        {
            m_punkty[i] = _r.m_punkty[i];
        }
        return *this;
    }
    punkt& operator[] (size_t i)
    {
        return m_punkty[i];
    }

    size_t ilosc() const {return m_rozmiar; }

    double obwod()
    {
        double obwod = 0;
        for(size_t i = 0; i < m_rozmiar - 1; i++)
        {
            obwod+=m_punkty[i].odleglosc(m_punkty[i+1]);
        }
        obwod+=m_punkty[m_rozmiar-1].odleglosc(m_punkty[0]);
        return obwod;
    }

    friend ostream& operator<< (ostream& out, const wielobok& r);
};

ostream& operator<< (ostream& out, const wielobok& r)
{
    for(size_t i=0; i < r.m_rozmiar; ++i)
        cout << i+1 << ")  " << r.m_punkty[i] << endl;
    return out;
}

int main()
{
    punkt p(2, 3);
    cout << p.x() << ' ' << p.y() << '\n';
    p.x() = 1;
    p.y() = 1;
    cout << p.x() << ' ' << p.y() << '\n';
    cout << p.odleglosc(punkt()) << "\n\n";
    const punkt t[] = { punkt(0, 0), punkt(0, 1), punkt(1, 1), punkt(1, 0) };
    for(size_t i=0; i < sizeof(t)/sizeof(punkt); ++i)
        cout << i+1 << ")  " << t[i] << endl;

    cout << "\n*****\n";
    wielobok w1(t, t+4);
    cout << w1.obwod() << '\n';

    w1[1] = punkt(0.5, 0.5);
    cout << w1.obwod() << '\n';
    cout << "***\n\n";  


    wielobok w2;
    w2 = wielobok(t, t+3);
    cout << w2.obwod() << '\n';

    for (size_t i = 0; i < w2.ilosc(); ++i)
        cout << w2[i].x() << ' ' << w2[i].y() << '\n';

    cout << "\n*****\n";
    wielobok w3(w2);
    w3[1] = punkt(0, -1);
    w3[2] = punkt(-1, -1);
    for (size_t i = 0; i < w3.ilosc(); ++i)
        cout << w3[i] << endl;
    cout << "***\n\n";

    cout << "\n*****\n";
    cout << w2 << "***\n" << w3;
    cout << "*****\n\n";

    cout << w2.obwod() - w3.obwod() << "\n\n";
}