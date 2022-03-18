<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="False"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Login id="Login1" runat="server" 
            CreateUserText="New user registration..." 
            CreateUserUrl="register.aspx" 
            PasswordRecoveryText="Forgot your password?" 
            PasswordRecoveryUrl="passwordRecovery.aspx"
            HelpPageText="Help logging in..." 
            HelpPageUrl="loginHelp.aspx" >
            <HyperLinkStyle font-italic="True" forecolor="Green">
            </HyperLinkStyle>
        </asp:Login>
    </form>
</body>
</html>
<!-- </Snippet1> -->
