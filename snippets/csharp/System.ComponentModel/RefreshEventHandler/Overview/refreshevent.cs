using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PropertyChanged;

/// <summary>
/// Summary description for Form1.
/// </summary>
public class Form1 : Form
{
    TextBox textBox1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    readonly Container _components;

    public Form1()
    {
        InitializeComponent();
        // TODO: Add any constructor code after InitializeComponent call
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
        textBox1 = new TextBox();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.TabIndex = 0;
        textBox1.Text = "textBox1";
        // 
        // Form1
        // 
        ClientSize = new Size(488, 301);
        Controls.AddRange([textBox1]);
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

    //<snippet1>
    void Form1_Load(object sender, EventArgs e)
    {
        textBox1.Text = "changed";
        TypeDescriptor.Refreshed += new RefreshEventHandler(OnRefresh);
        _ = TypeDescriptor.GetProperties(textBox1);
        TypeDescriptor.Refresh(textBox1);
    }

    protected static void OnRefresh(RefreshEventArgs e) =>
        Console.WriteLine(e.ComponentChanged.ToString());
    //</snippet1>
}

class Control : Component
{
    int position;

    public int Position
    {
        get => position;
        set
        {
            if (!position.Equals(value))
            {
                position = value;
                //RaisePropertyChangedEvent(position);
            }
        }
    }
}
