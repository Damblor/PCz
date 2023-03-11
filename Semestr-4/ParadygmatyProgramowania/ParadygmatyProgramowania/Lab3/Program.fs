// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

//Przyklady
type Lista<'a> =
| Pusta
| Wezel of 'a*Lista<'a>

let glowa =
    function
    | Pusta -> failwith "pusta"
    | Wezel(glowa,_) -> glowa

let ogon =
    function
    | Pusta -> failwith "pusta"
    | Wezel(_, ogon) -> ogon

(*let rec liczbaElementow =
    function
    | Pusta -> 0
    | Wezel(_, ogon) -> liczbaElementow ogon + 1*)


let liczbaElementow lista =
    let rec liczbaElementow suma =
        function
        | Pusta -> suma
        | Wezel(glowa, ogon) -> liczbaElementow (suma + 1) ogon
    liczbaElementow 0 lista

let rec dodajPo element nowyElement =
    function
    | Pusta -> failwith ("pusta" + element.ToString())
    | Wezel (glowa, ogon) ->
        if glowa = element then
            Wezel(element,Wezel(nowyElement,ogon))
        else
            Wezel(glowa, dodajPo element nowyElement ogon)

let rec ogonPoElemencie element =
    function
    | Pusta -> failwith ($"Brak elementu {element}")
    | Wezel (glowa,ogon) ->
        if glowa = element then
            ogon
        else
            ogonPoElemencie element ogon

let kopiujDoElementu element lista =
    let rec kopiujDoelementu element nowaLista =
        function
        | Pusta -> nowaLista
        | Wezel(glowa, ogon) ->
        let nowyElement = Wezel(glowa, nowaLista)
        if glowa = element then
            nowyElement
        else
            kopiujDoelementu element nowyElement ogon
    kopiujDoelementu element Pusta lista

let poloczListy lista1 lista2 = 
    let rec poloaczListy listaWynikowa =
        function
        | Pusta -> listaWynikowa
        | Wezel(glowa, ogon) ->
            poloaczListy(Wezel(glowa, listaWynikowa)) ogon
    poloaczListy lista2 lista1

let lista1 = Wezel(1,Wezel(2,Wezel(3,Wezel(4,Pusta))))
let lista2 = Wezel(1,Wezel(2,Wezel(3,Wezel(4,Pusta))))

let rec dwaRazyWieksza = 
    function
    | Pusta -> Pusta
    | Wezel(glowa, ogon) -> Wezel (glowa*2,dwaRazyWieksza ogon)

let rec tylkoParzyste =
    function
    | Pusta -> Pusta
    | Wezel(glowa, ogon) ->
        if glowa%2=0 then
            Wezel(glowa, tylkoParzyste ogon)
        else
            tylkoParzyste ogon

let rec zip lista1 lista2 =
    match (lista1, lista2) with
    | (Pusta, Pusta) -> Pusta
    | (Wezel (glowa1,ogon1), Wezel (glowa2,ogon2)) ->
        Wezel((glowa1,glowa2), zip ogon1 ogon2)
    | (Pusta, _) | (_, Pusta) -> failwith "Obie listy powinny miec taka sama liczbe elementow"

let rec sumuj =
    function
    | Pusta -> 0
    | Wezel(glowa, ogon) -> glowa + sumuj ogon
    
//Zadania listy
//Zadanie 3.1
let rec zad3_1 n =
    if n = 0 then
        Lista.Pusta
    else 
        Lista.Wezel(n, zad3_1 (n - 1))

//Zadanie 3.2
let rec zad3_2 n m =
    if(n = m) then
        Lista.Pusta
    else
        Lista.Wezel(n, zad3_2 (n + 1) m)

//Zadanie 3.3
let rec zad3_3 (n:int) = 
    function
    | Pusta -> failwith "Pusta"
    | Wezel(glowa, ogon) -> 
        if n = 0 then
            glowa
        else 
            zad3_3 (n - 1) ogon

//Zadanie 3.4
let rec zad3_4 (n:int) =
    function
        | Pusta -> false
        | Wezel(glowa, ogon) ->
            if glowa = n then
                true
            else
                zad3_4 n ogon
    
//Zadanie 3.5

//Zadanie 3.6
(*let rec zad3_6 (n:int) =
    function
    | Pusta -> failwith ("pusta")
    | Wezel (glowa, ogon) ->
        if n = 0 then
            
        else
            zad3_3 (n - 1) ogon*)
         
//Zadanie 3.7
let rec zad3_7 (lista:Lista<int>) =
    float (sumuj lista) / float(liczbaElementow lista)
  
//Zadanie 3.8
    


[<EntryPoint>]
let main argv =
    (*//Zad1
    let lista = zad3_1 10
    Console.WriteLine(lista.ToString())*)
    
    (*//Zad2
    let lista = zad3_2 2 10
    Console.WriteLine(lista.ToString())*)

    (*//Zad3
    Console.WriteLine(zad3_3 2 (zad3_1 10))*)

    (*//Zad4
    Console.WriteLine(zad3_4 11 (zad3_1 10))*)

    (*//Zad7
    Console.WriteLine(zad3_7 (zad3_1 10))*)
    
    
    (*Console.WriteLine(lista.ToString())
    Console.WriteLine((kopiujDoElementu 3 lista).ToString())
    Console.WriteLine((dwaRazyWieksza lista).ToString())
    Console.WriteLine((tylkoParzyste lista).ToString())
    Console.WriteLine((zip lista lista2).ToString())
    Console.WriteLine((sumuj lista).ToString())
    Console.WriteLine(drzewo.ToString())
    Console.WriteLine((wstaw 4 drzewo).ToString())*)
    0 // return an integer exit code