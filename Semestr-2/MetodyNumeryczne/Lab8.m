clear;
n=4;
A=rand(n);
Y=rand(n,1);

function Gauss(A,Y)
  n=size(A,1);
  X=zeros(n,1);
  R=[A Y];
  
  vec_pom=zeros(1,n);
  if R(1,1)==0
    for i=2:n
      if R(i,1)!=0
        vec_pom=R(1,:);
        R(1,:)=R(i,:);
        R(i,:)=vec_pom;
        break;
      endif
    endfor
 endif
  
  if det(A)!=0
    for s=1:n-1
      for i = s+1:n
        for j=s+1:n+1
          R(i,j)=R(i,j)-(R(i,s)/R(s,s)*(R(s,j)));
        endfor
      endfor
    endfor
    X(n)=R(n,n+1)/R(n,n);
    for i=1:n-1
      suma=0;
      for s=n-i+1:n
        suma=suma+R(n-i,s)*X(s);
      endfor
      X(n-i)=(R(n-i,n+1)-suma)/R(n-i,n-i);
    endfor
    disp("Rozwi¹zanie równania X");
    disp(X);
    disp("Sprawdzenie (A*X)");
    Z=A*X;
    disp(Z);
  else
    disp("Podany uk³ad równañ nie jest uk³adem oznaczonym (wyznacznik z macierzy wspó³czynników równy jest 0)");
  endif
endfunction

if n>0
  disp("Metoda Eliminacji Gaussa");
  disp("Domyslnie n = 4");
  Gauss(A,Y);
else
  disp("n musi byc wieksze od zera");
endif