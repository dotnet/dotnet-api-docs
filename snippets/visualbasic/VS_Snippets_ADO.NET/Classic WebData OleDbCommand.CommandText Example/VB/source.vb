﻿Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Public Sub CreateMyOleDbCommand()
     Dim command As New OleDbCommand()
     command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID"
     command.CommandTimeout = 20
 End Sub
' </Snippet1>
End Class
