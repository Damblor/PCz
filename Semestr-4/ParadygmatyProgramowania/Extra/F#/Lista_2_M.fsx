//2.1
open System
let x = int(Console.ReadLine())
match x with
| 1 -> printfn("Wprowadziles 1")
| 2 -> printfn("Wprowadziles 2")
| 3 -> printfn("Wprowadziles 3")
| 4 -> printfn("Wprowadziles 4")
| _ -> printfn("Wprowadziles inna wartosc niz 1234")

//2.2
open System
let z2 =
    let x = int(Console.ReadLine())
    let y = int(Console.ReadLine())
    (x,y)

match z2 with
| (a,b) when a>b -> printfn("Wieksza jest liczba %d") a
| (a,b) when a<b -> printfn("Wieksza jest liczba %d") b
| _ -> printfn("Liczby sa rowne")

//2.3
open System
let poleTRKT a b c =
    let obwod = a+b+c
    let pob = (a+b+c)/2.0
    let pole = Math.Sqrt(pob*(pob-a)*(pob-b)*(pob-c))
    (obwod,pole)

let wynik = poleTRKT 3 4 5

Console.WriteLine($"Obwod trojkata to: {fst wynik}, a jego pole to: {snd wynik}")

//2.4 2.5
open System
let mail = "malpa@pcz.com"

let rec extract_mail (mail:string) (i:int) = 
    if mail.[i]='@' then
        (mail.[0..i-1],mail.[i..mail.Length])
    else
        extract_mail mail (i+1)

let czy_pcz mail =
    let nazwa, domena = extract_mail mail 0
    match domena with
    | "@pcz.pl" -> Console.WriteLine($"Mail {nazwa}{domena} nalezy do domeny PCz")
    | _ -> Console.WriteLine($"Mail {nazwa}{domena} nie nalezy do domeny PCz")

czy_pcz mail

//2.6 2.7 zrobione w program.fsx <- lab1

//2.8 2.9
type Ulamek = {
    licznik:int
    mianownik:int
}

let u1 = {licznik=1;mianownik=2}
let u2 = {licznik=1;mianownik=2}

let dodaj_u (u1:Ulamek) (u2:Ulamek) = 
    if u1.mianownik=u2.mianownik then
        let x:Ulamek = {licznik=u1.licznik+u1.licznik;mianownik=u1.mianownik}
        x
    else
        let x:Ulamek = {licznik=u1.licznik*u1.mianownik+u2.licznik*u1.mianownik;mianownik = u1.mianownik*u2.mianownik}
        x

let odejmij_u (u1:Ulamek) (u2:Ulamek) = 
    if u1.mianownik=u2.mianownik then
        let x:Ulamek = {licznik=u1.licznik-u1.licznik;mianownik=u1.mianownik}
        x
    else
        let x:Ulamek = {licznik=u1.licznik*u1.mianownik-u2.licznik*u1.mianownik;mianownik = u1.mianownik*u2.mianownik}
        x

let pomnoz_u (u1:Ulamek) (u2:Ulamek) =
    let x:Ulamek = {licznik=u1.licznik*u2.licznik; mianownik=u1.mianownik*u2.mianownik}
    x

let dziel_u (u1:Ulamek) (u2:Ulamek) =
    let x:Ulamek = {licznik=u1.licznik*u2.mianownik; mianownik=u1.mianownik*u2.licznik}
    x

//2.10 - 2.14 skip

//2.15
open System
type Osoba = {
    imie:string
    nazwisko:string
    wiek:int
}

let utworz () =
    Console.Write("Podaj imie: ")
    let i:string = Console.ReadLine()
    Console.Write("Podaj nazwisko: ")
    let n:string = Console.ReadLine()
    Console.Write("Podaj wiek: ")
    let w:int = int(Console.ReadLine())
    let zwroc = {imie=i;nazwisko=n;wiek=w}
    zwroc

let modyfikuj (O:Osoba) =
    Console.Write("Podaj imie: ")
    let i:string = Console.ReadLine()
    Console.Write("Podaj nazwisko: ")
    let n:string = Console.ReadLine()
    Console.Write("Podaj wiek: ")
    let w:int = int(Console.ReadLine())
    if i="" then
        let zwroc = {imie=O.imie; nazwisko=n; wiek=w}
        zwroc
    elif n="" then
        let zwroc = {imie=i; nazwisko=O.nazwisko; wiek=w}
        zwroc
    elif w=0 then
        let zwroc = {imie=i; nazwisko=n; wiek=O.wiek}
        zwroc
    else
        let zwroc = {imie=i; nazwisko=n; wiek=w}
        zwroc 

let pokaz (O:Osoba) = 
    Console.WriteLine($"Imie i nazwisko: {O.imie} {O.nazwisko} Wiek: {O.wiek}")

let rec program (O:Osoba) =
    Console.WriteLine("1 - utworzenie rekordu\n2 - modyfikacja rekordu\n3 - pokaz rekord\n4 - zakonczenie programu")
    let wybor = int(Console.ReadLine())
    match wybor with
    | 1 -> program (utworz ())
    | 2 -> program (modyfikuj O)
    | 3 -> pokaz O
           program O
    | 4 -> Console.WriteLine("Zakonczono program")
           O
    | _ -> program O

let start = {imie="Brak";nazwisko="rekordu";wiek=0}
program start