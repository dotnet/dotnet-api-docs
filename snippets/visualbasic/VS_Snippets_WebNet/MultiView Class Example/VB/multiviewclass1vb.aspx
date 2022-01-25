<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>MultiView Class Example</title>
<script runat="server">

        Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            ' The first time the page loads,
            ' render the DefaultView.
            If Not IsPostBack Then
                ' Set DefaultView as the active view.
                MultiView1.SetActiveView(DefaultView)
            End If

        End Sub

        Sub LinkButton_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs)
            ' Determine which link button was clicked
            ' and set the active view to
            ' the view selected by the user.
            Select Case (e.CommandArgument)
                Case "DefaultView"
                    MultiView1.SetActiveView(DefaultView)
                Case "News"
                    MultiView1.SetActiveView(NewsView)
                Case "Shopping"
                    MultiView1.SetActiveView(ShoppingView)
                Case Else
                    Throw New Exception("You did not select a valid list item.")

            End Select

        End Sub

</script>

</head>
<body>
    <form id="Form1" runat="server">
        
        <h3>MultiView Class Example</h3>

        <asp:MultiView id="MultiView1"
            runat="Server">

            <asp:View id="DefaultView" 
                runat="Server">                

                <asp:Panel id="DefaultViewPanel" 
                    Width="330px" 
                    BackColor="#C0C0FF" 
                    BorderColor="#404040"
                    BorderStyle="Double"
                    runat="Server">  

                    <asp:Label id="DefaultLabel1" 
                        Font-bold="true"
                        Font-size="14" 
                        Text="The Default View"
                        runat="Server"
                        AssociatedControlID="DefaultView">
                    </asp:Label>                  

                    <asp:BulletedList id="DefaultBulletedList1" 
                        BulletStyle="Disc" 
                        DisplayMode="Hyperlink"
                        Target="_blank"
                        runat="Server">
                            <asp:ListItem Value="http://www.microsoft.com">Today's Weather</asp:ListItem>
                            <asp:ListItem Value="http://www.microsoft.com">Today's Stock Quotes</asp:ListItem>
                            <asp:ListItem Value="http://www.microsoft.com">Today's News Headlines</asp:ListItem>
                            <asp:ListItem Value="http://www.microsoft.com">Today's Featured Shopping</asp:ListItem>
                    </asp:BulletedList>

                    <hr />

                    <asp:Label id="DefaultLabel2"                      
                        Font-size="12" 
                        Text="Click a link to display a different view:"
                        runat="Server">
                    </asp:Label><br />
                
                    <asp:LinkButton id="Default_NewsLink" 
                        Text="Go to News View" 
                        OnCommand="LinkButton_Command"
                        CommandArgument="News" 
                        CommandName="Link"
            Width="150px"
                        runat="Server">
                    </asp:LinkButton>

                    <asp:LinkButton id="Default_ShoppingLink"
                        Text="Go to Shopping View" 
                        OnCommand="LinkButton_Command"
                        CommandArgument="Shopping" 
                        CommandName="Link"
            Width="150px"
                        runat="server">
                    </asp:LinkButton><br /><br />

                </asp:Panel>

            </asp:View>

            <asp:View id="NewsView" 
                runat="Server">

                <asp:Panel id="NewsPanel1" 
                    Width="330px" 
                    BackColor="#C0FFC0" 
                    BorderColor="#404040"
                    BorderStyle="Double"
                    runat="Server">

                    <asp:Label id="NewsLabel1" 
                        Font-bold="true"
                        Font-size="14"
                        Text="The News View"
                        runat="Server"
                        AssociatedControlID="NewsView">                    
                    </asp:Label>

                    <asp:BulletedList id="NewsBulletedlist1" 
                        BulletStyle="Disc" 
                        DisplayMode="Hyperlink"
                        Target="_blank"
                        runat="Server">
                            <asp:ListItem Value="http://www.microsoft.com">Today's International Headlines</asp:ListItem>
                            <asp:ListItem Value="http://www.microsoft.com">Today's National Headlines</asp:ListItem>
                            <asp:ListItem Value="http://www.microsoft.com">Today's Local News</asp:ListItem>
                    </asp:BulletedList>

                    <hr />

                    <asp:Label id="NewsLabel2"                      
                        Font-size="12" 
                        Text="Click a link to display a different view:"
                        runat="Server">
                    </asp:Label><br />

                    <asp:LinkButton id="News_DefaultLink" 
                        Text="Go to the Default View" 
                        OnCommand="LinkButton_Command"
                        CommandArgument="DefaultView" 
                        CommandName="Link"
                        Width="150px"
                        runat="Server">
                    </asp:LinkButton>

                    <asp:LinkButton id="News_ShoppingLink" 
                        Text="Go to Shopping View" 
                        OnCommand="LinkButton_Command"
                        CommandArgument="Shopping" 
                        CommandName="Link"
                        Width="150px"
                        runat="Server">
                    </asp:LinkButton><br /><br />

                </asp:Panel>

            </asp:View>

            <asp:View id="ShoppingView" 
                runat="Server">

                <asp:Panel id="ShoppingPanel1" 
                    Width="330px" 
                    BackColor="#FFFFC0" 
                    BorderColor="#404040"
                    BorderStyle="Double"
                    runat="Server">

                    <asp:Label id="ShoppingLabel1" 
                        Font-Bold="true"
                        Font-size="14"                         
                        Text="The Shopping View"
                        runat="Server"
                        AssociatedControlID="ShoppingView">
                    </asp:Label>

                    <asp:BulletedList id="ShoppingBulletedlist1" 
                        BulletStyle="Disc" 
                        DisplayMode="Hyperlink"
                        Target="_blank"
                        runat="Server">
                            <asp:ListItem Value="http://www.microsoft.com">Shop for Home and Garden </asp:ListItem>
                            <asp:ListItem Value="http://www.microsoft.com">Shop for Women's Fashions</asp:ListItem>
                            <asp:ListItem Value="http://www.microsoft.com">Shop for Men's Fashions</asp:ListItem>
                    </asp:BulletedList>

                    <hr />

                    <asp:Label id="ShoppingLabel2" 
                        Font-size="12" 
                        Text="Click a link to display a different view:"
                        runat="Server">
                    </asp:Label><br />

                    <asp:LinkButton id="Shopping_DefaultLink" 
                        Text="Go to the Default View" 
                        OnCommand="LinkButton_Command"
                        CommandArgument="DefaultView" 
                        CommandName="Link"
                        Width="150px"
                        runat="Server">
                    </asp:LinkButton>

                    <asp:LinkButton id="Shopping_NewsLink"
                        Text="Go to News View" 
                        OnCommand="LinkButton_Command"
                        CommandArgument="News" 
                        CommandName="Link"
                        Width="150px"
                        runat="Server">
                    </asp:LinkButton><br /><br />

                </asp:Panel>

            </asp:View>

        </asp:MultiView>

    </form>
</body>
</html>
<!--</Snippet1>-->
