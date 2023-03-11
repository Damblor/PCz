// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let fn1 (a, b) =
    if a * a > b * b then
        a
    else
        b

let fn2 =
    let r = new Random();
    let rec generuj n min max =
        if n = 1 then
            [(r.NextDouble() * (max - min) + min, r.NextDouble() * (max - min) + min)]
        else
            (r.NextDouble() * (max - min) + min, r.NextDouble() * (max - min) + min)::(generuj (n - 1) min max)
    generuj 40 -20.0 20.0
        
type list_of_points = (float * float) list

type prostakat = {
    x_zakres: (float * float);
    y_zakres: (float * float);
}

let rec fn3 (list: list_of_points): (list_of_points * list_of_points) =
    match list with
    | [] -> 
        let empty_list = List.empty<float * float>
        (empty_list, empty_list)
    | (x, y)::tail -> 
        let (w, poza) = fn3 tail
        if x * x + y * y <= 5.0**2.0 then
            ((x,y)::w, poza)
        else
            (w, (x,y)::poza)

let wariancja n k =
    let rec silnia n =
        if n = 0 then
            1
        else
            n * silnia (n - 1)
    (silnia n) / (silnia (n - k))

let czy_w_srodku (prost: prostakat) (punkt_x: float, punkt_y: float) =
    let w_zakresie p (min, max) = min <= p && p <= max
    (w_zakresie punkt_x (prost.x_zakres)) && (w_zakresie punkt_y (prost.y_zakres))

[<EntryPoint>]
let main argv =
    let p: prostakat = { x_zakres = (1.0, 4.0); y_zakres = (1.0, 3.0) }
    
    Console.WriteLine(czy_w_srodku p (1.5, 2.0));
    Console.WriteLine(czy_w_srodku p (1.5, 3.1));
    
    Console.WriteLine(fn1 (-5, 4));
    Console.WriteLine(fn2.Length);

    let (w, poza) = fn2 |> fn3
    w |> printfn "W: %A\n"
    poza |> printfn "Poza: %A"
    
    Console.WriteLine(wariancja 10 6);

    0 // return an integer exit code