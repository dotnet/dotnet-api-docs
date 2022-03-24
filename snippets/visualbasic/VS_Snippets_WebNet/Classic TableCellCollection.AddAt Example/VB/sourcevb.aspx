<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Sub Page_Load(sender As Object, e As EventArgs)
        Dim numrows As Integer = 5
        Dim numcells As Integer = 6
        Dim counter As Integer = 1

        ' Generate a basic table.         
        Dim rowNum As Integer
        For rowNum = 0 To numrows - 1
            Dim rw As New TableRow()
            Dim cellNum As Integer
            For cellNum = 0 To numcells - 1
                Dim cel As New TableCell()
                cel.Text = counter.ToString()
                counter += 1
                rw.Cells.Add(cel)
            Next
            Table1.Rows.Add(rw)
        Next

        ' Add cells in the middle of the table. 
        For rowNum = 0 To numrows - 1
            Dim cel As New TableCell()
            cel.Text = "Mid"
            Table1.Rows(rowNum).Cells.AddAt(numcells / 2, cel)
            counter += 1
        Next
    End Sub
 
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TableCellCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 
    <h3>TableCellCollection Example</h3>
    <asp:Table id="Table1" runat="server"/>
 
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
