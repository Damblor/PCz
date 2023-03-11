#include <string>
#include <vector>

class A
{
private:
	int a;
	int b;
	bool stan;
	B* b;
public:
	A();
	~A()
	{
		delete b;
	}
	B getB(char);
	bool metA(int);
};

class B
{
private:
	int cs;
	C* c;
public:
	void oper1();
	bool oper2(double);
	void oper3(int);
};

class C
{
private:
	int lp;
	std::string np;
	double wt;
	D lokD;
	std::vector<*B> b;
public:
	C();
};

class D
{
private:
	double lc;
	std::string np1;
	std::string np2;
	E* lokE;
public:
	D();
};

class E
{
private:
	std::string op;
	A* a;
public:
	E();
	~E()
	{
		delete a;
	}
	void op1(int, std::string);
	void op2(float);
};

class F : G
{
private:
	std::string op;
	int x;
	int y;
public:
	F();
	std::vector<*A> tF;
};

class G
{
public:
	G();
	void op1();
	void op2();
	double op3(double);
};
