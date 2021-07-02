%Piotr Krupa
%dane
A=[4,-4,2;3,-1,4];
B=[10,-1,6;12,1,-1;-3,0,2];

%Zad.2
function oblicz (a,b,c)
  fprintf('Funkcja\n');
  [l_wierszy,l_kolumn]=size(a);
  fprintf('Mnozenie macierzy A przez stala %d\n',c);
  for i=1:l_wierszy
    for j=1:l_kolumn
      a(i,j)=a(i,j)*c;
      fprintf('|A(%d,%d)=%d|',i,j,a(i,j));
    endfor
    fprintf('\n');
  endfor
  fprintf('Mnozenie macierzy A przez macierz B\n');
  for i=1:2
    for j=1:3
      C(i,j)= a(i,1)*b(1,j)+a(i,2)*b(2,j)+a(i,3)*b(3,j);
      fprintf('|C(%d,%d)=%d|',i,j,C(i,j));
    endfor
    fprintf('\n');
  endfor
endfunction

oblicz(A,B,2);