' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Main()
        ' <Snippet21>
        Dim softHyphen As String = ChrW(&HAD)
        Dim s1 As String = "ani" + softHyphen + "mal"
        Dim s2 As String = "animal"

        ' Find the index of the last soft hyphen followed by "n".
        Console.WriteLine(s1.LastIndexOf(softHyphen + "n"))
        Console.WriteLine(s2.LastIndexOf(softHyphen + "n"))

        ' Find the index of the last soft hyphen followed by "m".
        Console.WriteLine(s1.LastIndexOf(softHyphen + "m"))
        Console.WriteLine(s2.LastIndexOf(softHyphen + "m"))

        ' The example displays the following output:
        '
        ' 1
        ' 1
        ' 4
        ' 3
        ' </Snippet21>
    End Sub
End Module
