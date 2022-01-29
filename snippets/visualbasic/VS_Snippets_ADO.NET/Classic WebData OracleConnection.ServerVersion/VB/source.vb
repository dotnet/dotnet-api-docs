﻿Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Oracleclient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub CreateOracleConnection()
        Dim connectionString As String = "Data Source=Oracle8i;Integrated Security=yes"
        Using connection As New OracleConnection(connectionString)
            connection.Open()
            Console.WriteLine("ServerVersion: " & connection.ServerVersion _
               + ControlChars.NewLine + "State: " & connection.State)
        End Using
    End Sub
    ' </Snippet1>
End Module
