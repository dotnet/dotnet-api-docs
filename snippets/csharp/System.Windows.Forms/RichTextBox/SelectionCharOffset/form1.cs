﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RichTextBoxSelectionOffsetEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.RichTextBox richTextBox1;
      private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(8, 8);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(400, 168);
         this.richTextBox1.TabIndex = 0;
         this.richTextBox1.Text = "richTextBox1";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(312, 192);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(416, 382);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.richTextBox1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

      private void button1_Click(object sender, System.EventArgs e)
      {
         WriteOffsetTextToRichTextBox();
      }

		//<Snippet1>
		private void WriteOffsetTextToRichTextBox()
		{
			// Clear all text from the RichTextBox.
			richTextBox1.Clear();
			// Set the font for the text.
			richTextBox1.SelectionFont = new Font("Lucinda Console", 12);
			// Set the foreground color of the text.
			richTextBox1.SelectionColor = Color.Purple;
			// Set the baseline text.
			richTextBox1.SelectedText = "10";
			// Set the CharOffset to display superscript text.
			richTextBox1.SelectionCharOffset = 10;
			// Set the superscripted text.	
			richTextBox1.SelectedText = "2";
			// Reset the CharOffset to display text at the baseline.
			richTextBox1.SelectionCharOffset = 0;
			richTextBox1.AppendText("\n\n");
			// Change the forecolor of the next text selection.
			richTextBox1.SelectionColor = Color.Blue;
			// Set the baseline text.
			richTextBox1.SelectedText = "77";
			// Set the CharOffset to display subscript text.
			richTextBox1.SelectionCharOffset = -10;
			// Set the subscripted text.  
			richTextBox1.SelectedText = "3";
			// Reset the CharOffset to display text at the baseline.
			richTextBox1.SelectionCharOffset = 0; 
		}
		//</Snippet1>
   }
}
