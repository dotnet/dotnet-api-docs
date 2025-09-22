﻿Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected dataGrid1 As DataGrid    
    
' <Snippet1>
 Private Sub MyAddHandler()
     AddHandler dataGrid1.TableStyles.CollectionChanged, _
        AddressOf Collection_Changed
 End Sub    
    
 Private Sub Collection_Changed _
    (sender As Object, e As CollectionChangeEventArgs)
    
     Dim gts As GridTableStylesCollection = _
        CType(sender, GridTableStylesCollection)
     Console.WriteLine(gts.Count)
 End Sub
' </Snippet1>
End Class
