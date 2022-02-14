#include<iostream>
#include<fstream>
#include<cmath>
#include<string>
#include<cstring>

using namespace std;

class point
{
    double x, y;
public:
    point(): x(0), y(0){}
    point(const double& x, const double& y):x(x),y(y){}
    
    double& X() {return x;}
    double& Y() {return y;}

    const double& X() const {return x;}
    const double& Y() const {return y;}

    double distance(const point& p) const
    {
        double d = (p.x - x) * (p.x - x) + (p.y - y) * (p.y - y);
        if(d < 1e-20)
        {
            return 0;
        }
        return sqrt(d);
    }

    friend istream& operator>>(istream& in, point& p);
    friend ostream& operator<<(ostream& out, const point& p);
};

istream& operator>>(istream& in, point& p)
{
    return in >> p.x >> p.y;
}
ostream& operator<<(ostream& out, const point& p)
{
    return out << "(" << p.x << "," << p.y << ")";
}

class polygon
{
    unsigned n;
    point* points;
    unsigned* order;
public:
    polygon(): n(0), points(nullptr), order(nullptr){}
    polygon(const polygon& pol): n(pol.n), points(pol.n != 0 ? new point[pol.n] : nullptr), order(pol.n != 0 ? new unsigned[pol.n] : nullptr)
    {
        for (unsigned i = 0; i < pol.n; i++)
        {
            points[i] = pol.points[i];
            order[i] = pol.order[i];
        }
    }
    ~polygon()
    {
        delete[] points;
        delete[] order;
    }

    polygon& operator=(const polygon& pol)
    {
        if(this != &pol)
        {
            n = pol.n;
            if(points != nullptr)
            {
                delete[] points;
                points = nullptr;
            }
            if(order != nullptr)
            {
                delete[] order;
                order = nullptr;
            }
            points = pol.n != 0 ? new point[pol.n] : nullptr; 
            order = pol.n != 0 ? new unsigned[pol.n] : nullptr;
            for (unsigned i = 0; i < pol.n; i++)
            {
                points[i] = pol.points[i];
                order[i] = pol.order[i];
            }
        }
        return *this;
    }

    double obwod() const
    {
        double obw = 0;
        if(!order) throw string ("Brak tablicy order.");
        if(!points) throw string ("Brak tablicy points.");
        for (unsigned i = 0; i < n - 1; i++)
        {
            obw += points[order[i] - 1].distance(points[order[i + 1] - 1]);
        }
        obw += points[order[n-1] - 1].distance(points[order[0] - 1]);
        return obw;
    }

    double pole() const
    {
        double pole = 0;
        for (unsigned i = 0; i < n - 1; i++)
        {
            pole += points[order[i] - 1].X() * points[order[i + 1] - 1].Y() - points[order[i + 1] - 1].X() * points[order[i] - 1].Y();
        }
        pole += points[order[n - 1] - 1].X() * points[order[0] - 1].Y() - points[order[0] - 1].X() * points[order[n - 1] - 1].Y();
        return pole / 2;
    }

    void read(ifstream& read)
    {
        string buf;
        getline(read, buf);

        if(buf!="[POLYGON]") throw string("Brak nagłówka \"[POLYGON]\""); 
        cout << buf << endl;

        getline(read, buf);
        if(buf!="[NUMBER OF NODES]") throw string("Brak nagłówka \"[NUMBER OF NODES]\""); 
        cout << buf << endl;

        read >> n ; 
        getline(read, buf);

        if(!read || buf[0]!='\0' ) throw string("Nieprawidłowy format parmetru \"n\""); 
        cout << n << endl;

        if(n<3) throw string("Liczba punktów mniejsza od 3");

        getline(read, buf);
        if(buf!="[NODES]") throw string("Brak nagłówka \"[NODES]\""); 
        cout << buf << endl;

        if(points != nullptr)
        {
            delete[] points;
            points = nullptr;
        }
        points = new point[n]; 
        for (unsigned i = 0; i < n; i++)
        {
            int t;
            read >> t;
            double x, y;
            read >> x >> y;
            points[t - 1] = point(x,y);
            cout << t - 1 << " " << points[t - i] << '\n';
        }

        getline(read, buf);
        getline(read, buf);
        if(buf!="[POLYGON]") throw string("Brak nagłówka \"[POLYGON]\""); 
        cout << buf << endl;
        
        if(order != nullptr)
        {
            delete[] order;
            order = nullptr;
        }
        order = new unsigned[n];
        for (unsigned i = 0; i < n; i++)
        {
            read >> order[i];
            cout << order[i] << '\n';
        }
    }
};

struct blad {
  string txt;
  unsigned lp;
  blad():lp(0){}
  blad(const string& a, unsigned b):txt(a), lp(b){}
};
ostream& operator<<(ostream& out, const blad& p){return out<<p.txt<< ' ' << p.lp << endl; }


int main (int argc, char* argv[])try {

  if (argc !=2) throw int(0);
  if (strlen(argv[1]) < 5 ) throw int(1);
  if (string(argv[1]+(strlen(argv[1])-3))!="txt") throw 2 ;  

  ifstream file(argv[1]);
  if(!file) throw int (3);
  {
    polygon poly;
    try{
      poly.read(file);
      cout<< "obwód : " << poly.obwod()<< endl;
      cout<< "pole  : " << poly.pole()<< endl;  
    }
    catch ( const string& e ){ cout << e << endl;}
    catch ( const blad&   e ){ cout << e ;}
    file.close();
  }

  #ifdef _WIN32
    system("PAUSE");
  #endif
  return 0;
}
catch (int err){
  switch (err) {
    case 0: cout << err <<": Zła liczba parametrów programu.\n";
    break;
    case 1: cout << err <<": Zła nazwa pliku z danymi.\n";
    break;
    case 2: cout << err <<": Złe rozszerzenie pliku z danymi - musi być *.txt .\n";
    break;
    case 3: cout << err <<": Brak pliku o nazwie "<< argv[1] << " .\n";
  }
}
catch ( ... ) { cout << "Nieznana sytuacja wyjątkowa.\n"; }