// <snippet1>
// <snippet7>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
// </snippet7>

namespace BackgroundWorkerExample;

public class Form1 : Form
{
    public Form1() => InitializeComponent();

    // <snippet2>
    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // Do not access the form's BackgroundWorker reference directly.
        // Instead, use the reference provided by the sender parameter.
        BackgroundWorker bw = sender as BackgroundWorker;

        // Extract the argument.
        int arg = (int)e.Argument;

        // Start the time-consuming operation.
        e.Result = TimeConsumingOperation(bw, arg);

        // If the operation was canceled by the user, 
        // set the DoWorkEventArgs.Cancel property to true.
        if (bw.CancellationPending)
        {
            e.Cancel = true;
        }
    }
    // </snippet2>

    // <snippet3>
    // This event handler demonstrates how to interpret 
    // the outcome of the asynchronous operation implemented
    // in the DoWork event handler.
    void backgroundWorker1_RunWorkerCompleted(
        object sender,
        RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            // The user canceled the operation.
            _ = MessageBox.Show("Operation was canceled");
        }
        else if (e.Error != null)
        {
            // There was an error during the operation.
            string msg = $"An error occurred: {e.Error.Message}";
            _ = MessageBox.Show(msg);
        }
        else
        {
            // The operation completed normally.
            string msg = string.Format("Result = {0}", e.Result);
            _ = MessageBox.Show(msg);
        }
    }
    // </snippet3>

    // <snippet4>
    // This method models an operation that may take a long time 
    // to run. It can be cancelled, it can raise an exception,
    // or it can exit normally and return a result. These outcomes
    // are chosen randomly.
    int TimeConsumingOperation(
        BackgroundWorker bw,
        int sleepPeriod)
    {
        int result = 0;

        Random rand = new();

        while (!bw.CancellationPending)
        {
            bool exit = false;

            switch (rand.Next(3))
            {
                // Raise an exception.
                case 0:
                    {
                        throw new Exception("An error condition occurred.");
                    }

                // Sleep for the number of milliseconds
                // specified by the sleepPeriod parameter.
                case 1:
                    {
                        Thread.Sleep(sleepPeriod);
                        break;
                    }

                // Exit and return normally.
                case 2:
                    {
                        result = 23;
                        exit = true;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            if (exit)
            {
                break;
            }
        }

        return result;
    }
    // </snippet4>

    // <snippet5>
    void startBtn_Click(object sender, EventArgs e) => backgroundWorker1.RunWorkerAsync(2000);
    // </snippet5>

    // <snippet6>
    void cancelBtn_Click(object sender, EventArgs e) => backgroundWorker1.CancelAsync();
    // </snippet6>

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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent()
    {
        backgroundWorker1 = new BackgroundWorker();
        startBtn = new Button();
        cancelBtn = new Button();
        SuspendLayout();
        // 
        // backgroundWorker1
        // 
        backgroundWorker1.WorkerSupportsCancellation = true;
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        // 
        // startBtn
        // 
        startBtn.Location = new Point(12, 12);
        startBtn.Name = "startBtn";
        startBtn.Size = new Size(75, 23);
        startBtn.TabIndex = 0;
        startBtn.Text = "Start";
        startBtn.Click += startBtn_Click;
        // 
        // cancelBtn
        // 
        cancelBtn.Location = new Point(94, 11);
        cancelBtn.Name = "cancelBtn";
        cancelBtn.Size = new Size(75, 23);
        cancelBtn.TabIndex = 1;
        cancelBtn.Text = "Cancel";
        cancelBtn.Click += cancelBtn_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(183, 49);
        Controls.Add(cancelBtn);
        Controls.Add(startBtn);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    BackgroundWorker backgroundWorker1;
    Button startBtn;
    Button cancelBtn;
}

public class Program
{
    Program()
    {
    }

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
