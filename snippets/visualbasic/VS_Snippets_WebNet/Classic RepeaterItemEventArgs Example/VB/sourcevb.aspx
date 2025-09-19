<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="VB" runat="server">
    Dim Count As Integer = 1

    Sub Page_Load(Sender As Object, e As EventArgs)
        If Not IsPostBack Then
            Dim values As New ArrayList()
            
            values.Add(New PositionData("Microsoft", "Msft"))
            values.Add(New PositionData("Intel", "Intc"))
            values.Add(New PositionData("Dell", "Dell"))
            
            Repeater1.DataSource = values
            Repeater1.DataBind()
        End If
    End Sub

    Sub R1_ItemCreated(Sender As Object, e As RepeaterItemEventArgs)
        Dim iTypeText As String = ""
        
        Select Case e.Item.ItemType
            Case ListItemType.Item
                iTypeText = "Item"
            Case ListItemType.AlternatingItem
                iTypeText = "AlternatingItem"
            Case ListItemType.Header
                iTypeText = "Header"
            Case ListItemType.Footer
                iTypeText = "Footer"
            Case ListItemType.Separator
                iTypeText = "Separator"
        End Select
        Count = Count + 1
        Label1.Text &= "(" & Count & ") A Repeater " & _
            iTypeText & " has been created; <br />"
    End Sub
 
    Public Class PositionData
        
        Private myName As String
        Private myTicker As String        
        
        Public Sub New(newName As String, newTicker As String)
            Me.myName = newName
            Me.myTicker = newTicker
        End Sub        
        
        Public ReadOnly Property Name() As String
            Get
                Return myName
            End Get
        End Property        
        
        Public ReadOnly Property Ticker() As String
            Get
                Return myTicker
            End Get
        End Property
    End Class
    
</script>
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Repeater Example</title>
</head>
<body>
    <form id="form1" runat="server">

    <h3>Repeater Example</h3>
 
       <p style="font-weight: bold">Repeater1:</p>
         
       <asp:Repeater ID="Repeater1" OnItemCreated="R1_ItemCreated" runat="server">
          <HeaderTemplate>
             <table border="1">
                <tr>
                   <td style="font-weight:bold">Company</td>
                   <td style="font-weight:bold">Symbol</td>
                </tr>
          </HeaderTemplate>
             
          <ItemTemplate>
             <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "Name") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Ticker") %> </td>
             </tr>
          </ItemTemplate>
             
          <FooterTemplate>
             </table>
          </FooterTemplate>
             
       </asp:Repeater>
       <br />
         
       <asp:Label ID="Label1" Font-Names="Verdana" 
          ForeColor="Green" Font-Size="10pt" Runat="server"/>
    </form>
 </body>
 </html>
<!--</Snippet1>-->
