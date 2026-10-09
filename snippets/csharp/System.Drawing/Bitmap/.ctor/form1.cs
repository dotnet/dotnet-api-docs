using System;
using System.Drawing;
using System.Windows.Forms;

public class BitmapConstructorForm1 : Form

{
    public BitmapConstructorForm1() : base()
    {
        // This call is required by the Windows Form Designer.
        InitializeComponent();
        Button1.Click += new EventHandler(Button1_Click);
        Button2.Click += new EventHandler(Button2_Click);

        string filePath = "path//to//your//image.bmp";
        InitializeBitmap(filePath);
        InitializeStreamBitmap();

        // Add any initialization after the InitializeComponent() call.
    }

    // Form overrides Dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    // Required by the Windows Form Designer.
    private System.ComponentModel.IContainer components = null;

    // NOTE: The following procedure is required by the Windows Form Designer.
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    internal Button Button1;
    internal PictureBox PictureBox1;
    internal Button Button2;

    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
        Button1 = new Button();
        PictureBox1 = new PictureBox();
        Button2 = new Button();
        SuspendLayout();
        // 
        // Button1
        // 
        Button1.Location = new Point(24, 192);
        Button1.Name = "Button1";
        Button1.Size = new Size(96, 23);
        Button1.TabIndex = 2;
        Button1.Text = "Rotate and Flip";
        // 
        // PictureBox1
        // 
        PictureBox1.Location = new Point(48, 40);
        PictureBox1.Name = "PictureBox1";
        PictureBox1.Size = new Size(168, 72);
        PictureBox1.TabIndex = 3;
        PictureBox1.TabStop = false;
        // 
        // Button2
        // 
        Button2.Location = new Point(152, 192);
        Button2.Name = "Button2";
        Button2.TabIndex = 4;
        Button2.Text = "Button2";
        // 
        // Form1
        // 
        ClientSize = new Size(292, 266);
        Controls.Add(Button2);
        Controls.Add(PictureBox1);
        Controls.Add(Button1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    // <snippet3Intro>
    // The following code example demonstrates constructing how to construct 
    // a new Bitmap from a file.

    // This example is designed to be used with a Windows Forms that contains
    // a PictureBox named PictureBox1. 
    // 
    // Paste the code into a form and call InitializeBitmap from the form's
    // constructor or Load method.

    // </snippet3Intro>

    // <snippet4Intro>
    // The following code example demonstrates how to set the RotateFlip 
    // property of a Bitmap.  

    // This example is designed to be used with a Windows form that contains
    // a PictureBox named PictureBox1 and a button named Button1. 
    // Paste the code to a form, call InitializeBitmap from the form's
    // constructor or Load method and associate Button1_Click with the button's
    // click event. Ensure the filepath to the bitmap is valid on 
    // your system.
    // </snippet4Intro>

    //<snippet3>
    //<snippet4>
    Bitmap bitmap1;

    private void InitializeBitmap(string filePath)
    {
        try
        {
            bitmap1 = (Bitmap)Bitmap.FromFile(filePath);
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBox1.Image = bitmap1;
        }
        catch (System.IO.FileNotFoundException)
        {
            MessageBox.Show("There was an error. Check the path to the bitmap.");
        }
    }
    //</snippet4>

    private void Button1_Click(object sender, EventArgs e)
    {

        if (bitmap1 != null)
        {
            bitmap1.RotateFlip(RotateFlipType.Rotate180FlipY);
            PictureBox1.Image = bitmap1;
        }
    }
    //</snippet3>

    // The following code example demonstrates how to load a bitmap 
    // from an Icon handle, using the GraphicsUnit enumeration, and the  
    // the use of the RectangleF.Round method to draw the rectangle 
    // bounds of an icon.

    // This example is designed to be used with Windows Forms. Create
    // a form that contains a button named Button2. Paste the code into the
    // form and associate this method with the button's Click event.
    //<snippet1>
    private void Button2_Click(object sender, EventArgs e)
    {
        Bitmap bitmap1 = Bitmap.FromHicon(SystemIcons.Hand.Handle);
        Graphics formGraphics = CreateGraphics();
        GraphicsUnit units = GraphicsUnit.Point;

        RectangleF bmpRectangleF = bitmap1.GetBounds(ref units);
        Rectangle bmpRectangle = Rectangle.Round(bmpRectangleF);
        formGraphics.DrawRectangle(Pens.Blue, bmpRectangle);
        formGraphics.Dispose();
    }
    //</snippet1>

    // The following code example demonstrates how to load a bitmap 
    // from a stream.

    // This example is designed to be used with Windows Forms. Create
    // a form that contains a PictureBox named PictureBox1. Paste the code 
    // into the form and call InitializeStreamBitmap from the form's
    // constructor or Load method.
    //<snippet2>
    private void InitializeStreamBitmap()
    {
        try
        {
            using System.Net.Http.HttpClient client = new();
            using System.Net.Http.HttpResponseMessage response =
                client.GetAsync("http://www.microsoft.com//h/en-us/r/ms_masthead_ltr.gif")
                .GetAwaiter()
                .GetResult();
            response.EnsureSuccessStatusCode();
            using System.IO.Stream responseStream =
                response.Content.ReadAsStreamAsync()
                .GetAwaiter()
                .GetResult();
            Bitmap bitmap2 = new(responseStream);
            PictureBox1.Image = bitmap2;
        }
        catch (System.Net.Http.HttpRequestException)
        {
            MessageBox.Show("There was an error opening the image file. Check the URL");
        }
    }
    //</snippet2>

    // The following code example demonstrates how to use the Image.PixelFormat,
    // Image.Height, Image.Width, and BitmapData.Scan0 properties; the Bitmap.LockBits 
    // and Bitmap.UnlockBits methods; and the ImageLockMode enumeration. 
    // This example is designed to be used with Windows
    // Forms. To run this example, paste it into a form and handle the form's Paint event by
    // calling the LockUnlockBitsExample method, passing e as PaintEventArgs. 
    // This example assumes the existence of an 24bpp image file named fakePhoto.jpg at c:\.

    //<snippet5>
    private static void LockUnlockBitsExample(PaintEventArgs e)
    {
        // Create a new bitmap.
        Bitmap bmp = new("c:\\fakePhoto.jpg");

        // Lock the bitmap's bits.
        Rectangle rect = new(0, 0, bmp.Width, bmp.Height);
        System.Drawing.Imaging.BitmapData bmpData =
            bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            bmp.PixelFormat);

        // Get the address of the first line.
        IntPtr ptr = bmpData.Scan0;

        // Declare an array to hold the bytes of the bitmap.
        int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
        byte[] rgbValues = new byte[bytes];

        // Copy the RGB values into the array.
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

        // Set every third value to 255. A 24bpp bitmap will look red.
        for (int counter = 2; counter < rgbValues.Length; counter += 3)
        {
            rgbValues[counter] = 255;
        }

        // Copy the RGB values back to the bitmap
        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

        // Unlock the bits.
        bmp.UnlockBits(bmpData);

        // Draw the modified image.
        e.Graphics.DrawImage(bmp, 0, 150);
    }

    //</snippet5>

    public static void Run()
    {
        Application.Run(new BitmapConstructorForm1());
    }
}
