' <Snippet10>
Public Class StringSplit2
    Public Shared Sub Main()

        Dim delimStr As String = " ,.:"
        Dim delimiter As Char() = delimStr.ToCharArray()
        Dim words As String = "one two,three:four."

        Dim i As Integer
        For i = 1 To 5
            Dim split As String() = words.Split(delimiter, i)
            Console.WriteLine(ControlChars.Cr + "count = {0,2} ..............", i)
            Dim s As String
            For Each s In split
                Console.WriteLine("-{0}-", s)
            Next s
        Next i
    End Sub
End Class

' The example displays the following output:
'
'       count =  1 ..............
'       -one two,three:four.-
'       count =  2 ..............
'       -one-
'       -two,three:four.-
'       count =  3 ..............
'       -one-
'       -two-
'       -three:four.-
'       count =  4 ..............
'       -one-
'       -two-
'       -three-
'       -four.-
'       count =  5 ..............
'       -one-
'       -two-
'       -three-
'       -four-
'       --
' </Snippet10>
