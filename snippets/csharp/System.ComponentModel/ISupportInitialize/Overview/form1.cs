//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrackBar;

/// <summary>
/// Summary description for Form1.
/// </summary>
public class Form1 : Form
{
    Panel panel1;
    System.Windows.Forms.TrackBar trackBar1;
    System.Windows.Forms.TrackBar trackBar2;
    System.Windows.Forms.TrackBar trackBar3;
    Label label1;
    Label label3;
    Label label2;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    public Form1()
    {
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();

        //
        // TODO: Add any constructor code after InitializeComponent call
        //
        //<Snippet2>
        trackBar2.Orientation = Orientation.Vertical;
        trackBar3.Orientation = Orientation.Vertical;
        trackBar1.Maximum = trackBar2.Maximum = trackBar3.Maximum = 255;
        trackBar1.Width = 400;
        trackBar2.Height = trackBar3.Height = trackBar1.Width;
        trackBar1.LargeChange = trackBar2.LargeChange = trackBar3.LargeChange = 16;
        //</Snippet2>
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent()
    {
        trackBar1 = new System.Windows.Forms.TrackBar();
        trackBar2 = new System.Windows.Forms.TrackBar();
        trackBar3 = new System.Windows.Forms.TrackBar();
        panel1 = new Panel();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        //<Snippet4>
        trackBar1.BeginInit();
        trackBar2.BeginInit();
        trackBar3.BeginInit();
        SuspendLayout();
        //
        // trackBar1
        //
        trackBar1.Location = new Point(160, 400);
        trackBar1.Name = "trackBar1";
        trackBar1.TabIndex = 1;
        trackBar1.Scroll += trackBar_Scroll;
        //
        // trackBar2
        //
        trackBar2.Location = new Point(608, 40);
        trackBar2.Name = "trackBar2";
        trackBar2.TabIndex = 2;
        trackBar2.Scroll += trackBar_Scroll;
        //
        // trackBar3
        //
        trackBar3.Location = new Point(56, 40);
        trackBar3.Name = "trackBar3";
        trackBar3.TabIndex = 3;
        trackBar3.Scroll += trackBar_Scroll;
        trackBar1.EndInit();
        trackBar2.EndInit();
        trackBar3.EndInit();
        //</Snippet4>
        //
        // panel1
        //
        panel1.BorderStyle = BorderStyle.Fixed3D;
        panel1.Location = new Point(128, 32);
        panel1.Name = "panel1";
        panel1.Size = new Size(464, 352);
        panel1.TabIndex = 0;
        //
        // label1
        //
        label1.Location = new Point(288, 448);
        label1.Name = "label1";
        label1.TabIndex = 4;
        //
        // label2
        //
        label2.Location = new Point(600, 16);
        label2.Name = "label2";
        label2.Size = new Size(120, 16);
        label2.TabIndex = 5;
        //
        // label3
        //
        label3.Location = new Point(8, 16);
        label3.Name = "label3";
        label3.Size = new Size(120, 16);
        label3.TabIndex = 6;
        //
        // Form1
        //
        ClientSize = new Size(728, 477);
        Controls.AddRange(
        [
            label3,
            label2,
            label1,
            trackBar3,
            trackBar2,
            trackBar1,
            panel1
        ]);
        Name = "Form1";
        Text = "Color builder";
        Load += Form1_Load;
        ResumeLayout(false);
    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() => Application.Run(new Form1());

    void Form1_Load(object sender, EventArgs e) => showColorValueLabels();
    //<Snippet3>
    void showColorValueLabels()
    {
        label1.Text = "Red value is : " + trackBar1.Value.ToString();
        label2.Text = "Green Value is : " + trackBar2.Value.ToString();
        label3.Text = "Blue Value is : " + trackBar3.Value.ToString();
    }
    void trackBar_Scroll(object sender, EventArgs e)
    {
        System.Windows.Forms.TrackBar myTB = (System.Windows.Forms.TrackBar)sender;
        panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        myTB.Text = "Value is " + myTB.Value.ToString();
        showColorValueLabels();
    }
    //</Snippet3>
}
//</Snippet1>
