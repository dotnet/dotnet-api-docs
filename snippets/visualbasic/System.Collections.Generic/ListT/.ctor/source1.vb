' <Snippet1>
Imports System.Collections.Generic

Partial Public Class Program
    Public Shared Sub ShowPlanets()
        ' <snippet2>
        Dim planets As New List(Of String)

        Console.WriteLine(vbLf & "Capacity: {0}", planets.Capacity)

        planets.Add("Mercury")
        planets.Add("Venus")
        planets.Add("Earth")
        planets.Add("Mars")
        planets.Add("Jupiter")
        ' </snippet2>

        Console.WriteLine()
        For Each planet As String In planets
            Console.WriteLine(planet)
        Next

        Console.WriteLine(vbLf & "Capacity: {0}", planets.Capacity)
        Console.WriteLine("Count: {0}", planets.Count)

        Console.WriteLine(vbLf & "Contains(""Mars""): {0}", _
            planets.Contains("Mars"))

        Console.WriteLine(vbLf & "Insert(2, ""Saturn"")")
        planets.Insert(2, "Saturn")

        Console.WriteLine()
        For Each planet As String In planets
            Console.WriteLine(planet)
        Next
        ' <snippet3>
        ' Shows how to access the list using the Item property.
        Console.WriteLine(vbLf & "planets(3): {0}", planets(3))
        ' </snippet3>
        Console.WriteLine(vbLf & "Remove(""Jupiter"")")
        planets.Remove("Jupiter")

        Console.WriteLine()
        For Each planet As String In planets
            Console.WriteLine(planet)
        Next

        planets.TrimExcess()
        Console.WriteLine(vbLf & "TrimExcess()")
        Console.WriteLine("Capacity: {0}", planets.Capacity)
        Console.WriteLine("Count: {0}", planets.Count)

        planets.Clear()
        Console.WriteLine(vbLf & "Clear()")
        Console.WriteLine("Capacity: {0}", planets.Capacity)
        Console.WriteLine("Count: {0}", planets.Count)
    End Sub
End Class

' This code example produces the following output:
'
' Capacity: 0
'
' Mercury
' Venus
' Earth
' Mars
' Jupiter
'
' Capacity: 8
' Count: 5
'
' Contains("Mars"): True
'
' Insert(2, "Saturn")
'
' Mercury
' Venus
' Saturn
' Earth
' Mars
' Jupiter
'
' planets(3): Earth
'
' Remove("Jupiter")
'
' Mercury
' Venus
' Saturn
' Earth
' Mars
'
' TrimExcess()
' Capacity: 5
' Count: 5
'
' Clear()
' Capacity: 5
' Count: 0
' </Snippet1>
