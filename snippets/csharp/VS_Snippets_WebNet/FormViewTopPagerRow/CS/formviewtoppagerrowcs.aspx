<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeeFormView_ItemCreated(Object sender, EventArgs e)
  {

    // Get the pager row.
    FormViewRow pagerRow = EmployeeFormView.TopPagerRow;

    // Get the Label controls that display the current page information 
    // from the pager row.
    Label pageNum = (Label)pagerRow.FindControl("PageNumberLabel");
    Label totalNum = (Label)pagerRow.FindControl("TotalPagesLabel");

    if ((pageNum != null) && (totalNum != null))
    {
      // Update the Label controls with the current page values.
      int page = EmployeeFormView.PageIndex + 1;
      int count = EmployeeFormView.PageCount;

      pageNum.Text = page.ToString();
      totalNum.Text = count.ToString();
    }

  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView PagerTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView PagerTemplate Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        onitemcreated="EmployeeFormView_ItemCreated" 
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
          </table>    
        </itemtemplate>
        
        <pagertemplate>   
          <table width="100%">
            <tr>
              <td>
                <asp:linkbutton id="PreviousButton"
                  text="<"
                  commandname="Prev"
                  runat="Server"/>
                <asp:linkbutton id="NextButton"
                  text=">"
                  commandName="Next"
                  runat="Server"/> 
              </td>
              <td align="right">                
                Page <asp:label id="PageNumberLabel" runat="server"/> 
                of <asp:label id="TotalPagesLabel" runat="server"/>                
              </td>
            </tr>
          </table>          
        </pagertemplate>
          
        <pagersettings position="Top"
          mode="NextPrevious"/> 
                  
      </asp:formview>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->