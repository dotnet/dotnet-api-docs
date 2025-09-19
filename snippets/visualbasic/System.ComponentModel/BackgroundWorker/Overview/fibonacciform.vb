' <snippet1>
' <snippet2>
Imports System.ComponentModel
Imports System.Windows.Forms
' </snippet2>

Public Class FibonacciForm
    Inherits Form

    ' <snippet14>
    Private numberToCompute As Integer = 0
    Private highestPercentageReached As Integer = 0
    ' </snippet14>

    Private numericUpDown1 As NumericUpDown
    Private WithEvents startAsyncButton As Button
    Private WithEvents cancelAsyncButton As Button
    Private progressBar1 As ProgressBar
    Private resultLabel As Label
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker


    Public Sub New()
        InitializeComponent()
    End Sub

    ' <snippet13>
    Private Sub startAsyncButton_Click(ByVal sender As System.Object,
    ByVal e As System.EventArgs) _
    Handles startAsyncButton.Click

        ' Reset the text in the result label.
        resultLabel.Text = [String].Empty

        ' Disable the UpDown control until 
        ' the asynchronous operation is done.
        numericUpDown1.Enabled = False

        ' Disable the Start button until 
        ' the asynchronous operation is done.
        startAsyncButton.Enabled = False

        ' Enable the Cancel button while 
        ' the asynchronous operation runs.
        cancelAsyncButton.Enabled = True

        ' Get the value from the UpDown control.
        numberToCompute = CInt(numericUpDown1.Value)

        ' Reset the variable for percentage tracking.
        highestPercentageReached = 0

        ' <snippet3>

        ' Start the asynchronous operation.
        backgroundWorker1.RunWorkerAsync(numberToCompute)
        ' </snippet3>
    End Sub
    ' </snippet13>

    ' <snippet4>
    Private Sub cancelAsyncButton_Click(
    ByVal sender As System.Object,
    ByVal e As System.EventArgs) _
    Handles cancelAsyncButton.Click

        ' Cancel the asynchronous operation.
        backgroundWorker1.CancelAsync()

        ' Disable the Cancel button.
        cancelAsyncButton.Enabled = False

    End Sub
    ' </snippet4>

    ' <snippet5>
    ' This event handler is where the actual work is done.
    Private Sub backgroundWorker1_DoWork(
    ByVal sender As Object,
    ByVal e As DoWorkEventArgs) _
    Handles backgroundWorker1.DoWork

        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker =
            CType(sender, BackgroundWorker)

        ' Assign the result of the computation
        ' to the Result property of the DoWorkEventArgs
        ' object. This is will be available to the 
        ' RunWorkerCompleted eventhandler.
        e.Result = ComputeFibonacci(e.Argument, worker, e)
    End Sub
    ' </snippet5>

    ' <snippet6>
    ' This event handler deals with the results of the
    ' background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted(
    ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
    Handles backgroundWorker1.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If (e.Error IsNot Nothing) Then
            MessageBox.Show(e.Error.Message)
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            resultLabel.Text = "Canceled"
        Else
            ' Finally, handle the case where the operation succeeded.
            resultLabel.Text = e.Result.ToString()
        End If

        ' Enable the UpDown control.
        numericUpDown1.Enabled = True

        ' Enable the Start button.
        startAsyncButton.Enabled = True

        ' Disable the Cancel button.
        cancelAsyncButton.Enabled = False
    End Sub
    ' </snippet6>

    ' <snippet7>
    ' This event handler updates the progress bar.
    Private Sub backgroundWorker1_ProgressChanged(
    ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
    Handles backgroundWorker1.ProgressChanged

        progressBar1.Value = e.ProgressPercentage

    End Sub
    ' </snippet7>

    ' <snippet10>
    ' This is the method that does the actual work. For this
    ' example, it computes a Fibonacci number and
    ' reports progress as it does its work.
    Function ComputeFibonacci(
        ByVal n As Integer,
        ByVal worker As BackgroundWorker,
        ByVal e As DoWorkEventArgs) As Long

        ' The parameter n must be >= 0 and <= 91.
        ' Fib(n), with n > 91, overflows a long.
        If n < 0 OrElse n > 91 Then
            Throw New ArgumentException(
                "value must be >= 0 and <= 91", "n")
        End If

        Dim result As Long = 0

        ' <snippet8>
        ' Abort the operation if the user has canceled.
        ' Note that a call to CancelAsync may have set 
        ' CancellationPending to true just after the
        ' last invocation of this method exits, so this 
        ' code will not have the opportunity to set the 
        ' DoWorkEventArgs.Cancel flag to true. This means
        ' that RunWorkerCompletedEventArgs.Cancelled will
        ' not be set to true in your RunWorkerCompleted
        ' event handler. This is a race condition.
        ' <snippet11>
        If worker.CancellationPending Then
            e.Cancel = True
            ' </snippet11>
        Else
            If n < 2 Then
                result = 1
            Else
                result = ComputeFibonacci(n - 1, worker, e) +
                         ComputeFibonacci(n - 2, worker, e)
            End If

            ' <snippet12>
            ' Report progress as a percentage of the total task.
            Dim percentComplete As Integer =
                CSng(n) / CSng(numberToCompute) * 100
            If percentComplete > highestPercentageReached Then
                highestPercentageReached = percentComplete
                worker.ReportProgress(percentComplete)
            End If
            ' </snippet12>

        End If
        ' </snippet8>

        Return result

    End Function
    ' </snippet10>


    Private Sub InitializeComponent()
        numericUpDown1 = New NumericUpDown
        startAsyncButton = New Button
        cancelAsyncButton = New Button
        resultLabel = New Label
        progressBar1 = New ProgressBar
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        CType(numericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'numericUpDown1
        '
        numericUpDown1.Location = New System.Drawing.Point(16, 16)
        numericUpDown1.Maximum = New Decimal(New Integer() {91, 0, 0, 0})
        numericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numericUpDown1.Name = "numericUpDown1"
        numericUpDown1.Size = New System.Drawing.Size(80, 20)
        numericUpDown1.TabIndex = 0
        numericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'startAsyncButton
        '
        startAsyncButton.Location = New System.Drawing.Point(16, 72)
        startAsyncButton.Name = "startAsyncButton"
        startAsyncButton.Size = New System.Drawing.Size(120, 23)
        startAsyncButton.TabIndex = 1
        startAsyncButton.Text = "Start Async"
        '
        'cancelAsyncButton
        '
        cancelAsyncButton.Enabled = False
        cancelAsyncButton.Location = New System.Drawing.Point(153, 72)
        cancelAsyncButton.Name = "cancelAsyncButton"
        cancelAsyncButton.Size = New System.Drawing.Size(119, 23)
        cancelAsyncButton.TabIndex = 2
        cancelAsyncButton.Text = "Cancel Async"
        '
        'resultLabel
        '
        resultLabel.BorderStyle = BorderStyle.Fixed3D
        resultLabel.Location = New System.Drawing.Point(112, 16)
        resultLabel.Name = "resultLabel"
        resultLabel.Size = New System.Drawing.Size(160, 23)
        resultLabel.TabIndex = 3
        resultLabel.Text = "(no result)"
        resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'progressBar1
        '
        progressBar1.Location = New System.Drawing.Point(18, 48)
        progressBar1.Name = "progressBar1"
        progressBar1.Size = New System.Drawing.Size(256, 8)
        progressBar1.TabIndex = 4
        '
        'backgroundWorker1
        '
        backgroundWorker1.WorkerReportsProgress = True
        backgroundWorker1.WorkerSupportsCancellation = True
        '
        'FibonacciForm
        '
        ClientSize = New System.Drawing.Size(292, 118)
        Controls.Add(progressBar1)
        Controls.Add(resultLabel)
        Controls.Add(cancelAsyncButton)
        Controls.Add(startAsyncButton)
        Controls.Add(numericUpDown1)
        Name = "FibonacciForm"
        Text = "Fibonacci Calculator"
        CType(numericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New FibonacciForm)
    End Sub
End Class

' </snippet1>
