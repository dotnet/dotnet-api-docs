<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" >
  
  void Page_Load(Object sender, EventArgs e)
  {

    // Create an HtmlInputImage control.
    HtmlInputImage image = new HtmlInputImage();
    image.Src = "Image.jpg";
    image.Alt = "Alternate text for image.";

    // Add the control to the Controls collection of the 
    // PlaceHolder control.
    Place.Controls.Clear();
    Place.Controls.Add(image);

  }
  
   </script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  
<head runat="server">
    <title> HtmlInputImage Constructor Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlInputImage Constructor Example </h3> 
  
      <asp:PlaceHolder id="Place" 
                       runat="server"/>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
