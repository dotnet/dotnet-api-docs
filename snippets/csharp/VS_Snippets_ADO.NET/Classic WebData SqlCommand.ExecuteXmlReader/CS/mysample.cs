

using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    // <Snippet1>
    private static void CreateXMLReader(string queryString,
        string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(queryString, connection);
            System.Xml.XmlReader reader = command.ExecuteXmlReader();
        }
    }
    // </Snippet1>
}
