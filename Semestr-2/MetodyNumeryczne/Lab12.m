clear;

fx=inline("0.8*x^3+5.5*x+12");

a=0;
b=15;

function Prost(fx,n,a,b)
  p=(b-a)/n;
  s=0;
  for i=0:n-1
    s+=fx(a+p*i+p/2);
  endfor
  calka= p*s;
  fprintf("Calka dla n =%d wynosi: %f\n",n,calka);
endfunction

function Trap(fx,n,a,b)
  p=(b-a)/n;
  s=0;
  for i=1:n-1
    s+=fx(a+p*i);
  endfor
  s+=(fx(a)+fx(b))/2;
  calka= p*s;
  fprintf("Calka dla n =%d wynosi: %f\n",n,calka);
  
  
endfunction

fprintf("Metoda prostokatow\n");
Prost(fx,15,a,b);
Prost(fx,30,a,b);
Prost(fx,300,a,b);
fprintf("Metoda trapezow\n");
Trap(fx,15,a,b);
Trap(fx,30,a,b);
Trap(fx,300,a,b);

A=[0.8;0;5.5;12];
X=[0:15];

plot(X,polyval(A,X),'b');
K=polyval(A,X);
for i=1:16
   line([X(i) X(i)],[K(i) 0],"color","r");
endfor