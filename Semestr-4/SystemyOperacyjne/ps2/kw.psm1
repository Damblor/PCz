New-Variable -Name PI -Value [math]::PI -Option Constant
function WartoscDoKwadratu {
    PROCESS
    {
        [math]::Pow($_,2)
    }
}
New-Alias Kwadrat WartoscDoKwadratu