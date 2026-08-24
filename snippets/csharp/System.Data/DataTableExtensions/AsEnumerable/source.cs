//<snippet1>
using System;
using System.Data;

DataTable table = new();
table.Columns.Add("ID");
table.Columns.Add("ProductName");

table.Rows.Add("1", "Chai");
table.Rows.Add("2", "Queso Cabrales");
table.Rows.Add("3", "Tofu");

DisplayProducts(table);

static void DisplayProducts(DataTable table)
{
    EnumerableRowCollection<string> productNames =
        from product in table.AsEnumerable()
        select product.Field<string>("ProductName");

    Console.WriteLine("Product Names: ");
    foreach (string productName in productNames)
    {
        Console.WriteLine(productName);
    }
}
//</snippet1>
