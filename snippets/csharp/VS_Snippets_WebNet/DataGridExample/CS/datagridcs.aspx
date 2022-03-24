<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      ICollection CreateDataSource() 
      {
      
         // Create sample data for the DataGrid control.
         DataTable dt = new DataTable();
         DataRow dr;
 
         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
         // Populate the table with sample values.
         for (int i = 0; i < 9; i++) 
         {
            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = 1.23 * (i + 1);
 
            dt.Rows.Add(dr);
         }
 
         DataView dv = new DataView(dt);
         return dv;
      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
 
         // Load sample data only once when the page is first loaded.
         if (!IsPostBack) 
         {
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
         }

      }

      void Button_Click(Object sender, EventArgs e) 
      {

         // Count the number of selected items in the DataGrid control.
         int count = 0;

         // Display the selected times.
         Message.Text = "You Selected: <br />";

         // Iterate through each item (row) in the DataGrid control and 
         // determine whether it is selected.
         foreach (DataGridItem item in ItemsGrid.Items)
         {

            DetermineSelection(item, ref count);        

         }

         // If no items are selected, display the appropriate message.
         if (count == 0)
         {

            Message.Text = "No items selected";

         }

      }

      void DetermineSelection(DataGridItem item, ref int count)
      {

         // Retrieve the SelectCheckBox CheckBox control from the specified 
         // item (row) in the DataGrid control.
         CheckBox selection = (CheckBox)item.FindControl("SelectCheckBox");

         // If the item is selected, display the appropriate message and 
         // increment the count of selected items.
         if (selection != null)
         {

           if (selection.Checked)
           {
              Message.Text += "- " + item.Cells[1].Text + "<br />";
              count++;
           }

         }    

      }

   </script>
 
<head runat="server">
    <title>DataGrid Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGrid Example</h3>
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="False"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <Columns>

            <asp:BoundColumn DataField="IntegerValue" 
                 HeaderText="Item"/>

            <asp:BoundColumn DataField="StringValue" 
                 HeaderText="Description"/>

            <asp:BoundColumn DataField="CurrencyValue" 
                 HeaderText="Price"
                 DataFormatString="{0:c}">

               <ItemStyle HorizontalAlign="Right">
               </ItemStyle>

            </asp:BoundColumn>

            <asp:TemplateColumn HeaderText="Select Item">

               <ItemTemplate>

                  <asp:CheckBox id="SelectCheckBox"
                       Text="Add to Cart"
                       Checked="False"
                       runat="server"/>

               </ItemTemplate>

            </asp:TemplateColumn>
 
         </Columns> 
 
      </asp:DataGrid>

      <br /><br />

      <asp:Button id="SubmitButton"
           Text="Submit"
           OnClick = "Button_Click"
           runat="server"/>

      <br /><br />

      <asp:Label id="Message"
           runat="server"/>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->