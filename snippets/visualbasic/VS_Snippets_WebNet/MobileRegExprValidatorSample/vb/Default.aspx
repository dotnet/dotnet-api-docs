<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Const uNameExpr As String = "^[a-zA-Z](.{1,9})$"
        Const phoneExpr As String = _
            "((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"

        ' Define validation expressions.
        RegExprVal1.ValidationExpression = uNameExpr
        RegExprVal2.ValidationExpression = phoneExpr
        
        ReqFldVal1.Text = "User name is required"
        RegExprVal1.Text = "Must be between 2 to 10 characters"
        RegExprVal2.Text = "Please provide a valid number: (425) 555-0187"
        ' ErrorMessages appear in ValidationSummary.
        RegExprVal1.ErrorMessage = "Incorrect UserName format. Name" & _
            " can be 2 to 10 characters long"
        ReqFldVal1.ErrorMessage = "User name required"
        RegExprVal2.ErrorMessage = _
            "Please provide a valid number: (000) 000-0000"
    End Sub
    
    Private Sub OnCmdClick(ByVal sender As Object, ByVal e As EventArgs)
        If (Page.IsValid) Then
            ActiveForm = Form2
        End If
    End Sub

</script>

<html xmlns="http:'www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1" >
        <mobile:Label runat="server" id="Label1" 
            Text="Your information" 
            StyleReference="title" />   
        <mobile:Label runat="server" id="Label2" 
            Text="User Name (required)" />
        <mobile:Textbox  runat="server" id="TextBox1"/>
        <mobile:RequiredFieldValidator runat="server" 
            id="ReqFldVal1" ControlToValidate="TextBox1" />
        <mobile:RegularExpressionValidator runat="server" 
            id="RegExprVal1" ControlToValidate="TextBox1" />
        <mobile:Label runat="server" id="Label3" Text="Phone" />
        <mobile:Textbox  runat="server" id="TextBox2"/>
        <mobile:RegularExpressionValidator runat="server" 
            id="RegExprVal2" ControlToValidate="TextBox2" />
        <mobile:ValidationSummary ID="ValidationSummary1" 
            FormToValidate="Form1" HeaderText="Error Summary:" 
            runat="server" />
        <mobile:Command runat="server" id="Command1" 
            Text="Submit" OnClick="OnCmdClick"/>
    </mobile:Form>

    <mobile:Form id="Form2" runat="server" >
        <mobile:Label ID="Label4" runat="server" Text="Thank You." />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
