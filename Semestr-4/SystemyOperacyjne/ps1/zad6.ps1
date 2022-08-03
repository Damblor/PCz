Get-Process | Where-Object { 
    $_.Name -like "c*" -and $_.WS -ge 51200 }