<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    MyText.Style.Add(HtmlTextWriterStyle.Width, "200");
    FirstMessage.Text = "The text box font color is: " + 
      MyText.Style["color"] + "<br />" +
      "The text box width is: " + 
      MyText.Style[HtmlTextWriterStyle.Width];
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CssCollection This Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <input id="MyText"
             type="text" 
             value="Type a value here."
             style="font: 14pt Verdana; color: blue;"
             runat="server"/>
      <br />
      <asp:Label id="FirstMessage"
                 runat="server"/>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
