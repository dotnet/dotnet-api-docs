

using System;
using System.Data;
using System.Data.SqlClient;

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
            connection.Open();
            using(SqlDataReader reader =
                command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[0]));
                }
            }
        }
    }
    // </Snippet1>
}
