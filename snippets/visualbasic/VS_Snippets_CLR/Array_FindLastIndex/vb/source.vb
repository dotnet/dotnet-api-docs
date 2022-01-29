﻿' <Snippet1>
Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs() As String = { "Compsognathus", _
            "Amargasaurus",   "Oviraptor",      "Velociraptor", _
            "Deinonychus",    "Dilophosaurus",  "Gallimimus", _
            "Triceratops" }

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "Array.FindLastIndex(dinosaurs, AddressOf EndsWithSaurus): {0}", _
            Array.FindLastIndex(dinosaurs, AddressOf EndsWithSaurus))

        Console.WriteLine(vbLf & _
            "Array.FindLastIndex(dinosaurs, 4, AddressOf EndsWithSaurus): {0}", _
            Array.FindLastIndex(dinosaurs, 4, AddressOf EndsWithSaurus))

        Console.WriteLine(vbLf & _
            "Array.FindLastIndex(dinosaurs, 4, 3, AddressOf EndsWithSaurus): {0}", _
            Array.FindLastIndex(dinosaurs, 4, 3, AddressOf EndsWithSaurus))

    End Sub

    ' Search predicate returns true if a string ends in "saurus".
    Private Shared Function EndsWithSaurus(ByVal s As String) _
        As Boolean

        ' AndAlso prevents evaluation of the second Boolean
        ' expression if the string is so short that an error
        ' would occur.
        If (s.Length > 5) AndAlso _
            (s.Substring(s.Length - 6).ToLower() = "saurus") Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

' This code example produces the following output:
'
'Compsognathus
'Amargasaurus
'Oviraptor
'Velociraptor
'Deinonychus
'Dilophosaurus
'Gallimimus
'Triceratops
'
'Array.FindLastIndex(dinosaurs, AddressOf EndsWithSaurus): 5
'
'Array.FindLastIndex(dinosaurs, 4, AddressOf EndsWithSaurus): 1
'
'Array.FindLastIndex(dinosaurs, 4, 3, AddressOf EndsWithSaurus): -1
' </Snippet1>