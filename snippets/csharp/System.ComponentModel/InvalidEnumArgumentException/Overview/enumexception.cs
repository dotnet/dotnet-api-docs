using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace enumException;

/// <summary>
/// Summary description for Form1.
/// </summary>
public class Form1 : Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    readonly Container _components;

    public Form1()
    {
        InitializeComponent();
    }

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
        // 
        // Form1
        // 
        ClientSize = new Size(292, 273);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
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
        try
        {
            // Attempts to pass an invalid enum value (MessageBoxButtons) to the Show method
            MessageBoxButtons myButton = (MessageBoxButtons)123;
            MessageBox.Show("This is a message", "This is the Caption", myButton);
        }
        catch (InvalidEnumArgumentException invE)
        {
            Console.WriteLine(invE.Message);
            Console.WriteLine(invE.ParamName);
            Console.WriteLine(invE.StackTrace);
            Console.WriteLine(invE.Source);
        }
        //</snippet1>
    }
}
