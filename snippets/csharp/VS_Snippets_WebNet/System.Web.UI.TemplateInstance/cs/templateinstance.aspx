<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="AspNetSamples" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS.Controls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
  protected void Page_Load(object sender, EventArgs e)
  {
    this.DataBind();
    this.LoginViewLabel1.Text = "LoginView Anonymous Template Label Set Dynamically.";    
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TemplateInstance Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <AspNetSamples:MyLoginView id="MyLoginView1" runat="server">
        <AnonymousTemplate>
          <asp:Label ID="LoginViewLabel1" runat="server" Text="Test"/>
        </AnonymousTemplate>
      </AspNetSamples:MyLoginView>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
