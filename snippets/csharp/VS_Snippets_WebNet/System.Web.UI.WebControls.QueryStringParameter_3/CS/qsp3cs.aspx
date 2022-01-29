<!-- <Snippet1> -->
<%@ Page language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
private void Page_Load(object sender, System.EventArgs e)
{
  QueryStringParameter countryFilter =
    new QueryStringParameter("country", TypeCode.String, "country");

  MyAccessDataSource.FilterParameters.Add(countryFilter);
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">

      <!-- Use a Query String with country=USA -->
      <asp:gridview
        id ="GridView1"
        runat="server"
        datasourceid="MyAccessDataSource" />

<!-- Security Note: The AccessDataSource uses a QueryStringParameter,
     Security Note: which does not perform validation of input from the client.
     Security Note: To validate the value of the QueryStringParameter, handle the Selecting event. -->

      <asp:accessdatasource
        id="MyAccessDataSource"
        runat="server"
        datafile="Northwind.mdb"
        selectcommand="SELECT EmployeeID, LastName, Address, PostalCode, Country FROM Employees"
        filterexpression="Country = '{0}'">
      </asp:accessdatasource>
    </form>
  </body>
</html>
<!-- </Snippet1> -->