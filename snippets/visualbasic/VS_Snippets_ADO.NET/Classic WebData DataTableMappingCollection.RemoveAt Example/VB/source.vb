﻿Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    Protected mappings As DataTableMappingCollection
    
' <Snippet1>
 Public Sub RemoveDataTableMapping()
     ' ...
     ' create mappings
     ' ...
     If mappings.Contains(7) Then
         mappings.RemoveAt(7)
     End If
 End Sub
' </Snippet1>
End Class
