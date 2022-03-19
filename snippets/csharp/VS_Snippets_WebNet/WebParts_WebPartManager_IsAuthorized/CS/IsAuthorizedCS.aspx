<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Register Namespace="Samples.AspNet.CS.Controls" 
    TagPrefix="aspSample"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  protected void Page_Load(object sender, EventArgs e)
  {
    foreach (WebPart part in mgr1.WebParts)
    {
      if (mgr1.IsAuthorized(part))
        part.ExportMode = WebPartExportMode.All;
    }
    
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <aspSample:MyManagerAuthorize ID="mgr1" runat="server"  />
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:BulletedList 
            ID="BulletedList1" 
            Runat="server"
            DisplayMode="HyperLink" 
            Title="Favorite Links"
            AuthorizationFilter="admin">
            <asp:ListItem Value="http://msdn.microsoft.com">
              MSDN
            </asp:ListItem>
            <asp:ListItem Value="http://www.asp.net">
              ASP.NET
            </asp:ListItem>
            <asp:ListItem Value="http://www.msn.com">
              MSN
            </asp:ListItem>
          </asp:BulletedList>
          <asp:Label ID="Label1" runat="server" 
            Text="Hello World"
            AuthorizationFilter="user" />
          <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </ZoneTemplate>
      </asp:WebPartZone>
      <hr />
      <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->