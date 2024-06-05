﻿<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  protected void Page_Init(object sender, EventArgs e)
  {
    DynamicDataManager1.RegisterControl(Repeater1);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>DynamicControl.UIHint Sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
        AutoLoadForeignKeys="true" />
        
      <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
        <HeaderTemplate>
          <table border="1">
            <tr>
               <th>First Name</th>
               <th>Last Name</th>
               <th>Email</th>
            </tr>        
        </HeaderTemplate>
        <ItemTemplate>
          <tr>
            <td><asp:DynamicControl runat="server" DataField="FirstName" /></td>
            <td><asp:DynamicControl runat="server" DataField="LastName" /></td>
            <td><asp:DynamicControl runat="server" DataField="EmailAddress" UIHint="Email" />&nbsp;</td>
          </tr>
        </ItemTemplate>
        <FooterTemplate>
          </table>
        </FooterTemplate>
      </asp:Repeater>

      <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        TableName="Customers"
        ContextTypeName="AdventureWorksLTDataContext">
      </asp:LinqDataSource>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->