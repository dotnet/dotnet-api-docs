//<Snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication10;

public class Form1 : Form
{
    ToolStripButton toolStripButton1;
    ToolStripButton toolStripButton2;
    ToolStripButton toolStripButton3;
    ContextMenuStrip contextMenuStrip1;
    IContainer components;
    ToolStripMenuItem toolStripMenuItem1;
    ToolStripMenuItem toolStripMenuItem2;
    ContextMenuStrip contextMenuStrip2;
    ToolStripMenuItem rearrangeButtonsToolStripMenuItem;
    ToolStripMenuItem selectIconsToolStripMenuItem;
    ToolStrip toolStrip1;

    public Form1() => InitializeComponent();
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    void InitializeComponent()
    {
        components = new Container();
        ComponentResourceManager resources = new(typeof(Form1));
        toolStrip1 = new ToolStrip();
        toolStripButton1 = new ToolStripButton();
        toolStripButton2 = new ToolStripButton();
        toolStripButton3 = new ToolStripButton();
        contextMenuStrip1 = new ContextMenuStrip(components);
        contextMenuStrip2 = new ContextMenuStrip(components);
        toolStripMenuItem1 = new ToolStripMenuItem();
        toolStripMenuItem2 = new ToolStripMenuItem();
        rearrangeButtonsToolStripMenuItem = new ToolStripMenuItem();
        selectIconsToolStripMenuItem = new ToolStripMenuItem();
        toolStrip1.SuspendLayout();
        contextMenuStrip1.SuspendLayout();
        contextMenuStrip2.SuspendLayout();
        SuspendLayout();
        //
        // <Snippet2> 
        // Associate contextMenuStrip2 with toolStrip1.
        // toolStrip1 property settings follow.
        //
        toolStrip1.ContextMenuStrip = contextMenuStrip2;
        toolStrip1.Items.AddRange(
        [
            toolStripButton1,
            toolStripButton2,
            toolStripButton3
        ]);
        toolStrip1.Location = new Point(0, 0);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new Size(292, 25);
        toolStrip1.TabIndex = 0;
        toolStrip1.Text = "toolStrip1";
        // </Snippet2>
        // 
        // toolStripButton1
        // 
        toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
        toolStripButton1.ImageTransparentColor = Color.Magenta;
        toolStripButton1.Name = "toolStripButton1";
        toolStripButton1.Text = "toolStripButton1";
        // 
        // toolStripButton2
        // 
        toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
        toolStripButton2.ImageTransparentColor = Color.Magenta;
        toolStripButton2.Name = "toolStripButton2";
        toolStripButton2.Text = "toolStripButton2";
        // 
        // toolStripButton3
        // 
        toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
        toolStripButton3.ImageTransparentColor = Color.Magenta;
        toolStripButton3.Name = "toolStripButton3";
        toolStripButton3.Text = "toolStripButton3";
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Items.AddRange([
        toolStripMenuItem1,
        toolStripMenuItem2]);
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.RightToLeft = RightToLeft.No;
        contextMenuStrip1.Size = new Size(131, 48);
        // 
        // contextMenuStrip2
        // 
        contextMenuStrip2.Items.AddRange([
        rearrangeButtonsToolStripMenuItem,
        selectIconsToolStripMenuItem]);
        contextMenuStrip2.Name = "contextMenuStrip2";
        contextMenuStrip2.RightToLeft = RightToLeft.No;
        contextMenuStrip2.Size = new Size(162, 48);
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Text = "&Resize";
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Text = "&Keep on Top";
        // 
        // rearrangeButtonsToolStripMenuItem
        // 
        rearrangeButtonsToolStripMenuItem.Name = "rearrangeButtonsToolStripMenuItem";
        rearrangeButtonsToolStripMenuItem.Text = "R&earrange Buttons";
        // 
        // selectIconsToolStripMenuItem
        // 
        selectIconsToolStripMenuItem.Name = "selectIconsToolStripMenuItem";
        selectIconsToolStripMenuItem.Text = "&Select Icons";
        // 
        // <Snippet3> 
        // Associate contextMenuStrip1 with Form1.
        // Form1 property settings follow.
        //
        ClientSize = new Size(292, 266);
        ContextMenuStrip = contextMenuStrip1;
        Controls.Add(toolStrip1);
        Name = "Form1";
        toolStrip1.ResumeLayout(false);
        contextMenuStrip1.ResumeLayout(false);
        contextMenuStrip2.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
        // </Snippet3>
    }
}
//</Snippet1>
