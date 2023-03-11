$lista = Get-ChildItem -Force
$wielkosc = 0
Write-Host $lista
foreach ($element in $lista)
{
    Write-Host $element.Length
    Write-Host $element.Attributes
    Write-Host $element.Name
    if($element.Attributes -notcontains "Directory")
    {
        $wielkosc += $element.Length
    }
}
Write-Host "Rozmiar: " $wielkosc