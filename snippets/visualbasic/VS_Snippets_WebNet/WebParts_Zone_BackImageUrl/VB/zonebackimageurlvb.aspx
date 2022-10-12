<!-- <snippet1> -->
<%@ page language="VB" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="Form1" runat="server">
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuVB ID="DisplayModeMenu1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server">
        <zonetemplate>
          <asp:Calendar ID="cal1" Runat="server" Title="My Calendar" />
        </zonetemplate>
    </asp:webpartzone>
    <asp:webpartzone
      id="WebPartZone2"
      runat="server" 
      BackImageUrl="image.GIF">
    </asp:webpartzone>
  </form>
</body>
</html>
<!-- </snippet1> -->