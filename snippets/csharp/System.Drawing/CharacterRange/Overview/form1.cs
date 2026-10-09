using System;
using System.Drawing;
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
        Paint += new PaintEventHandler(Form1_Paint);

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
    internal System.Windows.Forms.Button Button1;
    internal System.Windows.Forms.Button Button2;
    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
        Button1 = new System.Windows.Forms.Button();
        Button2 = new System.Windows.Forms.Button();
        SuspendLayout();
        //
        //Button1
        //
        Button1.Location = new System.Drawing.Point(40, 208);
        Button1.Name = "Button1";
        Button1.TabIndex = 0;
        Button1.Text = "Button1";
        //
        //Button2
        //
        Button2.Location = new System.Drawing.Point(152, 208);
        Button2.Name = "Button2";
        Button2.TabIndex = 1;
        Button2.Text = "Button2";
        //
        //Form1
        //
        ClientSize = new System.Drawing.Size(292, 266);
        Controls.Add(Button2);
        Controls.Add(Button1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    // The following code example demonstrates how to create a CharacterRange 
    // and use it to highlight part of a string. This sample is designed to be
    // used with Windows Forms.  Paste the example into a form and
    // call the HighlightACharacterRange method when handling the 
    // form's Paint event, passing e as PaintEventArgs.
    // 
    //<snippet1>
    private void HighlightACharacterRange(PaintEventArgs e)
    {

        // Declare the string to draw.
        string message = "This is the string to highlight a word in.";

        // Declare the word to highlight.
        string searchWord = "string";

        // Create a CharacterRange array with the searchWord 
        // location and length.
        CharacterRange[] ranges =
            [new CharacterRange
            (message.IndexOf(searchWord), searchWord.Length)];

        // Construct a StringFormat object.
        StringFormat stringFormat1 = new StringFormat();

        // Set the ranges on the StringFormat object.
        stringFormat1.SetMeasurableCharacterRanges(ranges);

        // Declare the font to write the message in.
        Font largeFont = new Font(FontFamily.GenericSansSerif, 16.0F,
            GraphicsUnit.Pixel);

        // Construct a new Rectangle.
        Rectangle displayRectangle = new Rectangle(20, 20, 200, 100);

        // Convert the Rectangle to a RectangleF.
        RectangleF displayRectangleF = (RectangleF)displayRectangle;

        // Get the Region to highlight by calling the 
        // MeasureCharacterRanges method.
        Region[] charRegion = e.Graphics.MeasureCharacterRanges(message,
            largeFont, displayRectangleF, stringFormat1);

        // Draw the message string on the form.
        e.Graphics.DrawString(message, largeFont, Brushes.Blue,
            displayRectangleF);

        // Fill in the region using a semi-transparent color.
        e.Graphics.FillRegion(new SolidBrush(Color.FromArgb(50, Color.Fuchsia)),
            charRegion[0]);

        largeFont.Dispose();
    }
    //</snippet1>

    private void Form1_Paint(object sender, PaintEventArgs e)
    {

        HighlightACharacterRange(e);
    }

    // The following code example demonstrates the Color.op_Equality operator. 
    // This example is designed to be used with a Windows Form that  
    // contains a button named Button1.  Paste the following code into  
    // your form and associate the Button1_Click method with the button's
    // Click event.
    //<snippet2>    
    private void Button1_Click(object sender, System.EventArgs e)
    {

        if (BackColor == SystemColors.ControlDark)
        {
            BackColor = SystemColors.Control;
        }
    }
    //</snippet2>

    // The following code example demonstrates the Color.op_Inequality 
    // operator. This example is designed to be used with a Windows Form 
    // that contains a button named Button2.  Paste the following code 
    // into your form and associate the Button2_Click method with the
    //  button's Click event.
    //<snippet3>
    private void Button2_Click(object sender, System.EventArgs e)
    {

        if (BackColor != SystemColors.ControlDark)
        {
            BackColor = SystemColors.ControlDark;
        }
        if (!(Font.Bold))
        {
            Font = new Font(Font, FontStyle.Bold);
        }
    }
    //</snippet3>

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }
}
