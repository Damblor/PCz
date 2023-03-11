clear;

function Roz()
 %t(x)=-x^4+2x^3-x+3
 %k(x)=3x*ln(2x+1)+(x^2/x+1)
 %x0=3
 %h=0.1
 tx=inline("-x^4+2*x^3-x+3");
 kx=inline("3*x*log(2*x+1)+((x^2)/(x+1))");
 x=3;
 h=0.1;
 x1=x+h;
 x2=x-h;
 txp1=(tx(x1)-tx(x2))/(2*h);
 fprintf("Pierwsza pochodana t(x)\n");
 fprintf("%f\n",txp1);
 fprintf("Sprawdzenie\n");
 fprintf("t'(x)=-4x^3+6x^2-1\n");
 fprintf("%f\n",-4*3^3+6*3^2-1);
 
 kxp1=(kx(x1)-kx(x2))/(2*h);
 fprintf("Pierwsza pochodana k(x)\n");
 fprintf("%f\n",kxp1);
 fprintf("Sprawdzenie\n");
 fprintf("k'(x)=-x^2/(1+x)^2+(2x)/(1+x)+(6x)/(1+2x)+3log(1+2x)\n");
 fprintf("%f\n",-(3^2/(3+1)^2)+(2*3/(3+1))+(6*3/(2*3+1))+3*log(2*3+1));
 
 
 txp2=(tx(x1)+tx(x2)-2*tx(x))/(h^2);
 fprintf("Druga pochodana t(x)\n");
 fprintf("%f\n",txp2);
 fprintf("Sprawdzenie\n");
 fprintf("t''(x)=-12(-1+x)x\n");
 fprintf("%f\n",-12*(-1+3)*3);
 
 kxp2=(kx(x1)+kx(x2)-2*kx(x))/(h^2);
 fprintf("Druga pochodana k(x)\n");
 fprintf("%f\n",kxp2);
 fprintf("Sprawdzenie\n");
 fprintf("k''(x)=(2x^2)/(1+x)^3-(4x)/(1+x)^2+2/(1+x)-(12x)/(1+2x)^2+12/(1+2x)\n");
 fprintf("%f\n",(2*3^2)/(1+3)^3-(4*3)/(1+3)^2+2/(1+3)-(12*3)/(1+2*3)^2+12/(1+2*3));
  
  gx=(5*(txp2-kxp2)^2+10)/((txp1+kxp1)^2+1);
  fprintf("Dzialanie\n");
  fprintf("(5*(t''(x)-k''(x))^2+10)/((t'(x)+k'(x))^2+1)\n");
  fprintf("%f\n",gx);
  
  
  
  
endfunction

Roz();