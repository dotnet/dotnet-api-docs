﻿

using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlCommandCS
{
    class Program
    {
        // <Snippet1>
        private static void CreateCommand(string queryString,
            string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        // </Snippet1>
    }
}
