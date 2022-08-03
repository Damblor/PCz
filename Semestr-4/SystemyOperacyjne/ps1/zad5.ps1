[string]$miesiace = (Get-Culture).DateTimeFormat.MonthNames
Write-Host $miesiace
$miesiace.Remove($miesiace.IndexOf("luty"),5)
$tablica = $miesiace.Split(" ")
for($i = 0; $i -lt $tablica.Length - 1; $i++)
{
    $indeks = (Get-Culture).DateTimeFormat.MonthNames.IndexOf($tablica[$i]) + 1 
    $dni = (Get-Culture).Calendar.GetDaysInMonth(2018, $indeks)
    $tablica[$i] += "-" + $dni
}
$nowy = [string]::Join(" ",$tablica)
Write-Host $nowy