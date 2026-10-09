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
        ComboBox1.SelectedIndexChanged +=
            new EventHandler(ComboBox1_SelectedIndexChanged);

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
    internal System.Windows.Forms.ComboBox ComboBox1;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button Button1;
    internal System.Windows.Forms.Button Button2;
    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
        ComboBox1 = new System.Windows.Forms.ComboBox();
        Label1 = new System.Windows.Forms.Label();
        Button1 = new System.Windows.Forms.Button();
        Button2 = new System.Windows.Forms.Button();
        SuspendLayout();
        //
        //ComboBox1
        //
        ComboBox1.Items.AddRange(["Smaller", "Bigger"]);
        ComboBox1.Location = new System.Drawing.Point(64, 32);
        ComboBox1.Name = "ComboBox1";
        ComboBox1.Size = new System.Drawing.Size(121, 21);
        ComboBox1.TabIndex = 0;
        //
        //Label1
        //
        Label1.Location = new System.Drawing.Point(48, 136);
        Label1.Name = "Label1";
        Label1.Size = new System.Drawing.Size(184, 88);
        Label1.TabIndex = 1;
        Label1.Text = "Some text to change.";
        //
        // Button1
        //
        Button1.Location = new System.Drawing.Point(192, 56);
        Button1.Name = "Button1";
        Button1.TabIndex = 2;
        Button1.Text = "Button1";
        Button1.Click += new System.EventHandler(Button1_Click);
        // 
        // Button2
        // 
        Button2.Location = new System.Drawing.Point(200, 8);
        Button2.Name = "Button2";
        Button2.TabIndex = 3;
        Button2.Text = "Button2";
        Button2.Click += new System.EventHandler(Button2_Click);
        //
        //Form1
        //
        ClientSize = new System.Drawing.Size(292, 266);
        Controls.Add(Label1);
        Controls.Add(ComboBox1);
        Controls.Add(Button2);
        Controls.Add(Button1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    // The following code example demonstrates how to use the Size, 
    // SizeInPoints, and Unit properties. This example is designed to
    // be used with a Windows Form that contains a ComboBox named 
    // ComboBox1.  Paste the following code into the form and  
    // associate the ComboBox1_SelectedIndexChange method with the 
    // SelectedIndexChanged event of the ComboBox control.

    //<snippet1> 
    private void ComboBox1_SelectedIndexChanged(object sender,
        System.EventArgs e)
    {

        // Cast the sender object back to a ComboBox.
        ComboBox ComboBox1 = (ComboBox)sender;

        // Retrieve the selected item.
        string selectedString = (string)ComboBox1.SelectedItem;

        // Convert it to lowercase.
        selectedString = selectedString.ToLower();

        // Declare the current size.
        float currentSize;

        // Switch on the selected item. 
        switch (selectedString)
        {

            // If Bigger is selected, get the current size from the
            // Size property and increase it. Reset the font to the
            //  new size, using the current unit.
            case "bigger":
                currentSize = Label1.Font.Size;
                currentSize += 2.0F;
                Label1.Font = new Font(Label1.Font.Name, currentSize,
                    Label1.Font.Style, Label1.Font.Unit);

                // If Smaller is selected, get the current size, in points,
                // and decrease it by 1.  Reset the font with the new size
                // in points.
                break;
            case "smaller":
                currentSize = Label1.Font.SizeInPoints;
                currentSize -= 1;
                Label1.Font = new Font(Label1.Font.Name, currentSize,
                    Label1.Font.Style);
                break;
        }
    }
    //</snippet1> 

    // The following code example demonstrates how to use the
    // Font.#ctor(Font, FontStyle) constructor. To run this example, paste this code into  
    // a Windows Form that contains a button named Button1, and associate the 
    // Button1_Click method with the Click event of the button.
    //<snippet2>
    private void Button1_Click(object sender, System.EventArgs e)
    {
        Button1.Font = new Font(Font, FontStyle.Italic);
    }
    //</snippet2>

    // The following code example demonstrates how to use
    // the Font.#ctor(FontFamily, Single, FontStyle, GraphicsUnit) constructor.
    // This example is designed to be used with Windows
    // Forms. To run this example paste this code into a form that contains a 
    // button named Button2, and associate the Button2_Click method with
    // the Click event of the button. 
    //<snippet3>

    private void Button2_Click(object sender, System.EventArgs e)
    {

        Button2.Font = new Font(FontFamily.GenericMonospace, 12.0F,
            FontStyle.Italic, GraphicsUnit.Pixel);
    }
    //</snippet3>
    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }
}
