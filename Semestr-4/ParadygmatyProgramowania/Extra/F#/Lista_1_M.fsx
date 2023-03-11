let x = 1.1
let y = x + 2.0

let f = fun x -> x+1
f 1

let g = fun x y -> x+y
g 1 2

let f1 x = 
    let y = 2
    if x>10 then
        let z = 20
        x + y + z
    else
        x - y

printfn "Hello wrld %.2f %d" 2.3 1
System.Console.WriteLine("Hello wrld z obiektowki")

//1.1
open System
let pole_kola r = Math.PI*(r**r)
let wynik = pole_kola 2
Console.WriteLine($"Pole kola dla tego promienia jest rowne {wynik}")

//1.2
open System
let pierwiastki_rownania = fun (a:float) (b:float) (c:float) ->
    let delta:float = b*b - 4.0*a*c
    if delta < 0.0 then 
        Console.WriteLine("Rownanie nie ma rozwiazan");
        delta
    elif delta = 0.0 then
        let x0:float = -b/2.0*a
        Console.WriteLine($"Rownanie ma 1 rozwiazanie: {x0}")
        delta
    else
        let x1:float = (-b+Math.Sqrt(delta))/2.0*a
        let x2:float = (-b-Math.Sqrt(delta))/2.0*a
        Console.WriteLine($"Rownanie ma 2 rozwiazania: {x1} i {x2}")
        delta

pierwiastki_rownania 1 4 3

// 1.3
open System
let sprawdztrojkat = fun (a:float) (b:float) (c:float) ->
    let max = Math.Max(a,b)
    let max = Math.Max(max,c)
    let suma_mniejszych = a+b+c-max
    if max < suma_mniejszych then
        Console.WriteLine("Da sie zbudowac trojkat")
        true
    else
        Console.WriteLine("Nie da sie zbudowac trojkata")
        false

// //1.4
let policz_pole = fun (a:float) (b:float) (c:float) ->
    if sprawdztrojkat a b c = false then
        Console.WriteLine("Wiec nie policzysz tez pola!")
        0.0
    else
        let pob:float = (a+b+c)/2.0 //polowa obwodu
        let pole = Math.Sqrt(pob*(pob-a)*(pob-b)*(pob-c))
        pole

let p = policz_pole 8 15 17
Console.WriteLine($"Pole trojkata: {p}")

//1.5
let rec suma_n = fun n ->
    if n=1 then
        1
    else
        n + suma_n(n-1)

suma_n 3

//1.6
let rec potegowanie = fun x n ->
    if n = 0 then
        1
    else
        x * potegowanie x (n-1)

potegowanie 2 10

//1.7
let rec fibo = fun n ->
    if n<3 then 
        1
    else fibo(n-1) + fibo(n-2)

fibo 8

//1.8
let rec dwumian = fun n k ->
    if k=0 || k=n then
        1
    else
        dwumian (n-1) k + dwumian (n-1) (k-1)

dwumian 8 7


//1.9
open System;;
let rec czy_pierwsza (n:float) (i:float) = 
    if n<2.0 then
        false
    else
        if i<=Math.Sqrt(n) then
            if(n%i=0) then
                false
            else
                czy_pierwsza n (i+1.0)
        else
            true

czy_pierwsza 100 2

//1.10
let prawdopodobienstwo =
    let rec rzut_kostka (n:float) =
        let rand = new System.Random()
        let rzut = rand.Next(1,7)
        if n=0 then 0.0
        else
            if rzut=6 then
                1.0 + rzut_kostka(n-1.0)
            else
                0.0 + rzut_kostka(n-1.0)
    (rzut_kostka 1000)/1000.0

prawdopodobienstwo

//1.11
let prawdopodobienstwo2 =
    let rec rzut_kostka (n:float) =
        let rand = new System.Random()
        let rzut = rand.Next(1,7)
        let rzut2 = rand.Next(1,7)
        if n=0 then 0.0
        else
            if rzut=6 && rzut2=6 then
                1.0 + rzut_kostka(n-1.0)
            else
                0.0 + rzut_kostka(n-1.0)
    (rzut_kostka 1000)/1000.0

prawdopodobienstwo2

//1.12
let rec nwd a b = 
    if a=b then
        a
    else
        if a>b then
            nwd (a-b) b
        else
            nwd a (b-a)

nwd 12 18

//1.13
//nie zrobie tego.

//1.15
[<Measure>] type C
[<Measure>] type F
let zamien_na_f (st_c : float<C>) = 32.0<F> + 9.0<F>/5.0<C> * st_c

//1.16
let zamien_na_c (st_f : float<F>) = 5.0<C> / 9.0<F> * (st_f - 32.0<F>)

//1.17
let rec palindrom (slowo:string) poczatek =
    let dlugosc=slowo.Length-poczatek-1
    if dlugosc<= poczatek then
        true
    elif  slowo.[dlugosc]<>slowo.[poczatek] then
        false
    else 
        palindrom slowo (poczatek+1)
        
//1.18
let rec ilerazy (slowo:string) (litera:char) (ile:int) it=
    if slowo.Length-it<>0 then 
        if slowo.[it]=litera then                            
            ilerazy slowo litera (ile+1) (it+1)
        else 
            ilerazy slowo litera ile (it+1)
    else 
        ile

//1.19
let rec liczbawyr (zdanie:string) it ile=
    if it=0 then
        if zdanie.Length=0 then                                                  
            0
        elif zdanie.[0]=' ' then
            liczbawyr zdanie (it+1) (0)
        else 
            liczbawyr zdanie (it+1) (ile+1)
    elif it<zdanie.Length then
        if zdanie.[it]<>' ' && zdanie.[it-1]=' ' then
            liczbawyr zdanie (it+1) (ile+1)
        else
            liczbawyr zdanie (it+1) ile
     else 
        ile

 //1.20
let rec ilosccyfr (zdanie:string) it ile (out:string)=
    if it<zdanie.Length then 
        if it=0 && zdanie.[0]>='0' && zdanie.[0]<='9' then
            ilosccyfr zdanie (it+1) (ile+1) out
        elif zdanie.[it]>='0' && zdanie.[it]<='9' then  
            ilosccyfr zdanie (it+1) (ile+1) out
        else
            if ile>0 then 
                ilosccyfr zdanie (it+1) 0 (out+(string ile))
            else
                ilosccyfr zdanie (it+1) ile out
    else 
        out

//1.21
Console.Write("Jak się nazywasz? ")
let personalia = Console.ReadLine()
Console.WriteLine($"Witaj, {personalia}")

//1.22
Console.Write("Podaj rok, a powiem ci czy jest przestępny, czy nie: ")
let rok = Console.ReadLine()
if ((int rok)%4=0 && (int rok)%100<>0) || (int rok)%400=0 then
    Console.WriteLine($"{rok} jest przestepny")
else
    Console.WriteLine($"{rok} nie jest przestepny")

//1.23
Console.Write("Podaj 3 liczby: ")
let a = Console.ReadLine()
let b = Console.ReadLine()
let c = Console.ReadLine()

let sprawdz_trojkat = fun (a:float) (b:float) (c:float) ->
    let max = Math.Max(a,b)
    let max = Math.Max(max,c)
    let suma_mniejszych = a+b+c-max
    if max < suma_mniejszych then
        true
    else
        false

if sprawdz_trojkat (float a) (float b) (float c) = true then
    if((float a)=(float b)) || ((float a) = (float c)) || ((float b) = (float c)) then
        Console.WriteLine("Mozna zbudowac trojkat rownaramienny!")
    if (float a) = (float b) && (float a) = (float c) then
        Console.WriteLine("Mozna zbudowac trojkat rownoboczny!")
else
    Console.WriteLine("Nie mozna zbudowac trojkata!")

//1.24
open System
let pesel = Console.ReadLine()

let rec sprawdz_czy_poprawny (pesel:string) (i:int) = 
    if pesel.Length<>11 then
        false
    elif (pesel.[i]>='0' && pesel.[i]<='9') && i=pesel.Length-1 then
        true
    elif pesel.[i]>='0' && pesel.[i]<='9' then
        sprawdz_czy_poprawny pesel (i+1)
    else
        false

sprawdz_czy_poprawny pesel 0

let rozszyfruj_pesel (pesel:string) =
    if int(pesel.[9])%2=0 then
        if pesel.[2]='0' || pesel.[2]='1' then  
            let komunikat = $"Jestes kobieta, urodzilas sie {pesel.[4]}{pesel.[5]}-{pesel.[2]}{pesel.[3]}-19{pesel.[0]}{pesel.[1]}\n"
            komunikat
        else
            let komunikat = $"Jestes kobieta, urodzilas sie {pesel.[4]}{pesel.[5]}-{char(int(pesel.[2])-2)}{pesel.[3]}-20{pesel.[0]}{pesel.[1]}\n"
            komunikat
    else
        if pesel.[2]='0' || pesel.[2]='1' then  
            let komunikat = $"Jestes mezczyzna, urodziles sie {pesel.[4]}{pesel.[5]}-{pesel.[2]}{pesel.[3]}-19{pesel.[0]}{pesel.[1]}\n"
            komunikat
        else
            let komunikat = $"Jestes mezczyzna, urodziles sie {pesel.[4]}{pesel.[5]}-{char(int(pesel.[2])-2)}{pesel.[3]}-20{pesel.[0]}{pesel.[1]}\n"
            komunikat
    
let pesel_teller pesel:string =
    if (sprawdz_czy_poprawny pesel 0) = true then
        let komunikat = rozszyfruj_pesel pesel
        printfn("%s") komunikat
        komunikat
    else
        let komunikat = "Niepoprawny pesel"
        printfn("%s") komunikat
        komunikat
    
pesel_teller pesel        

//1.25 1.26
open System
let slowo = Console.ReadLine()

let rec szyfruj (tekst:string) (i:int) =
    if tekst.Length-1=i then
        let litera:string = string(char(int(tekst.[i])+2))
        litera
    else
        let litera:string = string(char(int(tekst.[i])+2))
        let ret = litera + szyfruj tekst (i+1)
        ret

let zaszyfrowane = szyfruj slowo 0

let rec odszyfruj (tekst:string) (i:int) = 
    if tekst.Length-1=i then
        let litera:string = string(char(int(tekst.[i])-2))
        litera
    else
        let litera:string = string(char(int(tekst.[i])-2))
        let ret = litera + odszyfruj tekst (i+1)
        ret

odszyfruj zaszyfrowane 0

//1.27
open System
let minuty = int(Console.ReadLine())

let oblicz_h minuty =
    if minuty >= 1440 then
        ("Doba ma mniej","niz 1440 minuty!")
    else
    if minuty<60 then
        let min = minuty
        if min < 10 then
            (string(0),string(0)+string(min))
        else
            (string(0),string(min))
    else
        let godziny = minuty/60
        let min = minuty-godziny*60
        if godziny < 10 then
            if min < 10 then
                (string(0)+string(godziny),string(0)+string(min))
            else
                (string(0)+string(godziny),string(min))
        else
            if min < 10 then
                (string(godziny),string(0)+string(min))
            else
                (string(godziny),string(min))

Console.WriteLine($"Jest godzina {fst(oblicz_h minuty)}:{snd(oblicz_h minuty)}")

//1.28 zmienione na sekundy bo by sie czekalo 1019339141979 czasu
open System
open System.Threading
let sekundy = int(Console.ReadLine())

let rec licznik sekundy =
    if sekundy = 0 then
        Console.WriteLine("###BUM###")
    else
        Console.WriteLine($"Do startu pozostało {sekundy} sekund.")
        Thread.Sleep(1000)
        licznik (sekundy-1)

licznik sekundy

//1.29
open System
let liczba = int(Console.ReadLine())

let rec collatz (x:double) (i:int) =
    if x=1.0 then
        Console.WriteLine($"{i}. {x}")
        x
    elif x%2.0=0.0 then
        Console.WriteLine($"{i}. {x}")
        collatz (x*0.5) (i+1)
    else
        Console.WriteLine($"{i}. {x}")
        collatz (3.0*x+1.0) (i+1)

collatz liczba 1

//1.30
open System

let rec srednia (x:float) (ile:float) =
    let liczba:float = float(Console.ReadLine())
    if liczba<0.0 then
        let wynik:float = x/ile
        Console.WriteLine($"Srednia: {wynik}")
        wynik
    else
        let suma:float = x + liczba
        srednia suma (ile+1.0)

srednia 0.0 0.0