Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.Data.SqlClient

Public Class Form1
    Inherits Form

    ' <Snippet1>
    ' handler for RowUpdating event
    Private Shared Sub OnRowUpdating(sender As Object, e As SqlRowUpdatingEventArgs)
        PrintEventArgs(e)
    End Sub

    ' handler for RowUpdated event
    Private Shared Sub OnRowUpdated(sender As Object, e As SqlRowUpdatedEventArgs)
        PrintEventArgs(e)
    End Sub

    Public Overloads Shared Function Main(args() As String) As Integer
        Const connectionString As String = "..."
        Const queryString As String = "SELECT * FROM Products"

        ' create DataAdapter
        Dim adapter As New SqlDataAdapter(queryString, connectionString)
        Dim builder As New SqlCommandBuilder(adapter)

        ' Create and fill DataSet (select only first 5 rows)
        Dim dataSet As New DataSet()
        adapter.Fill(dataSet, 0, 5, "Table")

        ' Modify DataSet
        Dim table As DataTable = dataSet.Tables("Table")
        table.Rows(0)(1) = "new product"

        ' add handlers
        AddHandler adapter.RowUpdating, AddressOf OnRowUpdating
        AddHandler adapter.RowUpdated, AddressOf OnRowUpdated

        ' update, this operation fires two events
        '(RowUpdating/RowUpdated) per changed row
        adapter.Update(dataSet, "Table")

        ' remove handlers
        RemoveHandler adapter.RowUpdating, AddressOf OnRowUpdating
        RemoveHandler adapter.RowUpdated, AddressOf OnRowUpdated
        Return 0
    End Function


    Private Overloads Shared Sub PrintEventArgs(args As SqlRowUpdatingEventArgs)
        Console.WriteLine("OnRowUpdating")
        Console.WriteLine("  event args: (" & " command=" & args.Command.CommandText &
           " commandType=" & args.StatementType & " status=" & args.Status & ")")
    End Sub


    Private Overloads Shared Sub PrintEventArgs(args As SqlRowUpdatedEventArgs)
        Console.WriteLine("OnRowUpdated")
        Console.WriteLine("  event args: (" & " command=" & args.Command.CommandText &
           " commandType=" & args.StatementType & " recordsAffected=" &
           args.RecordsAffected & " status=" & args.Status & ")")
    End Sub
End Class
' </Snippet1>
