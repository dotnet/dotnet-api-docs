// <snippet1>
// <snippet2>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
// </snippet2>

namespace BackgroundWorkerExample;

public class FibonacciForm : Form
{
    // <snippet14>
    int numberToCompute;
    int highestPercentageReached;
    // </snippet14>

    NumericUpDown numericUpDown1;
    Button startAsyncButton;
    Button cancelAsyncButton;
    ProgressBar progressBar1;
    Label resultLabel;
    BackgroundWorker backgroundWorker1;

    public FibonacciForm()
    {
        InitializeComponent();

        InitializeBackgroundWorker();
    }

    // Set up the BackgroundWorker object by 
    // attaching event handlers. 
    void InitializeBackgroundWorker()
    {
        backgroundWorker1.DoWork +=
             backgroundWorker1_DoWork;
        backgroundWorker1.RunWorkerCompleted +=

        backgroundWorker1_RunWorkerCompleted;
        backgroundWorker1.ProgressChanged +=

        backgroundWorker1_ProgressChanged;
    }

    // <snippet13>
    void startAsyncButton_Click(object sender,
        EventArgs e)
    {
        // Reset the text in the result label.
        resultLabel.Text = string.Empty;

        // Disable the UpDown control until 
        // the asynchronous operation is done.
        numericUpDown1.Enabled = false;

        // Disable the Start button until 
        // the asynchronous operation is done.
        startAsyncButton.Enabled = false;

        // Enable the Cancel button while 
        // the asynchronous operation runs.
        cancelAsyncButton.Enabled = true;

        // Get the value from the UpDown control.
        numberToCompute = (int)numericUpDown1.Value;

        // Reset the variable for percentage tracking.
        highestPercentageReached = 0;

        // <snippet3>
        // Start the asynchronous operation.
        backgroundWorker1.RunWorkerAsync(numberToCompute);
        // </snippet3>
    }
    // </snippet13>

    // <snippet4>
    void cancelAsyncButton_Click(object sender,
        EventArgs e)
    {
        // Cancel the asynchronous operation.
        backgroundWorker1.CancelAsync();

        // Disable the Cancel button.
        cancelAsyncButton.Enabled = false;
    }
    // </snippet4>

    // <snippet5>
    // This event handler is where the actual,
    // potentially time-consuming work is done.
    void backgroundWorker1_DoWork(object sender,
        DoWorkEventArgs e)
    {
        // Get the BackgroundWorker that raised this event.
        BackgroundWorker worker = sender as BackgroundWorker;

        // Assign the result of the computation
        // to the Result property of the DoWorkEventArgs
        // object. This is will be available to the 
        // RunWorkerCompleted eventhandler.
        e.Result = ComputeFibonacci((int)e.Argument, worker, e);
    }
    // </snippet5>

    // <snippet6>
    // This event handler deals with the results of the
    // background operation.
    void backgroundWorker1_RunWorkerCompleted(
        object sender, RunWorkerCompletedEventArgs e)
    {
        // First, handle the case where an exception was thrown.
        if (e.Error != null)
        {
            _ = MessageBox.Show(e.Error.Message);
        }
        else if (e.Cancelled)
        {
            // Next, handle the case where the user canceled 
            // the operation.
            // Note that due to a race condition in 
            // the DoWork event handler, the Cancelled
            // flag may not have been set, even though
            // CancelAsync was called.
            resultLabel.Text = "Canceled";
        }
        else
        {
            // Finally, handle the case where the operation 
            // succeeded.
            resultLabel.Text = e.Result.ToString();
        }

        // Enable the UpDown control.
        numericUpDown1.Enabled = true;

        // Enable the Start button.
        startAsyncButton.Enabled = true;

        // Disable the Cancel button.
        cancelAsyncButton.Enabled = false;
    }
    // </snippet6>

    // <snippet7>
    // This event handler updates the progress bar.
    void backgroundWorker1_ProgressChanged(object sender,
        ProgressChangedEventArgs e) => progressBar1.Value = e.ProgressPercentage;
    // </snippet7>

    // <snippet10>
    // This is the method that does the actual work. For this
    // example, it computes a Fibonacci number and
    // reports progress as it does its work.
    long ComputeFibonacci(int n, BackgroundWorker worker, DoWorkEventArgs e)
    {
        // The parameter n must be >= 0 and <= 91.
        // Fib(n), with n > 91, overflows a long.
        if (n is < 0 or > 91)
        {
            throw new ArgumentException(
                "value must be >= 0 and <= 91", nameof(n));
        }

        long result = 0;

        // <snippet8>
        // Abort the operation if the user has canceled.
        // Note that a call to CancelAsync may have set 
        // CancellationPending to true just after the
        // last invocation of this method exits, so this 
        // code will not have the opportunity to set the 
        // DoWorkEventArgs.Cancel flag to true. This means
        // that RunWorkerCompletedEventArgs.Cancelled will
        // not be set to true in your RunWorkerCompleted
        // event handler. This is a race condition.

        // <snippet11>
        if (worker.CancellationPending)
        {
            e.Cancel = true;
        }
        // </snippet11>
        else
        {
            result = n < 2
                ? 1
                : ComputeFibonacci(n - 1, worker, e) +
                         ComputeFibonacci(n - 2, worker, e);

            // <snippet12>
            // Report progress as a percentage of the total task.
            int percentComplete =
                (int)(n / (float)numberToCompute * 100);
            if (percentComplete > highestPercentageReached)
            {
                highestPercentageReached = percentComplete;
                worker.ReportProgress(percentComplete);
            }
            // </snippet12>
        }
        // </snippet8>

        return result;
    }
    // </snippet10>

    #region Windows Form Designer generated code

    void InitializeComponent()
    {
        numericUpDown1 = new NumericUpDown();
        startAsyncButton = new Button();
        cancelAsyncButton = new Button();
        resultLabel = new Label();
        progressBar1 = new ProgressBar();
        backgroundWorker1 = new BackgroundWorker();
        ((ISupportInitialize)numericUpDown1).BeginInit();
        SuspendLayout();
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new Point(16, 16);
        numericUpDown1.Maximum = new decimal(new int[] {
            91,
            0,
            0,
            0});
        numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new Size(80, 20);
        numericUpDown1.TabIndex = 0;
        numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // startAsyncButton
        // 
        startAsyncButton.Location = new Point(16, 72);
        startAsyncButton.Name = "startAsyncButton";
        startAsyncButton.Size = new Size(120, 23);
        startAsyncButton.TabIndex = 1;
        startAsyncButton.Text = "Start Async";
        startAsyncButton.Click += startAsyncButton_Click;
        // 
        // cancelAsyncButton
        // 
        cancelAsyncButton.Enabled = false;
        cancelAsyncButton.Location = new Point(153, 72);
        cancelAsyncButton.Name = "cancelAsyncButton";
        cancelAsyncButton.Size = new Size(119, 23);
        cancelAsyncButton.TabIndex = 2;
        cancelAsyncButton.Text = "Cancel Async";
        cancelAsyncButton.Click += cancelAsyncButton_Click;
        // 
        // resultLabel
        // 
        resultLabel.BorderStyle = BorderStyle.Fixed3D;
        resultLabel.Location = new Point(112, 16);
        resultLabel.Name = "resultLabel";
        resultLabel.Size = new Size(160, 23);
        resultLabel.TabIndex = 3;
        resultLabel.Text = "(no result)";
        resultLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // progressBar1
        // 
        progressBar1.Location = new Point(18, 48);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(256, 8);
        progressBar1.Step = 2;
        progressBar1.TabIndex = 4;
        // 
        // backgroundWorker1
        // 
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.WorkerSupportsCancellation = true;
        // 
        // FibonacciForm
        // 
        ClientSize = new Size(1794, 927);
        Controls.Add(progressBar1);
        Controls.Add(resultLabel);
        Controls.Add(cancelAsyncButton);
        Controls.Add(startAsyncButton);
        Controls.Add(numericUpDown1);
        Name = "FibonacciForm";
        Text = "Fibonacci Calculator";
        ((ISupportInitialize)numericUpDown1).EndInit();
        ResumeLayout(false);
    }
    #endregion

    [STAThread]
    static void Main() => Application.Run(new FibonacciForm());
}
// </snippet1>
