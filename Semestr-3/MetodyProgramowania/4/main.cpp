#include<iostream>
#include<cmath>

using namespace std;

class point
{
    double m_tab[3];
public:
    point(): m_tab {0,0,0}{}
    point(const double& _x, const double& _y, const double& _z): m_tab {_x, _y, _z}{}
    point(const double(& _a)[3])
    {
        for (size_t i = 0; i < 3; i++)
        {
            m_tab[i] = _a[i];
        }
    }
    point(const point* _p)
    {
        for (size_t i = 0; i < 3; i++)
        {
            m_tab[i] = _p->m_tab[i];
        }
    }

    double distance(const point& _p) const
    {
        double x = m_tab[0] - _p.m_tab[0];
        double y = m_tab[1] - _p.m_tab[1];
        double z = m_tab[2] - _p.m_tab[2];
        return sqrt(x*x+y*y+z*z);
    }

    friend bool operator== (const point& _p1, const point& _p2);
    friend bool operator< (const point& _p1, const point& _p2);
    friend point operator* (const double& _n, const point& _p);
    friend point operator* (const point& _p, const double& _n);

    friend ostream& operator<< (ostream& out, const point& _r);
    friend istream& operator>> (istream& in, const point& _r);
    friend point operator- (const point& _p1, const point& _p2);
    friend point operator+ (const point& _p1, const point& _p2);

    double& operator[] (int _i)
    {
        return m_tab[_i];
    }

    const double& operator[] (int _i) const
    {
        return m_tab[_i];
    }
};

bool operator== (const point& _p1, const point& _p2)
{
    if(&_p1 == &_p2)
    {
        return true;
    }
    return false;
}

bool operator< (const point& _p1, const point& _p2)
{
    if(&_p1 < &_p2)
    {
        return true;
    }
    return false;
}

point operator* (const double& _n, const point& _p)
{
    double x = _p.m_tab[0] * _n;
    double y = _p.m_tab[1] * _n;
    double z = _p.m_tab[2] * _n;
    return point(x, y, z);
}

point operator* (const point& _p, const double& _n)
{
    double x = _p.m_tab[0] * _n;
    double y = _p.m_tab[1] * _n;
    double z = _p.m_tab[2] * _n;
    return point(x, y, z);
}

ostream& operator<< (ostream& out, const point& _r)
{
    return out << "(" << _r.m_tab[0] << "," << _r.m_tab[1] << "," << _r.m_tab[2] << ")";
}

istream& operator>> (istream& in, point& _r)
{
    in >> _r[0];
    in >> _r[1];
    return in >> _r[2];
}

point operator- (const point& _p1, const point& _p2)
{
    double x = _p1.m_tab[0] - _p2.m_tab[0];
    double y = _p1.m_tab[1] - _p2.m_tab[1];
    double z = _p1.m_tab[2] - _p2.m_tab[2];
    return point(x, y, z);
}

point operator+ (const point& _p1, const point& _p2)
{
    double x = _p1.m_tab[0] + _p2.m_tab[0];
    double y = _p1.m_tab[1] + _p2.m_tab[1];
    double z = _p1.m_tab[2] + _p2.m_tab[2];
    return point(x, y, z);
}

int main()
{
    //...
    double x[2][3] = {{1.0, 1.0, 1.0},
                    {1.0, 2.0, 3.0}};

    point p1(x[0]), p2(x[1]); 
    const point p3(0.4, 0.2, 0.1);

    cout << p1 << ", " << p2 << '\n';
    cout << p3[0] << ' ' << p3[1] << ' ' << p3[2] << '\n';
    cout << p1.distance(point()) << endl;
    cout << p3.distance(p1) << endl;

    cout << "***************\n";
    cout << p1 + p2 << endl;
    cout << p1 - p3 << endl;
    cout << "***************\n";
    cout << "***************\n";
    cout << 3.14 * p2 << endl;
    cout << p2 * 3.14 << endl;
    cout << "***************\n";
    cout << (p1 < p3) << endl;
    cout << (p1 == point(1.0, 1.0, 1.0)) << endl;
    cout << "***************\n";
    cin >> p1;
    cout << "***************\n";
    cout << p1 << '\n';
}