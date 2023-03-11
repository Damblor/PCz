open System

[<EntryPoint>]

let main argv = 

    // Zadanie 1
    // Pole koła
    let poleKola (r: float) =
        r * r * 3.14

    poleKola 10




    // Zadanie 2
    // Wartość pierwiastków równania kwadratowego
    let kwadrat a b c =
        let ac = 4.0 * a * c
        let delta = b * b - ac
        if delta < 0 then
            printfn "Brak rozwiązań"
        elif delta = 0 then
            let x0 = -b / (2.0 * a)
            printfn $"X = {x0}"
        else
            let x0 = (-b - sqrt delta) / (2.0 * a)
            let x1 = (-b + sqrt delta) / (2.0 * a)
            printfn $"X1 = {x0}"
            printfn $"X2 = {x1}"

    kwadrat 1 4 3





    // Zadanie 3
    // Z trzech podanych wartości rzeczywistych da się zbudować trójkąt
    let trojkat a b c =
        if a + b > c && a + c > b && c + b > a then
            printfn $"Można zbudować trójkąt"
        else
            printfn $"Nie można zbudować trójkąta"    
    
    trojkat 3 4 5







    // Zadanie 4
    // Pole trójkąta na podstawie boków
    let poleTrojk a b c =
        let p = (a + b + c) / 2.0
        let PP = sqrt(p * (p - a) * (p - b) * (p - c))
        printfn $"Pole wynosi: {PP}"

    poleTrojk 12 13 15






    // Zadanie 5
    // Rekurencyjnie suma n pierwszych liczb
    let rec suma n = 
        if n < 0 then
            failwith  "Błąd"
        elif n = 0 then
            0
        else
            n + suma(n - 1)

    suma 5







    // Zadanie 6
    // Rekurencyjnie wyznaczy x^n
    let rec potega x n =
        if x = 0 then
            0
        elif n = 0 then
            1
        else
            x * potega x (n - 1)

    potega 5 3





    // Zadanie 7
    // n-ty element fibbonaciego
    let rec fib n = 
        if n = 0 then
            0
        elif n = 1 then
            1
        else
            fib (n - 1) + fib(n - 2)

    fib 19




    // Zadanie 8
    // Dwumian newtona
    let rec netwon n k = 
        if k = 0 then
            1
        elif k = n then
            1
        else
            newton (n - 1) k + newton (n - 1) (k - 1)

    newton 12 5



    // Zadanie 9
    // Rekurencyjnie sprawdza czy jest to liczba pierwsza
    let rec pierwsza n i =
        if i = n then
            printfn "Jest liczba pierwsza"
        elif n = 2 || n = 3 then
            printfn "Jest liczba pierwsza"
        elif n % i = 0 then
            printfn "Nie jest liczba pierwsza"
        elif i > n then
            printfn "Nie jest liczba pierwsza"
        else 
            pierwsza n (i + 1)
        
    pierwsza 13 2




    // Zadanie 10
    // Na podstawie 1000 rzutów kostką określi prawdopodobieństwo wyrzucenia 6
    let rec szansa1 (n: float) = 
        n / (n * 6.0) 
    
    szansa1 1000



    // Zadanie 11
    // Na podstawie 1000 rzutów kostką określi prawdopodobieństwo wyrzucenia dwóch szóstek
    let rec szansa2 (n: float) = 
        (2.0 * n) / (n * 36.0) 
    
    szansa2 1000




    // Zadanie 12
    // NWD 2 liczb
    let rec NWD = function
        | (0, b) -> b
        | (a, b) -> NWD(b % a, a)

    NWD(68, 36)



    // Zadanie 13
    // Przybliżona wartość szerego nieskończonego
    let rec szereg1 i = 
        let szer1 = 1.0 / (i * i)
        if szer1 < 0.0000001 then
            1.0 / ((i-1.0) * (i-1.0))
        else 
            szereg1 (i + 1.0)
    
    szereg1 1







    let gora i = 
        (-1.0) ** i

    let rec dol n = 
        if n = 0.0 then
            1.0
        else
            n * dol (n-1.0)

    let rec szereg2 i = 
        let szer2 = (gora i / dol i)
        if abs szer2 < 0.0000001 then
            let wynik = gora (i-1.0) / dol (i-1.0)
            wynik
        else 
            szereg2 (i + 1.0)

    szereg2 1






    let rec szereg3 i = 
        let szer3 = 1.0 / (i * (i + 1.0))
        if szer3 < 0.0000001 then
            1.0 / ((i-1.0) * (i))
        else 
            szereg3 (i + 1.0)

    szereg3 1






    let gora2 i = 
        (-2.0) ** i

    let rec dol2 n = 
        if n = 0.0 then
            1.0
        else
            n * dol2 (n-1.0)

    let rec szereg4 i = 
        let szer4 = (gora2 i / dol2 i)
        if abs szer4 < 0.0000001 then
            let wynik = gora2 (i-1.0) / dol2 (i-1.0)
            wynik
        else 
            szereg4 (i + 1.0)

    szereg4 1





    // Zadanie 14
    // DO ZROBIENIA




    // Zadanie 15
    let CtoF (T: float) =
        32.0 + ((9.0/5.0) * T)

    CtoF 28




    // Zadanie 16
    let FtoC (T: float) =
        (T - 32.0) * (5.0/9.0)

    FtoC 82.4




    // Zadanie 17
    let isPal str = 
        let str = str |> Seq.filter ((<>) ' ') |> Seq.toList
        str = (str |> List.rev)

    isPal "kajak"




    // Zadanie 18
    let szukaj x str =
        Seq.length(Seq.filter (fun x' -> x' = x) str)
    
    szukaj 'x' "maxx"





    // Zadanie 19
    let licz x str =
        Seq.length(Seq.filter (fun x' -> x' = x) str) + 1

    licz ' ' "Przykładowy tekst do zadania 19"






    // Zadanie 20





    // Zadanie 21
    // Wprowadz imie, nazwisko i je wyświetl
    let zadanie21 = 
        printf "Podaj imie: "
        let imie = System.Console.ReadLine()
        printf "Podan nazwisko: "
        let nazwisko = System.Console.ReadLine()
        printfn $"Witaj <{imie} {nazwisko}>"




    // Zadanie 22
    let zadanie22 = 
        printf "Podaj rok: "
        let rok = System.Console.ReadLine()
        if System.Int32.Parse(rok) % 4 = 0 then
            printfn "Rok przestępny"
        else 
            printfn "Rok nieprzestępny"



    // Zadanie 23
    let zadanie23 = 
        printf "Podaj 1 liczbę: "
        let l1 = System.Console.ReadLine()
        printf "Podaj 2 liczbę: "
        let l2 = System.Console.ReadLine()
        printf "Podaj 3 liczbę: "
        let l3 = System.Console.ReadLine()
        let a = System.Double.Parse(l1)
        let b = System.Double.Parse(l2)
        let c = System.Double.Parse(l3)
        if a + b > c && a + c > b && c + b > a then
            if a = b && a = c then
                printfn "Można zbudować trójkąt równoboczny"
            elif a*a + b*b = c*c then
                printfn "Można zbudowac trójkąt prostokątny"
            elif (a = b && c <> a)  || (a = c && b <> a) || (b = c && a <> b) then
                printfn "Można zbudowac trójkąt równoramienny"
        else
            printfn "Nie można zbudować trójkąta"




    // Zadanie 24
    let zadanie24 = 
        printf "Podaj swój PESEL: "
        let pesel = System.Console.ReadLine()
        if pesel.Length <> 11 then
            failwith "Niepoprany pesel"
        else 
            let rok = pesel.Substring(0, 2)
            let mies = pesel.Substring(2, 2)
            let dzien = pesel.Substring(4, 2)
            let plec = pesel.Substring(9, 1)
            
            printfn $"Data urodzenia: {dzien}.{mies}.19{rok}"
            if System.Int32.Parse(plec) % 2 = 0 then
                printfn "Płeć: Kobieta"
            else 
                printfn "Płeć: Mężczyzna"






    // Zadanie 25
    open System
    let Cezar n s =
        let shift c =
            if Char.IsLetter c then
                let a = (if Char.IsLower c then 'a' else 'A') |> int
                (int c - a + n) % 26 + a |> char
            else c
        String.map shift s
 
    let szyfruj n = 
        Cezar n

    encrypt 5 "Test"




    // Zadanie 26
    open System
    let Cezar n s =
        let shift c =
            if Char.IsLetter c then
                let a = (if Char.IsLower c then 'a' else 'A') |> int
                (int c - a + n) % 26 + a |> char
            else c
        String.map shift s

    let odszyfruj n = 
        Cezar (26 - n)

    decrypt 5 "Yjxy"







    // Zadanie 27
    let zadanie27 = 
        printf "Podaj liczbę: "
        let n = System.Console.ReadLine()
        let liczba = System.Int32.Parse(n)
        let min = liczba % 60
        let godz = liczba / 60
        if godz > 23 then
            printfn "Przekroczona liczbę godzin w dobie"
        else
            printfn $"Jest godzina: {godz}:{min}"







    // Zadanie 28
    let zadanie28 = 
        printf "Podaj liczbę: "
        let n = System.Console.ReadLine()
        let minut = System.Int32.Parse(n)
        let rec stoper minut = 
            printfn $"Do startu pozostało: {minut}"
            if minut = 0 then
                printfn "START!"
            else 
                stoper (minut - 1)
    
        stoper minut







    // Zadanie 29
    let zadanie 29 = 
        let x = System.Console.ReadLine()
        let n = System.Int32.Parse(x)
        if n > 0 then
            let mutable licznik = 1
            printfn $"1. {n}"
            let rec Collatz n = 
                if n > 1 then
                    if n % 2 = 0 then
                        licznik <- licznik + 1
                        printfn $"{licznik}. {n}"
                        Collatz (n / 2)
                    elif n % 2 = 1 then
                        licznik <- licznik + 1
                        printfn $"{licznik}. {n}"
                        Collatz (3 * n + 1)
                    else
                        0
                elif n = 1 then
                    printfn $"{licznik + 1}. {n}"
                    0
                else 
                    printf "KONIEC"
                    0
        else 
            failwith "Podano niedodatnią liczbę"







    // Zadanie 30
    let zadanie30 = 
        printfn "Podaj liczbę"
        let mutable x = System.Console.ReadLine()
        let mutable liczba = System.Int32.Parse(x)
        while (liczba >= 0) do
            printfn "Podaj liczbe: "
            let mutable x2 = System.Console.ReadLine()
            let mutable liczba2 = System.Int32.Parse(x2)
            liczba <- liczba2

            

    0