<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void Page_Load(Object sender, EventArgs e)
  {

    // Create a new GridView control.
    GridView customersGridView = new GridView();

    // Set the GridView control's properties.
    customersGridView.ID = "CustomersGridView";
    customersGridView.DataSourceID = "CustomersSqlDataSource";
    customersGridView.AutoGenerateColumns = true;
    customersGridView.AutoGenerateEditButton = true;
    customersGridView.AllowPaging = true;
    customersGridView.DataKeyNames = new String[1] { "CustomerID" };

    // Programmatically register the event-handling method
    // for the RowDeleted event of the GridView control.
    customersGridView.RowUpdated += new GridViewUpdatedEventHandler(this.CustomersGridView_RowUpdated);
    customersGridView.RowCancelingEdit += new GridViewCancelEditEventHandler(this.CustomersGridView_RowCancelingEdit);
    customersGridView.RowEditing += new GridViewEditEventHandler(this.CustomersGridView_RowEditing);
    
    // Add the GridView control to the Controls collection
    // of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customersGridView);
    
  }

  void CustomersGridView_RowUpdated(Object sender, GridViewUpdatedEventArgs e)
  {
    
    // Indicate whether the update operation succeeded.
    if(e.Exception == null)
    {
      Message.Text = "Row updated successfully.";
    }
    else
    {
      e.ExceptionHandled = true;
      Message.Text = "An error occurred while attempting to update the row.";
    }
    
  }

  void CustomersGridView_RowCancelingEdit(Object sender, GridViewCancelEditEventArgs e)
  {
        
    // The update operation was canceled. Clear the message label.
    Message.Text = "";
    
  }

  void CustomersGridView_RowEditing(Object sender, GridViewEditEventArgs e)
  {
    // The GridView control is entering edit mode. Clear the message label.
    Message.Text = "";
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewUpdatedEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewUpdatedEventHandler Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"          
        runat="server"/>
                
      <br/>
            
      <asp:placeholder id="GridViewPlaceHolder"
        runat="server"/>
            
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