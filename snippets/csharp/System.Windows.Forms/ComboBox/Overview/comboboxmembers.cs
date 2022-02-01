﻿using System;
using System.Windows.Forms;

namespace Win32Form1Namespace {

    public class Win32Form1 : System.Windows.Forms.Form {
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button addGrandButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button showSelectedButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Label label1;
        
        public Win32Form1() {
            this.InitializeComponent();
        }
        
        [System.STAThreadAttribute()]
        public static void Main() {
            System.Windows.Forms.Application.Run(new Win32Form1());
        }
        
        private void InitializeComponent() {
            this.addButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.addGrandButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.showSelectedButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton.Location = new System.Drawing.Point(248, 32);
            this.addButton.Size = new System.Drawing.Size(40, 24);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            this.textBox2.Location = new System.Drawing.Point(8, 64);
            this.textBox2.Size = new System.Drawing.Size(232, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "";
            this.addGrandButton.Location = new System.Drawing.Point(8, 96);
            this.addGrandButton.Size = new System.Drawing.Size(280, 23);
            this.addGrandButton.TabIndex = 2;
            this.addGrandButton.Text = "Add 1,000 Items";
            this.addGrandButton.Click += new System.EventHandler(this.addGrandButton_Click);
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right);
            this.comboBox1.DropDownWidth = 280;
            this.comboBox1.Items.AddRange(new object[] {"Item 1",
                        "Item 2",
                        "Item 3",
                        "Item 4",
                        "Item 5"});
            this.comboBox1.Location = new System.Drawing.Point(8, 248);
            this.comboBox1.Size = new System.Drawing.Size(280, 21);
            this.comboBox1.TabIndex = 7;
            this.showSelectedButton.Location = new System.Drawing.Point(8, 128);
            this.showSelectedButton.Size = new System.Drawing.Size(280, 24);
            this.showSelectedButton.TabIndex = 4;
            this.showSelectedButton.Text = "What Item is Selected?";
            this.showSelectedButton.Click += new System.EventHandler(this.showSelectedButton_Click);
            this.textBox1.Location = new System.Drawing.Point(8, 32);
            this.textBox1.Size = new System.Drawing.Size(232, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "";
            this.findButton.Location = new System.Drawing.Point(248, 64);
            this.findButton.Size = new System.Drawing.Size(40, 24);
            this.findButton.TabIndex = 3;
            this.findButton.Text = "Find";
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            this.label1.Location = new System.Drawing.Point(8, 224);
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test ComboBox";
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.comboBox1,
                        this.textBox2,
                        this.textBox1,
                        this.showSelectedButton,
                        this.findButton,
                        this.addGrandButton,
                        this.addButton,
                        this.label1});
            this.Text = "ComboBox Sample";
        }
//<Snippet2>        
        private void addButton_Click(object sender, System.EventArgs e) {
           comboBox1.Items.Add(textBox1.Text);
        }
//</Snippet2>

//<Snippet3>
        private void addGrandButton_Click(object sender, System.EventArgs e) {
            comboBox1.BeginUpdate();
            for (int i = 0; i < 1000; i++) {
                comboBox1.Items.Add("New Item " + i.ToString());
            }
            comboBox1.EndUpdate();
        }
//</Snippet3>

//<Snippet4>
        private void findButton_Click(object sender, System.EventArgs e) {
            int index = comboBox1.FindString(textBox2.Text);
            comboBox1.SelectedIndex = index;
        }
//</Snippet4>

//<Snippet5>
        private void showSelectedButton_Click(object sender, System.EventArgs e) {
            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;

            MessageBox.Show("Selected Item Text: " + selectedItem.ToString() + "\n" +
                            "Index: " + selectedIndex.ToString());
        }
//</Snippet5>
    }
}
