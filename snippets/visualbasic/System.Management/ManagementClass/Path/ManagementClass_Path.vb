﻿'<Snippet1>
Imports System.Management

Public Class Sample

    Public Shared Function Main(ByVal args() _
        As String) As Integer

        Dim c As New ManagementClass
        c.Path.ClassName = "Win32_Process"

        Dim m As MethodData
        For Each m In c.Methods
            Console.WriteLine( _
                "The class contains the method : {0}", m.Name)
        Next m

        Return 0
    End Function
End Class
'</Snippet1>