﻿Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
 Private Sub AddConstraint(table As DataTable)
     Dim uniqueConstraint As UniqueConstraint
     ' Assuming a column named "UniqueColumn" exists, and 
     ' its Unique property is true.
     uniqueConstraint = _
        New UniqueConstraint(table.Columns("UniqueColumn"))
     table.Constraints.Add(uniqueConstraint)
 End Sub
' </Snippet1>
End Class
