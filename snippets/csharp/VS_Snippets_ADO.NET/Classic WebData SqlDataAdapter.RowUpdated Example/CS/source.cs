using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

public class Form1 : Form
{
    // <Snippet1>
    // handler for RowUpdating event
    private static void OnRowUpdating(object sender, SqlRowUpdatingEventArgs e)
    {
        PrintEventArgs(e);
    }

    // handler for RowUpdated event
    private static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e)
    {
        PrintEventArgs(e);
    }

    public static int Main()
    {
        const string connectionString = "...";
        const string queryString = "SELECT * FROM Products";

        // create DataAdapter
        SqlDataAdapter adapter = new(queryString, connectionString);
        SqlCommandBuilder builder = new(adapter);

        // Create and fill DataSet (select only first 5 rows)
        DataSet dataSet = new();
        adapter.Fill(dataSet, 0, 5, "Table");

        // Modify DataSet
        DataTable table = dataSet.Tables["Table"];
        table.Rows[0][1] = "new product";

        // add handlers
        adapter.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
        adapter.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);

        // update, this operation fires two events
        // (RowUpdating/RowUpdated) per changed row
        adapter.Update(dataSet, "Table");

        // remove handlers
        adapter.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
        adapter.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
        return 0;
    }

    private static void PrintEventArgs(SqlRowUpdatingEventArgs args)
    {
        Console.WriteLine("OnRowUpdating");
        Console.WriteLine("  event args: (" +
            " command=" + args.Command +
            " commandType=" + args.StatementType +
            " status=" + args.Status + ")");
    }

    private static void PrintEventArgs(SqlRowUpdatedEventArgs args)
    {
        Console.WriteLine("OnRowUpdated");
        Console.WriteLine("  event args: (" +
            " command=" + args.Command +
            " commandType=" + args.StatementType +
            " recordsAffected=" + args.RecordsAffected +
            " status=" + args.Status + ")");
    }
    // </Snippet1>
}
