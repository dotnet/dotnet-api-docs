using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

class Form1 : Form
{
    private Button button1 = new Button();
    public Form1()
    {
        //InitializeComponent();
        Controls.Add(button1);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
    // <snippet4>
    private Image GetImageOfCustomControl(Control userControl)
    {
        Image controlImage = null;
        AttributeCollection attrCol =
                TypeDescriptor.GetAttributes(userControl);
        ToolboxBitmapAttribute imageAttr = (ToolboxBitmapAttribute)
            attrCol[typeof(ToolboxBitmapAttribute)];
        if (imageAttr != null)
        {
            controlImage = imageAttr.GetImage(userControl);
        }

        return controlImage;
    }
    // </snippet4>
}

// The following code example demonstrates how to use the 
// ToolBoxBitmapAttribute#ctor(string) costructor to set stop.bmp as the
// toolbox icon for the StopSignControl. This example assumes
// the existence of a 16-by-16-pixel bitmap named stop.bmp at c:\.
//<snippet1>
[System.Drawing.ToolboxBitmap("c:\\stop.bmp")]
public class StopSignControl :
    System.Windows.Forms.UserControl

{
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button Button1;

    public StopSignControl() : base()
    {
        Label1 = new System.Windows.Forms.Label();
        Button1 = new System.Windows.Forms.Button();

        Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));

        Label1.ForeColor = System.Drawing.Color.Red;
        Label1.Location = new System.Drawing.Point(24, 56);
        Label1.Name = "Label1";
        Label1.TabIndex = 0;
        Label1.Text = "Stop!";
        Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        Button1.Enabled = false;
        Button1.Location = new System.Drawing.Point(56, 88);
        Button1.Name = "Button1";
        Button1.Size = new System.Drawing.Size(40, 32);
        Button1.TabIndex = 1;
        Button1.Text = "stop";

        Controls.Add(Button1);
        Controls.Add(Label1);
        Name = "StopSignControl";
    }

    private void StopSignControl_MouseEnter(object sender, System.EventArgs e)
    {

        Label1.Text.ToUpper();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 14.0F,
        System.Drawing.FontStyle.Bold);
        Button1.Enabled = true;
    }

    private void StopSignControl_MouseLeave(object sender, System.EventArgs e)
    {

        Label1.Text.ToLower();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 12.0F,
        System.Drawing.FontStyle.Regular);
        Button1.Enabled = false;
    }
}
//</snippet1>

// The following code example demonstrates how to use the 
// ToolBoxBitmapAttribute#ctor(type, string) constructor to set StopSignControl2.bmp as a toolbox
// icon for the StopSignControl. This example assumes
// the existence of a 16-by-16-pixel bitmap named StopSignControl2.bmp with its 
// BuildAction property set to EmbeddedResource.
//<snippet2>
[System.Drawing.ToolboxBitmap(typeof(StopSignControl2), "StopSignControl2.bmp")]
public class StopSignControl2 :
    System.Windows.Forms.UserControl

{
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button Button1;

    public StopSignControl2() : base()
    {
        Label1 = new System.Windows.Forms.Label();
        Button1 = new System.Windows.Forms.Button();

        Label1.Font = new System.Drawing.Font("Microsoft Sans Serif",
            12.0F, System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, ((byte)0));
        Label1.ForeColor = System.Drawing.Color.Red;
        Label1.Location = new System.Drawing.Point(24, 56);
        Label1.Name = "Label1";
        Label1.TabIndex = 0;
        Label1.Text = "Stop!";
        Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        Button1.Enabled = false;
        Button1.Location = new System.Drawing.Point(56, 88);
        Button1.Name = "Button1";
        Button1.Size = new System.Drawing.Size(40, 32);
        Button1.TabIndex = 1;
        Button1.Text = "stop";
        Controls.Add(Button1);
        Controls.Add(Label1);
        Name = "StopSignControl";
    }

    private void StopSignControl_MouseEnter(object sender, System.EventArgs e)
    {
        Label1.Text.ToUpper();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 14.0F,
            System.Drawing.FontStyle.Bold);
        Button1.Enabled = true;
    }

    private void StopSignControl_MouseLeave(object sender, System.EventArgs e)
    {

        Label1.Text.ToLower();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 12.0F,
        System.Drawing.FontStyle.Regular);
        Button1.Enabled = false;
    }
}
//</snippet2>

// The following code example demonstrates how to use the 
// ToolBoxBitmapAttribute#ctor(type) constructor to set the icon of the button control
// to the toolbox icon for a UserControl named StopSignControl3. 
//<snippet3>
[System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.Button))]
public class StopSignControl3 :
    System.Windows.Forms.UserControl

{
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button Button1;

    public StopSignControl3() : base()
    {
        Label1 = new System.Windows.Forms.Label();
        Button1 = new System.Windows.Forms.Button();

        Label1.Font = new System.Drawing.Font("Microsoft Sans Serif",
            12.0F, System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, ((byte)0));
        Label1.ForeColor = System.Drawing.Color.Red;
        Label1.Location = new System.Drawing.Point(24, 56);
        Label1.Name = "Label1";
        Label1.TabIndex = 0;
        Label1.Text = "Stop!";
        Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        Button1.Enabled = false;
        Button1.Location = new System.Drawing.Point(56, 88);
        Button1.Name = "Button1";
        Button1.Size = new System.Drawing.Size(40, 32);
        Button1.TabIndex = 1;
        Button1.Text = "stop";
        Controls.Add(Button1);
        Controls.Add(Label1);
        Name = "StopSignControl";
    }

    private void StopSignControl_MouseEnter(object sender, System.EventArgs e)
    {
        Label1.Text.ToUpper();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily,
        14.0F, System.Drawing.FontStyle.Bold);
        Button1.Enabled = true;
    }

    private void StopSignControl_MouseLeave(object sender, System.EventArgs e)
    {
        Label1.Text.ToLower();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily,
        12.0F, System.Drawing.FontStyle.Regular);
        Button1.Enabled = false;
    }
}
//</snippet3>
