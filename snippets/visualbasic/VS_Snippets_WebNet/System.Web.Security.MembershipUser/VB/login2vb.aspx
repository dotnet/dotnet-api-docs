<!-- <Snippet7> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim passwordExpiresDays As Double = 90

Public Sub Login_OnClick(sender As Object, args As EventArgs)

   Dim u As MembershipUser = Membership.GetUser(UsernameTextbox.Text)

   If u Is Nothing Then
     Msg.Text = "Invalid user name. Please check your user name and try again."
     Return
   End If

   If Membership.ValidateUser(UsernameTextbox.Text, PasswordTextbox.Text) Then
      If u.LastPasswordChangedDate.AddDays(passwordExpiresDays) < DateTime.Now Then
        Msg.Text = "Your password has expired. Please change your password to a new value."
        UsernameLabel.Text = UsernameTextbox.Text
        ChangePasswordPanel.Visible = True
        LoginPanel.Visible = False
      Else
        FormsAuthentication.RedirectFromLoginPage(UsernameTextbox.Text, NotPublicCheckBox.Checked)
      End If
   Else
     Msg.Text = "Invalid password. Please check your password and try again."
   End If
End Sub

Public Sub ChangePassword_OnClick(sender As Object, args As EventArgs)

  ' Update the password.

  Dim u As MembershipUser = Membership.GetUser(UsernameLabel.Text)

  If u.ChangePassword(OldPasswordTextbox.Text, NewPasswordTextbox.Text) Then
    Msg.Text = "Password changed."
    ChangePasswordPanel.Visible = False
    LoginPanel.Visible = True
  Else
    Msg.Text = "Password change failed. Please re-enter your values and try again."
  End If
End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Login</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Login</h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  <asp:Panel id="LoginPanel" runat="Server">

    Username: <asp:Textbox id="UsernameTextbox" runat="server" /><br />
    Password: <asp:Textbox id="PasswordTextbox" runat="server" TextMode="Password" /><br />
 
    <asp:Button id="LoginButton" Text="Login" OnClick="Login_OnClick" runat="server" />
    <asp:CheckBox id="NotPublicCheckBox" runat="server" /> Check here if this is <span style="text-decoration:underline">not</span> a public computer.

  </asp:Panel>

  <asp:Panel id="ChangePasswordPanel" runat="Server" Visible="False">
    <table cellpadding="3" border="0">
      <tr>
        <td>Username:</td>
        <td><b><asp:Label id="UsernameLabel" runat="server" /></b></td>
        <td></td>
      </tr>
      <tr>
        <td>Old Password:</td>
        <td><asp:Textbox id="OldPasswordTextbox" runat="server" TextMode="Password" /></td>
        <td><asp:RequiredFieldValidator id="OldPasswordRequiredValidator" runat="server"
                                        ControlToValidate="OldPasswordTextbox" ForeColor="red"
                                        Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <tr>
        <td>Password:</td>
        <td><asp:Textbox id="NewPasswordTextbox" runat="server" TextMode="Password" /></td>
        <td><asp:RequiredFieldValidator id="PasswordRequiredValidator" runat="server"
                                        ControlToValidate="NewPasswordTextbox" ForeColor="red"
                                        Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <tr>
        <td>Confirm Password:</td>
        <td><asp:Textbox id="PasswordConfirmTextbox" runat="server" TextMode="Password" /></td>
        <td><asp:RequiredFieldValidator id="PasswordConfirmRequiredValidator" runat="server"
                                        ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                                        Display="Static" ErrorMessage="Required" />
            <asp:CompareValidator id="PasswordConfirmCompareValidator" runat="server"
                                        ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                                        Display="Static" ControlToCompare="PasswordTextBox"
                                        ErrorMessage="Confirm password must match password." />
        </td>
      </tr>
      <tr>
        <td></td>
        <td><asp:Button id="ChangePasswordButton" Text="Change Password" 
                        OnClick="ChangePassword_OnClick" runat="server" /></td>
      </tr>
    </table>
  </asp:Panel>

</form>
<br />

</body>
</html>
<!-- </Snippet7> -->
