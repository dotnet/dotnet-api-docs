using System;
using System.Data;
using System.Windows.Forms;

public class Form1 : Form
{
    protected DataSet DataSet1;

    // <Snippet1>
    private void GetConstraints(DataTable dataTable)
    {
        Console.WriteLine();

        // Print the table's name.
        Console.WriteLine($"TableName: {dataTable.TableName}");

        // Iterate through the collection and
        // print each name and type value.
        foreach (Constraint constraint in dataTable.Constraints)
        {
            Console.WriteLine($"Constraint Name: {constraint.ConstraintName}");
            Console.WriteLine($"Type: {constraint.GetType()}");

            // If the constraint is a UniqueConstraint,
            // print its properties using a function below.
            if (constraint is UniqueConstraint uniqueConstraint)
            {
                PrintUniqueConstraintProperties(uniqueConstraint);
            }

            // If the constraint is a ForeignKeyConstraint,
            // print its properties using a function below.
            if (constraint is ForeignKeyConstraint foreignKeyConstraint)
            {
                PrintForeignKeyConstraintProperties(foreignKeyConstraint);
            }
        }
    }

    private void PrintUniqueConstraintProperties(
        UniqueConstraint uniqueConstraint)
    {
        // Get the Columns as an array.
        DataColumn[] columnArray = uniqueConstraint.Columns;

        // Print each column's name.
        foreach (DataColumn column in columnArray)
        {
            Console.WriteLine($"Column Name: {column.ColumnName}");
        }
    }

    private void PrintForeignKeyConstraintProperties(
        ForeignKeyConstraint foreignKeyConstraint)
    {
        // Get the Columns as an array.
        DataColumn[] columnArray = foreignKeyConstraint.Columns;

        // Print each column's name.
        foreach (DataColumn column in columnArray)
        {
            Console.WriteLine($"Column Name: {column.ColumnName}");
        }
        Console.WriteLine();

        // Get the related columns and print each column's name.
        columnArray = foreignKeyConstraint.RelatedColumns;
        foreach (DataColumn column in columnArray)
        {
            Console.WriteLine($"Related Column Name: {column.ColumnName}");
        }
        Console.WriteLine();
    }
    // </Snippet1>
}
