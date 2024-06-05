<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_RowUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs)
    
    ' Indicate whether the update operation succeeded.
    If e.Exception Is Nothing Then
    
      Message.Text = "Row updated successfully."
    
    Else
    
      e.ExceptionHandled = True
      Message.Text = "An error occurred while attempting to update the row."
    
    End If
    
  End Sub

  Sub CustomersGridView_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        
    ' The update operation was canceled. Clear the message label.
    Message.Text = ""
    
  End Sub

  Sub CustomersGridView_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
  
    ' The GridView control is entering edit mode. Clear the message label.
    Message.Text = ""
    
  End Sub
    

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView RowUpdated Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView RowUpdated Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"          
        runat="server"/>
                
      <br/>
            
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
        onrowupdated="CustomersGridView_RowUpdated"
        onrowcancelingedit="CustomersGridView_RowCancelingEdit"
        onrowediting="CustomersGridView_RowEditing"   
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