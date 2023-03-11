open System

[<EntryPoint>]

let main argv = 
    // Zadanie 1
    let zadanie1 = 
        printf "Podaj wartość: "
        let a = System.Console.ReadLine()
        let x = System.Int32.Parse(a)
        match x with
            | 1 -> printfn "Wprowadziłeś 1"
            | 2 -> printfn "Wprowadziłeś 2"
            | 3 -> printfn "Wprowadziłeś 3"
            | 4 -> printfn "Wprowadziłeś 4"
            | _ -> printfn "Wprowadziłeś inną wartośc niż 1, 2, 3 lub 4"






    // Zadanie 2
    let zadanie2 = 
        printf "Podaj piewszą liczbę: "
        let a = System.Console.ReadLine()
        printf "Podaj piewszą liczbę: "
        let b = System.Console.ReadLine()
        let x = System.Int32.Parse(a)
        let y = System.Int32.Parse(b)
        let para = (x, y)
        let porownanie x y =
            if x > y then
                x
            else
                y
        porownanie x y






    // Zadanie 3
    let funTroj a b c = 
        let obwod = a + b + c
        let p = (a + b + c) / 2.0
        let PP = sqrt(p * (p - a) * (p - b) * (p - c))
        let trojkat1 = (obwod, PP)
        printfn $"Obwód trójkąta to: {fst trojkat1}"
        printfn $"Pole trójkąta to: {snd trojkat1}"
    

    funTroj 3.0 4.0 5.0






    // Zadanie 4
    open System
    let rozdziel (text:String) = 
        let osobno = text.Split([|"@"|], StringSplitOptions.None)
        let id = osobno.[0]
        let ds = osobno.[1]
        printfn $"Identyfikator: {id}"
        printfn $"Adres domenosy serwera: {ds}"

    rozdziel "JakubJanik2k@gmail.com"





    // Zadanie 5
    open System
    let rozdziel (text:String) = 
        let osobno = text.Split([|"@"|], StringSplitOptions.None)
        let id = osobno.[0]
        let ds = osobno.[1]
        printfn $"Identyfikator: {id}"
        printfn $"Adres domenosy serwera: {ds}"
        match ds with
            | "pcz.pl" -> printfn $"{id} należy do domeny PCz"
            | _ -> printfn $"{id} nie należy do domeny PCz"

    rozdziel "JakubJanik2k@pcz.pl"





    // Zadanie 6
    type Punkt = {
        x:float
        y:float
        z:float
    }

    let p1 = {x=3; y=4; z=5}
    let p2 = {x=8; y=7; z=6}

    let Euklides = 
        let xx = (p1.x - p2.x)**2
        let yy = (p1.y - p2.y)**2
        let zz = (p1.z - p2.z)**2
        let wyn = sqrt (xx + yy + zz)
        printfn $"Odległośc między punktami wynosi: {wyn}"







    // Zadanie 7
    type okrag = {
        srodek: float * float;
        promien: float;
    }

    let p3 = (5.0, 6.0)
    let o1 = {srodek = (10, 10); promien = 10;}

    let odleglosc (x1:float, y1:float) (x2:float, y2:float) = 
        sqrt ((x1-x2)**2 + (y1-y2)**2)


    let czyWSrodku okrag punkt = 
        (odleglosc okrag.srodek punkt) < okrag.promien

    czyWSrodku o1 p3





    // Zadanie 8









    // Zadanie 9











    // Zadanie 10

    open System
    let okreslDate (text:String) = 
        let osobno = text.Split([|"."|], StringSplitOptions.None)
        let dzien = osobno.[0]
        let miesiac = osobno.[1]
        let rok = osobno.[2]

        let przest = 
            if rok % 4 = 1 then
                1
            else
                0

        let CC = 
            if rok >= 1700 && rok < 1800 then
                4
            elif rok >= 1800 && rok < 1900 then
                2
            elif rok >= 1900 && rok < 2000 then
                0
            elif rok >= 2000 && rok < 2100 then
                6
            elif rok >= 2100 && rok < 2200 then
                4
            elif rok >= 2200 && rok < 2300 then
                2
            elif rok >= 2300 then
                0
            else
                failwith "ERROR"
        
        let MC = 
            if miesiac = 01 then
                0
            elif miesiac = 02 then
                3
            elif miesiac = 02 then
                3
            elif miesiac = 02 then
                6
            elif miesiac = 02 then
                1
            elif miesiac = 02 then
                4
            elif miesiac = 02 then
                6
            elif miesiac = 02 then
                2
            elif miesiac = 02 then
                5
            elif miesiac = 02 then
                0
            elif miesiac = 02 then
                3
            elif miesiac = 02 then
                5
            else 
                failwith "ERROR"

        let YC = 










    let dataa = System.Console.ReadLine()
    okreslDate dataa







    // Zadanie 11
    let podziel (a:float) (b:float) = 
        if b <> 0 then
            a / b
        else
            failwith "Nie można dzielić przez 0"

    podziel 10 4







    // Zadanie 12











    // Zadanie 13
    let funTroj2 a b c = 
        if a + b > c && a + c > b && c + b > a then
            let obwod = a + b + c
            let p = (a + b + c) / 2.0
            let PP = sqrt(p * (p - a) * (p - b) * (p - c))
            let trojkat1 = (obwod, PP)
            printfn $"Obwód trójkąta to: {fst trojkat1}"
            printfn $"Pole trójkąta to: {snd trojkat1}"
        else
            printfn $"Nie można zbudować trójkąta"    
        
    
    funTroj2 3.0 4.0 5.0





    // Zadanie 14
    let zadanie14 = 
        printf "Podaj współczynnik a: "
        let a1 = System.Console.ReadLine()
        printf "Podaj współczynnik b: "
        let b1 = System.Console.ReadLine()
        printf "Podaj współczynnik c: "
        let c1 = System.Console.ReadLine()
        let a = System.Int32.Parse(a1)
        let b = System.Int32.Parse(b1)
        let c = System.Int32.Parse(c1)

















    // Zadanie 15
    type osoba = {
        i:string
        n:string
        w:int
    }

    let zadanie15 = 
        printfn "WYBIERZ OPCJE"
        printfn "1 - Utworzenie rekordu"
        printfn "2 - Modyfikacja rekordu"
        printfn "3 - Pokaz rekordu"
        printfn "4 - zakończenie programu"
        let mutable x = System.Console.ReadLine()
        let mutable liczba = System.Int32.Parse(x)
        while (liczba <> 4 && liczba < 4 && liczba > 0) do
            if liczba = 1 then
                printfn "Podaj imie"
                let imie1 = System.Console.ReadLine()
                printfn "Podaj nazwisko"
                let nazwisko1 = System.Console.ReadLine()
                printfn "Podaj wiek"
                let wiek1 = System.Console.ReadLine()
                let wiek11 = System.Int32.Parse(wiek1)
                let os1 = {i=imie1; n=nazwisko1; w=wiek11}
                printfn "Utworzono rekord"
            elif liczba = 2 then
                printfn "XD2"
            else
                printfn $"Imie: {os1.i}"
                printfn $"Nazwisko: {os1.n}"
                printfn $"Wiek: {os1.w}"
                
            printfn "WYBIERZ OPCJE"
            printfn "1 - Utworzenie rekordu"
            printfn "2 - Modyfikacja rekordu"
            printfn "3 - Pokaz rekordu"
            printfn "4 - zakończenie programu"
            let mutable x2 = System.Console.ReadLine()
            let mutable liczba2 = System.Int32.Parse(x2)
            liczba <- liczba2
        printfn "ZAKOŃCZONO PROGRAM"




                // To do liczba = 1
                printf "Podaj imie: "
                let im = System.Console.ReadLine()
                printf "Podaj nazwisko: "
                let naz = System.Console.ReadLine()
                printf "Podaj wiek: "
                let wi = System.Console.ReadLine()
                let wie = System.Int32.Parse(wi)
                let os {imie=im; nazwisko=naz; wiek=wie}

                // To do liczba = 2
                printfn $"Imię: {os.imie}"
                printf "Podaj nowe imie: "
                let im = System.Console.ReadLine()
                printfn $"Nazwisko: {os.nazwisko}"
                printf "Podaj nowe nazwisko: "
                let naz = System.Console.ReadLine()
                printfn $"Wiek: {os.wiek}"
                printf "Podaj nowy wiek: "
                let wi = System.Console.ReadLine()
                let wie = System.Int32.Parse(wi)
                let os {imie=im; nazwisko=naz; wiek=wie}

                // To do liczba = else
                printfn $"Imię: {os.imie}"
                printfn $"Nazwisko: {os.nazwisko}"
                printfn $"Wiek: {os.wiek}"







    // Zadanie 16


    0