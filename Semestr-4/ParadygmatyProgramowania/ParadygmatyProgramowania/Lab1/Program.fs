open System

let poleKola r =
    r * r * Math.PI

let kwadrat a b c =
    let delta = b * b - 4.0 * a * c
    if delta < 0 then
        string "brak pierwiastkow"
    else if delta > 0 then
        let x1 = (-b - Math.Sqrt(delta)) / 2.0 * a
        let x2 = (b - Math.Sqrt(delta)) / 2.0 * a
        string (x1,x2)
    else 
        let x = -b / 2.0 * a
        string x

let czytrojkat a b c =
    a + b > c && a + c > b && b + c > a
        
let trojkat a b c =
    if czytrojkat a b c = false then
        string "Trojkat nie istnieje"
    else
        let p =  a + b + c
        let P = Math.Sqrt(p * (p - a) * (p - b) * (p - c))
        string p

let rec naturalne n =
    if n < 0 then 
        failwith "nieprawidlowe dane"
    else if n = 0 then
        0
    else 
        n + naturalne(n - 1)

let rec rek x n =
    if n < 0 then
        failwith "nieprawidlowe dane"
    else if n = 0 then
        1
    else
        x * rek x (n-1)

let rec fibb n =
    if n = 0 then
        0
    else if n = 1 then
        1
    else
        fibb(n-1) + fibb(n-2)

let rec dwumian n k =
    if k = 0 || n = k then
        1
    else
        dwumian(n - 1) k + dwumian(n - 1) (k - 1)

let rec pierwsza x i =
    if x % i <> 0 && i < x then
        pierwsza x (i + 1)
    else
        if x = i then
            true
        else
            false
    
let rec dzielnik a b =
    if b <> 0 then
        a
    else
        dzielnik b (a % b)

let e = Math.Pow(10.0, -7.0)

let rec silnia n =
    let wynik = n
    if n = 1 then
        1
    else
        wynik * silnia(n - 1)

let rec szereg1 i =
    let wartosc = 1.0 / (i * i)
    if Math.Abs(wartosc) < e then
        0.0
    else
        wartosc + szereg1(i + 1.0)

        

[<EntryPoint>]
let main argv =
    Console.WriteLine(poleKola(1.0));
    Console.WriteLine(kwadrat 1.0 5.0 1.0);
    Console.WriteLine(czytrojkat 2.0 2.0 3.0);
    Console.WriteLine(trojkat 2.0 2.0 3.0);
    Console.WriteLine(naturalne 4);
    Console.WriteLine(rek 2 2)
    Console.WriteLine(fibb 11)
    Console.WriteLine(dwumian 11 4)
    Console.WriteLine(pierwsza 12 2)
    Console.WriteLine(dzielnik 3 9)
    Console.WriteLine(szereg1 1)
    0 // return an integer exit code