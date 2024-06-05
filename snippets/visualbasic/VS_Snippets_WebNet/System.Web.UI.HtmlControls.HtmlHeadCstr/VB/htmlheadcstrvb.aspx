<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Programmatically create an HtmlHead control.
    Dim head As New HtmlHead()

    ' Add the page title to the header element.
    Dim title As New HtmlTitle()
    title.Text = "HtmlHead Constructor Example"
    head.Controls.Add(title)

    ' Add a defined style sheet that contains the body
    ' style to the HtmlHead control.
    Dim link As New HtmlLink()
    link.Href = "~/Stylesheet.css"
    link.Attributes.Add("rel", "stylesheet")
    link.Attributes.Add("type", "text/css")
    head.Controls.Add(link)

    ' Add the HtmlHead controls to the Controls
    ' collection of the page.
    Page.FindControl("HtmlElement").Controls.AddAt(0, head)
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml"  id="HtmlElement"
      runat="server">

<body>
  <form id="form1" runat="server">
  
  <h3>HtmlHead Class Constructor Example </h3>
        
  <hr />
    
  <asp:label id="Label1" 
    text = "View the HTML source code of this page to see the title 
            and style sheet link added to the header element."
    runat="server">
  </asp:label>   
        
  </form>
</body>
</html>
<!--</Snippet1>-->