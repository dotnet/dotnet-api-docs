<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ListBox AutoPostBack Example</title>
<script runat="server">

      Sub Page_Load(sender As Object, e As EventArgs)
      
         If Not IsNothing(ListBox1.SelectedItem)
            Label1.Text = "You selected: " & ListBox1.SelectedItem.Value
         Else
            Label1.Text = ""
         End If

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>ListBox AutoPostBack Example</h3>

      Select an item from the list box: <br /><br />

      <asp:ListBox id="ListBox1" 
           Rows="4"
           AutoPostBack="True" 
           SelectionMode="Single"  
           runat="server">
 
         <asp:ListItem>Item 1</asp:ListItem>
         <asp:ListItem>Item 2</asp:ListItem>
         <asp:ListItem>Item 3</asp:ListItem>
         <asp:ListItem>Item 4</asp:ListItem>
         <asp:ListItem>Item 5</asp:ListItem>
         <asp:ListItem>Item 6</asp:ListItem>
  
      </asp:ListBox>

      <br /><br />

      <asp:Label id="Label1"
           runat="server"/>

   </form>

</body>
</html>
 
<!--</Snippet1>-->
