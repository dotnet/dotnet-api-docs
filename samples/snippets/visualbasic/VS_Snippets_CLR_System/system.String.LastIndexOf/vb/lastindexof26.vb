' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Main()
        ' <Snippet26>
        Dim softHyphen As String = ChrW(&HAD)
        Dim s1 As String = "ani" + softHyphen + "mal"
        Dim s2 As String = "animal"

        Console.WriteLine("Culture-sensitive comparison:")

        ' Use culture-sensitive comparison to find the last soft hyphen followed by "n".
        Console.WriteLine(s1.LastIndexOf(softHyphen + "n", StringComparison.CurrentCulture))
        Console.WriteLine(s2.LastIndexOf(softHyphen + "n", StringComparison.CurrentCulture))

        ' Use culture-sensitive comparison to find the last soft hyphen followed by "m".
        Console.WriteLine(s1.LastIndexOf(softHyphen + "m", StringComparison.CurrentCulture))
        Console.WriteLine(s2.LastIndexOf(softHyphen + "m", StringComparison.CurrentCulture))

        Console.WriteLine("Ordinal comparison:")

        ' Use ordinal comparison to find the last soft hyphen followed by "n".
        Console.WriteLine(s1.LastIndexOf(softHyphen + "n", StringComparison.Ordinal))
        Console.WriteLine(s2.LastIndexOf(softHyphen + "n", StringComparison.Ordinal))

        ' Use ordinal comparison to find the last soft hyphen followed by "m".
        Console.WriteLine(s1.LastIndexOf(softHyphen + "m", StringComparison.Ordinal))
        Console.WriteLine(s2.LastIndexOf(softHyphen + "m", StringComparison.Ordinal))

        ' The example displays the following output:
        '
        ' Culture-sensitive comparison:
        ' 1
        ' 1
        ' 4
        ' 3
        ' Ordinal comparison:
        ' -1
        ' -1
        ' 3
        ' -1
        ' </Snippet26>
    End Sub
End Module
