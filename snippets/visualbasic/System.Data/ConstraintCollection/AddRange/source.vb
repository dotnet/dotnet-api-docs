﻿Imports System.Data

Public Class Sample
    
    ' <Snippet1>
    Public Shared Sub ConstraintAddRange(dataSet As DataSet)
        Try
            ' Reference the tables from the DataSet.
            Dim customersTable As DataTable = dataSet.Tables("Customers")
            Dim ordersTable As DataTable = dataSet.Tables("Orders")

            ' Create unique and foreign key constraints.
            Dim uniqueConstraint As New UniqueConstraint( _
                customersTable.Columns("CustomerID"))
            Dim fkConstraint As New ForeignKeyConstraint("CustOrdersConstraint", _
                customersTable.Columns("CustomerID"), _
                ordersTable.Columns("CustomerID"))

            ' Add the constraints.
            customersTable.Constraints.AddRange(New Constraint() _
                {uniqueConstraint, fkConstraint})

        Catch ex As Exception
            ' Process exception and return.
            Console.WriteLine($"Exception of type {ex.GetType()} occurred.")
        End Try
    End Sub
    ' </Snippet1>
End Class
