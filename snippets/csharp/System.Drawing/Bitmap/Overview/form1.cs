using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

public class Form1 :
    System.Windows.Forms.Form

{
    #region " Windows Form Designer generated code "

    public Form1() : base()
    {

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        Button1.Click += new EventHandler(Button1_Click);
        Button2.Click += new EventHandler(Button2_Click);
        Button3.Click += new EventHandler(Button3_Click);
        Button4.Click += new EventHandler(Button4_Click);
        Button5.Click += new EventHandler(Button5_Click);

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
    private System.ComponentModel.IContainer components;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    internal System.Windows.Forms.PictureBox PictureBox1;
    internal System.Windows.Forms.Button Button1;
    internal System.Windows.Forms.Button Button2;
    internal System.Windows.Forms.Button Button3;
    internal System.Windows.Forms.Button Button4;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button Button5;
    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
        PictureBox1 = new System.Windows.Forms.PictureBox();
        Button1 = new System.Windows.Forms.Button();
        Button2 = new System.Windows.Forms.Button();
        Button3 = new System.Windows.Forms.Button();
        Button4 = new System.Windows.Forms.Button();
        Label1 = new System.Windows.Forms.Label();
        Button5 = new System.Windows.Forms.Button();
        SuspendLayout();
        //
        //PictureBox1
        //
        PictureBox1.Location = new System.Drawing.Point(24, 8);
        PictureBox1.Name = "PictureBox1";
        PictureBox1.Size = new System.Drawing.Size(100, 88);
        PictureBox1.TabIndex = 0;
        PictureBox1.TabStop = false;
        //
        //Button1
        //
        Button1.Location = new System.Drawing.Point(192, 8);
        Button1.Name = "Button1";
        Button1.TabIndex = 2;
        Button1.Text = "Button1";
        //
        //Button2
        //
        Button2.Location = new System.Drawing.Point(192, 40);
        Button2.Name = "Button2";
        Button2.TabIndex = 3;
        Button2.Text = "Button2";
        //
        //Button3
        //
        Button3.Location = new System.Drawing.Point(192, 72);
        Button3.Name = "Button3";
        Button3.TabIndex = 4;
        Button3.Text = "Button3";
        //
        //Button4
        //
        Button4.Location = new System.Drawing.Point(192, 104);
        Button4.Name = "Button4";
        Button4.TabIndex = 5;
        Button4.Text = "Button4";
        //
        //Label1
        //
        Label1.Location = new System.Drawing.Point(24, 72);
        Label1.Name = "Label1";
        Label1.Size = new System.Drawing.Size(152, 32);
        Label1.TabIndex = 6;
        Label1.Text = "Label1";
        //
        //Button5
        //
        Button5.Location = new System.Drawing.Point(200, 136);
        Button5.Name = "Button5";
        Button5.TabIndex = 7;
        Button5.Text = "Button5";
        //
        //Form1
        //
        ClientSize = new System.Drawing.Size(292, 266);
        Controls.Add(Button5);
        Controls.Add(Label1);
        Controls.Add(Button4);
        Controls.Add(Button3);
        Controls.Add(Button2);
        Controls.Add(Button1);
        Controls.Add(PictureBox1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    // The following code example demonstrates how to construct a new Bitmap
    // from a file, using the GetPixel and SetPixel methods to
    // recolor the image. It also uses the PixelFormat property. 

    // This example is designed to be used with a Windows Forms that contains
    // a Label, PictureBox and Button named Label1, PictureBox1 and Button1, 
    // respectively. Paste the code into the form and associate  the 
    // Button1_Click method with the button's Click event.
    //<snippet1>
    Bitmap image1;

    private void Button1_Click(object sender, System.EventArgs e)
    {

        try
        {
            // Retrieve the image.
            image1 = new Bitmap(@"C:\Documents and Settings\All Users\"
                + @"Documents\My Music\music.bmp", true);

            int x, y;

            // Loop through the images pixels to reset color.
            for (x = 0; x < image1.Width; x++)
            {
                for (y = 0; y < image1.Height; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                    image1.SetPixel(x, y, newColor);
                }
            }

            // Set the PictureBox to display the image.
            PictureBox1.Image = image1;

            // Display the pixel format in Label1.
            Label1.Text = "Pixel format: " + image1.PixelFormat.ToString();
        }
        catch (ArgumentException)
        {
            MessageBox.Show("There was an error." +
                "Check the path to the image file.");
        }
    }
    //</snippet1>

    // The following code example demonstrates how to obtain a new bitmap
    // using the FromFile method. It also demonstrates a TextureBrush.

    // This example is designed to be used with Windows Forms. Create 
    // a form containing a button named Button2. Paste the code into the form
    // and associate the Button2_Click method with the button's Click event.
    //<snippet2>
    private void Button2_Click(object sender, System.EventArgs e)
    {
        try
        {
            Bitmap image1 = (Bitmap)Image.FromFile(@"C:\Documents and Settings\" +
                @"All Users\Documents\My Music\music.bmp", true);

            TextureBrush texture = new TextureBrush(image1)
            {
                WrapMode = System.Drawing.Drawing2D.WrapMode.Tile
            };
            Graphics formGraphics = CreateGraphics();
            formGraphics.FillEllipse(texture,
                new RectangleF(90.0F, 110.0F, 100, 100));
            formGraphics.Dispose();
        }
        catch (System.IO.FileNotFoundException)
        {
            MessageBox.Show("There was an error opening the bitmap." +
                "Please check the path.");
        }
    }
    //</snippet2>

    // The following code example demonstrates how to create a pen 
    // and set its DashStyle property. 

    // This example is designed to be used with Windows Forms. Create
    // a form that contains a Button named Button3. Paste the code into the 
    // form and associate the Button3_Click method with the button's 
    // Click event.
    //<snippet3>
    private void Button3_Click(object sender, System.EventArgs e)
    {

        Graphics buttonGraphics = Button3.CreateGraphics();
        Pen myPen = new Pen(Color.ForestGreen, 4.0F)
        {
            DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot
        };

        Rectangle theRectangle = Button3.ClientRectangle;
        theRectangle.Inflate(-2, -2);
        buttonGraphics.DrawRectangle(myPen, theRectangle);
        buttonGraphics.Dispose();
        myPen.Dispose();
    }
    //</snippet3>

    // The following code example demonstrates the Clear method.

    // This example is designed to be used with Windows Forms.
    // Create a form that contains a Button named Button4.
    // Paste the code into the form and associate 
    // the Button4_Click method with the button's Click event.
    //<snippet4>
    private void Button4_Click(object sender, System.EventArgs e)
    {

        Graphics buttonGraphics = Button4.CreateGraphics();
        buttonGraphics.Clear(Button4.BackColor);
        buttonGraphics.Dispose();
    }
    //</snippet4>

    // The following code example demonstrates calling the Save method.

    // This example is designed to be used with Windows Forms. 
    // Create a form that contains a button named Button5.
    // Paste the code to the form and associate 
    // the Button5_Click method with button's Click event.
    //<snippet5>
    private void Button5_Click(object sender, System.EventArgs e)
    {
        try
        {
            if (image1 != null)
            {
                image1.Save("c:\\myBitmap.bmp");
                Button5.Text = "Saved file.";
            }
        }
        catch (Exception)
        {
            MessageBox.Show("There was a problem saving the file." +
                "Check the file permissions.");
        }
    }
    //</snippet5>

    //<note> this example was extracted from the "Reading Metadata"
    // conceptual topic</note>
    // The following method demonstrates how to read and display 
    // the metadata in an image file using the PropertyItem class and
    // PropertyItems property. 

    // This example is designed to be used a Windows Form that imports 
    // the System.Drawing.Imaging namespace.
    // Paste the code into the form and change the path to fakePhoto.jpg 
    // to point to an image file on your system. Call the ExtractMetaData 
    // method when handling the form's Paint event, passing e as PaintEventArgs.
    //<snippet6>
    private void ExtractMetaData(PaintEventArgs e)
    {
        try
        {
            // Create an Image object. 
            Image theImage = new Bitmap("c:\\fakePhoto.jpg");

            // Get the PropertyItems property from image.
            PropertyItem[] propItems = theImage.PropertyItems;

            // Set up the display.
            Font font1 = new Font("Arial", 10);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            int X = 0;
            int Y = 0;

            // For each PropertyItem in the array, display the id, 
            // type, and length.
            int count = 0;
            foreach (PropertyItem propItem in propItems)
            {
                e.Graphics.DrawString("Property Item " +
                    count.ToString(), font1, blackBrush, X, Y);
                Y += font1.Height;

                e.Graphics.DrawString("   ID: 0x" +
                    propItem.Id.ToString("x"), font1, blackBrush, X, Y);
                Y += font1.Height;

                e.Graphics.DrawString("   type: " +
                    propItem.Type.ToString(), font1, blackBrush, X, Y);
                Y += font1.Height;

                e.Graphics.DrawString("   length: " +
                    propItem.Len.ToString() +
                    " bytes", font1, blackBrush, X, Y);
                Y += font1.Height;
                count += 1;
            }
            font1.Dispose();
        }
        catch (Exception)
        {
            MessageBox.Show("There was an error." +
                "Make sure the path to the image file is valid.");
        }
    }
    //</snippet6>
    // <Note to Cheryl--Put this one ImageExamples>
    // The following code example demonstrates how to use the GetPropertyItem
    // and SetPropertyItem methods. This example is designed to be used with Windows
    // Forms. To run this example paste it into a form, and handle the form's Paint event
    // by calling the DemonstratePropertyItem method, passing e as PaintEventArgs.
    //<snippet7>
    private void DemonstratePropertyItem(PaintEventArgs e)
    {

        // Create two images.
        Image image1 = Image.FromFile("c:\\FakePhoto1.jpg");
        Image image2 = Image.FromFile("c:\\FakePhoto2.jpg");

        // Get a PropertyItem from image1.
        PropertyItem propItem = image1.GetPropertyItem(20624);

        // Change the ID of the PropertyItem.
        propItem.Id = 20625;

        // Set the PropertyItem for image2.
        image2.SetPropertyItem(propItem);

        // Draw the image.
        e.Graphics.DrawImage(image2, 20.0F, 20.0F);
    }
    //</snippet7>

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }
}
