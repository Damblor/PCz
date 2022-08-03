// Learn more about F# at http://fsharp.org

open System

type Wynik<'a> = 
| Poprawny of 'a
| Bledny of string

let dzielenie a b =
    if b <> 0.0 then
        Poprawny (a/b)
    else
        Bledny "Nie można dzielić przez 0"

let doString = function
| Poprawny r -> (string r)
| Bledny e -> e


[<EntryPoint>]
let main argv =
    printfn "Podaj wartosc A i B: "
    let a = float (Console.ReadLine ())
    let b = float (Console.ReadLine ())
    let wynik = dzielenie a b
    printfn "%s" (doString wynik)

    0 // return an integer exit code
