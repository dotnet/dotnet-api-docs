' Visual Basic .NET Document
Option Strict On

Module Example3
    Public Sub Simple()
        ' <Snippet12>
        Dim value As String = "This is a short string."
        Dim delimiter As Char = "s"c
        Dim substrings() As String = value.Split(delimiter)
        For Each substring In substrings
            Console.WriteLine(substring)
        Next
    End Sub

    ' The example displays the following output:
    '
    '     Thi
    '      i
    '      a
    '     hort
    '     tring.
    ' </Snippet12>
End Module
