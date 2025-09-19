using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EventDescriptor;

/// <summary>
/// Summary description for Form1.
/// </summary>
public class Form1 : Form
{
    Button button1;
    TextBox textBox1;
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
        button1 = new Button();
        textBox1 = new TextBox();
        SuspendLayout();
        //
        // button1
        //
        button1.Name = "button1";
        button1.TabIndex = 0;
        button1.Text = "button1";
        //
        // textBox1
        //
        textBox1.Location = new Point(8, 96);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(608, 160);
        textBox1.TabIndex = 1;
        textBox1.Text = "textBox1";
        //
        // Form1
        //
        ClientSize = new Size(632, 273);
        Controls.AddRange(
        [
            textBox1,
            button1
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
        EventDescriptorCollection events = TypeDescriptor.GetEvents(button1);
        // Displays each event's information in the collection in a text box.
        foreach (System.ComponentModel.EventDescriptor myEvent in events)
        {
            textBox1.Text += myEvent.Category + '\n';
            textBox1.Text += myEvent.Description + '\n';
            textBox1.Text += myEvent.DisplayName + '\n';
        }
        //</snippet1>
    }
}
