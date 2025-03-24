using System;
using Oracle.ManagedDataAccess.Client;

class Program
{
    static void Main()
    {
        // <Snippet1>
        OracleConnectionStringBuilder builder =
            new(GetConnectionString());
        Console.WriteLine($"Connection string = '{builder.ConnectionString}'");

        // Keys you've provided return true.
        Console.WriteLine(builder.ContainsKey("Integrated Security"));

        // Keys that are valid but have not been set return true.
        Console.WriteLine(builder.ContainsKey("Unicode"));

        // Keys that do not exist return false.
        Console.WriteLine(builder.ContainsKey("MyKey"));
        // </Snippet1>
    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file.
        return "Server=OracleDemo;Integrated Security=True";
    }
}
