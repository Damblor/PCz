open System

type drzewo_binarne<'T> =
| Node of ('T * drzewo_binarne<'T> * drzewo_binarne<'T>)
| Empty

let sprawdz (warunek: 'a -> bool) (drzewo: drzewo_binarne<'a>) =
    let rec spr drzewo (warunek: 'a -> bool) =
        match drzewo with
        | Empty -> true
        | Node(v, left, right) ->
            (warunek v) && (spr left warunek) && (spr right warunek)
    spr drzewo warunek

[<EntryPoint>]
let main argv =
    let warunek a = a > 5
    Console.WriteLine(
        sprawdz warunek (Node(6, Node(6, Empty, Empty), Node(8, Empty, Empty)))
    );
    Console.WriteLine(
        sprawdz warunek (Node(6, Node(4, Empty, Empty), Node(8, Empty, Empty)))
    );
    0