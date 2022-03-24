﻿Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
    ' <Snippet1>
Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    Private Sub GetPreferredSize()
        Dim g As Graphics
        g = Me.CreateGraphics()
        Dim gridPreferredSize As Size
        Dim myTextColumn As MyGridColumn
        ' Assuming column 1 of a DataGrid control is a 
        ' DataGridTextBoxColumn.
        myTextColumn = CType(dataGrid1.TableStyles(0). _
        GridColumnStyles(1), MyGridColumn)
        Dim myVal As String
        myVal = "A long string value"
        gridPreferredSize = myTextColumn.GetPrefSize _
        (g, myVal)
        Console.WriteLine(gridPreferredSize)
    End Sub 
End Class 

Public Class MyGridColumn
Inherits DataGridTextBoxColumn
   public Function GetPrefSize(g As Graphics , val As string) _
   As Size
      return me.GetPreferredSize(g, val)
   End Function
End Class
    ' </Snippet1>
