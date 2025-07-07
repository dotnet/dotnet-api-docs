﻿Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    ' <Snippet1>
    Public Sub ReadOrderData(ByVal connectionString As String)
        Dim queryString As String = _
            "SELECT OrderID, CustomerID FROM dbo.Orders;"
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)
            connection.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()
            Try
                While reader.Read()
                    Console.WriteLine(String.Format("{0}, {1}", _
                        reader(0), reader(1)))
                End While
            Finally
                ' Always call Close when done reading.
                reader.Close()
            End Try
        End Using
    End Sub
    ' </Snippet1>

End Module
