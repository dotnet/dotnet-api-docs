﻿
Public Module Source
    Sub Example()
        ' <Snippet3>
        Console.WriteLine(Math.Round(3.44, 1))
        Console.WriteLine(Math.Round(3.45, 1))
        Console.WriteLine(Math.Round(3.46, 1))
        Console.WriteLine()

        Console.WriteLine(Math.Round(4.34, 1))
        Console.WriteLine(Math.Round(4.35, 1))
        Console.WriteLine(Math.Round(4.36, 1))

        ' The example displays the following output:
        '       3.4
        '       3.4
        '       3.5
        '       
        '       4.3
        '       4.4
        '       4.4
        ' </Snippet3>
    End Sub
End Module
