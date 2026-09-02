using System;
using System.Drawing;
using System.Windows.Forms;

public class BitmapConstructorForm11 :
    System.Windows.Forms.Form

{
    #region " Windows Form Designer generated code "

    public BitmapConstructorForm11() : base()
    {

        //This call is required by the Windows Form Designer.
        InitializeComponent();

        //Add any initialization after the InitializeComponent() call
    }

    //Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components = null;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
        // 
        // Form1
        // 
        ClientSize = new System.Drawing.Size(292, 266);
        Name = "Form1";
        Text = "Form1";
        Paint += new System.Windows.Forms.PaintEventHandler(Form1_Paint);
    }

    #endregion

    //<snippet1>
    private void ConstructFromResourceSaveAsGif(PaintEventArgs e)
    {

        // Construct a bitmap from the button image resource.
        Bitmap bmp1 = new Bitmap(typeof(Button), "Button.bmp");

        // Save the image as a GIF.
        bmp1.Save("c:\\button.gif", System.Drawing.Imaging.ImageFormat.Gif);

        // Construct a new image from the GIF file.
        Bitmap bmp2 = new Bitmap("c:\\button.gif");

        // Draw the two images.
        e.Graphics.DrawImage(bmp1, new Point(10, 10));
        e.Graphics.DrawImage(bmp2, new Point(10, 40));

        // Dispose of the image files.
        bmp1.Dispose();
        bmp2.Dispose();
    }
    //</snippet1>

    public static void Run()
    {
        Application.Run(new BitmapConstructorForm11());
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        ConstructFromResourceSaveAsGif(e);
    }
}
