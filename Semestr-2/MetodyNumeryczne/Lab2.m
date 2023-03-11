%Piotr Krupa
%dane
A=[4,3,0.5;1,-1,5;-0.5,2,2];
B=[-2,1.5,4;-2,1,2.5;-1,-2,-1];

%Mno¿enie
for i=1:3
  for j=1:3
    C(i,j)=A(i,1)*B(1,j)+A(i,2)*B(2,j)+A(i,3)*B(3,j);
  endfor
endfor
disp("Mnozenie A i B");
disp(C);

%Wyznacznik macierzy
disp("Wyznacznik macie¿y C:");
detC=C(1,1)*C(2,2)*C(3,3)+C(1,2)*C(2,3)*C(3,1)+C(1,3)*C(2,1)*C(3,2)-C(1,3)*C(2,2)*C(3,1)-C(2,3)*C(3,2)*C(1,1)-C(3,3)*C(1,2)*C(2,1);
disp(detC);
disp("Prawidlowy wynik:");
disp(det(C));
if detC!=0
  %Dope³nienia algebraiczne
  D = zeros(3, 3);
  for i = 1:3
    for j = 1:3
      M = zeros(2, 2);
      w=1;
      for p=1:3
        if p!=i
          k=1;
          for t=1:3
            if t!=j
              M(w,k)=C(p,t);
              k=k+1;
            end
          end
          w=w+1;
        end
      end
      D(i,j) = (-1)^(i+j) * (M(1,1) * M(2,2) - M(1,2) * M(2,1));
    endfor
  endfor
  %Transponowanie
  for i=1:3
    for j=1:3
      DT(i,j)=D(j,i);
    endfor
  endfor
  disp("Moja macierz transponowana:");
  disp(DT);
  %Odwracanie
  C_odw=(1/detC)*DT;
  disp("Moja macierz odwrotna:");
  disp(C_odw);
  disp("Prawidlowy wynik:");
  disp(inv(C));
else
  disp("Wyznacznik jest równy 0");
endif