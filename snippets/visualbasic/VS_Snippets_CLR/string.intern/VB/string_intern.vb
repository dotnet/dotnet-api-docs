﻿'<snippet1>
Imports System.Text

Class Sample

    Public Shared Sub Main()
        Dim s1 As String = "MyTest"
        Dim s2 As String = New StringBuilder().Append("My").Append("Test").ToString()
        Dim s3 As String = String.Intern(s2)
        Console.WriteLine($"s1 = {s1}")
        Console.WriteLine($"s2 = {s2}")
        Console.WriteLine($"s3 = {s3}")
        Console.WriteLine($"Is s2 the same reference as s1?: {s2 Is s1}")
        Console.WriteLine($"Is s3 the same reference as s1?: {s3 Is s1}")
    End Sub
End Class
'
's1 = MyTest
's2 = MyTest
's3 = MyTest
'Is s2 the same reference as s1?: False
'Is s3 the same reference as s1?: True
'
'</snippet1>
