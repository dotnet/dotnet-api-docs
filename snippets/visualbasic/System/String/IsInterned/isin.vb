'<snippet1>
' Sample for String.IsInterned(String)
Imports System.Text

Class Sample
    Public Shared Sub Main()
        ' Constructed strings are not automatically interned.
        Dim s1 As String = New StringBuilder().Append("My").Append("Test").ToString()
        Dim s2 As String = New StringBuilder().Append("My").Append("Test").ToString()

        ' Neither string is in the intern pool yet.
        Console.WriteLine($"Is s1 interned? {String.IsInterned(s1) IsNot Nothing}")
        Console.WriteLine($"Is s2 interned? {String.IsInterned(s2) IsNot Nothing}")

        ' Intern s1 explicitly.
        Dim i1 As String = String.Intern(s1)

        ' Now s2 can be found in the intern pool.
        Dim i2 As String = String.IsInterned(s2)

        Console.WriteLine($"Is s2 interned after interning s1? {i2 IsNot Nothing}")
        Console.WriteLine($"Are i1 and i2 the same reference? {Object.ReferenceEquals(i1, i2)}")
    End Sub
End Class

' This example produces the following results:
'
' Is s1 interned? False
' Is s2 interned? False
' Is s2 interned after interning s1? True
' Are i1 and i2 the same reference? True

'</snippet1>