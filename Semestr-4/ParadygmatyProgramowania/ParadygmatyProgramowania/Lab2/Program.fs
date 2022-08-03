// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let zad1() = 
    Console.WriteLine("Podaj wartosc");
    let x = Int32.Parse(Console.ReadLine())
    match x with
    | 1 -> "Wprowadziles 1"
    | 2 -> "Wprowadziles 2"
    | 3 -> "Wprowadziles 3"
    | 4 -> "Wprowadziles 4"
    | _ -> "Wprowadziles inna wartosc 1, 2, 3 lub 4"

let zad2() = 
    Console.WriteLine("Podaj wartosc a");
    let a = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Podaj wartosc b");
    let b = Int32.Parse(Console.ReadLine());
    let para = (a, b)
    match para with
    | (a, b) when a > b -> "Pierwsza jest wieksza"
    | (a, b) when a < b -> "Druga jest wieksza"
    | _ -> "Obie sa rowne"

let zad3 a b c =
    let obwod = a + b + c
    let p = obwod / 2.0

    let pole = sqrt(p * (p-a) * (p-b) * (p-c))

    let para = (obwod, pole)
    match para with
    | (obwod, pole) -> "pole trojkata to :" + pole.ToString() + ", a obwod to: " + obwod.ToString()

let rozdziel (text : string) =
    let words = text.Split[|'@'|]
    (words[0],words[1])

let zad4 text =
    match rozdziel text with
    | (nazwa, domena) -> "nazwa to :" + nazwa + ", a Domena to: " + domena

let zad5 text =
    match rozdziel text with
    | (_, domena) when domena.Equals("pcz.pl")-> "Nalezy do PCZ.PL"
    | _ -> "Nie nalezy do PCZ.PL"

let zad6 (x1:float, y1:float, z1:float) (x2:float, y2:float, z2:float) =
    let (x,y,z) = (x1 - x2, y1 - y2, z1 - z2)

    let wynik = sqrt(x * x + y * y + z * z)
    wynik.ToString()

let zad7 (x1:float, y1:float) r (x2:float, y2:float) =
    let (x,y) = (x1 - x2, y1 - y2)
    let wynik = sqrt(x * x + y * y)
    match wynik with
    | wynik when wynik <= r -> "Nalezy do okregu"
    | _ -> "Nie nalezy"

type Ulamek = {
    a:int
    b:int
}

let dodaj (x:Ulamek) (y:Ulamek) =
    


[<EntryPoint>]
let main argv =
    Console.WriteLine(zad7 (0.0,0.0) 2 (1.5,0.0));
    0 // return an integer exit code