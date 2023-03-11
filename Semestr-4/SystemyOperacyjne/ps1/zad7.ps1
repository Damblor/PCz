[int]$x = Read-Host "Podaj x"
[int]$y = Read-Host "Podaj y"
[char]$znak = Read-Host "podaj znak"

$wynik = 0

switch ($znak) {
    '+' { $wynik = $x+$y }
    '-' { $wynik = $x-$y }
    '*' { $wynik = $x*$y }
    '/' { $wynik = $x/$y }
    Default { $wynik = "Zly znak"}
}
Write-Host $wynik