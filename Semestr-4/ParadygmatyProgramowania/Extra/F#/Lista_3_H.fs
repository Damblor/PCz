open System

type Lista<'a> = 
    | Pusta
    | Element of 'a*Lista<'a>
    
let glowa = function
    | Pusta -> failwith "Brak glowy - lista jest pusta"
    | Element (glowa, _) -> glowa

let ogon = function
    | Pusta -> Pusta
    | Element(_, ogon) -> ogon



type Drzewo = 
        | Pusta
        | Wezel of int * Drzewo * Drzewo

let rec wielkoscDrzewa suma = function
    | Pusta -> suma
    | Wezel(x, l, p) ->
        let suma = wielkoscDrzewa suma l
        wielkoscDrzewa (suma + 1) p

let rec sumaDrzewa suma = function
    | Pusta -> suma
    | Wezel(x, l, p) ->
        let suma = sumaDrzewa suma l
        sumaDrzewa (suma + x) p

let rec szukajElementuWDrzewie e = function
    | Pusta -> false
    | Wezel(x, _, _) when x = e -> true
    | Wezel(_, l, p) ->
        if szukajElementuWDrzewie e l then true
        else szukajElementuWDrzewie e p


let rec glebokosc = function
    | Pusta -> 0
    | Wezel (_, l, p) -> 
        let gl = glebokosc l
        let gp = glebokosc p
        1 + max gl gp


[<EntryPoint>]

let main argv = 
    // Zadanie 1
    (* 
        Napisz funkcję, która generuje listę zbudowaną z N pierwszych liczb naturalnych. 
        Sygnatura funkcji powinna przymować następującą postać
        nPierwszych: n:int ->Lista<int> 
    *)
    let rec nPierwszych n =
        if n = 0 then
            Pusta
        else
            Element(n, nPierwszych (n-1))

    let l1 = nPierwszych 4


        





    // Zadanie 2
    // Napisz funkcję, która generuję listę liczb całkowitych z określonego przedziału min, max. 
    // Funkcja powinna również pozwalać okreslić krok z jakim wartości będę generowane. 
    // Pietwszą wartością na liście powinna być min, a ostatnia powinna być mniejsza lub równa max.
    let rec minMaxPrzed min max =
        if min = max then
            Pusta
        else
            Element(min, minMaxPrzed (min+1) max)

    let l2 = minMaxPrzed 2 7







    // Zadanie 3
    // Napisz funkcję, która zwróci n-ty element listy
    let l3 = [1..9]

    let rec nElem n li =
    match n, li with
      | 0, (x::_)   -> x
      | _, (_::li') -> nElem (n - 1) li'
      | _, []       -> invalidArg "n" "N jest za duże"
    
    nElem 2 l3
        









    // Zadanie 4
    // Napisz funkcję, która określi czy dany element znajduje się na liście.
    let l4 = [1..9]

    let rec czyJest n li =
    match n, li with
      | 0, (x::_)   -> true
      | _, (_::li') -> czyJest (n - 1) li'
      | _, []       -> false
    
    czyJest 5 l4




    // Zadanie 5
    // Napisz funkcję, która określi indeks podanego elementu. 
    // Jeżeli element nie znajduje się na liście zwróć odpowiednią wartość (możesz wykorzystać unie z dyskryminatorem)
    let l5 = [1..9]

    let znajdzInd n li = 
        li |> Seq.findIndex (fun s -> s = n)
    
    znajdzInd 5 l5







    // Zadanie 6
    // Napisz funkcję, która usuwa z listy element na podanej pozycji.
    let l6 = [1..9]

    let rec usunIndek i li =
    match i, li with
    | 0, x::xs -> xs
    | i, x::xs -> x::usunIndek (i - 1) xs
    | i, [] -> failwith "Nie znaleziono indeksu"
    
    let l66 = usunIndek 5 l6
    






    // Zadanie 7
    // Napisz funkcję pozwalającą obliczyć średnią wartość na liście.
    let l7 = [1..10]
    List.average (List.map (fun x -> float(x)) l7)








    // Zadanie 8
    (*
        Napisz funkcję, która pozwoli połączyć tablicę stringów w jeden łańcuch
        znaków. Funkcja powinna przyjmować parametr separator, który określa znak lub znaki
        jakimi należy rozdzielić poszczególne łańcuchy.
    *)
    let l8 = ["Kot";"w";"butach"]
    let polacz8 sep lis1 = 
        let r = lis1 |> List.fold (fun r s -> r + s + sep) ""
        printfn "%s" r

    polacz8 "---" l8








    // Zadanie 9
    (* 
        Napisz funkcję, która będzie przyjmowała listę stringów oraz zwracała listę
        liczb całkowitych zawierającą długość poszczególnych łańcuchów znaków. \
    *)
    let l9 = ["Lista"; "do"; "zadania"; "dziewiatego"]

    let naInta lis = 
        let f = fun (s:string) -> s.Length
        let lis1 = lis |> List.map f
        printf "%A" lis1

    naInta l9





    // Zadanie 10
    (*
        Napisz funkcję, która będzie przyjmowała listę stringów oraz wyszukiwała najdłuższy i najktótszy wyraz.
    *)
    let l10 = ["Lista"; "do"; "zadania"; "dziesiatego"]

    let minMaxSlow llis = 
        let f = fun (s:string) -> s.Length

        let znajdzInd n li = 
            li |> Seq.findIndex (fun s -> s = n)
        
        let rec nElem n li =
            match n, li with
            | 0, (x::_)   -> x
            | _, (_::li') -> nElem (n - 1) li'
            | _, []       -> invalidArg "n" "N jest za duże"

        let listNum = llis |> List.map f
        let maks = List.reduce max listNum
        let mini = List.reduce min najdluz
        let maxIndek = znajdzInd maks listNum
        let minIndek = znajdzInd mini listNum
        let maxSlow = nElem maxIndek llis
        let minSlow = nElem minIndek llis
        printfn $"Najdluższe słowo: {maxSlow}"
        printfn $"Najkrótsze słowo: {minSlow}"

    minMaxSlow l10

    

    


    // Zadanie 11 // NIE DZIALA
    (*
        Napisz funkcję,która będzie przyjmowała listę stringów reprezentujących
        polskie imiona i zwróci tylko listę imion żeńskich.
    *)
    let l11 = ["Agata"; "Tomasz"; "Weronika"; "Jakub"; "Kasia"; "Piotr"]
    let l111 = Element("Agata", Element("Tomasz", Element("Weronika", Element("Kasia", Pusta))))

  let rec filtrowanie predykat = function
    | Pusta -> Pusta
    | Element(x, ogon) when predykat(x) -> Element(x, filtrowanie predykat ogon)
    | Element(_, ogon) -> filtrowanie predykat ogon

    let aKon (x:string) = x.EndsWith 'a'
    let kona (n:string) = fun x -> n.EndsWith 'a'
//let wiekszeNiz n = fun x -> x > n
    filtrowanie (fun a -> aKon(a)) l111
    filtrowanie (kona) l11



    




    // Zadanie 12
    (*
        Napisz funkcję,która będzie odwracała kolejność elementów na liście.
    *)
    let l12 = [1..9]

    
    let rec reverse list =
        match list with
            |[] -> []
            |[x] -> [x]
            | glowa::ogon -> reverse ogon @ [glowa]

    reverse l12





    // Zadanie 13  // Jak się zrobi z11 to to będzie już es
    (*
        Napisz funkcję, która będzie przyjmowała listę stringów reprezentujących
        polskie imiona i zwróci dwie listy: osobno listę imion żeńskich oraz listę imion męskich.
    *)







    // Zadanie 14   // Nie zreobione
    (*
        Napisz funkcję,która będzie przyjmowała dwie listy liczb całkowitych i
        zwracała listę wartości logicznych, gdzie true określa, że liczba na pierwszej liście była
        większa, a false, że wartośc na drugiej liście była większa. Jeżeli jedna lista jest dłuższa
        od drugiej zwróć wyjątek informujący o tym fakcie.
    *)
    let l14a = [5; 1; 2; 7; 31; 12]
    let l14b = [1; 41; 22; 1; 4; 2]

    let logicznePorow la lb =
        let rec compare xl yl = 
            match xl, yl with 
            | [], [] -> false
            | x::xs, y::ys -> if x > y then
                Element(true, compare xs, ys)
            | _ -> false
        compare la lb

    logicznePorow l14a l14b
    





    
    // Zadanie 15
    (*
        Napisz funkcję, która będzie przyjmowała dwie listy liczb całkowitych i
        zwracała listę wartości zdefiniowanego przez ciebie typu wyliczeniowego, gdzie Pierwsza
        określa, że liczba na pierwszej liście była większa, a Druga, że wartośc na drugiej liście
        była większa. Jeżeli jedna lista się skończy, to generowanie listy wejściowej ma trwać
        dalej dopóki są elementy na drugiej liście. W tym przypadku przyjmujemy, że istniejący
        element jest większy niż nieistniejący.
    *)





    // Zadanie 16 // BEZ TYPU WYLICZENIOWEGO
    (*
        Napisz funkcję, która sprawdzi, czy lista elementów jest posortowana. Kierunek 
        sortowania (malejący lub rosnący) powinien być zdefiniowany jako typ wyliczeniowy
        i przekazywany do funkcji.
    *)

    type wybor22 = 
        | rosnaca = 1
        | malejaca = 0


    let l16 = [4; 1; 55; 2; 36; 21; 44]
    let l16a = [1; 3; 5; 7; 9; 11; 13]
    let l16b = [444; 124; 64; 42; 41; 22; 1]

    let czyPosortowana li = 
        printfn "Wybierz tryb sortowania:"
        printfn "1 - rosnąca"
        printfn "2 - malejaca"
        let wybor1 = System.Console.ReadLine()
        let wybor = System.Int32.Parse(wybor1)
        if wybor = 1 then
            let posort = List.sort li
            li = posort
        elif wybor = 2 then
            let posort = List.sort li
            let rec reverse list =
                match list with
                |[] -> []
                |[x] -> [x]
                | glowa::ogon -> reverse ogon @ [glowa]
            let posortOdw = reverse posort
            li = posortOdw
        else
            failwith "Wybrano złą opcję sortowania"

    czyPosortowana l16
    czyPosortowana l16a
    czyPosortowana l16b




    // Zadanie 17
    (*
        Napisz funkcję, która będzie przyjmowała dwie posortowane listy liczb
        całkowitych (listy powinny być posortowanewtym samym kierunku). Funkcja powinna
        łączyć te listy w jedną z zachowaniem porządku.
    *)







    // Zadanie 18
    (*
        Zaimplementuj stos wykorzystjąc przedstawioną listę łączoną
    *)











    // Zadanie 19
    (*
        Zaimplementuj mapę wykorzystując przedstawioną listę łączoną. Na liście
        przechowuj pary elementów (klucz;wartość). Dostęp do dowolnego elementu powinien
        następować po podaniu klucza.
    *)








    // Zadanie 20
    (*
        Napisz funckję, która będzie zliczała liczbę elementów na drzewie binarnym.
    *)
    

    let d1 = Wezel(4, Wezel(2, Wezel(1, Pusta, Pusta), Wezel(3, Pusta, Pusta)), Wezel(7, Pusta, Wezel(8, Pusta, Pusta)))

    wielkoscDrzewa 0 d1






    // Zadanie 21
    (*
        Napisz funkcję, która oblicza sumę wartości przechowywanychwdrzewie binarnym.
    *)

    let d2 = Wezel(4, 
                    Wezel(2, 
                            Wezel(1,  Pusta, Pusta), 
                            Wezel(3, Pusta, Pusta)), 
                    Wezel(7, 
                        Pusta, 
                        Wezel(8, Pusta, Pusta)))

    sumaDrzewa 0 d2









    // Zadanie 22
    (*
        Napisz funkcję pozwalającą usunąć element z uporządkowanego drzewa binarnego
    *)












    // Zadanie 23
    (*
        Napisz funkcję pozwalającą określić czy w uporządkowanym drzewie binarnym znajduje się podana wartość
    *)

    let d4 = Wezel(4, Wezel(2, Wezel(1, Pusta, Pusta), Wezel(3, Pusta, Pusta)), Wezel(7, Pusta, Wezel(8, Pusta, Pusta)))
    szukajElementuWDrzewie 7 d4







    // Zadanie 24
    (*
        Ścieżką do węzła N w drzewie nazywamy kolekcję wszystkich węzłów
        prowadzących od korzenia do tego węzła. Przykładowo, dla drzewa z ścieżka
        do węzła 8.0 to {4.0, 7.0, 8.0}. Napisz funkcję zwracającą ścieżkę do węzła z określoną
        wartością (dla uproszczenia zakładamy, że wartościwdrzewie się nie powtarzają).
    *)











    // Zadanie 25
    (*
        Napisz funkcję, która dla drzewa binarnego zwraca jego głębokość, czyli
        liczbę elementówwjego najdłuższej gałęzi.
    *)

    let d6 = Wezel(4, 
                Wezel(2, 
                        Wezel(1,  Pusta, Pusta), 
                        Wezel(3, Pusta, Pusta)), 
                Wezel(7, 
                    Pusta, 
                    Wezel(8, Pusta, Pusta)))
    glebokosc d6









    // Zadanie 26
    (*
        Niech drzewo reprezentuje wyrażenia arytmetyczne np:Zdefiniuj odpowiednie struktury do opisu takiego 
        drzewa oraz napisz funkcje, która pozwoli wyznaczyć wartość takiego wyrażenia.
        Możliwe do zastosowania operatory to: +, -, *, /, ^  (potęgowanie).
    *)










    // Zadanie 27
    (*
        Rozszerz poprzedni program tak, aby wspierał również funkcje np. sin, cos lub inne z typu Math
    *)









    // Zadanie 28
    (*
        Rozszerz poprzednmie programy tak, aby wspierały również zmienne (symbole), 
        których wartośc może być ustalona przed obliczeniem wartości wyrażenia.
    *)














    // Zadanie 29
    (*
        Jedno z zadań przedstawionych na poprzednich zajęciach dotyczyło wprowadzania i wyświetlania 
        informacji o osobie (Lista 2, zadanie 15). Rozszerz je, tak aby dało się wprowadzać dowolną liczbę osób.
        Rozszerz typ Osoba dodając do niego jednoznaczny identyfikator danej osoby (określ co to może być).
        Funkcje pokaż rekord i modyfikacja rekordu powinny pozwolić określić, na którym rekordzie 
        użytkownik chce wykonać działa nia.Dodaj również funkcje pozwalające wyszukać wszystkie 
        osoby o podanym nazwisku (i wyświetlić listę tych osób na ekranie)oraz usunąć wybraną osobę.
    *)










    // Zadanie 30
    (*
        Napisz program,który będzie pozwalał użytkownikowi na wprowadzanie
        z klawiatury liczb oraz operatorów i funkcji matematycznych w odwrotnej notacji polskiej
        (przy czym zakładamy, że każdy element jest podawany w nowej linii i zatwierdzany osobno).
        Po podaniu symbolu '=' program powinien obliczać wartość podanego wyrażenia.
    *)

    0









