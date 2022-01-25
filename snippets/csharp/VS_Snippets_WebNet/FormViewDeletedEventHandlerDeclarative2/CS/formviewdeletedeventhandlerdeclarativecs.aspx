<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeeFormView_ItemDeleted(Object sender, FormViewDeletedEventArgs e)
  {
    // Use the Exception property to determine whether an exception
    // occurred during the delete operation.
    if (e.Exception == null)
    {
      // Use the AffectedRows property to determine whether the
      // record was deleted. Sometimes an error might occur that 
      // does not raise an exception, but prevents the delete
      // operation from completing.
      if (e.AffectedRows == 1)
      {
        MessageLabel.Text = "Record deleted successfully.";
      }
      else
      {
        MessageLabel.Text = "An error occurred during the delete operation.";
      }
    }
    else
    {
      // Insert the code to handle the exception.
      MessageLabel.Text = e.Exception.Message;
      
      // Use the ExceptionHandled property to indicate that the 
      // exception has already been handled.
      e.ExceptionHandled = true;
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormViewDeletedEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewDeletedEventHandler Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        onitemdeleted="EmployeeFormView_ItemDeleted"  
        runat="server">
        
        <itemtemplate>
        
          <table>
            <tr>
              <td>
                <asp:image id="EmployeeImage"
                  imageurl='<%# Eval("PhotoPath") %>'
                  alternatetext='<%# Eval("LastName") %>' 
                  runat="server"/>
              </td>
              <td>
                <h3><%# Eval("FirstName") %>&nbsp;<%# Eval("LastName") %></h3>      
                <%# Eval("Title") %>        
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:button id="DeleteButton"
                  text="Delete Record"
                  commandname="Delete"
                  runat="server" />
              </td>
            </tr>
          </table>
        
        </itemtemplate>         
                  
      </asp:formview>
      
      <asp:label id="MessageLabel"
        forecolor="Red"
        runat="server"/>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        deletecommand="Delete [Employees] Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->