<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language = "VB" runat="server">
 
    Function CreateDataSource() As ICollection
        Dim dt As New DataTable()
        Dim dr As DataRow
        
        dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
        
        Dim i As Integer
        For i = 0 To 9
            dr = dt.NewRow()
            dr(0) = "Item " & i.ToString()
            dt.Rows.Add(dr)
        Next i
        
        Dim dv As New DataView(dt)
        Return dv
    End Function 'CreateDataSource


    Sub Page_Load(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            DataList1.DataSource = CreateDataSource()
            DataList1.DataBind()
        End If
    End Sub 'Page_Load


    Sub Button_Click(sender As Object, e As EventArgs)
        
        Label1.Text = "The ItemIndex of each item in the DataList are: <br />"
        
        Dim item As DataListItem
        For Each item In  DataList1.Items
            Label1.Text &= "<br />" & item.ItemIndex.ToString() & " - " & CType(item.Controls(1), DataBoundLiteralControl).Text
        Next item
    End Sub 'Button_Click
  
   </script>
 
<head runat="server">
    <title>DataListItem ItemIndex Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataListItem ItemIndex Example</h3>
 
      <asp:DataList id="DataList1" runat="server"
           BorderColor="black"
           CellPadding="3"
           Font-Names="Verdana"
           Font-Size="8pt">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <HeaderTemplate>

            Items

         </HeaderTemplate>
               
         <ItemTemplate>

            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>

         </ItemTemplate>
 
      </asp:DataList>

        <br /><br />

      <asp:Button id="Button1"
           Text="Display ItemIndex for Items in the DataList"
           OnClick="Button_Click"
           runat="server"/>
 
      <br /><br />

      <asp:Label id="Label1"
           runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
