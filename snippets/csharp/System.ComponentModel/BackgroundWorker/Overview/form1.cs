// <snippet1>
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BackgroundWorkerSimple;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.WorkerSupportsCancellation = true;
    }

    void startAsyncButton_Click(object sender, EventArgs e)
    {
        if (!backgroundWorker1.IsBusy)
        {
            // Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync();
        }
    }

    void cancelAsyncButton_Click(object sender, EventArgs e)
    {
        if (backgroundWorker1.WorkerSupportsCancellation)
        {
            // Cancel the asynchronous operation.
            backgroundWorker1.CancelAsync();
        }
    }

    // This event handler is where the time-consuming work is done.
    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;

        for (int i = 1; i <= 10; i++)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                break;
            }
            else
            {
                // Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress(i * 10);
            }
        }
    }

    // This event handler updates the progress.
    void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) => resultLabel.Text = e.ProgressPercentage.ToString() + "%";

    // This event handler deals with the results of the background operation.
    void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => resultLabel.Text = e.Cancelled ? "Canceled!" : e.Error != null ? "Error: " + e.Error.Message : "Done!";
}
// </snippet1>
