Write-Host "1.Wiosna 2.Lato 3.Jesien 4.Zima"
[int]$p = Read-Host "Wybierz pore: "
switch ($p) {
    1 { Write-Host "1" }
    2 { Write-Host "2" }
    3 { Write-Host "3" }
    4 { Write-Host "4" }
    Default { Write-Host "JEstes gupi"}
}