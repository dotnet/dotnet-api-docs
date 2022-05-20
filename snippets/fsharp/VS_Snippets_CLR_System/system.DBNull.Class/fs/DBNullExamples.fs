open System
open System.Data
open System.Data.OleDb

type DBNullExample() =
    // <Snippet1>
    member this.OutputLabels(dt: DataTable) =
        let mutable label = ""

        // Iterate rows of table
        for row in dt.Rows do
            let mutable label = String.Empty
            label <- label + this.AddFieldValue(label, row, "Title")
            label <- label + this.AddFieldValue(label, row, "FirstName")
            label <- label + this.AddFieldValue(label, row, "MiddleInitial")
            label <- label + this.AddFieldValue(label, row, "LastName")
            label <- label + this.AddFieldValue(label, row, "Suffix")
            label <- label + "\n"
            label <- label + this.AddFieldValue(label, row, "Address1")
            label <- label + this.AddFieldValue(label, row, "AptNo")
            label <- label + "\n"
            let labelLen = label.Length
            label <- label + this.AddFieldValue(label, row, "Address2")
            let labelLen =
                if label.Length <> labelLen then
                    label + "\n"
                else label
            label <- label + this.AddFieldValue(label, row, "City")
            label <- label + this.AddFieldValue(label, row, "State")
            label <- label + this.AddFieldValue(label, row, "Zip")
            printfn $"{label}"
            printfn ""

    member _.AddFieldValue(label: string, row: DataRow, fieldName: string) =
        if DBNull.Value.Equals row[fieldName] |> not then
            (string row[fieldName]) + " "
        else
            String.Empty
    // </Snippet1>

let ex = DBNullExample()
let conn = new OleDbConnection()
let cmd = new OleDbCommand()
let adapter = new OleDbDataAdapter()
let ds = new DataSet()
let dbFilename = @"c:\Data\contacts.mdb"

// Open database connection
conn.ConnectionString <- "Provider=Microsoft.Jet.OLEDB.4.0Data Source=" + dbFilename + ""
conn.Open()
// Define command : retrieve all records in contact table
cmd.CommandText <- "SELECT * FROM Contact"
cmd.Connection <- conn
adapter.SelectCommand <- cmd
// Fill dataset
ds.Clear()
adapter.Fill(ds, "Contact")
|> ignore
// Close connection
conn.Close()
// Output labels to console	
ex.OutputLabels ds.Tables["Contact"]