[int]$ilosc = Read-Host "Podaj ilosc"
for($i = 0; $i -lt $ilosc; $i++)
{
    New-Item ((Get-Random -SetSeed $i).ToString()+".txt") -ItemType "File"
}