open System

open System.Data
open System.Data.SqlClient
open System.Collections.Generic
open System.ComponentModel
open System.Drawing
open System.Linq
open System.Text
open System.Windows.Forms

type Form1() =
    inherit Form()
      
    let connectionString = @"Data Source=RONPET59\SQLEXPRESSInitial Catalog=SurveyDBIntegrated Security=True"

    let grid = new DataGridView()

    member _.CompareForMissing(value: obj) =
        // <Snippet1>
        DBNull.Value.Equals value
        // </Snippet1>

    // <Snippet2>
    member this.Form1_Load(sender: obj, e: EventArgs) =
        // Define ADO.NET objects.
        use conn = new SqlConnection(connectionString)
        use cmd = new SqlCommand()

        // Open connection, and retrieve dataset.
        conn.Open()

        // Define Command object.
        cmd.CommandText <- "Select * From Responses"
        cmd.CommandType <- CommandType.Text
        cmd.Connection <- conn

        // Retrieve data reader.
        let dr = cmd.ExecuteReader()

        let fieldCount = dr.FieldCount
        let fieldValues = Array.zeroCreate<obj> fieldCount
        let headers = 
            // Get names of fields.
            Array.init fieldCount dr.GetName

        // Set up data grid.
        grid.ColumnCount <- fieldCount

        grid.ColumnHeadersDefaultCellStyle.BackColor <- Color.Navy
        grid.ColumnHeadersDefaultCellStyle.ForeColor <- Color.White
        grid.ColumnHeadersDefaultCellStyle.Font <- new Font(grid.Font, FontStyle.Bold)

        grid.AutoSizeRowsMode <- DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        grid.ColumnHeadersBorderStyle <- DataGridViewHeaderBorderStyle.Single
        grid.CellBorderStyle <- DataGridViewCellBorderStyle.Single
        grid.GridColor <- Color.Black
        grid.RowHeadersVisible <- true

        for columnNumber = 0 to headers.Length - 1 do
            grid.Columns[columnNumber].Name <- headers[columnNumber]

        // Get data, replace missing values with "NA", and display it.
        while dr.Read() do
            dr.GetValues fieldValues |> ignore
            for fieldCounter = 0 to fieldCount do
                if Convert.IsDBNull fieldValues[fieldCounter] then
                    fieldValues[fieldCounter] <- "NA"
            grid.Rows.Add fieldValues |> ignore
        dr.Close()

    override _.Dispose(disposing) =
        if disposing then
            grid.Dispose();
        base.Dispose disposing
    // </Snippet2>


/// The main entry point for the application.
[<EntryPoint; STAThread>]
let main _ =
   Application.EnableVisualStyles()
   Application.SetCompatibleTextRenderingDefault false
   Application.Run(new Form1())
   0
