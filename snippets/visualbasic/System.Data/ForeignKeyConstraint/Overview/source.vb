﻿Option Explicit On
Option Strict On
Imports System.Data

Module Module1


    ' <Snippet1>
    ' The next line goes into the Declarations section of the module:
    ' SuppliersProducts is a class derived from DataSet.
    Private suppliersProducts As SuppliersProducts

    Private Sub CreateConstraint()
        ' Declare parent column and child column variables.
        Dim parentColumn As DataColumn
        Dim childColumn As DataColumn
        Dim fkeyConstraint As ForeignKeyConstraint

        ' Set parent and child column variables.
        parentColumn = suppliersProducts.Tables("Suppliers").Columns("SupplierID")
        childColumn = suppliersProducts.Tables("Products").Columns("SupplierID")
        fkeyConstraint = New ForeignKeyConstraint( _
            "SupplierFKConstraint", parentColumn, childColumn)

        ' Set null values when a value is deleted.
        fkeyConstraint.DeleteRule = Rule.SetNull
        fkeyConstraint.UpdateRule = Rule.Cascade
        fkeyConstraint.AcceptRejectRule = AcceptRejectRule.Cascade

        ' Add the constraint, and set EnforceConstraints to true.
        suppliersProducts.Tables("Products").Constraints.Add(fkeyConstraint)
        suppliersProducts.EnforceConstraints = True
    End Sub
    ' </Snippet1>

    Sub Main()
        CreateConstraint()
        Console.ReadLine()

    End Sub

End Module

Public Class SuppliersProducts : Inherits DataSet

End Class