// <Snippet1>
using System;
using System.Data;

class Program
{
    static void Main()
    {
        // Create two tables and add them into the DataSet.
        DataTable orderTable = CreateOrderTable();
        DataTable orderDetailTable = CreateOrderDetailTable();
        DataSet salesSet = new();
        salesSet.Tables.Add(orderTable);
        salesSet.Tables.Add(orderDetailTable);

        // Set the relations between the tables
        // and create the related constraint.
        salesSet.Relations.Add(
            "OrderOrderDetail",
            orderTable.Columns["OrderId"],
            orderDetailTable.Columns["OrderId"],
            true);

        Console.WriteLine("After creating the foreign key constraint, " +
            "you'll see the following error if you insert " +
            "an order detail with the wrong OrderId:\n");
        try
        {
            DataRow errorRow = orderDetailTable.NewRow();
            errorRow[0] = 1;
            errorRow[1] = "O0007";
            orderDetailTable.Rows.Add(errorRow);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine();

        // Insert the rows into the table.
        InsertOrders(orderTable);
        InsertOrderDetails(orderDetailTable);

        Console.WriteLine("The initial Order table.");
        ShowTable(orderTable);

        Console.WriteLine("The OrderDetail table.");
        ShowTable(orderDetailTable);

        // Use the Aggregate-Sum on the child table column to get the result.
        DataColumn colSub = new("SubTotal", typeof(decimal), "Sum(Child.LineTotal)");
        orderTable.Columns.Add(colSub);

        // Compute the tax by referencing the SubTotal expression column.
        DataColumn colTax = new("Tax", typeof(decimal), "SubTotal*0.1");
        orderTable.Columns.Add(colTax);

        // If the OrderId is 'Total', compute the amount due on all orders; otherwise, compute the amount due on this order.
        DataColumn colTotal = new(
            "TotalDue",
            typeof(decimal),
            "IIF(OrderId='Total',Sum(SubTotal)+Sum(Tax),SubTotal+Tax)");
        orderTable.Columns.Add(colTotal);

        DataRow row = orderTable.NewRow();
        row["OrderId"] = "Total";
        orderTable.Rows.Add(row);

        Console.WriteLine("The Order table with the expression columns.");
        ShowTable(orderTable);

        Console.WriteLine("Press any key to exit.....");
        Console.ReadKey();
    }

    private static DataTable CreateOrderTable()
    {
        DataTable orderTable = new("Order");

        // Define the columns one at a time.
        DataColumn colId = new("OrderId", typeof(string));
        orderTable.Columns.Add(colId);

        DataColumn colDate = new("OrderDate", typeof(DateTime));
        orderTable.Columns.Add(colDate);

        // Set the OrderId column as the primary key.
        orderTable.PrimaryKey = [colId];

        return orderTable;
    }

    private static DataTable CreateOrderDetailTable()
    {
        DataTable orderDetailTable = new("OrderDetail");

        // Define all the columns at once.
        DataColumn[] cols =
        [
            new DataColumn("OrderDetailId", typeof(int)),
            new DataColumn("OrderId", typeof(string)),
            new DataColumn("Product", typeof(string)),
            new DataColumn("UnitPrice", typeof(decimal)),
            new DataColumn("OrderQty", typeof(int)),
            new DataColumn("LineTotal", typeof(decimal), "UnitPrice*OrderQty")
        ];

        orderDetailTable.Columns.AddRange(cols);
        orderDetailTable.PrimaryKey = [orderDetailTable.Columns["OrderDetailId"]];
        return orderDetailTable;
    }

    private static void InsertOrders(DataTable orderTable)
    {
        // Add one row at a time.
        DataRow row1 = orderTable.NewRow();
        row1["OrderId"] = "O0001";
        row1["OrderDate"] = new DateTime(2013, 3, 1);
        orderTable.Rows.Add(row1);

        DataRow row2 = orderTable.NewRow();
        row2["OrderId"] = "O0002";
        row2["OrderDate"] = new DateTime(2013, 3, 12);
        orderTable.Rows.Add(row2);

        DataRow row3 = orderTable.NewRow();
        row3["OrderId"] = "O0003";
        row3["OrderDate"] = new DateTime(2013, 3, 20);
        orderTable.Rows.Add(row3);
    }

    private static void InsertOrderDetails(DataTable orderDetailTable)
    {
        // Use an Object array to insert all the rows.
        // Values in the array are matched sequentially to the columns,
        // based on the order in which they appear in the table.
        object[][] rows =
        [
            [1, "O0001", "Mountain Bike", 1419.5, 36],
            [2, "O0001", "Road Bike", 1233.6, 16],
            [3, "O0001", "Touring Bike", 1653.3, 32],
            [4, "O0002", "Mountain Bike", 1419.5, 24],
            [5, "O0002", "Road Bike", 1233.6, 12],
            [6, "O0003", "Mountain Bike", 1419.5, 48],
            [7, "O0003", "Touring Bike", 1653.3, 8],
        ];

        foreach (object[] row in rows)
        {
            orderDetailTable.Rows.Add(row);
        }
    }

    private static void ShowTable(DataTable table)
    {
        foreach (DataColumn col in table.Columns)
        {
            Console.Write("{0,-14}", col.ColumnName);
        }
        Console.WriteLine();

        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn col in table.Columns)
            {
                if (col.DataType.Equals(typeof(DateTime)))
                    Console.Write("{0,-14:d}", row[col]);
                else if (col.DataType.Equals(typeof(decimal)))
                    Console.Write("{0,-14:C}", row[col]);
                else
                    Console.Write("{0,-14}", row[col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
// </Snippet1>
