Public Module Example
    Public Sub Main()
        ' <Snippet24>
        Dim searchString As String = ChrW(&HAD) + "m"

        Dim s1 As String = "ani" + ChrW(&HAD) + "m"
        Dim s2 As String = "animal"

        Dim position As Integer

        position = s1.LastIndexOf("m"c)
        If position >= 1 Then
            Console.WriteLine(s1.LastIndexOf(searchString, position, position, StringComparison.CurrentCulture))
            Console.WriteLine(s1.LastIndexOf(searchString, position, position, StringComparison.Ordinal))
        End If

        position = s2.LastIndexOf("m"c)
        If position >= 1 Then
            Console.WriteLine(s2.LastIndexOf(searchString, position, position, StringComparison.CurrentCulture))
            Console.WriteLine(s2.LastIndexOf(searchString, position, position, StringComparison.Ordinal))
        End If

        ' The example displays the following output:
        '
        ' 4
        ' 3
        ' 3
        ' -1
        ' </Snippet24>
    End Sub
End Module
