%Piotr Krupa
%dane
w1=[-5,5];
w2=[-3,1];
w3=[1,2];
w4=[2,-1];
w5=[-2,4];
w6=[4,-1];

n = input("Podaj ilosc punktow: ");
for i=1:n
  vector_x(i)=input("Podaj x punkt:");
endfor

m1=min(min(vector_x),-6);
m2=max(max(vector_x),6);

disp("Macierz X");
X=[w1(1,1)^0, w1(1,1)^1, w1(1,1)^2,w1(1,1)^3, w1(1,1)^4, w1(1,1)^5;
 w2(1,1)^0, w2(1,1)^1, w2(1,1)^2,w2(1,1)^3, w2(1,1)^4, w2(1,1)^5;
 w3(1,1)^0, w3(1,1)^1, w3(1,1)^2,w3(1,1)^3, w3(1,1)^4, w3(1,1)^5;
 w4(1,1)^0, w4(1,1)^1, w4(1,1)^2,w4(1,1)^3, w4(1,1)^4, w4(1,1)^5;
 w5(1,1)^0, w5(1,1)^1, w5(1,1)^2,w5(1,1)^3, w5(1,1)^4, w5(1,1)^5;
 w6(1,1)^0, w6(1,1)^1, w6(1,1)^2,w6(1,1)^3, w6(1,1)^4, w6(1,1)^5];
disp(X);

disp("Macierz Y");
Y=[w1(1,2);w2(1,2);w3(1,2);w4(1,2);w5(1,2);w6(1,2)];
disp(Y);

disp("Macierz wspolczynnikow");
A=inv(X)*Y;
disp(A);

fprintf(' W(x)=%f*x^5 + %f*x^4 + %f*x^3 +%f*x^2 + %f*x + %f \n',A(6,1), A(5,1), A(4,1), A(3,1), A(2,1), A(1,1));

x=[m1:0.5:m2];
y=zeros(1,13);
y=A(1,1)+A(2,1)*x.+A(3,1)*x.^2+A(4,1)*x.^3+A(5,1)*x.^4+A(6,1)*x.^5;
 
plot(x,y);
grid on;
hold on;

vector_y=A(1,1)+A(2,1)*vector_x.+A(3,1)*vector_x.^2+A(4,1)*vector_x.^3+A(5,1)*vector_x.^4+A(6,1)*vector_x.^5;

plot(vector_x,vector_y,'rx');

plot(w1(1,1),w1(1,2),'--gs');
plot(w2(1,1),w2(1,2),'--gs');
plot(w3(1,1),w3(1,2),'--gs');
plot(w4(1,1),w4(1,2),'--gs');
plot(w5(1,1),w5(1,2),'--gs');
plot(w6(1,1),w6(1,2),'--gs');