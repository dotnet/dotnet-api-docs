<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head>
    <title> HtmlAnchor ServerClick Event Example </title>
<script runat="server">

      Sub HtmlAnchor_Click(sender As Object, e As EventArgs)
         
         Message.InnerHtml = "Thank you for clicking the HtmlAnchor control."

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> HtmlAnchor ServerClick Event Example </h3>

      <a id="AnchorButton"
         onserverclick="HtmlAnchor_Click"
         runat="server">

         Click Here

      </a>

      <br /><br />

      <span id="Message" runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->