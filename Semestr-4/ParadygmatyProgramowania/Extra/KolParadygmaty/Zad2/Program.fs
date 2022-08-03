// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

type BinartTree<'T> =
| Node of ('T * BinartTree<'T> * BinartTree<'T>)
| Empty

let CheckCondition (condition: 'a -> bool) (tree: BinartTree<'a>) =
    let rec Check tree (condition: 'a -> bool) =
        match tree with
        | Empty -> true
        | Node(c, left, right) -> (condition c) && (Check left condition) && (Check right condition)
    Check tree condition

[<EntryPoint>]
let main argv =
    let condition x = x = 0
    Console.WriteLine(CheckCondition condition (Node(2, Node(11, Empty, Empty), Node(4, Empty, Empty))));
    Console.WriteLine(CheckCondition condition (Node(1, Node(3, Empty, Empty), Node(-8, Empty, Empty))));
    Console.WriteLine(CheckCondition condition (Node(-1, Node(3, Empty, Empty), Node(7, Empty, Empty))));
    Console.WriteLine(CheckCondition condition (Node(0, Node(0, Empty, Empty), Node(0, Empty, Empty))));
    0 // return an integer exit code