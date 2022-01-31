﻿// <Snippet1>
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
   private System.ComponentModel.Container components;
   private Button button1;
   private Button button2;
   private DataGrid myDataGrid;   
   private DataSet myDataSet;
   private bool TablesAlreadyAdded;
   public Form1()
   {
      // Required for Windows Form Designer support.
      InitializeComponent();
      // Call SetUp to bind the controls.
      SetUp();
   }

   protected override void Dispose( bool disposing ){
      if( disposing ){
         if (components != null){
            components.Dispose();}
      }
      base.Dispose( disposing );
   }
   private void InitializeComponent()
   {
      // Create the form and its controls.
      this.components = new System.ComponentModel.Container();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.myDataGrid = new DataGrid();
      
      this.Text = "DataGrid Control Sample";
      this.ClientSize = new System.Drawing.Size(450, 330);
      
      button1.Location = new Point(24, 16);
      button1.Size = new System.Drawing.Size(120, 24);
      button1.Text = "Change Appearance";
      button1.Click+=new System.EventHandler(button1_Click);

      button2.Location = new Point(150, 16);
      button2.Size = new System.Drawing.Size(120, 24);
      button2.Text = "Get Binding Manager";
      button2.Click+=new System.EventHandler(button2_Click);

      myDataGrid.Location = new  Point(24, 50);
      myDataGrid.Size = new Size(300, 200);
      myDataGrid.CaptionText = "Microsoft DataGrid Control";
      myDataGrid.MouseUp += new MouseEventHandler(Grid_MouseUp);
      
      this.Controls.Add(button1);
      this.Controls.Add(button2);
      this.Controls.Add(myDataGrid);
   }

   public static void Main()
   {
      Application.Run(new Form1());
   }
   
   private void SetUp()
   {
      // Create a DataSet with two tables and one relation.
      MakeDataSet();
      /* Bind the DataGrid to the DataSet. The dataMember
      specifies that the Customers table should be displayed.*/
      myDataGrid.SetDataBinding(myDataSet, "Customers");
   }

   private void button1_Click(object sender, System.EventArgs e)
   {
      if(TablesAlreadyAdded) return;
      AddCustomDataTableStyle();
   }

   private void AddCustomDataTableStyle()
   {
      DataGridTableStyle ts1 = new DataGridTableStyle();
      ts1.MappingName = "Customers";
      // Set other properties.
      ts1.AlternatingBackColor = Color.LightGray;

      /* Add a GridColumnStyle and set its MappingName 
      to the name of a DataColumn in the DataTable. 
      Set the HeaderText and Width properties. */
      
      DataGridColumnStyle boolCol = new DataGridBoolColumn();
      boolCol.MappingName = "Current";
      boolCol.HeaderText = "IsCurrent Customer";
      boolCol.Width = 150;
      ts1.GridColumnStyles.Add(boolCol);
      
      // Add a second column style.
      DataGridColumnStyle TextCol = new DataGridTextBoxColumn();
      TextCol.MappingName = "custName";
      TextCol.HeaderText = "Customer Name";
      TextCol.Width = 250;
      ts1.GridColumnStyles.Add(TextCol);

      // Create the second table style with columns.
      DataGridTableStyle ts2 = new DataGridTableStyle();
      ts2.MappingName = "Orders";

      // Set other properties.
      ts2.AlternatingBackColor = Color.LightBlue;
      
      // Create new ColumnStyle objects
      DataGridColumnStyle cOrderDate = 
      new DataGridTextBoxColumn();
      cOrderDate.MappingName = "OrderDate";
      cOrderDate.HeaderText = "Order Date";
      cOrderDate.Width = 100;
      ts2.GridColumnStyles.Add(cOrderDate);

      /* Use a PropertyDescriptor to create a formatted
      column. First get the PropertyDescriptorCollection
      for the data source and data member. */
      PropertyDescriptorCollection pcol = this.BindingContext
      [myDataSet, "Customers.custToOrders"].GetItemProperties();
 
      /* Create a formatted column using a PropertyDescriptor.
      The formatting character "c" specifies a currency format. */     
      DataGridColumnStyle csOrderAmount = 
      new DataGridTextBoxColumn(pcol["OrderAmount"], "c", true);
      csOrderAmount.MappingName = "OrderAmount";
      csOrderAmount.HeaderText = "Total";
      csOrderAmount.Width = 100;
      ts2.GridColumnStyles.Add(csOrderAmount);

      /* Add the DataGridTableStyle instances to 
      the GridTableStylesCollection. */
      myDataGrid.TableStyles.Add(ts1);
      myDataGrid.TableStyles.Add(ts2);

     // Sets the TablesAlreadyAdded to true so this doesn't happen again.
     TablesAlreadyAdded=true;
   }

   private void button2_Click(object sender, System.EventArgs e)
   {
      BindingManagerBase bmGrid;
      bmGrid = BindingContext[myDataSet, "Customers"];
      MessageBox.Show("Current BindingManager Position: " + bmGrid.Position);
   }

   private void Grid_MouseUp(object sender, MouseEventArgs e)
   {
      // Create a HitTestInfo object using the HitTest method.

      // Get the DataGrid by casting sender.
      DataGrid myGrid = (DataGrid)sender;
      DataGrid.HitTestInfo myHitInfo = myGrid.HitTest(e.X, e.Y);
      Console.WriteLine(myHitInfo);
      Console.WriteLine(myHitInfo.Type);
      Console.WriteLine(myHitInfo.Row);
      Console.WriteLine(myHitInfo.Column);
   }

   // Create a DataSet with two tables and populate it.
   private void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = new DataSet("myDataSet");
      
      // Create two DataTables.
      DataTable tCust = new DataTable("Customers");
      DataTable tOrders = new DataTable("Orders");

      // Create two columns, and add them to the first table.
      DataColumn cCustID = new DataColumn("CustID", typeof(int));
      DataColumn cCustName = new DataColumn("CustName");
      DataColumn cCurrent = new DataColumn("Current", typeof(bool));
      tCust.Columns.Add(cCustID);
      tCust.Columns.Add(cCustName);
      tCust.Columns.Add(cCurrent);

      // Create three columns, and add them to the second table.
      DataColumn cID = 
      new DataColumn("CustID", typeof(int));
      DataColumn cOrderDate = 
      new DataColumn("orderDate",typeof(DateTime));
      DataColumn cOrderAmount = 
      new DataColumn("OrderAmount", typeof(decimal));
      tOrders.Columns.Add(cOrderAmount);
      tOrders.Columns.Add(cID);
      tOrders.Columns.Add(cOrderDate);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(tCust);
      myDataSet.Tables.Add(tOrders);

      // Create a DataRelation, and add it to the DataSet.
      DataRelation dr = new DataRelation
      ("custToOrders", cCustID , cID);
      myDataSet.Relations.Add(dr);
   
      /* Populates the tables. For each customer and order, 
      creates two DataRow variables. */
      DataRow newRow1;
      DataRow newRow2;

      // Create three customers in the Customers Table.
      for(int i = 1; i < 4; i++)
      {
         newRow1 = tCust.NewRow();
         newRow1["custID"] = i;
         // Add the row to the Customers table.
         tCust.Rows.Add(newRow1);
      }
      // Give each customer a distinct name.
      tCust.Rows[0]["custName"] = "Customer1";
      tCust.Rows[1]["custName"] = "Customer2";
      tCust.Rows[2]["custName"] = "Customer3";

      // Give the Current column a value.
      tCust.Rows[0]["Current"] = true;
      tCust.Rows[1]["Current"] = true;
      tCust.Rows[2]["Current"] = false;

      // For each customer, create five rows in the Orders table.
      for(int i = 1; i < 4; i++)
      {
         for(int j = 1; j < 6; j++)
         {
            newRow2 = tOrders.NewRow();
            newRow2["CustID"]= i;
            newRow2["orderDate"]= new DateTime(2001, i, j * 2);
            newRow2["OrderAmount"] = i * 10 + j  * .1;
            // Add the row to the Orders table.
            tOrders.Rows.Add(newRow2);
         }
      }
   }
}
// </Snippet1>
