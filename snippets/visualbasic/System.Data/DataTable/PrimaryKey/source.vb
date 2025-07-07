﻿Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms


Public Class Form1 : Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub GetPrimaryKeys(table As DataTable)
     ' Create the array for the columns.
     Dim columns As DataColumn()
     columns = table.PrimaryKey

     ' Get the number of elements in the array.
     Console.WriteLine($"Column Count: {columns.Length}")
     For i = 0 To columns.GetUpperBound(0)
         Console.WriteLine($"{columns(i).ColumnName} {columns(i).DataType}")
     Next
 End Sub
 
 Private Sub SetPrimaryKeys()
     ' Create a new DataTable and set two DataColumn objects as primary keys.
     Dim table As New DataTable()
     Dim keys(1) As DataColumn
     Dim column  As DataColumn

     ' Create column 1.
     column = New DataColumn()
     column.DataType = Type.GetType("System.String")
     column.ColumnName= "FirstName"

     ' Add the column to the DataTable.Columns collection.
     table.Columns.Add(column)
     ' Add the column to the array.
     keys(0) = column
 
     ' Create column 2 and add it to the array.
     column = New DataColumn()
     column.DataType = Type.GetType("System.String")
     column.ColumnName = "LastName"
     table.Columns.Add(column)

     ' Add the column to the array.
     keys(1) = column

     ' Set the PrimaryKeys property to the array.
     table.PrimaryKey = keys
 End Sub
' </Snippet1>

End Class
