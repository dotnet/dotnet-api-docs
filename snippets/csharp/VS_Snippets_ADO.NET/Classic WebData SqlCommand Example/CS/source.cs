﻿

using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlCommandCS
{
    class Program
    {
        // <Snippet1>
        private static void ReadOrderData(string connectionString)
        {
            string queryString =
                "SELECT OrderID, CustomerID FROM dbo.Orders;";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}",
                            reader[0], reader[1]));
                    }
                }
            }
        }
        // </Snippet1>
    }
}
