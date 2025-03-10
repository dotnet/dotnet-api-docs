// <snippet100>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITypedListCS;

public partial class Form1 : Form
{
    SortableBindingList<Customer> sortableBindingListOfCustomers;
    BindingList<Customer> bindingListOfCustomers;

    readonly IContainer _components;
    FlowLayoutPanel flowLayoutPanel1;
    Label label2;
    DataGridView dataGridView1;
    Button button1;
    Button button2;

    public Form1() => InitializeComponent();

    void Form1_Load(object sender, EventArgs e)
    {
        sortableBindingListOfCustomers = [];
        bindingListOfCustomers = [];

        dataGridView1.DataSource = bindingListOfCustomers;
    }

    void button1_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = sortableBindingListOfCustomers;
    }

    void button2_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = bindingListOfCustomers;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
        {
            _components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    void InitializeComponent()
    {
        ComponentResourceManager resources = new(typeof(Form1));
        flowLayoutPanel1 = new FlowLayoutPanel();
        label2 = new Label();
        dataGridView1 = new DataGridView();
        button1 = new Button();
        button2 = new Button();
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
        flowLayoutPanel1.Size = new Size(566, 51);
        flowLayoutPanel1.TabIndex = 13;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(3, 6);
        label2.Margin = new Padding(3, 6, 3, 6);
        label2.Name = "label2";
        label2.Size = new Size(558, 39);
        label2.TabIndex = 0;
        label2.Text = "This sample demonstrates how to implement the ITypedList interface.  Clicking on the 'Sort Columns' button will bind the DataGridView to a sub-classed BindingList<T> that implements ITypedList to provide a sorted list of columns.  Clicking on the 'Reset' button will bind the DataGridView to a normal BindingList<T>.";
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.Anchor = AnchorStyles.Top
                               | AnchorStyles.Bottom
                               | AnchorStyles.Left
                               | AnchorStyles.Right;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(6, 57);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.Size = new Size(465, 51);
        dataGridView1.TabIndex = 14;
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button1.Location = new Point(477, 57);
        button1.Name = "button1";
        button1.Size = new Size(82, 23);
        button1.TabIndex = 15;
        button1.Text = "Sort Columns";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button2.Location = new Point(477, 86);
        button2.Name = "button2";
        button2.Size = new Size(82, 23);
        button2.TabIndex = 16;
        button2.Text = "Reset";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(566, 120);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(dataGridView1);
        Controls.Add(flowLayoutPanel1);
        Name = "Form1";
        Text = "ITypedList Sample";
        Load += Form1_Load;
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
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
// </snippet100>
