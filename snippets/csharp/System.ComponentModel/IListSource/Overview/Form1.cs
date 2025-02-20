// <snippet1000>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IListSourceCS;

public class Form1 : Form
{
    Container components;
    FlowLayoutPanel flowLayoutPanel1;
    Label label2;
    DataGridView dataGridView1;
    DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn;
    DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    EmployeeListSource employeeListSource1;

    public Form1() => InitializeComponent();

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    void InitializeComponent()
    {
        components = new Container();
        DataGridViewCellStyle dataGridViewCellStyle1 = new();
        DataGridViewCellStyle dataGridViewCellStyle2 = new();
        flowLayoutPanel1 = new FlowLayoutPanel();
        label2 = new Label();
        dataGridView1 = new DataGridView();
        nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        salaryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        employeeListSource1 = new EmployeeListSource(components);
        flowLayoutPanel1.SuspendLayout();
        ((ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.AutoSize = true;
        flowLayoutPanel1.Controls.Add(label2);
        flowLayoutPanel1.Dock = DockStyle.Top;
        flowLayoutPanel1.Location = new Point(0, 0);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(416, 51);
        flowLayoutPanel1.TabIndex = 11;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(3, 6);
        label2.Margin = new Padding(3, 6, 3, 6);
        label2.Name = "label2";
        label2.Size = new Size(408, 39);
        label2.TabIndex = 0;
        label2.Text = "This sample demonstrates how to implement the IListSource interface.  In this sam" +
            "ple, a DataGridView is bound at design time to a Component (employeeListSource1)" +
            " that implements IListSource.";
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 255, 192);
        dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange([
        nameDataGridViewTextBoxColumn,
        salaryDataGridViewTextBoxColumn,
        iDDataGridViewTextBoxColumn]);
        dataGridView1.DataSource = employeeListSource1;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 51);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.Size = new Size(416, 215);
        dataGridView1.TabIndex = 12;
        // 
        // nameDataGridViewTextBoxColumn
        // 
        nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
        nameDataGridViewTextBoxColumn.FillWeight = 131.7987F;
        nameDataGridViewTextBoxColumn.HeaderText = "Name";
        nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
        // 
        // salaryDataGridViewTextBoxColumn
        // 
        salaryDataGridViewTextBoxColumn.DataPropertyName = "ParkingID";
        salaryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
        salaryDataGridViewTextBoxColumn.FillWeight = 121.8274F;
        salaryDataGridViewTextBoxColumn.HeaderText = "Parking ID";
        salaryDataGridViewTextBoxColumn.Name = "salaryDataGridViewTextBoxColumn";
        // 
        // iDDataGridViewTextBoxColumn
        // 
        iDDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
        iDDataGridViewTextBoxColumn.FillWeight = 46.37391F;
        iDDataGridViewTextBoxColumn.HeaderText = "ID";
        iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
        iDDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(416, 266);
        Controls.Add(dataGridView1);
        Controls.Add(flowLayoutPanel1);
        Name = "Form1";
        Text = "IListSource Sample";
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        ((ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
// </snippet1000>
