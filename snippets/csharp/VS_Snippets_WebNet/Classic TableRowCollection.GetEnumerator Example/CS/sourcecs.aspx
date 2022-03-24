<!--<Snippet1>-->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Text" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        int numRows = 5;
        int numCells = 6;
        int counter = 1;
        ArrayList a_row = new ArrayList();

        // Create a table.
        for (int rowNum = 0; rowNum < numRows; rowNum++)
        {
            TableRow rw = new TableRow();
            for (int cellNum = 0; cellNum < numCells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = counter.ToString();
                rw.Cells.Add(cel);
                counter++;
            }
            Table1.Rows.Add(rw);
        }
    }

    void Button_Click(object sender, EventArgs e)
    {
        int rowCounter = 0;
        TableCell currentCell;
        StringBuilder tb = new StringBuilder();

        // Create an IEnumerator for the rows of a table.
        IEnumerator myRowEnum = Table1.Rows.GetEnumerator();

        tb.Append("The copied items from the table are: <br />");

        // Iterate through the IEnumerator and display its contents.
        while (myRowEnum.MoveNext())
        {
            // Create an IEnumerator for the cells of the row.
            IEnumerator myCellEnum = Table1.Rows[rowCounter].Cells.GetEnumerator();

            // Iterate through the IEnumerator and display its contents.
            while (myCellEnum.MoveNext())
            {
                currentCell = (TableCell)myCellEnum.Current;
                tb.Append(currentCell.Text + ", ");
            }
            rowCounter++;
        }
        Label1.Text = tb.ToString();
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
        <asp:Table id="Table1" runat="server"/>
        <br />&nbsp;<br />
        <asp:Button id="Button1"
            Text="Copy Table to Array"
            OnClick="Button_Click"
            runat="server"/>
        <br />&nbsp;<br />
        <asp:Label id="Label1" runat="server"/>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
