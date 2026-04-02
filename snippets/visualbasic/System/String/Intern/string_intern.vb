'<snippet1>
Imports System.Text

Class Sample

    Public Shared Sub Main()
        Dim s1 As String = New StringBuilder().Append("My").Append("Test").ToString()
        Dim s2 As String = New StringBuilder().Append("My").Append("Test").ToString()
        Console.WriteLine($"s1 = {s1}")
        Console.WriteLine($"s2 = {s2}")
        Console.WriteLine($"Are s1 and s2 equal in value? {s1 = s2}")
        Console.WriteLine($"Are s1 and s2 the same reference? {s1 Is s2}")

        Dim i1 As String = String.Intern(s1)
        Dim i2 As String = String.Intern(s2)
        Console.WriteLine("After interning:")
        Console.WriteLine($"  Are i1 and i2 equal in value? {i1 = i2}")
        Console.WriteLine($"  Are i1 and i2 the same reference? {i1 Is i2}")
    End Sub
End Class
'
's1 = MyTest
's2 = MyTest
'Are s1 and s2 equal in value? True
'Are s1 and s2 the same reference? False
'After interning:
'  Are i1 and i2 equal in value? True
'  Are i1 and i2 the same reference? True
'
'</snippet1>
