// <snippet10>
// <snippet11>
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
// </snippet11>

namespace AsyncOperationManagerExample;

// This form tests the PrimeNumberCalculator component.
public class PrimeNumberCalculatorMain : Form
{
    /////////////////////////////////////////////////////////////
    // Private fields
    //
    #region Private fields

    PrimeNumberCalculator primeNumberCalculator1;
    GroupBox taskGroupBox;
    ListView listView1;
    ColumnHeader taskIdColHeader;
    ColumnHeader progressColHeader;
    ColumnHeader currentColHeader;
    Panel buttonPanel;
    Panel panel2;
    Button startAsyncButton;
    Button cancelButton;
    ColumnHeader testNumberColHeader;
    ColumnHeader resultColHeader;
    ColumnHeader firstDivisorColHeader;
    IContainer _components;
    int progressCounter;
    readonly int progressInterval = 100;

    #endregion // Private fields

    /////////////////////////////////////////////////////////////
    // Construction and destruction
    //
    #region Private fields
    public PrimeNumberCalculatorMain()
    {
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();

        // Hook up event handlers.
        primeNumberCalculator1.CalculatePrimeCompleted +=

            primeNumberCalculator1_CalculatePrimeCompleted;

        primeNumberCalculator1.ProgressChanged +=
            new ProgressChangedEventHandler(
            primeNumberCalculator1_ProgressChanged);

        listView1.SelectedIndexChanged +=
             listView1_SelectedIndexChanged;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _components?.Dispose();
        }
        base.Dispose(disposing);
    }

    #endregion // Construction and destruction

    /////////////////////////////////////////////////////////////
    //
    #region Implementation

    // This event handler selects a number randomly to test
    // for primality. It then starts the asynchronous 
    // calculation by calling the PrimeNumberCalculator
    // component's CalculatePrimeAsync method.
    void startAsyncButton_Click(
        object sender, EventArgs e)
    {
        // Randomly choose test numbers 
        // up to 200,000 for primality.
        Random rand = new();
        int testNumber = rand.Next(200000);

        // Task IDs are Guids.
        Guid taskId = Guid.NewGuid();
        _ = AddListViewItem(taskId, testNumber);

        // Start the asynchronous task.
        primeNumberCalculator1.CalculatePrimeAsync(
            testNumber,
            taskId);
    }

    void listView1_SelectedIndexChanged(
        object sender,
        EventArgs e) =>
            cancelButton.Enabled = CanCancel();

    // This event handler cancels all pending tasks that are
    // selected in the ListView control.
    void cancelButton_Click(
        object sender,
        EventArgs e)
    {

        // Cancel all selected tasks.
        foreach (ListViewItem lvi in listView1.SelectedItems)
        {
            // Tasks that have been completed or canceled have 
            // their corresponding ListViewItem.Tag property
            // set to null.
            if (lvi.Tag != null)
            {
                Guid taskId = (Guid)lvi.Tag;
                primeNumberCalculator1.CancelAsync(taskId);
                lvi.Selected = false;
            }
        }

        cancelButton.Enabled = false;
    }

    // <snippet40>
    // This event handler updates the ListView control when the
    // PrimeNumberCalculator raises the ProgressChanged event.
    //
    // On fast computers, the PrimeNumberCalculator can raise many
    // successive ProgressChanged events, so the user interface 
    // may be flooded with messages. To prevent the user interface
    // from hanging, progress is only reported at intervals. 
    void primeNumberCalculator1_ProgressChanged(
        ProgressChangedEventArgs e)
    {
        if (progressCounter++ % progressInterval == 0)
        {
            Guid taskId = (Guid)e.UserState;

            if (e is CalculatePrimeProgressChangedEventArgs)
            {
                CalculatePrimeProgressChangedEventArgs cppcea =
                    e as CalculatePrimeProgressChangedEventArgs;

                _ = UpdateListViewItem(
                    taskId,
                    cppcea.ProgressPercentage,
                    cppcea.LatestPrimeNumber);
            }
            else
            {
                _ = UpdateListViewItem(
                    taskId,
                    e.ProgressPercentage);
            }
        }
        else if (progressCounter > progressInterval)
        {
            progressCounter = 0;
        }
    }
    // </snippet40>

    // <snippet12>
    // This event handler updates the ListView control when the
    // PrimeNumberCalculator raises the CalculatePrimeCompleted
    // event. The ListView item is updated with the appropriate
    // outcome of the calculation: Canceled, Error, or result.
    void primeNumberCalculator1_CalculatePrimeCompleted(
        object sender,
        CalculatePrimeCompletedEventArgs e)
    {
        Guid taskId = (Guid)e.UserState;

        if (e.Cancelled)
        {
            string result = "Canceled";

            ListViewItem lvi = UpdateListViewItem(taskId, result);

            if (lvi != null)
            {
                lvi.BackColor = Color.Pink;
                lvi.Tag = null;
            }
        }
        else if (e.Error != null)
        {
            string result = "Error";

            ListViewItem lvi = UpdateListViewItem(taskId, result);

            if (lvi != null)
            {
                lvi.BackColor = Color.Red;
                lvi.ForeColor = Color.White;
                lvi.Tag = null;
            }
        }
        else
        {
            bool result = e.IsPrime;

            ListViewItem lvi = UpdateListViewItem(
                taskId,
                result,
                e.FirstDivisor);

            if (lvi != null)
            {
                lvi.BackColor = Color.LightGray;
                lvi.Tag = null;
            }
        }
    }
    // </snippet12>

    #endregion // Implementation

    /////////////////////////////////////////////////////////////
    //
    #region Private Methods

    ListViewItem AddListViewItem(
        Guid guid,
        int testNumber)
    {
        ListViewItem lvi = new()
        {
            Text = testNumber.ToString(
                CultureInfo.CurrentCulture.NumberFormat)
        };

        _ = lvi.SubItems.Add("Not Started");
        _ = lvi.SubItems.Add("1");
        _ = lvi.SubItems.Add(guid.ToString());
        _ = lvi.SubItems.Add("---");
        _ = lvi.SubItems.Add("---");
        lvi.Tag = guid;

        _ = listView1.Items.Add(lvi);

        return lvi;
    }

    ListViewItem UpdateListViewItem(
        Guid guid,
        int percentComplete,
        int current)
    {
        ListViewItem lviRet = null;

        foreach (ListViewItem lvi in listView1.Items)
        {
            if (lvi.Tag != null)
            {
                if ((Guid)lvi.Tag == guid)
                {
                    lvi.SubItems[1].Text =
                        percentComplete.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);
                    lvi.SubItems[2].Text =
                        current.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);
                    lviRet = lvi;
                    break;
                }
            }
        }

        return lviRet;
    }

    ListViewItem UpdateListViewItem(
        Guid guid,
        int percentComplete,
        int current,
        bool result,
        int firstDivisor)
    {
        ListViewItem lviRet = null;

        foreach (ListViewItem lvi in listView1.Items)
        {
            if ((Guid)lvi.Tag == guid)
            {
                lvi.SubItems[1].Text =
                    percentComplete.ToString(
                    CultureInfo.CurrentCulture.NumberFormat);
                lvi.SubItems[2].Text =
                    current.ToString(
                    CultureInfo.CurrentCulture.NumberFormat);
                lvi.SubItems[4].Text =
                    result ? "Prime" : "Composite";
                lvi.SubItems[5].Text =
                    firstDivisor.ToString(
                    CultureInfo.CurrentCulture.NumberFormat);

                lviRet = lvi;

                break;
            }
        }

        return lviRet;
    }

    ListViewItem UpdateListViewItem(
        Guid guid,
        int percentComplete)
    {
        ListViewItem lviRet = null;

        foreach (ListViewItem lvi in listView1.Items)
        {
            if (lvi.Tag != null)
            {
                if ((Guid)lvi.Tag == guid)
                {
                    lvi.SubItems[1].Text =
                        percentComplete.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);
                    lviRet = lvi;
                    break;
                }
            }
        }

        return lviRet;
    }

    ListViewItem UpdateListViewItem(
        Guid guid,
        bool result,
        int firstDivisor)
    {
        ListViewItem lviRet = null;

        foreach (ListViewItem lvi in listView1.Items)
        {
            if (lvi.Tag != null)
            {
                if ((Guid)lvi.Tag == guid)
                {
                    lvi.SubItems[4].Text =
                        result ? "Prime" : "Composite";
                    lvi.SubItems[5].Text =
                        firstDivisor.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);
                    lviRet = lvi;
                    break;
                }
            }
        }

        return lviRet;
    }

    ListViewItem UpdateListViewItem(
        Guid guid,
        string result)
    {
        ListViewItem lviRet = null;

        foreach (ListViewItem lvi in listView1.Items)
        {
            if (lvi.Tag != null)
            {
                if ((Guid)lvi.Tag == guid)
                {
                    lvi.SubItems[4].Text = result;
                    lviRet = lvi;
                    break;
                }
            }
        }

        return lviRet;
    }

    bool CanCancel()
    {
        bool oneIsActive = false;

        foreach (ListViewItem lvi in listView1.SelectedItems)
        {
            if (lvi.Tag != null)
            {
                oneIsActive = true;
                break;
            }
        }

        return oneIsActive == true;
    }

    #endregion

    #region Windows Form Designer generated code

    void InitializeComponent()
    {
        _components = new Container();
        taskGroupBox = new GroupBox();
        buttonPanel = new Panel();
        cancelButton = new Button();
        startAsyncButton = new Button();
        listView1 = new ListView();
        testNumberColHeader = new ColumnHeader();
        progressColHeader = new ColumnHeader();
        currentColHeader = new ColumnHeader();
        taskIdColHeader = new ColumnHeader();
        resultColHeader = new ColumnHeader();
        firstDivisorColHeader = new ColumnHeader();
        panel2 = new Panel();
        primeNumberCalculator1 = new PrimeNumberCalculator(_components);
        taskGroupBox.SuspendLayout();
        buttonPanel.SuspendLayout();
        SuspendLayout();
        // 
        // taskGroupBox
        // 
        taskGroupBox.Controls.Add(buttonPanel);
        taskGroupBox.Controls.Add(listView1);
        taskGroupBox.Dock = DockStyle.Fill;
        taskGroupBox.Location = new Point(0, 0);
        taskGroupBox.Name = "taskGroupBox";
        taskGroupBox.Size = new Size(608, 254);
        taskGroupBox.TabIndex = 1;
        taskGroupBox.TabStop = false;
        taskGroupBox.Text = "Tasks";
        // 
        // buttonPanel
        // 
        buttonPanel.Controls.Add(cancelButton);
        buttonPanel.Controls.Add(startAsyncButton);
        buttonPanel.Dock = DockStyle.Bottom;
        buttonPanel.Location = new Point(3, 176);
        buttonPanel.Name = "buttonPanel";
        buttonPanel.Size = new Size(602, 75);
        buttonPanel.TabIndex = 1;
        // 
        // cancelButton
        // 
        cancelButton.Enabled = false;
        cancelButton.Location = new Point(128, 24);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(88, 23);
        cancelButton.TabIndex = 1;
        cancelButton.Text = "Cancel";
        cancelButton.Click += cancelButton_Click;
        // 
        // startAsyncButton
        // 
        startAsyncButton.Location = new Point(24, 24);
        startAsyncButton.Name = "startAsyncButton";
        startAsyncButton.Size = new Size(88, 23);
        startAsyncButton.TabIndex = 0;
        startAsyncButton.Text = "Start New Task";
        startAsyncButton.Click += startAsyncButton_Click;
        // 
        // listView1
        // 
        listView1.Columns.AddRange(new ColumnHeader[] {
                testNumberColHeader,
                progressColHeader,
                currentColHeader,
                taskIdColHeader,
                resultColHeader,
                firstDivisorColHeader});
        listView1.Dock = DockStyle.Fill;
        listView1.FullRowSelect = true;
        listView1.GridLines = true;
        listView1.Location = new Point(3, 16);
        listView1.Name = "listView1";
        listView1.Size = new Size(602, 160);
        listView1.TabIndex = 0;
        listView1.View = View.Details;
        // 
        // testNumberColHeader
        // 
        testNumberColHeader.Text = "Test Number";
        testNumberColHeader.Width = 80;
        // 
        // progressColHeader
        // 
        progressColHeader.Text = "Progress";
        // 
        // currentColHeader
        // 
        currentColHeader.Text = "Current";
        // 
        // taskIdColHeader
        // 
        taskIdColHeader.Text = "Task ID";
        taskIdColHeader.Width = 200;
        // 
        // resultColHeader
        // 
        resultColHeader.Text = "Result";
        resultColHeader.Width = 80;
        // 
        // firstDivisorColHeader
        // 
        firstDivisorColHeader.Text = "First Divisor";
        firstDivisorColHeader.Width = 80;
        // 
        // panel2
        // 
        panel2.Location = new Point(200, 128);
        panel2.Name = "panel2";
        panel2.TabIndex = 2;
        // 
        // PrimeNumberCalculatorMain
        // 
        ClientSize = new Size(608, 254);
        Controls.Add(taskGroupBox);
        Name = "PrimeNumberCalculatorMain";
        Text = "Prime Number Calculator";
        taskGroupBox.ResumeLayout(false);
        buttonPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
    #endregion

    [STAThread]
    static void Main() =>
        Application.Run(new PrimeNumberCalculatorMain());
}

// <snippet30>

/////////////////////////////////////////////////////////////
#region PrimeNumberCalculator Implementation

// <snippet7>
public delegate void ProgressChangedEventHandler(
    ProgressChangedEventArgs e);

public delegate void CalculatePrimeCompletedEventHandler(
    object sender,
    CalculatePrimeCompletedEventArgs e);
// </snippet7>

// This class implements the Event-based Asynchronous Pattern.
// It asynchronously computes whether a number is prime or
// composite (not prime).
public class PrimeNumberCalculator : Component
{
    // <snippet22>
    delegate void WorkerEventHandler(
        int numberToCheck,
        AsyncOperation asyncOp);
    // </snippet22>

    // <snippet9>
    SendOrPostCallback onProgressReportDelegate;
    SendOrPostCallback onCompletedDelegate;
    // </snippet9>

    // <snippet23>
    readonly HybridDictionary userStateToLifetime =
        [];
    // </snippet23>

    Container components;

    /////////////////////////////////////////////////////////////
    #region Public events

    // <snippet8>
    public event ProgressChangedEventHandler ProgressChanged;
    public event CalculatePrimeCompletedEventHandler CalculatePrimeCompleted;
    // </snippet8>

    #endregion

    /////////////////////////////////////////////////////////////
    #region Construction and destruction

    public PrimeNumberCalculator(IContainer container)
    {
        container.Add(this);
        InitializeComponent();

        InitializeDelegates();
    }

    // <snippet21>
    public PrimeNumberCalculator()
    {
        InitializeComponent();

        InitializeDelegates();
    }
    // </snippet21>

    // <snippet20>
    protected virtual void InitializeDelegates()
    {
        onProgressReportDelegate =
            new SendOrPostCallback(ReportProgress);
        onCompletedDelegate =
            new SendOrPostCallback(CalculateCompleted);
    }
    // </snippet20>

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    #endregion // Construction and destruction

    /////////////////////////////////////////////////////////////
    #region Implementation

    // <snippet3>
    // This method starts an asynchronous calculation. 
    // First, it checks the supplied task ID for uniqueness.
    // If taskId is unique, it creates a new WorkerEventHandler 
    // and calls its BeginInvoke method to start the calculation.
    public virtual void CalculatePrimeAsync(
        int numberToTest,
        object taskId)
    {
        // Create an AsyncOperation for taskId.
        AsyncOperation asyncOp =
            AsyncOperationManager.CreateOperation(taskId);

        // Multiple threads will access the task dictionary,
        // so it must be locked to serialize access.
        lock (userStateToLifetime.SyncRoot)
        {
            if (userStateToLifetime.Contains(taskId))
            {
                throw new ArgumentException(
                    "Task ID parameter must be unique",
                    nameof(taskId));
            }

            userStateToLifetime[taskId] = asyncOp;
        }

        // Start the asynchronous operation.
        WorkerEventHandler workerDelegate = new(CalculateWorker);
        _ = workerDelegate.BeginInvoke(
            numberToTest,
            asyncOp,
            null,
            null);
    }
    // </snippet3>

    // <snippet32>
    // Utility method for determining if a 
    // task has been canceled.
    bool TaskCanceled(object taskId) =>
        userStateToLifetime[taskId] == null;
    // </snippet32>

    // <snippet4>
    // This method cancels a pending asynchronous operation.
    public void CancelAsync(object taskId)
    {
        if (userStateToLifetime[taskId] is AsyncOperation)
        {
            lock (userStateToLifetime.SyncRoot)
            {
                userStateToLifetime.Remove(taskId);
            }
        }
    }
    // </snippet4>

    // <snippet27>
    // This method performs the actual prime number computation.
    // It is executed on the worker thread.
    void CalculateWorker(
        int numberToTest,
        AsyncOperation asyncOp)
    {
        bool isPrime = false;
        int firstDivisor = 1;
        Exception e = null;

        // Check that the task is still active.
        // The operation may have been canceled before
        // the thread was scheduled.
        if (!TaskCanceled(asyncOp.UserSuppliedState))
        {
            try
            {
                // Find all the prime numbers up to 
                // the square root of numberToTest.
                ArrayList primes = BuildPrimeNumberList(
                    numberToTest,
                    asyncOp);

                // Now we have a list of primes less than
                // numberToTest.
                isPrime = IsPrime(
                    primes,
                    numberToTest,
                    out firstDivisor);
            }
            catch (Exception ex)
            {
                e = ex;
            }
        }

        //CalculatePrimeState calcState = new CalculatePrimeState(
        //        numberToTest,
        //        firstDivisor,
        //        isPrime,
        //        e,
        //        TaskCanceled(asyncOp.UserSuppliedState),
        //        asyncOp);

        //this.CompletionMethod(calcState);

        CompletionMethod(
            numberToTest,
            firstDivisor,
            isPrime,
            e,
            TaskCanceled(asyncOp.UserSuppliedState),
            asyncOp);

        //completionMethodDelegate(calcState);
    }
    // </snippet27>

    // <snippet5>
    // This method computes the list of prime numbers used by the
    // IsPrime method.
    ArrayList BuildPrimeNumberList(
        int numberToTest,
        AsyncOperation asyncOp)
    {
        ArrayList primes = [];
        int n = 5;

        // Add the first prime numbers.
        _ = primes.Add(2);
        _ = primes.Add(3);

        // Do the work.
        while (n < numberToTest &&
               !TaskCanceled(asyncOp.UserSuppliedState))
        {
            if (IsPrime(primes, n, out int firstDivisor))
            {
                // Report to the client that a prime was found.
                ProgressChangedEventArgs e = new CalculatePrimeProgressChangedEventArgs(
                    n,
                    (int)(n / (float)numberToTest * 100),
                    asyncOp.UserSuppliedState);

                asyncOp.Post(onProgressReportDelegate, e);

                _ = primes.Add(n);

                // Yield the rest of this time slice.
                Thread.Sleep(0);
            }

            // Skip even numbers.
            n += 2;
        }

        return primes;
    }
    // </snippet5>

    // <snippet28>
    // This method tests n for primality against the list of 
    // prime numbers contained in the primes parameter.
    bool IsPrime(
        ArrayList primes,
        int n,
        out int firstDivisor)
    {
        bool foundDivisor = false;
        bool exceedsSquareRoot = false;

        int i = 0;
        firstDivisor = 1;

        // Stop the search if:
        // there are no more primes in the list,
        // there is a divisor of n in the list, or
        // there is a prime that is larger than 
        // the square root of n.
        while (
            (i < primes.Count) &&
            !foundDivisor &&
            !exceedsSquareRoot)
        {
            // The divisor variable will be the smallest 
            // prime number not yet tried.
            int divisor = (int)primes[i++];

            // Determine whether the divisor is greater
            // than the square root of n.
            if (divisor * divisor > n)
            {
                exceedsSquareRoot = true;
            }
            // Determine whether the divisor is a factor of n.
            else if (n % divisor == 0)
            {
                firstDivisor = divisor;
                foundDivisor = true;
            }
        }

        return !foundDivisor;
    }
    // </snippet28>

    // <snippet24>
    // This method is invoked via the AsyncOperation object,
    // so it is guaranteed to be executed on the correct thread.
    void CalculateCompleted(object operationState)
    {
        CalculatePrimeCompletedEventArgs e =
            operationState as CalculatePrimeCompletedEventArgs;

        OnCalculatePrimeCompleted(e);
    }

    // This method is invoked via the AsyncOperation object,
    // so it is guaranteed to be executed on the correct thread.
    void ReportProgress(object state)
    {
        ProgressChangedEventArgs e =
            state as ProgressChangedEventArgs;

        OnProgressChanged(e);
    }

    protected void OnCalculatePrimeCompleted(
        CalculatePrimeCompletedEventArgs e) =>
        CalculatePrimeCompleted?.Invoke(this, e);

    protected void OnProgressChanged(ProgressChangedEventArgs e) =>
        ProgressChanged?.Invoke(e);
    // </snippet24>

    // <snippet26>
    // This is the method that the underlying, free-threaded 
    // asynchronous behavior will invoke.  This will happen on
    // an arbitrary thread.
    void CompletionMethod(
        int numberToTest,
        int firstDivisor,
        bool isPrime,
        Exception exception,
        bool canceled,
        AsyncOperation asyncOp)

    {
        // If the task was not previously canceled,
        // remove the task from the lifetime collection.
        if (!canceled)
        {
            lock (userStateToLifetime.SyncRoot)
            {
                userStateToLifetime.Remove(asyncOp.UserSuppliedState);
            }
        }

        // Package the results of the operation in a 
        // CalculatePrimeCompletedEventArgs.
        CalculatePrimeCompletedEventArgs e =
            new(


                numberToTest,
                firstDivisor,
                isPrime,
                exception,
                canceled,
                asyncOp.UserSuppliedState);

        // End the task. The asyncOp object is responsible 
        // for marshaling the call.
        asyncOp.PostOperationCompleted(onCompletedDelegate, e);

        // Note that after the call to OperationCompleted, 
        // asyncOp is no longer usable, and any attempt to use it
        // will cause an exception to be thrown.
    }
    // </snippet26>

    #endregion

    /////////////////////////////////////////////////////////////
    #region Component Designer generated code

    void InitializeComponent() => components = new Container();

    #endregion

}

// <snippet29>
public class CalculatePrimeProgressChangedEventArgs :
        ProgressChangedEventArgs
{
    public CalculatePrimeProgressChangedEventArgs(
        int latestPrime,
        int progressPercentage,
        object userToken) : base(progressPercentage, userToken) => LatestPrimeNumber = latestPrime;

    public int LatestPrimeNumber { get; } = 1;
}
// </snippet29>

// <snippet6>
public class CalculatePrimeCompletedEventArgs :
    AsyncCompletedEventArgs
{
    readonly int numberToTestValue;
    readonly int firstDivisorValue = 1;
    readonly bool isPrimeValue;

    public CalculatePrimeCompletedEventArgs(
        int numberToTest,
        int firstDivisor,
        bool isPrime,
        Exception e,
        bool canceled,
        object state) : base(e, canceled, state)
    {
        numberToTestValue = numberToTest;
        firstDivisorValue = firstDivisor;
        isPrimeValue = isPrime;
    }

    public int NumberToTest
    {
        get
        {
            // Raise an exception if the operation failed or 
            // was canceled.
            RaiseExceptionIfNecessary();

            // If the operation was successful, return the 
            // property value.
            return numberToTestValue;
        }
    }

    public int FirstDivisor
    {
        get
        {
            // Raise an exception if the operation failed or 
            // was canceled.
            RaiseExceptionIfNecessary();

            // If the operation was successful, return the 
            // property value.
            return firstDivisorValue;
        }
    }

    public bool IsPrime
    {
        get
        {
            // Raise an exception if the operation failed or 
            // was canceled.
            RaiseExceptionIfNecessary();

            // If the operation was successful, return the 
            // property value.
            return isPrimeValue;
        }
    }
}

// </snippet6>

#endregion

// </snippet30>
// </snippet10>
