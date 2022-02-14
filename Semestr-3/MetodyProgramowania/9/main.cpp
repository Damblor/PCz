#include<iostream>
#include<fstream>
#include<cstdio>
#include<string>

using namespace std;

template<typename T1, typename T2>
class para
{
    T1 f;
    T2 s;
public:
    para(): f(), s(){}
    para(const T1& t1, const T2& t2): f(t1), s(t2){}

    template<typename U, typename Z>
    friend ostream& operator<< (ostream& out, const para<U,Z>& v);
    
    template<typename U, typename Z>
    friend ostream& operator>> (ostream& in, const para<U,Z>& v);
};

template<typename U, typename Z>
ostream& operator<< (ostream& out, const para<U,Z>& v)
{
    out << v.f << ' ' << v.s;
    return out;
}

template<typename U, typename Z>
ostream& operator>> (ostream& in, const para<U,Z>& v)
{
	in >> v.f >> v.s;
	return in;
}

template<typename T>
class vec
{
    size_t s;
    T* tab;

public:
    vec(): s(0), tab(nullptr){}
    vec(const int& w): s(w), tab(s? new T[s] : nullptr){}
    vec(const T* t1, const T* t2): s(t2-t1), tab(s ? new T[s] : nullptr)
    {
        for (size_t i = 0; i < s; i++)
        {
            tab[i] = t1[i];
        }
    }
    vec(const vec& v): s(v.s), tab(s ? new T[s] : nullptr)
    {
        for (size_t i = 0; i < s; i++)
        {
            tab[i] = v.tab[i];
        }
    }
    ~vec() {delete [] tab;}
    int size() const {return s;}
    
    T& operator[] (int i)
    {
        return tab[i];
    }

    vec<T>& operator= (const vec<T>& v)
    {
        if(this == &v) return *this;
        if(tab != nullptr)
            delete[] tab;
        s = v.s;
        tab = s ? new T[s] : nullptr;
        for(size_t i = 0; i < s; i++)
        {
            tab[i] = v.tab[i];
        }
        return *this;
    }

    template<typename U>
    friend ostream& operator<< (ostream& out, const vec<U>& v);
    template<typename U>
    friend ifstream& operator>> (ifstream& in, vec<U>& v);
};

template<typename T>
ostream& operator<< (ostream& out, const vec<T>& v)
{
    for (size_t i = 0; i < v.s; i++)
    {
        out << v.tab[i] << '\n';
    }
    return out;
}


template<typename T>
ifstream& operator>> (ifstream& in, vec<T>& v)
{
    size_t s = 0;
    while (true)
    {
        string k;
        getline(in,k);
        if(!k.empty())
            s++;
        else
            break;
    }
    in.seekg(0);
    v.s = s;
    v.tab = new para<string,int>[s];
    string del = ",";
    for (size_t i = 0; i < s; i++)
    {
        string k;
        getline(in,k);
        string k1 = k.substr(0,k.find(del));
        string k2 = k.erase(0,k1.length() + del.length());
        v.tab[i] = para<string,int>(k1,stoi(k2));
    }
    return in;
}

int main()
{
    vec<int> t1(4);
    for (int i = 0; i < t1.size(); ++i)
    {
        cout << t1[i];
        t1[i] = i;
    }
    cout << '\n';
    cout << t1;

    string s[] = {"Ala", "ma", "kota"};

    const vec<string> s1(s, s+3);
    cout << s1;

    vec<int> t2(t1);
    cout << t2;

    vec<string> s2;
    s2 = s1;
    cout << s2;

    vec< para<string, int> > vp1;

    ifstream plik("data2.csv");
    //...

    plik >> vp1;
    cout << vp1;
    
    para<string,int> vp2;

    //cout << vp1[0] << '\n';

    //...
}
