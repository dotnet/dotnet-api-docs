using System;
using System.Data;
// <Snippet1>
// You may need to set a reference to the System.Data.OracleClient
// assembly before you can run this sample.
using System.Data.OracleClient;

class Program
{
    static void Main()
    {
        OracleConnectionStringBuilder builder =
            new OracleConnectionStringBuilder(GetConnectionString());
        Console.WriteLine("Connection string = " + builder.ConnectionString);

        // Keys you've provided return true.
        Console.WriteLine(builder.ContainsKey("Integrated Security"));

        // Keys that are valid but have not been set return true.
        Console.WriteLine(builder.ContainsKey("Unicode"));

        // Keys that do not exist return false.
        Console.WriteLine(builder.ContainsKey("MyKey"));

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file.
        return "Server=OracleDemo;Integrated Security=True";
    }
}
// </Snippet1>
