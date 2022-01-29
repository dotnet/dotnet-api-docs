﻿<%@ Page Language="C#" AutoEventWireup="true" 
CodeFile="GetTable.aspx.cs" 
Inherits="DocGetTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>
</head>
<body>
    <h2>GetTable Methods</h2>

    <form runat="server">
  
     <asp:GridView ID="GridDataSource1" runat="server"
        AutoGenerateColumns="false"
        DataSourceID="LinqDataSource1"
        AllowPaging="true">
        <Columns>
          <asp:DynamicField DataField="FirstName" />
          <asp:DynamicField DataField="LastName" />
          <asp:TemplateField HeaderText="Addresses">
            <ItemTemplate>
              <%# GetAdresses(2)%>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
        
    </form>
    
     <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        TableName="Customers"
        ContextTypeName="AdventureWorksLTDataContext" >
      </asp:LinqDataSource>
</body>
