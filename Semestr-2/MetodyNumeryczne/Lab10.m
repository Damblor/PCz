clear;

function Newt()
  F1=inline("2*x*y+2*x*z+2*y*z-22","x","y","z");
  F2=inline("x^2-3*y*z-2*x*y^2+25","x","y","z");
  F3=inline("-3*y^3+2*x^2*z^2+6","x","y","z");
  W11=inline("2*y+2*z","x","y","z");
  W12=inline("2*x+2*z","x","y","z");
  W13=inline("2*x+2*y","x","y","z");
  W21=inline("2*x-2*y^2","x","y","z");
  W22=inline("-3*z-4*x*y^2","x","y","z");
  W23=inline("-3*y","x","y","z");
  W31=inline("4*x*z^2","x","y","z");
  W32=inline("-9*y^2","x","y","z");
  W33=inline("4*x^2*z","x","y","z");
  
  blad = 0.05;
  niedokladnosc = blad+1;
  
  X=[2;2.5;3];
  F=zeros(3,1);
  W=zeros(3,3);
  
  while niedokladnosc > blad
    W(1,1)=W11(X(1,1),X(2,1),X(3,1));
    W(1,2)=W12(X(1,1),X(2,1),X(3,1));
    W(1,3)=W13(X(1,1),X(2,1),X(3,1));
    W(2,1)=W21(X(1,1),X(2,1),X(3,1));
    W(2,2)=W22(X(1,1),X(2,1),X(3,1));
    W(2,3)=W23(X(1,1),X(2,1),X(3,1));
    W(3,1)=W31(X(1,1),X(2,1),X(3,1));
    W(3,2)=W32(X(1,1),X(2,1),X(3,1));
    W(3,3)=W33(X(1,1),X(2,1),X(3,1));
    
    F(1,1)=F1(X(1,1),X(2,1),X(3,1));
    F(2,1)=F2(X(1,1),X(2,1),X(3,1));
    F(3,1)=F3(X(1,1),X(2,1),X(3,1));
    F=F*(-1);
    dX=inv(W)*F;
    X=X+dX;
    disp(X);
    niedokladnosc=abs(F1(X(1,1),X(2,1),X(3,1)))+abs(F2(X(1,1),X(2,1),X(3,1)))+abs(F3(X(1,1),X(2,1),X(3,1)));
    disp("***");
    
    
  endwhile
  disp("wynik")
  disp(X);
  disp("Wartosc funkcji F1, F2, F3 po podstawieniu szukanych X");
  fprintf("%f\n",F1(X(1,1),X(2,1),X(3,1)));
  fprintf("%f\n",F2(X(1,1),X(2,1),X(3,1)));
  fprintf("%f\n",F3(X(1,1),X(2,1),X(3,1)));
  
  
  
  
endfunction

Newt();