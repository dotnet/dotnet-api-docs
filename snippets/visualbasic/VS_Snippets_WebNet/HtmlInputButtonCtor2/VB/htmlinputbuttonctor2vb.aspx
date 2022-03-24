<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a new HtmlInputButton control as a Submit button. 
    Dim button As HtmlInputButton = New HtmlInputButton("submit")
    button.ID = "SubmitButton"
    button.Value = "Submit"

    ' Create a new HtmlInputButton control as a Reset button.
    Dim button2 As HtmlInputButton = New HtmlInputButton("reset")
    button2.ID = "ResetButton"
    button2.Value = "Reset"

    ' Add the controls to the Controls collection of the
    ' PlaceHolder control. 
    Place.Controls.Clear()
    Place.Controls.Add(button)
    Place.Controls.Add(button2)

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>HtmlInputButton Constructor Example</title>
</head>
<body>
   <form id="form1" runat="server">
      <h3> HtmlInputButton Constructor Example </h3>

      <asp:Placeholder id="Place" 
           runat="server"/>

   </form>
</body>
</html>
<!-- </Snippet1> -->