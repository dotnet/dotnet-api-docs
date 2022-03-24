<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    ' This custom Login control uses a site-specific method
    ' to record the current date and time when users are 
    ' authenticated at the site.
    Class CustomLogin
        Inherits Login
        
        Private Sub SiteSpecificUserLoggingMethod(ByVal UserName As String)
            ' Insert code to record the current date and time
            ' when this user was authenticated at the site.
        End Sub
        
        Overrides Protected Sub OnLoggedIn(ByVal e As EventArgs)
            SiteSpecificUserLoggingMethod(UserName)
        End Sub
    End Class
    
    ' Add the custom login control to the page.
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim loginControl As New CustomLogin

        loginControl.ID = "loginControl"

        PlaceHolder1.Controls.Add(loginControl)
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:placeholder id="Placeholder1" runat="Server"></asp:placeholder>
</form>
</body>
</html>
<!-- </Snippet1> -->
