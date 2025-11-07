' <Snippet1>
Imports System.Collections.Generic

Partial Public Class Program
    Public Shared Sub Main()

        Dim animals As New List(Of String)(4)

        Console.WriteLine(vbLf & "Capacity: {0}", animals.Capacity)

        animals.Add("Cat")
        animals.Add("Dog")
        animals.Add("Squirrel")
        animals.Add("Wolf")

        Console.WriteLine()
        For Each animal As String In animals
            Console.WriteLine(animal)
        Next

        Console.WriteLine(vbLf & _
            "Dim roAnimals As IList(Of String) = animals.AsReadOnly")
        Dim roAnimals As IList(Of String) = animals.AsReadOnly

        Console.WriteLine(vbLf & "Elements in the read-only IList:")
        For Each animal As String In roAnimals
            Console.WriteLine(animal)
        Next

        Console.WriteLine(vbLf & "animals(2) = ""Lion""")
        animals(2) = "Lion"

        Console.WriteLine(vbLf & "Elements in the read-only IList:")
        For Each animal As String In roAnimals
            Console.WriteLine(animal)
        Next

    End Sub
End Class

' This code example produces the following output:
'
' Capacity: 4
'
' Cat
' Dog
' Squirrel
' Wolf
'
' Dim roAnimals As IList(Of String) = animals.AsReadOnly
'
' Elements in the read-only IList:
' Cat
' Dog
' Squirrel
' Wolf
'
' animals(2) = "Lion"
'
' Elements in the read-only IList:
' Cat
' Dog
' Lion
' Wolf
' </Snippet1>
