<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!-- <Snippet4> -->
<script runat="server">
    protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.WhereParameters.Add("Name", "Bike");
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Example Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            AutoGenerateWhereClause="true" 
            OnSelecting="LinqDataSource_Selecting" 
            ID="LinqDataSource1" 
            runat="server">
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1" 
            ID="GridView1" 
            runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
<!-- </Snippet4> -->