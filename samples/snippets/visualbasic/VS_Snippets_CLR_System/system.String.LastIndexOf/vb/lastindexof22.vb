' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Main()
        ' <Snippet22>
        Dim position As Integer
        Dim softHyphen As String = ChrW(&HAD)
        Dim s1 As String = "ani" + softHyphen + "mal"
        Dim s2 As String = "animal"

        ' Find the index of the soft hyphen followed by "n".
        position = s1.LastIndexOf("m")
        Console.WriteLine($"'m' at position {position}")

        If position >= 0 Then
            Console.WriteLine(s1.LastIndexOf(softHyphen + "n", position))
        End If

        position = s2.LastIndexOf("m")
        Console.WriteLine($"'m' at position {position}")

        If position >= 0 Then
            Console.WriteLine(s2.LastIndexOf(softHyphen + "n", position))
        End If

        ' Find the index of the soft hyphen followed by "m".
        position = s1.LastIndexOf("m")
        Console.WriteLine($"'m' at position {position}")

        If position >= 0 Then
            Console.WriteLine(s1.LastIndexOf(softHyphen + "m", position))
        End If

        position = s2.LastIndexOf("m")
        Console.WriteLine($"'m' at position {position}")

        If position >= 0 Then
            Console.WriteLine(s2.LastIndexOf(softHyphen + "m", position))
        End If

        ' The example displays the following output:
        '
        ' 'm' at position 4
        ' 1
        ' 'm' at position 3
        ' 1
        ' 'm' at position 4
        ' 4
        ' 'm' at position 3
        ' 3
        ' </Snippet22>
    End Sub
End Module
