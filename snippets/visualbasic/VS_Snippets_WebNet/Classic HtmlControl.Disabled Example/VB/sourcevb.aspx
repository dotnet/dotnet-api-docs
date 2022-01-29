<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlControl Disabled Property Example</title>
<script language="VB" runat="server">
    Sub Submit_Clicked(sender As Object, e As EventArgs)
        
        Message.InnerHtml = "You clicked the submit button."
    End Sub 'Submit_Clicked
     
    Sub Enable_Clicked(sender As Object, e As EventArgs)
        
        Message.InnerHtml = ""
        Submit2.Disabled = Not Submit2.Disabled
    End Sub 'Enable_Clicked 
  </script>
</head>
 
<body>
   <form id="form1" method="post" runat="server">

      <h3>HtmlControl Disabled Property Example</h3>

      <input id="Submit1"        
             type="submit"
             value="Enable/Disable Submit Button"
             onserverclick="Enable_Clicked"
             runat="server"/>

      <br /><br />

      <input id="Submit2"        
             type="submit"
             value="Submit"
             onserverclick="Submit_Clicked"
             runat="server"/>
      
      

      <br /><br />

      <span id="Message" runat="server"/>  
 
   </form>

</body>
</html>
   
<!--</Snippet1>-->
