// <snippet10>

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SAMP = Microsoft.Samples.WinForms.Cs.HelpLabel;

namespace Microsoft.Samples.WinForms.Cs.HostApp;
public class HostApp : Form
{
    /// <summary>
    ///    Required designer variable.
    /// </summary>
    Container components;
    Label label1;
    TextBox textBox1;
    Button button1;
    SAMP.HelpLabel helpLabel1;

    public HostApp() =>
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();

    /// <summary>
    ///    Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent()
    {
        components = new Container();
        label1 = new Label();
        button1 = new Button();
        textBox1 = new TextBox();
        helpLabel1 = new SAMP.HelpLabel();

        label1.Location = new Point(16, 16);
        label1.Text = "Name:";
        label1.Size = new Size(56, 24);
        label1.TabIndex = 3;

        helpLabel1.Dock = DockStyle.Bottom;
        helpLabel1.Size = new Size(448, 40);
        helpLabel1.TabIndex = 0;
        helpLabel1.Location = new Point(0, 117);

        button1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
        button1.Size = new Size(104, 40);
        button1.TabIndex = 1;
        helpLabel1.SetHelpText(button1, "This is the Save Button. Press the Save Button to save your work.");
        button1.Text = "&Save";
        button1.Location = new Point(336, 56);

        Text = "Control Example";
        ClientSize = new Size(448, 157);

        textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        textBox1.Location = new Point(80, 16);
        textBox1.Text = "<Name>";
        helpLabel1.SetHelpText(textBox1, "This is the name field. Please enter your name here.");
        textBox1.TabIndex = 2;
        textBox1.Size = new Size(360, 20);

        Controls.Add(label1);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Controls.Add(helpLabel1);
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main() => Application.Run(new HostApp());
}

// </snippet10>
