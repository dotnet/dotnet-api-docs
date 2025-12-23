' <Snippet1>
Imports System.Collections.Generic

Partial Public Class Program
    Public Shared Sub ShowFruits()

        Dim input() As String = { "Apple", _
                                  "Banana", _
                                  "Orange" }

        Dim fruits As New List(Of String)(input)

        Console.WriteLine(vbLf & "Capacity: {0}", fruits.Capacity)
        Console.WriteLine()

        For Each fruit As String In fruits
            Console.WriteLine(fruit)
        Next

        Console.WriteLine(vbLf & "AddRange(fruits)")
        fruits.AddRange(fruits)

        Console.WriteLine()
        For Each fruit As String In fruits
            Console.WriteLine(fruit)
        Next

        Console.WriteLine(vbLf & "RemoveRange(2, 2)")
        fruits.RemoveRange(2, 2)

        Console.WriteLine()
        For Each fruit As String In fruits
            Console.WriteLine(fruit)
        Next

        input = New String() { "Mango", _
                               "Pineapple", _
                               "Watermelon" }

        Console.WriteLine(vbLf & "InsertRange(3, input)")
        fruits.InsertRange(3, input)

        Console.WriteLine()
        For Each fruit As String In fruits
            Console.WriteLine(fruit)
        Next

        Console.WriteLine(vbLf & "output = fruits.GetRange(2, 3).ToArray")
        Dim output() As String = fruits.GetRange(2, 3).ToArray()

        Console.WriteLine()
        For Each fruit As String In output
            Console.WriteLine(fruit)
        Next

    End Sub
End Class

' This code example produces the following output:
'
' Capacity: 3
'
' Apple
' Banana
' Orange
'
' AddRange(fruits)
'
' Apple
' Banana
' Orange
' Apple
' Banana
' Orange
'
' RemoveRange(2, 2)
'
' Apple
' Banana
' Banana
' Orange
'
' InsertRange(3, input)
'
' Apple
' Banana
' Banana
' Mango
' Pineapple
' Watermelon
' Orange
'
' output = fruits.GetRange(2, 3).ToArray
'
' Banana
' Mango
' Pineapple
' </Snippet1>
