<%@ Page Language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">


    Private Sub Page_Load(sender as object, e As EventArgs)

        ' <snippet5>
        ' Declare a string variable and set it to the result
        ' of a call to the ApplyAppPathModifier method.
        ' Then set the NavigateUrl property of a Hyperlink control
        ' to the string's value.
        Dim urlConverted As String = Response.ApplyAppPathModifier("TestPage.aspx")
        hlTest1.NavigateUrl = urlConverted
        ' </snippet5>
    End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        This is some placeholder text. For another page, click  
        <asp:HyperLink id="hlTest1" runat="server" >here</asp:HyperLink>.
    </form>
</body>
</html>