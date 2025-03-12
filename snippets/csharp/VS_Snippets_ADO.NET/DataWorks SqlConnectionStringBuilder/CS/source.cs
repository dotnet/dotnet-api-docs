using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // <Snippet1>
        // Create a new SqlConnectionStringBuilder and
        // initialize it with a few name/value pairs.
        SqlConnectionStringBuilder builder = new(
            "Server=(local);Integrated Security=true;" +
            "Initial Catalog=AdventureWorks"
            );

        // The input connection string used the
        // Server key, but the new connection string uses
        // the well-known Data Source key instead.
        Console.WriteLine($"Original connection string: '{builder.ConnectionString}'");

        // Now that the connection string has been parsed,
        // you can work with individual items.
        Console.WriteLine($"Initial catalog: '{builder.InitialCatalog}'");
        builder.InitialCatalog = "Northwind";
        builder.AsynchronousProcessing = true;

        // You can refer to connection keys using strings,
        // as well. When you use this technique (the default
        // Item property in Visual Basic, or the indexer in C#),
        // you can specify any synonym for the connection string key name.
        builder["Server"] = ".";
        builder["Connect Timeout"] = 1000;
        builder["Trusted_Connection"] = true;
        Console.WriteLine($"Modified connection string: '{builder.ConnectionString}'");
        // </Snippet1>
    }
}
