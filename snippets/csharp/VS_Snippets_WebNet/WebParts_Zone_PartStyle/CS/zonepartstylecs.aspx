<!-- <snippet1> -->
<%@ page language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void cal1_SelectionChanged(object sender, EventArgs e)
  {
    WebPartZone1.PartStyle.BackColor = 
        System.Drawing.Color.Red;
  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Favorite Links</title>
</head>
<body>
  <form id="Form1" runat="server">
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server">
        <zonetemplate>
          <asp:Calendar 
            ID="cal1" 
            Runat="server" 
            Title="My Calendar" 
            OnSelectionChanged="cal1_SelectionChanged" />
          <asp:Literal ID="literal1" Runat="server">
            <h2>Favorite Links</h2>
            <a href="http://www.microsoft.com">Microsoft</a>
            <br />
            <a href="http://msdn.microsoft.com">MSDN</a>
          </asp:Literal>
        </zonetemplate>
    </asp:webpartzone>
  </form>
</body>
</html>
<!-- </snippet1> -->