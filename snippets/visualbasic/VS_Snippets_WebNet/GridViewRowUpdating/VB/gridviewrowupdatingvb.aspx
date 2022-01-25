<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
    
    ' Use the CopyTo method to copy the DictionaryEntry objects in the 
    ' NewValues collection to an array.
    Dim records(e.NewValues.Count - 1) As DictionaryEntry
    e.NewValues.CopyTo(records, 0)
    
    ' Iterate through the array and HTML encode all user-provided values 
    ' before updating the data source.
    Dim entry As DictionaryEntry
    For Each entry In records
            
      e.NewValues(entry.Key) = Server.HtmlEncode(entry.Value.ToString())
      
    Next
        
  End Sub
       
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView RowUpdating Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView RowUpdating Example</h3>
            
      <!-- The GridView control automatically sets the columns     -->
      <!-- specified in the datakeynames property as read-only.    -->
      <!-- No input controls are rendered for these columns in     -->
      <!-- edit mode.                                              -->
      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="true"
        autogenerateeditbutton="true"
        allowpaging="true" 
        datakeynames="CustomerID"
        onrowupdating="CustomersGridView_RowUpdating"  
        runat="server">
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        updatecommand="Update Customers SET CompanyName=@CompanyName, Address=@Address, City=@City, PostalCode=@PostalCode, Country=@Country WHERE (CustomerID = @CustomerID)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->