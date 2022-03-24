﻿using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
    static void Main()
    {
        string x = "Provider=SQLOLEDB;Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI";
        OpenConnection(x);
        Console.ReadLine();
    }

    // <Snippet1>
    static void OpenConnection(string connectionString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection.State: {0}", connection.State);

                connection.Close();
                OleDbConnection.ReleaseObjectPool();
                Console.WriteLine("Connection.State: {0}", connection.State);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // The connection is automatically closed when the
            // code exits the using block.
        }
    }
    // </Snippet1>
}
