<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Button Example</title>
<script language="C#" runat="server">

      void SubmitBtn_Click(Object sender, EventArgs e) 
      {
         Message.Text="Hello World!!";
      }

   </script>
</head>
<body>
   <form id="form1" runat="server">

      <h3>Button Example</h3>

      Click on the submit button.<br /><br />
 
      <asp:Button id="Button1"
           Text="Submit"
           OnClick="SubmitBtn_Click" 
           runat="server"/>
       
      <br />

      <asp:label id="Message" runat="server"/>
 
   </form>
</body>
</html>
<!--</Snippet1>-->
