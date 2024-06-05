﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FormSizeEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(176, 56);
         this.button1.Name = "button1";
         this.button1.TabIndex = 0;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1});
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
         CreateMyOpaqueForm();
      }

      //<Snippet1>
      private void CreateMyOpaqueForm()
      {
         // Create a new form.
         Form form2 = new Form();
         // Set the text displayed in the caption.
         form2.Text = "My Form";
         // Set the opacity to 75%.
         form2.Opacity = .75;
         // Size the form to be 300 pixels in height and width.
         form2.Size = new Size(300,300);
         // Display the form in the center of the screen.
         form2.StartPosition = FormStartPosition.CenterScreen;

         // Display the form as a modal dialog box.
         form2.ShowDialog();
      }
      //</Snippet1>
	}
}
