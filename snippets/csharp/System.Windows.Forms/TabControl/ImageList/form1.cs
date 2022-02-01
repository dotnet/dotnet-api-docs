﻿// <snippet1>
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;

public class Form1 : Form
{
    public Form1()
    {
        IContainer components = new Container();
        ResourceManager resources = new ResourceManager(typeof(Form1));
        TabControl tabControl1 = new TabControl();
        TabPage tabPage1 = new TabPage();

        // Declares and instantiates the ImageList object.
        ImageList myImages = new ImageList(components);

        tabControl1.Controls.Add(tabPage1);
        // Sets the images in myImages to display on the tabs of tabControl1. 
        tabControl1.ImageList = myImages;
 
        tabPage1.ImageIndex = 0;
        tabPage1.Text = "tabPage1";

        // Gets the handle that provides the data of myImages.
        myImages.ImageStream = ((ImageListStreamer)(resources.GetObject("myImages.ImageStream")));
    
        // Sets properties of myImages. 
        myImages.ColorDepth = ColorDepth.Depth8Bit;
        myImages.ImageSize = new Size(16, 16);
        myImages.TransparentColor = Color.Transparent;

        this.Controls.Add(tabControl1);
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>