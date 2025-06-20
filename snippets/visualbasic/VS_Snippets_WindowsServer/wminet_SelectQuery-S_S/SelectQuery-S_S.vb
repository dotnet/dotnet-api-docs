﻿'<Snippet1>
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim s As New SelectQuery("Win32_Service", _
            "State = 'Stopped'")

        Dim searcher As ManagementObjectSearcher
        searcher = New ManagementObjectSearcher(s)

        For Each service As ManagementObject In searcher.Get()
            'show the class
            Console.WriteLine(service.ToString())
        Next


    End Function 'Main
End Class
'</Snippet1>