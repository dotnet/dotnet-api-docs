﻿Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim s As String = GetConnectionString()

        OpenSqlConnection(s)
        Console.ReadLine()

    End Sub
    ' <Snippet1>
    Private Sub OpenSqlConnection(ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion)
            Console.WriteLine("WorkstationId: {0}", connection.WorkstationId)
        End Using
    End Sub
    ' </Snippet1>
    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file, using the
        ' System.Configuration.ConfigurationSettings.AppSettings property
        Return "Data Source=(local);Database=AdventureWorks;" _
          & "Integrated Security=SSPI;"
    End Function
End Module
