#include <iostream>
#include <vector>
#include <iterator>
#include <algorithm>
#include <list>
#include <set>

using namespace std;

class losuj
{
	unsigned min;
	unsigned max;
public:
    losuj(unsigned min, unsigned max): min(min), max(max){}

    unsigned operator()() const
    {
        return rand() % (max - min + 1) + min;
    }
};

class alg1
{
	unsigned min;
	unsigned max;
public:
    alg1(unsigned min, unsigned max): min(min), max(max){}

    bool operator()(const unsigned& l) const
    {
        if(l >= min && l <= max) return false;
        return true;
    }

};

int main()
{
    vector<unsigned> ve(25);
    generate_n(ve.begin(),25,losuj(26,89));
    copy(ve.begin(), ve.end(), ostream_iterator<unsigned>(cout, ", "));
    cout << endl;
    sort(ve.begin(),ve.end());
    ve.erase(unique(ve.begin(),ve.end()),ve.end());

	/*set<unsigned> s;
	for(unsigned i = 0; i < 25; i++)
		s.insert(ve[i]);
	ve.assign(s.begin(),s.end());*/

    copy(ve.begin(), ve.end(), ostream_iterator<unsigned>(cout, ", "));
    cout << endl;

    list<unsigned> li;
    remove_copy_if(ve.begin(),ve.end(),back_inserter(li),alg1(35,75));
 
    cout <<"\n lista\n";
    ostream_iterator<unsigned> iter(cout, ", ");
    copy(li.begin(), li.end(), iter);
    cout << endl;
    return 0;
}
