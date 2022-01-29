<!-- <Snippet13> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim pageSize As Integer = 5
Dim totalUsers As Integer
Dim totalPages As Integer
Dim currentPage As Integer = 1

Private Sub GetUsers()
  UserGrid.DataSource = Membership.FindUsersByEmail(EmailTextBox.Text, _
                          currentPage - 1, pageSize, totalUsers)

  totalPages = ((totalUsers - 1) \ pageSize) + 1

  ' Ensure that we do not navigate past the last page of users.

  If currentPage > totalPages Then
    currentPage = totalPages
    GetUsers()
    Return
  End If

  UserGrid.DataBind()
  CurrentPageLabel.Text = currentPage.ToString()
  TotalPagesLabel.Text = totalPages.ToString()

  If currentPage = totalPages Then
    NextButton.Visible = False
  Else
    NextButton.Visible = True
  End If

  If currentPage = 1 Then
    PreviousButton.Visible = False
  Else
    PreviousButton.Visible = True
  End If

  If totalUsers <= 0 Then
    NavigationPanel.Visible = False
  Else
    NavigationPanel.Visible = True
  End If
End Sub

Public Sub NextButton_OnClick(sender As Object, args As EventArgs)
  currentPage = Convert.ToInt32(CurrentPageLabel.Text)
  currentPage += 1
  GetUsers()
End Sub

Public Sub PreviousButton_OnClick(sender As Object, args As EventArgs)
  currentPage = Convert.ToInt32(CurrentPageLabel.Text)
  currentPage -= 1
  GetUsers()
End Sub

Public Sub GoButton_OnClick(sender As Object, args As EventArgs)
  currentPage = 1
  GetUsers()
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Find Users by Email</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>User List</h3>

  Email address to Search for: 
    <asp:TextBox id="EmailTextBox" runat="server" />
    <asp:Button id="GoButton" Text=" Go " OnClick="GoButton_OnClick" runat="server" /><br />

  <asp:Panel id="NavigationPanel" Visible="False" runat="server">
    <table border="0" cellpadding="3" cellspacing="3">
      <tr>
        <td style="width:100">Page <asp:Label id="CurrentPageLabel" runat="server" />
            of <asp:Label id="TotalPagesLabel" runat="server" /></td>
        <td style="width:60"><asp:LinkButton id="PreviousButton" Text="< Prev"
                            OnClick="PreviousButton_OnClick" runat="server" /></td>
        <td style="width:60"><asp:LinkButton id="NextButton" Text="Next >"
                            OnClick="NextButton_OnClick" runat="server" /></td>
      </tr>
    </table>
  </asp:Panel>

  <asp:DataGrid id="UserGrid" runat="server"
                CellPadding="2" CellSpacing="1"
                Gridlines="Both">
    <HeaderStyle BackColor="darkblue" ForeColor="white" />
  </asp:DataGrid>

</form>

</body>
</html>
<!-- </Snippet13> -->