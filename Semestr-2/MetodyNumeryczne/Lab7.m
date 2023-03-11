x = [30,25];
funkcja = [1,-3,-9,-5,0];
q = 0.001;

function Sieczne(x,f,q,nm)
  n = 1;
  while(!((abs(x(n+1)-x(n))<=q)||(n==nm)))
  n=n+1;
  x(n+1)=x(n)-polyval(f,x(n))*(x(n)-x(n-1))/(polyval(f,x(n))-polyval(f,x(n-1)));
  endwhile
  
  b=x(n+1)-x(n);
  fprintf("Wartosc funkcji f(%d) jest rowna %d\n",x(n),polyval(f,x(n)));
  fprintf("Wartosc funkcji f(%d) jest rowna %d\n",5,polyval(f,5));
  fprintf("Blad wynosi %d\n",b);
endfunction

Sieczne(x,funkcja,q,50);