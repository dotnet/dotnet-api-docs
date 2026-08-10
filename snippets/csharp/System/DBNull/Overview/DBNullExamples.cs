using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.Versioning;

public class DBNullExample
{
    [SupportedOSPlatform("windows")]
    public static void Main()
    {
        DBNullExample ex = new();
        OleDbConnection conn = new();
        OleDbCommand cmd = new();
        OleDbDataAdapter adapter = new();
        DataSet ds = new();
        string dbFilename = @"c:\Data\contacts.mdb";

        // Open database connection
        conn.ConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dbFilename};";
        conn.Open();
        // Define command : retrieve all records in contact table
        cmd.CommandText = "SELECT * FROM Contact";
        cmd.Connection = conn;
        adapter.SelectCommand = cmd;
        // Fill dataset
        ds.Clear();
        adapter.Fill(ds, "Contact");
        // Close connection
        conn.Close();
        // Output labels to console
        ex.OutputLabels(ds.Tables["Contact"]);
    }

    // <Snippet1>
    private void OutputLabels(DataTable dt)
    {
        string label;

        // Iterate rows of table
        foreach (DataRow row in dt.Rows)
        {
            int labelLen;
            label = string.Empty;
            label += AddFieldValue(row, "Title");
            label += AddFieldValue(row, "FirstName");
            label += AddFieldValue(row, "MiddleInitial");
            label += AddFieldValue(row, "LastName");
            label += AddFieldValue(row, "Suffix");
            label += "\n";
            label += AddFieldValue(row, "Address1");
            label += AddFieldValue(row, "AptNo");
            label += "\n";
            labelLen = label.Length;
            label += AddFieldValue(row, "Address2");
            if (label.Length != labelLen)
                label += "\n";
            label += AddFieldValue(row, "City");
            label += AddFieldValue(row, "State");
            label += AddFieldValue(row, "Zip");
            Console.WriteLine(label);
            Console.WriteLine();
        }
    }

    private string AddFieldValue(DataRow row,
                                 string fieldName)
    {
        if (!DBNull.Value.Equals(row[fieldName]))
            return (string)row[fieldName] + " ";
        else
            return string.Empty;
    }
    // </Snippet1>
}
