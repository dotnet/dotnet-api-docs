<%--<snippet9>--%>
<%@ control inherits = "LogOnControl" src = "LogOnControl.vb" %>

<table style="font: 10pt verdana;border-width:1;border-style:solid;border-color:black;" cellspacing="15">
<tr>
<td><b>Login: </b></td>
<td><ASP:TextBox id="user" runat="server"/></td>
</tr>
<tr>
<td><b>Password: </b></td>
<td><ASP:TextBox id="password" TextMode="Password" runat="server"/></td>
</tr>
<tr>
<td><ASP:Label id="message" runat="server"/></td>
</tr>
<tr>
</tr>
</table>
<%--</snippet9>--%>