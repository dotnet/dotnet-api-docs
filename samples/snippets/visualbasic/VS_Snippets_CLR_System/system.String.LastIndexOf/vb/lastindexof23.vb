' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Main()
        ' <Snippet23>
        Dim position As Integer
        Dim softHyphen As String = ChrW(&HAD)

        Dim s1 As String = "ani" + softHyphen + "mal"
        Dim s2 As String = "animal"

        ' Find the index of the soft hyphen followed by "n".
        position = s1.LastIndexOf("m")
        Console.WriteLine("'m' at position {0}", position)
        If position >= 0 Then
            Console.WriteLine(s1.LastIndexOf(softHyphen + "n", position, position + 1))
        End If

        position = s2.LastIndexOf("m")
        Console.WriteLine("'m' at position {0}", position)
        If position >= 0 Then
            Console.WriteLine(s2.LastIndexOf(softHyphen + "n", position, position + 1))
        End If

        ' Find the index of the soft hyphen followed by "m".
        position = s1.LastIndexOf("m")
        Console.WriteLine("'m' at position {0}", position)
        If position >= 0 Then
            Console.WriteLine(s1.LastIndexOf(softHyphen + "m", position, position + 1))
        End If

        position = s2.LastIndexOf("m")
        Console.WriteLine("'m' at position {0}", position)
        If position >= 0 Then
            Console.WriteLine(s2.LastIndexOf(softHyphen + "m", position, position + 1))
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
        ' </Snippet23>
    End Sub
End Module
