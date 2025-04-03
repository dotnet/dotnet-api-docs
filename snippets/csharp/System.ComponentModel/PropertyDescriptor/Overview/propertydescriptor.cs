using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyPropertyDescriptor;

/// <summary>
/// Summary description for Form1.
/// </summary>
public class Form1 : Form
{
    TextBox textBox1;
    Button button1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    readonly Container _components;

    public Form1() =>
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _components?.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent()
    {
        textBox1 = new TextBox();
        button1 = new Button();
        SuspendLayout();
        //
        // textBox1
        //
        textBox1.Location = new Point(120, 16);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(288, 272);
        textBox1.TabIndex = 0;
        textBox1.Text = "textBox1";
        //
        // button1
        //
        button1.Location = new Point(40, 112);
        button1.Name = "button1";
        button1.TabIndex = 1;
        button1.Text = "button1";
        //
        // Form1
        //
        ClientSize = new Size(448, 333);
        Controls.AddRange(
        [
            button1,
            textBox1
        ]);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        ResumeLayout(false);
    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() => Application.Run(new Form1());

    void Form1_Load(object sender, EventArgs e)
    {
        //<snippet1>
        // Creates a new collection and assign it the properties for button1.
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(button1);

        // Sets an PropertyDescriptor to the specific property.
        PropertyDescriptor myProperty = properties.Find("Text", false);

        // Prints the property and the property description.
        textBox1.Text = myProperty.DisplayName + '\n';
        textBox1.Text += myProperty.Description + '\n';
        textBox1.Text += myProperty.Category + '\n';
        //</snippet1>
    }
}
