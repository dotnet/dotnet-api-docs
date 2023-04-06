﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RemoveMenuItemCS1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
			InitializeMyMenu();

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
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 276);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		// <snippet1>
		public void InitializeMyMenu()
		{
			// Create the MainMenu object.
			MainMenu myMainMenu = new MainMenu();
	
			// Create the MenuItem objects.
			MenuItem fileMenu = new MenuItem("&File");
			MenuItem editMenu = new MenuItem("&Edit");
			MenuItem newFile = new MenuItem("&New");
			MenuItem openFile = new MenuItem("&Open");
			MenuItem exitProgram = new MenuItem("E&xit");
	
			// Add the MenuItem objects to myMainMenu.
			myMainMenu.MenuItems.Add(fileMenu);
			myMainMenu.MenuItems.Add(editMenu);
		
			// Add three submenus to the File menu.
			fileMenu.MenuItems.Add(newFile);
			fileMenu.MenuItems.Add(openFile);
			fileMenu.MenuItems.Add(exitProgram);
		
			// Assign myMainMenu to the form.
			Menu = myMainMenu;
		
			// Remove the item "Open" from the File menu.
			fileMenu.MenuItems.Remove(openFile);
		}
		// </snippet1>

		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}
	}
}
