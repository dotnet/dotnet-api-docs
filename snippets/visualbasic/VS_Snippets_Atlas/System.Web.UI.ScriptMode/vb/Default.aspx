<%@ Page Language="VB" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- <Snippet1> -->
        <asp:ScriptManager ID="SM" runat="server" ScriptMode="Release">
            <Scripts>
                <asp:ScriptReference Path="CustomClient.js" ScriptMode="Debug" />
            </Scripts>
        </asp:ScriptManager>
        <!-- </Snippet1> -->
        <div>
        </div>
    </form>
</body>
</html>
