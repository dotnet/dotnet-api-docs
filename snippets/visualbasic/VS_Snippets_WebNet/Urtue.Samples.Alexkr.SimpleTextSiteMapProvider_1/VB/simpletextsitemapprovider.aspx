<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SiteMapProvider Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" SiteMapProvider="SimpleTextSiteMapProvider" />
      <asp:SiteMapPath ID="SiteMapPath1" runat="server" RenderCurrentNodeAsLink="true" ></asp:SiteMapPath>    
    </div>
    </form>
</body>
</html>
