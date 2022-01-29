<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomerGridView_DataBound(Object sender, EventArgs e)
  {

    // Use the Count property to determine whether the
    // DataKeys collection contains any items.
    if (CustomerGridView.DataKeys.Count > 0)
    {

      MessageLabel.Text = "The primary key of each record displayed are: <br/><br/>";

      // Use the GetEnumerator method to create an enumerator that 
      // contains the DataKey objects for the GridView control.
      IEnumerator keyEnumerator = CustomerGridView.DataKeys.GetEnumerator();

      // Iterate though the enumerator and display the primary key
      // value of each record displayed.
      while (keyEnumerator.MoveNext())
      {
        DataKey key = (DataKey)keyEnumerator.Current;
        MessageLabel.Text += key.Value.ToString() + "<br/>";
      }

    }
    else
    {
      MessageLabel.Text = "No DataKey objects.";
    }

  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>DataKeyArray Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DataKeyArray Example</h3>
                       
        <asp:gridview id="CustomerGridView"
          datasourceid="CustomerDataSource"
          autogeneratecolumns="true"
          datakeynames="CustomerID"  
          allowpaging="true"
          ondatabound="CustomerGridView_DataBound" 
          runat="server">
            
        </asp:gridview>
        
        <br/>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the Web.config file.                            -->
        <asp:sqldatasource id="CustomerDataSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->