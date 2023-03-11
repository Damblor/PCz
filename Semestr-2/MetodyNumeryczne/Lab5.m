vector_x1=[-10,-5,1,6,9,11];
vector_y1=[3,-5,1,9,0,4];
vector_x2=[-12,-9,-6,-2,1,4,6,8,9,12];
vector_y2=[3,-1,-4,-2,2,2,7,1,0,5];

function Aproks(x,y,stopien)
  if length(x)==length(y)
    n=length(x);
    X=zeros(stopien+1,stopien+1);
    A=zeros(stopien+1,1);
    Y=zeros(stopien+1,1);
    for i=1:stopien+1
      for j=1:stopien+1
        for k=1:n
          X(i,j)= X(i,j) + x(k)^(i-1+j-1);
        end
      end
    end
      disp("Macierz X");
    disp(X);
    for i=1:stopien+1
      for k=1:n
        Y(i,1)=Y(i,1) + (y(k)*x(k)^(i-1));
    end
    end
    disp("Macierz Y");
    disp(Y);
    A=inv(X)*Y;
    disp("Macierz A - wspó³czynników");
    disp(A);
    yi=zeros(1,n);
    for i=1:n
      for j=1:stopien+1
        yi(1,i)= yi(1,i) + A(j)*x(i)^(j-1);
      end
    end
    disp("Macierz yi")
    disp(yi);
  
    plot(x,y, 'bx--');
    grid on;
    hold on;
    plot(x,yi, 'ro--');
  else
    disp("Liczba wspó³rzêdnych x nie jest równa liczbie wspó³rzêdnych y");
  endif
  
endfunction

subplot(1,2,1);
Aproks(vector_x1,vector_y1,2);
tytul_rys=sprintf('Niebieskie - punkty rzeczywiste\n czerwone - punkty obliczone\n na podstawie uzyskanego wielomianu\n Zad.1');
title(tytul_rys);
subplot(1,2,2);
Aproks(vector_x2,vector_y2,7);
tytul_rys=sprintf('Niebieskie - punkty rzeczywiste\n czerwone - punkty obliczone\n na podstawie uzyskanego wielomianu\n Zad.3');
title(tytul_rys);
