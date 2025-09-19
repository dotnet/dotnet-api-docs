using System;
using System.Data.Odbc;

public class Example
{
    // <Snippet1>
    public void CreateOdbcConnection()
    {
        string connectionString = "...";

        using (OdbcConnection connection = new(connectionString))
        {
            connection.Open();
            Console.WriteLine($"ServerVersion: {connection.ServerVersion}"
                + $"\nDatabase: {connection.Database}");

            // The connection is automatically closed at
            // the end of the Using block.
        }
    }
    // </Snippet1>
}
