<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)

        Dim IsServerAvailable As Boolean

        ' If second is an even number, the server is available
        ' Replace this line with a valid check for the server.
        IsServerAvailable = (DateTime.Now.Second Mod 2 = 0)

        If Not IsServerAvailable Then
            Server.Transfer("Notify.aspx", True)
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Switch Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Database Server is Available</h2>
    
    <p>This page appears if the database server 
        is available.</p>
    
    <p>Enter a pretend Server Name: 
        <asp:TextBox ID="serverNameText" 
        runat="server">MyDatabaseServer</asp:TextBox>
    </p>
    
    <p><asp:Button ID="SubmitButton" runat="server" 
        Text="Is server available?" /></p>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
