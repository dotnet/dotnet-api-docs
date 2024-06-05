﻿<!-- <Snippet1> -->
<%@ Page Language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script runat="server">
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Get an image that is in the same directory as the currently executing control.
        Image1.ImageUrl = VirtualPathUtility.GetDirectory( _
            Request.AppRelativeCurrentExecutionFilePath) + "image1.jpg"
        Label1.Text = "App-relative Image URL = " + Image1.ImageUrl
    End Sub
    
</script>

<head id="Head1" runat="server">
    <title>HttpRequest AppRelativeCurrentExecutionFilePath</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <asp:Image ID="Image1" runat="server" /><br />
            <asp:Label ID="Label1" runat="server" />
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->