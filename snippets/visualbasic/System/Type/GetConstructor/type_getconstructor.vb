﻿' <Snippet1>
Imports System.Reflection
Imports System.Security

Public Class MyClass1

    Public Sub New()
    End Sub

    Public Sub New(ByVal i As Integer)
    End Sub

    Public Shared Sub Main()
        Try
            Dim myType As Type = GetType(MyClass1)
            Dim types(0) As Type
            types(0) = GetType(Int32)
            ' Get the constructor that takes an integer as a parameter.
            Dim constructorInfoObj As ConstructorInfo = myType.GetConstructor(types)
            If Not (constructorInfoObj Is Nothing) Then
                Console.WriteLine("The constructor of MyClass that takes an integer as a parameter is: ")
                Console.WriteLine(constructorInfoObj.ToString())
            Else
                Console.WriteLine("The constructor of MyClass that takes no " + "parameters is not available.")
            End If

        Catch e As Exception
            Console.WriteLine("Exception caught.")
            Console.WriteLine(("Source: " + e.Source))
            Console.WriteLine(("Message: " + e.Message))
        End Try
    End Sub
End Class
' </Snippet1>
