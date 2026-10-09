using System;
using System.Data;
using System.Windows.Forms;

public class Form1 : Form
{
    protected DataSet DataSet1;

    // <Snippet1>
    private void MakeTableWithUniqueConstraint()
    {
        DataTable table = new("table");
        DataColumn column = new("UniqueColumn")
        {
            Unique = true
        };
        table.Columns.Add(column);

        // Print count, name, and type.
        Console.WriteLine($"Constraints.Count {table.Constraints.Count}");
        Console.WriteLine(table.Constraints[0].ConstraintName);
        Console.WriteLine(table.Constraints[0].GetType());

        // Add a second unique column.
        column = new("UniqueColumn2")
        {
            Unique = true
        };
        table.Columns.Add(column);

        // Print info again.
        Console.WriteLine($"Constraints.Count {table.Constraints.Count}");
        Console.WriteLine(table.Constraints[1].ConstraintName);
        Console.WriteLine(table.Constraints[1].GetType());
    }

    private void MakeTableWithForeignConstraint()
    {
        // Create a DataSet.
        DataSet dataSet = new("dataSet");

        // Make two tables.
        DataTable customersTable = new("Customers");
        DataTable ordersTable = new("Orders");

        // Create four columns, two for each table.
        DataColumn name = new("Name");
        DataColumn id = new("ID");
        DataColumn orderId = new("OrderID");
        DataColumn cDate = new("OrderDate");

        // Add columns to tables.
        customersTable.Columns.Add(name);
        customersTable.Columns.Add(id);
        ordersTable.Columns.Add(orderId);
        ordersTable.Columns.Add(cDate);

        // Add tables to the DataSet.
        dataSet.Tables.Add(customersTable);
        dataSet.Tables.Add(ordersTable);

        // Create a DataRelation for two of the columns.
        DataRelation myRelation = new("CustomersOrders", id, orderId, true);
        dataSet.Relations.Add(myRelation);

        // Print TableName, Constraints.Count,
        // ConstraintName and Type.
        foreach (DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName);
            Console.WriteLine($"Constraints.Count {table.Constraints.Count}");
            Console.WriteLine($"ParentRelations.Count {table.ParentRelations.Count}");
            Console.WriteLine($"ChildRelations.Count {table.ChildRelations.Count}");
            foreach (Constraint constraint in table.Constraints)
            {
                Console.WriteLine(constraint.ConstraintName);
                Console.WriteLine(constraint.GetType());
            }
        }
    }
    // </Snippet1>
}
