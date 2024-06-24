module sortasync
// System.Diagnostics
//
// Requires .NET Framework version 1.2 or higher.

// The following example uses the sort command to sort a list
// of input text lines, and displays the sorted list to the console.

// <Snippet1>
// Define the namespaces used by this sample.
open System
open System.Text
open System.Diagnostics

// Define variables shared by class methods.
let mutable sortOutput = StringBuilder()
let mutable numOutputLines = 0;

let sortOutputHandler (sendingProcess: obj) (outLine: DataReceivedEventArgs) =
    // Collect the sort command output.
    if String.IsNullOrEmpty outLine.Data |> not then
        numOutputLines <- numOutputLines + 1
        // Add the text to the collected output.
        sortOutput.Append(Environment.NewLine + $"[{numOutputLines}] - {outLine.Data}") |> ignore

let sortInputListText () =
    // Initialize the process and its StartInfo properties.
    // The sort command is a console application that
    // reads and sorts text input.

    let sortProcess = new Process();
    sortProcess.StartInfo.FileName <- "Sort.exe"

    // Set UseShellExecute to false for redirection.
    sortProcess.StartInfo.UseShellExecute <- false;

    // Redirect the standard output of the sort command.
    // This stream is read asynchronously using an event handler.
    sortProcess.StartInfo.RedirectStandardOutput <- true;
    sortOutput <- StringBuilder();

    // Set our event handler to asynchronously read the sort output.
    sortProcess.OutputDataReceived.AddHandler sortOutputHandler

    // Redirect standard input as well.  This stream
    // is used synchronously.
    sortProcess.StartInfo.RedirectStandardInput <- true;

    // Start the process.
    sortProcess.Start() |> ignore

    // Use a stream writer to synchronously write the sort input.
    let sortStreamWriter = sortProcess.StandardInput;

    // Start the asynchronous read of the sort output stream.
    sortProcess.BeginOutputReadLine();

    // Prompt the user for input text lines.  Write each
    // line to the redirected input stream of the sort command.
    printfn "Ready to sort up to 50 lines of text"

    let mutable inputText = ""
    let mutable numInputLines = 0
    while String.IsNullOrEmpty inputText do
        printfn "Enter a text line (or press the Enter key to stop):"

        inputText <- Console.ReadLine()
        if String.IsNullOrEmpty inputText |> not then
            numInputLines <- numInputLines + 1
            sortStreamWriter.WriteLine inputText

    printfn "<end of input stream>\n"

    // End the input stream to the sort command.
    sortStreamWriter.Close()

    // Wait for the sort process to write the sorted text lines.
    sortProcess.WaitForExit()

    if numOutputLines > 0 then
        // Write the formatted and sorted output to the console.
        printfn $" Sort results = {numOutputLines} sorted text line(s) "
        printfn "----------"
        printfn $"{sortOutput}"
    else
        printfn " No input lines were sorted."

    sortProcess.Close();

// The main entry point for the application.
do
    try
        sortInputListText ()
    with :? InvalidOperationException as e ->
        printfn "Exception:"
        printfn $"{e}"
// </Snippet1>
