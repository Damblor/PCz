// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let wariancja n =
    let rec oblicz n =
        if n < 4 then
            0.0
        else
            (double)1/6.0 + oblicz (n - 1)
    oblicz n

[<EntryPoint>]
let main argv =
    Console.WriteLine(wariancja 5)
    
    0 // return an integer exit code