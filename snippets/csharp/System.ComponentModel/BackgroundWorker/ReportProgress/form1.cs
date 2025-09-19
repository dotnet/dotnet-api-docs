// <Snippet1>
using System;
using System.ComponentModel;
using System.Windows.Forms;

class FibonacciNumber : Form
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new FibonacciNumber());
    }

    readonly StatusStrip progressStatusStrip;
    readonly ToolStripProgressBar toolStripProgressBar;
    readonly NumericUpDown requestedCountControl;
    readonly Button goButton;
    readonly TextBox outputTextBox;
    readonly BackgroundWorker backgroundWorker;
    readonly ToolStripStatusLabel toolStripStatusLabel;
    int requestedCount;

    public FibonacciNumber()
    {
        Text = "Fibonacci";

        // Prepare the StatusStrip.
        progressStatusStrip = new StatusStrip();
        toolStripProgressBar = new ToolStripProgressBar
        {
            Enabled = false
        };
        toolStripStatusLabel = new ToolStripStatusLabel();
        _ = progressStatusStrip.Items.Add(toolStripProgressBar);
        _ = progressStatusStrip.Items.Add(toolStripStatusLabel);

        FlowLayoutPanel flp = new()
        {
            Dock = DockStyle.Top
        };

        Label beforeLabel = new()
        {
            Text = "Calculate the first ",
            AutoSize = true
        };
        flp.Controls.Add(beforeLabel);
        // <Snippet2>
        requestedCountControl = new NumericUpDown
        {
            Maximum = 1000,
            Minimum = 1,
            Value = 100
        };
        flp.Controls.Add(requestedCountControl);
        // </Snippet2>
        Label afterLabel = new()
        {
            Text = "Numbers in the Fibonacci sequence.",
            AutoSize = true
        };
        flp.Controls.Add(afterLabel);

        goButton = new Button
        {
            Text = "&Go"
        };
        goButton.Click += button1_Click;
        flp.Controls.Add(goButton);

        outputTextBox = new TextBox
        {
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            Dock = DockStyle.Fill
        };

        Controls.Add(outputTextBox);
        Controls.Add(progressStatusStrip);
        Controls.Add(flp);

        backgroundWorker = new BackgroundWorker
        {
            WorkerReportsProgress = true
        };
        backgroundWorker.DoWork += backgroundWorker1_DoWork;
        backgroundWorker.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        backgroundWorker.ProgressChanged += backgroundWorker1_ProgressChanged;
    }

    // <snippet10>
    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // This method will run on a thread other than the UI thread.
        // Be sure not to manipulate any Windows Forms controls created
        // on the UI thread from this method.
        backgroundWorker.ReportProgress(0, "Working...");
        decimal lastlast = 0;
        decimal last = 1;
        decimal current;
        if (requestedCount >= 1)
        { AppendNumber(0); }
        if (requestedCount >= 2)
        { AppendNumber(1); }
        for (int i = 2; i < requestedCount; ++i)
        {
            // Calculate the number.
            checked { current = lastlast + last; }
            // Introduce some delay to simulate a more complicated calculation.
            System.Threading.Thread.Sleep(100);
            AppendNumber(current);
            backgroundWorker.ReportProgress(100 * i / requestedCount, "Working...");
            // Get ready for the next iteration.
            lastlast = last;
            last = current;
        }

        backgroundWorker.ReportProgress(100, "Complete!");
    }
    // </snippet10>

    delegate void AppendNumberDelegate(decimal number);
    // <Snippet3>
    void AppendNumber(decimal number)
    {
        if (outputTextBox.InvokeRequired)
        { _ = outputTextBox.Invoke(new AppendNumberDelegate(AppendNumber), number); }
        else
        { outputTextBox.AppendText(number.ToString("N0") + Environment.NewLine); }
    }
    // </Snippet3>
    void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        toolStripProgressBar.Value = e.ProgressPercentage;
        toolStripStatusLabel.Text = e.UserState as string;
    }

    void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error is OverflowException)
        { outputTextBox.AppendText(Environment.NewLine + "**OVERFLOW ERROR, number is too large to be represented by the decimal data type**"); }
        toolStripProgressBar.Enabled = false;
        requestedCountControl.Enabled = true;
        goButton.Enabled = true;
    }

    void button1_Click(object sender, EventArgs e)
    {
        goButton.Enabled = false;
        toolStripProgressBar.Enabled = true;
        requestedCount = (int)requestedCountControl.Value;
        requestedCountControl.Enabled = false;
        outputTextBox.Clear();
        backgroundWorker.RunWorkerAsync();
    }
}
// </Snippet1>
