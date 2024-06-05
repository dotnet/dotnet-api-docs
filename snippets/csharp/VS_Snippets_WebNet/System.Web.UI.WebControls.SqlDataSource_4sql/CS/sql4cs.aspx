<!-- <Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:SqlDataSource
          id="SqlDataSource1"
          runat="server"
          DataSourceMode="DataSet"
          ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
          SelectCommand="SELECT FirstName, LastName, Title FROM Employees">
      </asp:SqlDataSource>

      <asp:GridView
          id="GridView1"
          runat="server"
          AllowSorting="True"
          DataSourceID="SqlDataSource1">
      </asp:GridView>

    </form>
  </body>
</html>
<!-- </Snippet1> -->