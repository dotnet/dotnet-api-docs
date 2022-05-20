<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeeFormView_ModeChanged(Object sender, EventArgs e)
  {

    // Display the current mode in the header row.
    switch (EmployeeFormView.CurrentMode)
    {
      case FormViewMode.Edit:
        EmployeeFormView.HeaderText = "Edit Mode";
        EmployeeFormView.HeaderStyle.BackColor = System.Drawing.Color.Red;
        break;
      case FormViewMode.ReadOnly:
        EmployeeFormView.HeaderText = "Read-Only Mode";
        EmployeeFormView.HeaderStyle.BackColor = System.Drawing.Color.Green;
        break;
      default:
        EmployeeFormView.HeaderText = "Unsupported mode.";
        EmployeeFormView.HeaderStyle.BackColor = System.Drawing.Color.Yellow;
        break;
    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView ModeChanged Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView ModeChanged Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        headertext="Read-Only Mode" 
        headerstyle-backcolor="Green"
        emptydatatext="No employees found."
        onmodechanged="EmployeeFormView_ModeChanged"  
        runat="server">
        
        <itemtemplate>
          <table>
            <tr>
              <td rowspan="6">
                <asp:image id="EmployeeImage"
                  imageurl='<%# Eval("PhotoPath") %>'
                  alternatetext='<%# Eval("LastName") %>' 
                  runat="server"/>
              </td>
              <td colspan="2">
                  &nbsp; 
              </td>
            </tr>
            <tr>
              <td>
                <b>Name:</b>
              </td>
              <td>
                <%# Eval("FirstName") %> <%# Eval("LastName") %>
              </td>
            </tr>
            <tr>
              <td>
                <b>Title:</b>
              </td>
              <td>
                <%# Eval("Title") %>
              </td>
            </tr>
            <tr>
              <td>
                <b>Hire Date:</b>                 
              </td>
              <td>
                <%# Eval("HireDate","{0:d}") %>
              </td>
            </tr>
            <tr style="height:150" valign="top">
              <td>
                <b>Address:</b>
              </td>
              <td>
                <%# Eval("Address") %><br/>
                <%# Eval("City") %> <%# Eval("Region") %>
                <%# Eval("PostalCode") %><br/>
                <%# Eval("Country") %>   
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:linkbutton id="Edit"
                  text="Edit"
                  commandname="Edit"
                  runat="server"/> 
              </td>
            </tr>
          </table>       
        </itemtemplate>
        <edititemtemplate>
          <table>
            <tr>
              <td rowspan="6">
                <asp:image id="EmployeeEditImage"
                  imageurl='<%# Eval("PhotoPath") %>'
                  alternatetext='<%# Eval("LastName") %>' 
                  runat="server"/>
              </td>
              <td colspan="2">
                  &nbsp; 
              </td>
            </tr>
            <tr>
              <td>
                <b><asp:Label runat="server" 
                  AssociatedControlID="FirstNameUpdateTextBox" 
                  Text="Name" />:</b>
              </td>
              <td>
                <asp:textbox id="FirstNameUpdateTextBox"
                  text='<%# Bind("FirstName") %>'
                  accesskey="n" tabindex="1" runat="server"/>
                <asp:textbox id="LastNameUpdateTextBox"
                  text='<%# Bind("LastName") %>'
                  accesskey="l" tabindex="2" runat="server"/>
              </td>
            </tr>
            <tr>
              <td>
                <b><asp:Label runat="server" 
                  AssociatedControlID="TitleUpdateTextBox" 
                  Text="Title" />:</b>
              </td>
              <td>
                <asp:textbox id="TitleUpdateTextBox"
                  text='<%# Bind("Title") %>'
                  accesskey="t" tabindex="3" runat="server"/> 
              </td>
            </tr>
            <tr>
                <b><asp:Label runat="server" 
                  AssociatedControlID="HireDateUpdateTextBox" 
                  Text="Hire Date" />:</b>
              <td>
                <asp:textbox id="HireDateUpdateTextBox"
                  text='<%# Bind("HireDate", "{0:d}") %>'
                  accesskey="h" tabindex="4" runat="server" />
              </td>
            </tr>
            <tr style="height:150" valign="top">
              <td>
                <b><asp:Label runat="server" 
                  AssociatedControlID="AddressUpdateTextBox" 
                  Text="Address" />:</b>
              </td>
              <td>
                <asp:textbox id="AddressUpdateTextBox"
                  text='<%# Bind("Address") %>'
                  accesskey="a" tabindex="5" runat="server"/>
                <br/>
                <asp:textbox id="CityUpdateTextBox"
                  text='<%# Bind("City") %>'
                  accesskey="c" tabindex="6" runat="server"/> 
                <asp:textbox id="RegionUpdateTextBox"
                  text='<%# Bind("Region") %>'
                  width="40"
                  accesskey="r" tabindex="7" runat="server"/>
                <asp:textbox id="PostalCodeUpdateTextBox"
                  text='<%# Bind("PostalCode") %>'
                  width="60"
                  accesskey="p" tabindex="8" runat="server"/>
                <br/>
                <asp:textbox id="CountryUpdateTextBox"
                  text='<%# Bind("Country") %>'
                  accesskey="u" tabindex="9" runat="server"/> 
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:linkbutton id="UpdateButton"
                  text="Update" tabindex="10" 
                  commandname="Update"
                  runat="server"/>
                <asp:linkbutton id="CancelButton"
                  text="Cancel" tabindex="11" 
                  commandname="Cancel"
                  runat="server"/> 
              </td>
            </tr>
          </table>       
        </edititemtemplate>
                  
      </asp:formview>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [Address], [City], [Region], [PostalCode], [Country], [HireDate], [PhotoPath] From [Employees]"
        updatecommand="Update [Employees] Set [LastName]=@LastName, [FirstName]=@FirstName, [Title]=@Title, [Address]=@Address, [City]=@City, [Region]=@Region, [PostalCode]=@PostalCode, [Country]=@Country Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->