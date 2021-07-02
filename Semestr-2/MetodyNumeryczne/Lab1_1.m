%Piotr Krupa
%dane
A=[3,1;2,4;1,3;2,2;5,6];
B=[-1,2,6,-3,-1;6,4,-5,1,5];

%Zad.1
[l_wierszy,l_kolumn]=size(A);
C=zeros(l_kolumn,l_wierszy);
for i=1:l_wierszy
  for j=1:l_kolumn
    C(j,i)=A(i,j);
  endfor
endfor
[l_wierszy,l_kolumn]=size(B);
for i=1:l_wierszy
  for j=1:l_kolumn
    D(i,j)=C(i,j)-B(i,j);
    fprintf('|D(%d,%d)=%d|',i,j,D(i,j));
  endfor
  fprintf('\n');
endfor