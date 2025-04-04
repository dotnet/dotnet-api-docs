// <snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

public class Form1 : Form
{
    readonly BackgroundWorker backgroundWorker1;
    Button downloadButton;
    ProgressBar progressBar1;
    XmlDocument document;

    public Form1()
    {
        InitializeComponent();

        // Instantiate BackgroundWorker and attach handlers to its
        // DoWork and RunWorkerCompleted events.
        backgroundWorker1 = new BackgroundWorker();
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
    }

    // <snippet2>
    void downloadButton_Click(object sender, EventArgs e)
    {
        // Start the download operation in the background.
        backgroundWorker1.RunWorkerAsync();

        // Disable the button for the duration of the download.
        downloadButton.Enabled = false;

        // Once you have started the background thread you
        // can exit the handler and the application will
        // wait until the RunWorkerCompleted event is raised.

        // Or if you want to do something else in the main thread,
        // such as update a progress bar, you can do so in a loop
        // while checking IsBusy to see if the background task is
        // still running.

        while (backgroundWorker1.IsBusy)
        {
            progressBar1.Increment(1);
            // Keep UI messages moving, so the form remains
            // responsive during the asynchronous operation.
            Application.DoEvents();
        }
    }
    // </snippet2>

    // <snippet3>
    void backgroundWorker1_DoWork(
        object sender,
        DoWorkEventArgs e)
    {
        document = new XmlDocument();

        // Uncomment the following line to
        // simulate a noticeable latency.
        //Thread.Sleep(5000);

        // Replace this file name with a valid file name.
        document.Load("http://www.tailspintoys.com/sample.xml");
    }
    // </snippet3>

    // <snippet4>
    void backgroundWorker1_RunWorkerCompleted(
        object sender,
        RunWorkerCompletedEventArgs e)
    {
        // Set progress bar to 100% in case it's not already there.
        progressBar1.Value = 100;

        if (e.Error == null)
            MessageBox.Show(document.InnerXml, "Download Complete");
        else
        {
            MessageBox.Show(
                "Failed to download file",
                "Download failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        // Enable the download button and reset the progress bar.
        downloadButton.Enabled = true;
        progressBar1.Value = 0;
    }
    // </snippet4>

    #region Windows Form Designer generated code

    /// <summary>
    /// Required designer variable.
    /// </summary>
    readonly IContainer _components;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
        {
            _components.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support
    /// </summary>
    void InitializeComponent()
    {
        downloadButton = new Button();
        progressBar1 = new ProgressBar();
        SuspendLayout();
        //
        // downloadButton
        //
        downloadButton.Location = new Point(12, 12);
        downloadButton.Name = "downloadButton";
        downloadButton.Size = new Size(100, 23);
        downloadButton.TabIndex = 0;
        downloadButton.Text = "Download file";
        downloadButton.UseVisualStyleBackColor = true;
        downloadButton.Click += downloadButton_Click;
        //
        // progressBar1
        //
        progressBar1.Location = new Point(12, 50);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(100, 26);
        progressBar1.TabIndex = 1;
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(133, 104);
        Controls.Add(progressBar1);
        Controls.Add(downloadButton);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion
}

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}
// </snippet1>
