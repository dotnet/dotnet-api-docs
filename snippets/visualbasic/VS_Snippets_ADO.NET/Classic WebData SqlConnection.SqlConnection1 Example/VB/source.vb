﻿Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        OpenSqlConnection()
        Console.ReadLine()

    End Sub
    ' <Snippet1>
    Private Sub OpenSqlConnection()
        Dim connectionString As String = GetConnectionString()

        Using connection As New SqlConnection(connectionString)

            connection.Open()

            Console.WriteLine("State: {0}", connection.State)
            Console.WriteLine("ConnectionString: {0}", _
                connection.ConnectionString)
        End Using
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file, using the
        ' System.Configuration.ConfigurationSettings.AppSettings property
        Return "Data Source=(local);Database=AdventureWorks;" _
          & "Integrated Security=SSPI;"
    End Function
    ' </Snippet1>
End Module
