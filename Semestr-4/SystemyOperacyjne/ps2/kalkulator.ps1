switch($args.Count)
{
    1 
    {
        Write-Host "1.pierwiastek 2.Sin 3. Cos 4.Tan"
        [int]$d = Read-Host "Podaj dzialanie"
        switch ($d) {
            1 { $w = [math]::Sqrt($args[0])
                Write-Host $w }
            2 {  }
            3 {  }
            4 {  }
            Default {Write-Error "Jestes gupi"}
        }
    }
    2 
    {
        
    }
    Default {Write-Error "Jestes gupi"}
}