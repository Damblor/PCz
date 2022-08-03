// Learn more about F# at http://fsharp.org

open System

type Ulamek = int*int

let dodawanie u1 u2 = 
    ((fst u1)*(snd u2)+(snd u1)*(fst u2), (snd u1)*(snd u2))

let odejmowanie u1 u2 = 
    ((fst u1)*(snd u2)-(snd u1)*(fst u2), (snd u1)*(snd u2))

let mnozenie u1 u2 = 
    ((fst u1)*(fst u2), (snd u1)*(snd u2))

let dzielenie u1 u2 = 
    ((fst u1)*(snd u2), (snd u1)*(fst u2))

[<EntryPoint>]
let main argv =
    let u1 = (1,2)
    let u2 = (1,4)

    printfn "dodawanie %A" (dodawanie u1 u2)
    printfn "odejmowanie %A" (odejmowanie u1 u2)
    printfn "mnozenie %A" (mnozenie u1 u2)
    printfn "dzielenie %A" (dzielenie u1 u2)
    0 // return an integer exit code
