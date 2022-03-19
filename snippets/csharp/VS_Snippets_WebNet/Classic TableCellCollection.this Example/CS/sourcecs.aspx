<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    void Page_Load(Object sender, EventArgs e)
    {
        int numRows = 5;
        int numcells = 6;
        int counter = 1;
        ArrayList a_row = new ArrayList();
        ArrayList a_column = new ArrayList();

        // Create a table.
        for (int rowNum = 0; rowNum < numRows; rowNum++)
        {
            TableRow rw = new TableRow();
            for (int cellNum = 0; cellNum < numcells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = counter.ToString();
                rw.Cells.Add(cel);
                counter++;
            }
            Table1.Rows.Add(rw);
        }

        if (!IsPostBack)
        {
            // Create a DropDownList for the number of columns.
            for (int cellNum = 0; cellNum < numcells; cellNum++)
            {
                a_column.Add(cellNum.ToString());
            }

            // Create a DropDownList for the number of rows.
            for (int rowNum = 0; rowNum < numRows; rowNum++)
            {
                a_row.Add(rowNum.ToString());
            }

            List1.DataSource = a_column;
            List2.DataSource = a_row;
            List1.DataBind();
            List2.DataBind();
        }
    }

    void Button_Click(object sender, EventArgs e)
    {
        int column = List1.SelectedIndex;
        int row = List2.SelectedIndex;

        string spec = "The cell ({0}, {1}) contains the value {2}.";
        Label1.Text = String.Format(spec, column,
            row, Table1.Rows[row].Cells[column].Text);
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableCellCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h3>TableCellCollection Example</h3>
    <asp:Table id="Table1" 
        runat="server"/>
    <br />&nbsp;<br />
    <p>Select a column and row:<br />
        Column: <asp:DropDownList id="List1" 
            runat="server"/>
        Row: <asp:DropDownList id="List2"
            runat="server"/>
        <br />&nbsp;<br />
        <asp:Button id="Button1"
            Text="Display Cell Value"
            OnClick="Button_Click"
            runat="server"/>
        <br />&nbsp;<br />
        <asp:Label id="Label1"
            runat="server"/>
    </p>

    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
