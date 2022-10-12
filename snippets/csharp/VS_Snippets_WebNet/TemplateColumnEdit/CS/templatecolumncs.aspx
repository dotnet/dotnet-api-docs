<!--<Snippet1>-->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">

      DataTable Store = new DataTable();
      DataView StoreView;  

      void Page_Load(Object sender, EventArgs e) 
      {
         if(Session["StoreData"] == null)
         {
            DataRow dr;
 
            Store = new DataTable();      

            Store.Columns.Add(new DataColumn("Tax", typeof(String)));
            Store.Columns.Add(new DataColumn("Item", typeof(String)));
            Store.Columns.Add(new DataColumn("Price", typeof(String)));

            Session["StoreData"] = Store;
            
            // Create sample data.
            for (int i = 1; i <= 4; i++) 
            {
               dr = Store.NewRow();

               dr[0] = "0.0%";
               dr[1] = "Item " + i.ToString();
               dr[2] = (1.23 * (i + 1)).ToString();
 
               Store.Rows.Add(dr);
            }       

         }
         else
            Store = (DataTable)Session["StoreData"];

         StoreView = new DataView(Store);
         StoreView.Sort="Item";

         if(!IsPostBack)                    
            BindGrid();
                   
      }

      void MyDataGrid_Edit(Object sender, DataGridCommandEventArgs e) 
      {
         MyDataGrid.EditItemIndex = e.Item.ItemIndex;
         BindGrid();
      }

      void MyDataGrid_Cancel(Object sender, DataGridCommandEventArgs e) 
      {
         MyDataGrid.EditItemIndex = -1;
         BindGrid();
      }

      void MyDataGrid_Update(Object sender, DataGridCommandEventArgs e) 
      {
         // Get the text box that contains the price to edit. 
         // For bound columns the edited value is stored in a text box.
         // The text box is the first control in the Controls collection.
         TextBox priceText = (TextBox)e.Item.Cells[3].Controls[0];

         // Get the check box that indicates whether to include tax from the 
         // TemplateColumn. Notice that in this case, the check box control is
         // second control in the Controls collection.
         CheckBox taxCheck = (CheckBox)e.Item.Cells[2].Controls[1];

         String item = e.Item.Cells[1].Text;
         String price = priceText.Text;
       
         DataRow dr;

         // With a database, use an update command.  Since the data source is 
         // an in-memory DataTable, delete the old row and replace it with a new one.

         // Remove old entry.
         StoreView.RowFilter = "Item='" + item + "'";
         if (StoreView.Count > 0)
            StoreView.Delete(0);
         StoreView.RowFilter = "";
 
         // Add new entry.
         dr = Store.NewRow();

         if (taxCheck.Checked)
            dr[0] = "8.6%";
         else 
            dr[0] = "0.0%";
         dr[1] = item;
         dr[2] = price;
         Store.Rows.Add(dr);

         MyDataGrid.EditItemIndex = -1;
         BindGrid();
      }

      void BindGrid() 
      {
         MyDataGrid.DataSource = StoreView;
         MyDataGrid.DataBind();
      }

   </script>

<head runat="server">
    <title>TemplateColumn Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>TemplateColumn Example</h3>

      <asp:DataGrid id="MyDataGrid" runat="server"
           BorderColor="black"
           CellPadding="2"        
           OnEditCommand="MyDataGrid_Edit"
           OnCancelCommand="MyDataGrid_Cancel"
           OnUpdateCommand="MyDataGrid_Update"
           ShowFooter="True"
           AutoGenerateColumns="false">

         <Columns>

            <asp:EditCommandColumn
                 EditText="Edit"
                 CancelText="Cancel"
                 UpdateText="Update"
                 ItemStyle-Wrap="false"
                 HeaderText="Edit Controls"/>

            <asp:BoundColumn HeaderText="Description" 
                 ReadOnly="true" 
                 DataField="Item"/>

            <asp:TemplateColumn>

               <HeaderTemplate>
                  <b> Tax </b>
               </HeaderTemplate>

               <ItemTemplate>
                  <asp:Label
                       Text='<%# DataBinder.Eval(Container.DataItem, "Tax") %>'
                       runat="server"/>
               </ItemTemplate>

               <EditItemTemplate>

                  <asp:CheckBox
                       Text="Taxable" 
                       runat="server"/>

               </EditItemTemplate>

               <FooterTemplate>
                  <asp:HyperLink id="HyperLink1"
                       Text="Microsoft"
                       NavigateUrl="http://www.microsoft.com"
                       runat="server"/>
               </FooterTemplate>

            </asp:TemplateColumn>

            <asp:BoundColumn HeaderText="Price" 
                 DataField="Price"/>

         </Columns>

      </asp:DataGrid>

   </form>

</body>
</html>

<!--</Snippet1>-->