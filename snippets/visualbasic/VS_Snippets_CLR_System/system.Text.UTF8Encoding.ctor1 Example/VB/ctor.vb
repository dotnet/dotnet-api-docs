﻿' <Snippet1>
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        Dim utf8 As New UTF8Encoding()
        Dim encodingName As String = utf8.EncodingName
        Console.WriteLine("Encoding name: " & encodingName)
    End Sub
End Class
' </Snippet1>
