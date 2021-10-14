// <Snippet1>
using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string str = "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
        ReadOrderData(str);
    }

    private static void ReadOrderData(string connectionString)
    {
        string queryString =
            "SELECT OrderID, CustomerID FROM dbo.Orders;";

        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            SqlCommand command =
                new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();
        }
    }

    private static void ReadSingleRow(IDataRecord dataRecord)
    {
        Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
    }
}
// </Snippet1>