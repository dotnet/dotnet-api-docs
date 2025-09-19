﻿'<snippet01>
Imports System.Collections.Generic

Class Program

    '<snippet02>
    Shared Sub Main()

        Dim lowNumbers As HashSet(Of Integer) = New HashSet(Of Integer)()
        Dim highNumbers As HashSet(Of Integer) = New HashSet(Of Integer)()

        For i As Integer = 0 To 5
            lowNumbers.Add(i)
        Next i

        For i As Integer = 3 To 9
            highNumbers.Add(i)
        Next i

        Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count)
        DisplaySet(lowNumbers)

        Console.Write("highNumbers contains {0} elements: ", highNumbers.Count)
        DisplaySet(highNumbers)

        Console.WriteLine("highNumbers ExceptWith lowNumbers...")
        highNumbers.ExceptWith(lowNumbers)

        Console.Write("highNumbers contains {0} elements: ", highNumbers.Count)
        DisplaySet(highNumbers)

    End Sub
    ' This example provides output similar to the following:
    ' lowNumbers contains 6 elements: { 0 1 2 3 4 5 }
    ' highNumbers contains 7 elements: { 3 4 5 6 7 8 9 }
    ' highNumbers ExceptWith lowNumbers...
    ' highNumbers contains 4 elements: { 6 7 8 9 }
    '</snippet02>

    Private Shared Sub DisplaySet(ByVal coll As HashSet(Of Integer))
        Console.Write("{")
        For Each i As Integer In coll
            Console.Write(" {0}", i)
        Next i
        Console.WriteLine(" }")
    End Sub

End Class
'</snippet01>
