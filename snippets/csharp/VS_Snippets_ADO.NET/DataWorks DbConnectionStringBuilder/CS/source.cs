using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ConBuilderCS
{
    class Program
    {
        static void Main()
        {
            // <Snippet1>
            DbConnectionStringBuilder builder =
                new DbConnectionStringBuilder();
            builder.ConnectionString = @"Data Source=c:\MyData\MyDb.mdb";
            builder.Add("Provider", "Microsoft.Jet.Oledb.4.0");
            // Set up row-level locking.
            builder.Add("Jet OLEDB:Database Locking Mode", 1);

            // The DbConnectionStringBuilder class
            // is database agnostic, so it's possible to
            // build any type of connection string using
            // this class.

            // The ConnectionString property might have been
            // formatted by the DbConnectionStringBuilder class.
            OleDbConnection oledbConnect = new
                OleDbConnection(builder.ConnectionString);
            Console.WriteLine(oledbConnect.ConnectionString);

            // Use the same DbConnectionStringBuilder to create
            // a SqlConnection object.
            builder.Clear();
            builder.Add("integrated security", true);
            builder.Add("Initial Catalog", "AdventureWorks");
            builder.Add("Data Source", "(local)");

            SqlConnection sqlConnect = new
                SqlConnection(builder.ConnectionString);
            Console.WriteLine(sqlConnect.ConnectionString);

            // Pass the DbConnectionStringBuilder an existing
            // connection string, and you can retrieve and
            // modify any of the elements.
            builder.ConnectionString = "server=(local);initial catalog=AdventureWorks";
            builder["Server"] = ".";

            // Setting the indexer adds the value, if necessary.
            builder["Integrated Security"] = true;
            Console.WriteLine(builder.ConnectionString);
            // </Snippet1>
        }
    }
}
