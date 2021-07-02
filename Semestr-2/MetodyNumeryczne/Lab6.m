Y=[-5,2,4,-3,-2,3,7,5,-2,-6,1];
X=[-7,-6,-4,-3,0,1,3,5,6,8,10];

function Fun6(X,Y,stopien)
  if length(X)==length(Y)
    n=length(X);
    if stopien<n-1
    A=polyfit(X,Y,stopien);
    Wy=zeros(1,n);
    for i=1:n
      for j=1:stopien+1
        Wy(1,i)=Wy(1,i) + A(1,j)*X(1,i)^(stopien+1-j);
      end
    end
    plot(X,Y,'rx');
    grid on;
    hold on;
    plot(X, Wy);
    
    step=(max(X)-min(X))/1000;
    Ry=zeros(1,1001);
    Rx=zeros(1,1001);
    for i=1:1001
    Rx(1,i)=min(X)+(i-1)*step;
      for j=1:stopien+1
        Ry(1,i)=Ry(1,i) + A(1,j)*Rx(1,i)^(stopien+1-j);
      end
    end
    plot(Rx, Ry,'--r');

    fprintf("Sprawdzenie dla stopnia %i\n",stopien);
    disp("Blad bezwzgledny");
    bzw = 0;
    for i=1:n
      bzw = bzw + abs(Y(i)-Wy(i));
    end
    disp(bzw);
    disp("Blad kwadratowy");
    bk = 0;
    for i=1:n
      bk = bk + (Y(i)-Wy(i)).^2;
    end
    disp(bk);
    disp("Sredni blad procentowy");
    sbp = 0;
    for i=1:n
      sbp = sbp + abs((Y(i)-Wy(i))./Y(i));
    end
    sbp = 1/n * sbp * 100;
    disp(sbp);
    disp("Srednie odchylenie od krzywej");
    sook = 0;
    for i=1:n
      sook = sook + ((Y(i)-Wy(i)).^2);
    end
    sook = sqrt(sook/(n-stopien-1));
    disp(sook);
    disp("");
    opis=sprintf("Stopien: %i\nBzw=%f, Bk=%f, Sbp=%f, Sook=%f",stopien,bzw, bk, sbp, sook);
    title(opis);
    else
    disp("Za duzy stopien wielomianu aproksymujacego");
    end
  end
endfunction

subplot(1,3,1);
Fun6(X,Y,4);
subplot(1,3,2);
Fun6(X,Y,2);
subplot(1,3,3);
Fun6(X,Y,6);
