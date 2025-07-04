﻿' <Snippet1>

Imports System.Reflection

Class Program

    ' Method to get:
    Public Sub MethodA()
    End Sub


    Public Shared Sub Main(ByVal args() As String)

        ' Get MethodA()
        Dim mInfo As MethodInfo = GetType(Program).GetMethod("MethodA", _
        	BindingFlags.Public Or BindingFlags.Instance)
        Console.WriteLine("Found method: {0}", mInfo)

    End Sub
End Class
' </Snippet1>
