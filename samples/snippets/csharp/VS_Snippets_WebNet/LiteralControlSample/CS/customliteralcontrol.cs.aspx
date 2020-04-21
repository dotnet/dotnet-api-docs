<%@ Register TagPrefix="CustomLiteralControl" Namespace="CustomLiteralControl" Assembly="customliteralcontrol" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">
 void Page_Load (object sender, EventArgs e)
 {
// <Snippet4>
    CustomLiteralControlClass myLiteralControlClass1= 
                   new CustomLiteralControlClass();
    myLiteralControlClass1.Text="This Control demonstrates the constructor1";
// </Snippet4>
// <Snippet5>
    CustomLiteralControlClass myLiteralControlClass2= 
                   new CustomLiteralControlClass("This Control demonstrates the constructor2");
// </Snippet5>
    Label1.Text="<br /><b>"+myLiteralControlClass1.Text+"</b></br>";
    Label2.Text="<br /><b>"+myLiteralControlClass2.Text+"</b></br>";
    MyControl.Text="";

 }
 void Show_Text(object sender, EventArgs e)
 {
    MyControl.Text=TextBox1.Text;
 }
      </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>
                </title>
<%--
        // System.Web.UI.LiteralControl.LiteralControl()
        // System.Web.UI.LiteralControl.LiteralControl(string)
         The following example demonstrates the LiteralControl() and LiteralControl(string) 
         constructors. The CustomLiteralControl class is derived from LiteralControl.
         The 'Text' property of 'LiteralControl' is overridden in CustomLiteralControlClass.
     --%>
    </head>
    <body>
        <form method="post" action="WebForm1.aspx" runat="server" id="Form1">
            <h1 style="text-align:center">Sample for LiteralControl Class</h1>
            <h3>
                <b>Enter some text into the textbox.. </b>
            </h3>
            <asp:TextBox ID="TextBox1" Runat="server" Text=""></asp:TextBox>
            <br />
            <asp:Button ID="Button1" Runat="server" Text="Submit" OnClick="Show_Text"></asp:Button>
            <CustomLiteralControl:CustomLiteralControlClass Id="MyControl" Text="" runat="server">
                <asp:Button id="Button2" Text="Hello this is  text of child control of the  CustomLiteralControlClass" runat="server"></asp:Button>
            </CustomLiteralControl:CustomLiteralControlClass>
            <asp:Label ID="Label1" Runat="server"></asp:Label>
            <asp:Label ID="Label2" Runat="server"></asp:Label>
        </form>
    </body>
</html>
