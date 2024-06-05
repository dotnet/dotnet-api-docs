<!---
The following example demonstrates the Remove(ListItem), RemoveAt,
Clear, CopyTo, and Item  methods of the ListItemCollection class. It 
provides two buttons that allow the user to either delete all items
from a ListBox or to specify an item that should be deleted.
-->
    
<%@ Page language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">

  void Delete1_Click(Object Sender, EventArgs e)
  {
// <Snippet1>
// <Snippet2>
      if(ListBox1.Items.Count > 0)
      {   
          ListItem myListItem = null;
          bool removeSuccess = true;
          if (PositionValue.Text == "")
          {                  
              // Deletion by removing the ListItem.
              myListItem = ListBox1.Items.FindByText(CRName.Text);
              ListBox1.Items.Remove(myListItem);
              removeSuccess = true;
          }
          else
          {
// <Snippet3>
              int selectedPosition = Convert.ToInt32(PositionValue.Text);
              myListItem = ListBox1.Items[selectedPosition];
              // Deletion by removing the ListItem at the specified position.
              ListBox1.Items.RemoveAt(selectedPosition);
              removeSuccess = true;          
// </Snippet3>
          }
// </Snippet2>
// </Snippet1>
          if(removeSuccess)
          { 
              // Display the deleted ListItem details.     
              ResultText.Text="<b>Successfully deleted. " +
                  "The details of the deleted ListItem are:</b>";
              int pos = myListItem.Text.IndexOf("-");
              CRLabel.Text=" <b>Country or Region Name:</b>"
                  + myListItem.Text.Substring(0,pos);
          }
      }
      else
      {
          ResultText.Text ="<b>No ListItems were there to delete from the ListBox.</b>";
      }
      CRName.Text = "";
  }
      
  void DeleteAll_Click(Object Sender, EventArgs e)
  {     
// <Snippet4>
// <Snippet5> 
      // Copy the items in the ListItemCollection to an array before 
      // deleting them.     
      ListItem[] myListItemArray = new ListItem[ListBox1.Items.Count];
      ListBox1.Items.CopyTo(myListItemArray, 0);
      
      // Delete all the items from the ListBox.
      ListBox1.Items.Clear();
      DeleteLabel.Text = "<b>All items in the ListBox were deleted successfully." 
          + "</b><br /><b>The deleted items are:";
      String listResults="";
          foreach(ListItem myItem in myListItemArray)
          {
              listResults = listResults + myItem.Text + "<br />";
          }
      ResultsLabel.Text = listResults;
// </Snippet5>
// </Snippet4>
      }      

      
      void Page_Load(Object Sender, EventArgs e)
      {      
          ResultText.Text="";
          DeleteLabel.Text="";
          ResultsLabel.Text = "";  
          PositionValue.Text = "";  
      }
    </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>
                ListItemCollection Example
            </title>
</head>

    <body>
        <center>
            <h3>
                ListItemCollection Example
            </h3>
        </center>
        <form runat="server" id="Form1">
            <table style="text-align:center; background-color:#ffffcc" id="Table1">
                <tr>
                    <td colspan="3" align="center">
                        <b>List of countries and regions:</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:ListBox id="ListBox1" runat="server">
                            <asp:ListItem>Australia</asp:ListItem>
                            <asp:ListItem>Brazil</asp:ListItem>
                            <asp:ListItem>Bulgaria</asp:ListItem>
                            <asp:ListItem>Canada</asp:ListItem>
                            <asp:ListItem>China</asp:ListItem>
                            <asp:ListItem>Egypt</asp:ListItem>
                            <asp:ListItem>Finland</asp:ListItem>
                            <asp:ListItem>France</asp:ListItem>
                            <asp:ListItem>Germany</asp:ListItem>
                            <asp:ListItem>India</asp:ListItem>
                            <asp:ListItem>Japan</asp:ListItem>
                            <asp:ListItem>Peru</asp:ListItem>
                            <asp:ListItem>Russia</asp:ListItem>
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>

            <table style="text-align:center">
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="DeleteLabel" Runat="server">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="ResultsLabel" Runat="server">
                        </asp:Label>
                    </td>
                </tr>
            </table>

            <table style="text-align:center">
                <tr>
                    <td colspan="3">                        
                        <asp:Label ID="ResultText" Runat="server">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Label ID="CRLabel" Runat="server">
                        </asp:Label>
                    </td>
                </tr>
            </table>

            <table style="text-align:center">
                <tr>
                    <td style="text-align:center; background-color:#ffffcc">
                        To delete an item, enter a country name
                        or position number.
                    </td>
                </tr>
            </table>

            <table style="text-align:center; border-width:0">
                <tr style="background-color:#ffccff">
                    <td>
                        <asp:Label ID="NameLabel" Visible="true" 
                            Text="Enter the country or region name:" 
                            Runat="server" AssociatedControlID="CRName">
                        </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="CRName" Runat="server" 
                            Visible="true" Text="">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr style="background-color:#ffffcc">
                    <td>
                        <asp:Label ID="Position" Visible="true" 
                            Text="Enter the Position in the ListBox:"
                            Runat="server" AssociatedControlID="PositionValue">
                        </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="PositionValue" Runat="server" 
                            Visible="true" Text="">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="DeleteButton" Runat="server" 
                            Visible="true" Text="Delete from ListBox" 
                            OnClick="Delete1_Click">
                        </asp:Button>
                    </td>
                </tr>
            </table>

            <table style="text-align:center; border-width:0">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="DeleteallLabel" 
                            Text="Click the Delete All button to delete all list items"
                            Runat="server" AssociatedControlID="Delete1">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="Delete1" Text="Delete All" 
                            OnClick="DeleteAll_Click" Runat="server">
                        </asp:Button>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
