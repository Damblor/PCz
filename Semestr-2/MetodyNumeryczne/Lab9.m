clear;
A1=[20,-5,4,-4;3,10,-3,-1;2,0,4,0;2,-1,-2,8];
A2=[0,10,3,-1;20,3,2,10;2,3,0,10;2,-1,8,2];
A3=[1,2,3,4;2,0,5,2;1,1,4,2;2,1,1,1];
B1=[12;20;28;52];
B2=[35;103;27;23];
B3=[40;32;31;16];

function Iter(A,B)
  n=length(B);
  L=zeros(n);
  D=zeros(n);
  U=zeros(n);
  t=12;
  r=0.3;
  
  for i=1:n
    for j=1:n
      if i>j
        L(i,j)=A(i,j);
      elseif i<j
        U(i,j)=A(i,j);
      else
        D(i,j)=A(i,j);
      endif
    endfor
  endfor
  for i=1:n
    if (D(i,i)==0)
      disp("Wystapienie 0 na przekatnej");
      return;
    endif
  endfor
    
  N=inv(D);
  H=zeros(n);
  
  for i=1:n
    for j=1:n
      if i!=j
        H(i,j)=-A(i,j)/A(i,i);
      endif
    endfor
  endfor
  
  if (max(sum(abs(H)))<1) || (max(sum(abs(H')))<1)
    x=zeros(4,1);
    for i=1:t
      disp(['Wynik dla iteracji nr ',num2str(i)]);
      x=-N*(L+U)*x+N*B;
      disp(x);
      if(sum(abs((A*x)-B)) < r)
        break;
      endif
    endfor
    disp("Sumaryczny blad rozwiazania");
    disp(sum(abs((A*x)-B)));
    disp("Sprawdzenie - wynik dokladny");
    disp(inv(A)*B);
  else
    disp("Warunek wystarczaj¹cy uzyskania zbie¿noœci nie zosta³ spe³niony");
  endif
endfunction

disp("Uklad 1");
Iter(A1,B1);
disp("Uklad 2");
Iter(A2,B2);
disp("Uklad 3");
Iter(A3,B3);

disp("W ukladzie 2 i 3 wystepuja zera na przekatnej");