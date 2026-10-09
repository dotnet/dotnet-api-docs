using System;
using System.Data;
using System.Windows.Forms;

public class Form5 : Form
{
    protected DataSet DataSet1;

    // <Snippet1>
    private void AddForeignConstraint(
        DataSet dataSet, DataTable table)
    {
        try
        {
            // Get the tables from the DataSet.
            DataTable customersTable = dataSet.Tables["Customers"];
            DataTable ordersTable = dataSet.Tables["Orders"];

            // Set columns.
            DataColumn[] parentColumns =
            [
                customersTable.Columns["id"],
                customersTable.Columns["Name"]
            ];
            DataColumn[] childColumns =
            [
                ordersTable.Columns["CustomerID"],
                ordersTable.Columns["CustomerName"]
            ];

            // Create a ForeignKeyConstraint.
            table.Constraints.Add("CustOrdersConstraint",
                parentColumns, childColumns);
        }
        catch (Exception ex)
        {
            // In case the constraint already exists,
            // catch the collision here and respond.
            Console.WriteLine($"Exception of type {ex.GetType()} occurred.");
        }
    }
    // </Snippet1>
}
