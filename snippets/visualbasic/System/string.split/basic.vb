Module basic
    Public Sub Basic1()
        '<snippet1>
        Dim s As String = "Today" & vbTab & "I'm going to school"
        Dim subs As String() = s.Split(" "c, Char.Parse(vbTab))

        For Each substring In subs
            Console.WriteLine("Substring: " & substring)
        Next

        ' This example produces the following output:
        '
        ' Substring: Today
        ' Substring: I 'm
        ' Substring: going
        ' Substring: to
        ' Substring: school
        '</snippet1>
    End Sub
End Module
