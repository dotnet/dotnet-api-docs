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
    Public Sub CreateOleDbParameter()
        Dim parameter As New OleDbParameter("Description", OleDbType.VarChar, 88)
        parameter.Direction = ParameterDirection.Output
    End Sub 
    ' </Snippet1>
End Class
