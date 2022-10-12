﻿// System.Windows.Forms.DataGridTableStyle.ColumnHeadersVisible;
// System.Windows.Forms.DataGridTableStyle.ColumnHeadersVisibleChanged;

/* The following example demonstrates the property 'ColumnHeadersVisible'
   and event 'ColumnHeadersVisibleChanged' of DataGridTableStyle.
   The following program creates a Windows form, a DataSet containing two DataTable objects,
   and a DataRelation that relates the two tables. A button on the form changes the appearance
   of column headers on the grid.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SampleDataGridTableStyle
{
   public class DataGridTableStyle_Sample : System.Windows.Forms.Form
   {
      private System.Windows.Forms.DataGrid myDataGrid;
      private System.Windows.Forms.DataGridTableStyle myDataGridTableStyle1;
      private DataSet myDataSet;
      private System.Windows.Forms.Button btnheader;
      private System.Windows.Forms.Label myHeaderLabel;
      private System.ComponentModel.Container components = null;

      public DataGridTableStyle_Sample()
      {
         InitializeComponent();
         // Call SetUp to bind the controls.
         SetUp();
      }
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if (components != null) 
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.myHeaderLabel = new System.Windows.Forms.Label();
         this.btnheader = new System.Windows.Forms.Button();
         this.myDataGrid = new System.Windows.Forms.DataGrid();
         ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // myHeaderLabel
         // 
         this.myHeaderLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.myHeaderLabel.Location = new System.Drawing.Point(48, 216);
         this.myHeaderLabel.Name = "myHeaderLabel";
         this.myHeaderLabel.Size = new System.Drawing.Size(160, 23);
         this.myHeaderLabel.TabIndex = 2;
         this.myHeaderLabel.Text = "Header Status";
         // 
         // btnheader
         // 
         this.btnheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.btnheader.Location = new System.Drawing.Point(216, 200);
         this.btnheader.Name = "btnheader";
         this.btnheader.Size = new System.Drawing.Size(144, 40);
         this.btnheader.TabIndex = 1;
         this.btnheader.Text = "Remove Header";
         this.btnheader.Click += new System.EventHandler(this.btnheader_Click);
         // 
         // myDataGrid
         // 
         this.myDataGrid.CaptionText = "Microsoft DataGrid Control";
         this.myDataGrid.DataMember = "";
         this.myDataGrid.LinkColor = System.Drawing.Color.Gray;
         this.myDataGrid.Location = new System.Drawing.Point(48, 32);
         this.myDataGrid.Name = "myDataGrid";
         this.myDataGrid.SelectionBackColor = System.Drawing.SystemColors.Window;
         this.myDataGrid.Size = new System.Drawing.Size(312, 128);
         this.myDataGrid.TabIndex = 0;
         // 
         // DataGridTableStyle_Sample
         // 
         this.ClientSize = new System.Drawing.Size(416, 277);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.btnheader,
                                                                      this.myHeaderLabel,
                                                                      this.myDataGrid});
         this.Name = "DataGridTableStyle_Sample";
         this.Text = "DataGridTableStyle_Sample";
         this.Load += new System.EventHandler(this.DataGridTableStyle_Sample_Load);
         ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).EndInit();
         this.ResumeLayout(false);
      }
      #endregion

      [STAThread]
      static void Main() 
      {   
         Application.Run(new DataGridTableStyle_Sample());
      }      
      private void SetUp()
      {
         // Create a DataSet with two tables and one relation.
         MakeDataSet();
         // Bind the DataGrid to the DataSet.
         myDataGrid.SetDataBinding(myDataSet, "Customers");
      }

      // Create a DataSet with two tables and populate it.
      private void MakeDataSet()
      {
         // Create a DataSet.
         myDataSet = new DataSet("myDataSet");
      
         // Create Customer DataTables.
         DataTable tCust = new DataTable("Customers");
         // Create two columns, and add them to the first table.
         DataColumn cCustID = new DataColumn("CustID", typeof(int));
         DataColumn cCustName = new DataColumn("CustName");
         DataColumn cCurrent = new DataColumn("Current", typeof(bool));
         tCust.Columns.Add(cCustID);
         tCust.Columns.Add(cCustName);
         tCust.Columns.Add(cCurrent);

         // Create Customer order table.
         DataTable tOrders = new DataTable("Orders");
         // Create three columns, and add them to the second table.
         DataColumn cID = new DataColumn("CustID", typeof(int));
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
   
         // Populate the tables. 
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
         tCust.Rows[0]["custName"] = "Alpha";
         tCust.Rows[1]["custName"] = "Beta";
         tCust.Rows[2]["custName"] = "Gamma";

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
               // Add row to the Orders table.
               tOrders.Rows.Add(newRow2);
            }
         }
      }

// <Snippet1>
// <Snippet2>

      private void DataGridTableStyle_Sample_Load(object sender,
                                                EventArgs e)
      {
         myDataGridTableStyle1 = new DataGridTableStyle();
         myHeaderLabel.Text = "Header Status :" 
            + myDataGridTableStyle1.ColumnHeadersVisible.ToString();
         if(myDataGridTableStyle1.ColumnHeadersVisible == true)
         {
            btnheader.Text = "Remove Header";
         }
         else
         {
            btnheader.Text = "Add Header";
         }
         AddCustomDataTableStyle();
      } 
      private void AddCustomDataTableStyle()
      {           
         myDataGridTableStyle1.ColumnHeadersVisibleChanged 
            += new System.EventHandler(ColumnHeadersVisibleChanged_Handler);

         // Set ColumnheaderVisible property.         
         myDataGridTableStyle1.MappingName = "Customers";

         // Add a GridColumnStyle and set its MappingName 
         DataGridColumnStyle myBoolCol = new DataGridBoolColumn();
         myBoolCol.MappingName = "Current";
         myBoolCol.HeaderText = "IsCurrent Customer";
         myBoolCol.Width = 150;         
         myDataGridTableStyle1.GridColumnStyles.Add(myBoolCol);
      
         // Add a second column style.
         DataGridColumnStyle myTextCol = new DataGridTextBoxColumn();
         myTextCol.MappingName = "custName";
         myTextCol.HeaderText = "Customer Name";
         myTextCol.Width = 250;
         myDataGridTableStyle1.GridColumnStyles.Add(myTextCol);

         // Create new ColumnStyle objects
         DataGridColumnStyle cOrderDate = new DataGridTextBoxColumn();
         cOrderDate.MappingName = "OrderDate";
         cOrderDate.HeaderText = "Order Date";
         cOrderDate.Width = 100;

         // PropertyDescriptor to create a formatted column.
         PropertyDescriptorCollection myPropertyDescriptorCollection = this.BindingContext
            [myDataSet, "Customers.custToOrders"].GetItemProperties();
 
         // Create a formatted column using a PropertyDescriptor.         
         DataGridColumnStyle csOrderAmount = 
            new DataGridTextBoxColumn(myPropertyDescriptorCollection["OrderAmount"], "c", true);
         csOrderAmount.MappingName = "OrderAmount";
         csOrderAmount.HeaderText = "Total";
         csOrderAmount.Width = 100;

         // Add the DataGridTableStyle instances to GridTableStylesCollection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1);              
      }          
      private void ColumnHeadersVisibleChanged_Handler(object sender,
                                                            EventArgs e)
      {         
         myHeaderLabel.Text = "Header Status :" 
            + myDataGridTableStyle1.ColumnHeadersVisible.ToString();
      }      
      private void btnheader_Click(object sender, EventArgs e)
      {
         if(myDataGridTableStyle1.ColumnHeadersVisible == true)
         {            
            myDataGridTableStyle1.ColumnHeadersVisible = false;
            btnheader.Text = "Add Header";
         }
         else
         {
            myDataGridTableStyle1.ColumnHeadersVisible = true;
            btnheader.Text = "Remove Header";
         }         
     }     
// </Snippet2>
// </Snippet1>
   }
}
