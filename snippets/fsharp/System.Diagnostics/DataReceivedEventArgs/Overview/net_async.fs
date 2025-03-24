module netasync
// System.Diagnostics
//
// Requires .NET Framework version 1.2 or higher.

// The following example uses the net view command to list the
// available network resources available on a remote computer,
// and displays the results to the console. Specifying the optional
// error log file redirects error output to that file.

// <Snippet2>
// Define the namespaces used by this sample.
open System
open System.Text
open System.Globalization
open System.IO
open System.Diagnostics

// Define variables shared by functions.
let mutable streamError = Unchecked.defaultof<StreamWriter>
let mutable netErrorFile = ""
let mutable netOutput = StringBuilder()
let mutable errorRedirect = false
let mutable errorsWritten = false

let netOutputDataHandler (sendingProcess: obj) (outLine: DataReceivedEventArgs) =
    // Collect the net view command output.
    if String.IsNullOrEmpty outLine.Data |> not then
        // Add the text to the collected output.
        netOutput.Append(Environment.NewLine + "  " + outLine.Data) |> ignore

let netErrorDataHandler (sendingProcess: obj) (errLine: DataReceivedEventArgs) =
    // Write the error text to the file if there is something
    // to write and an error file has been specified.

    if String.IsNullOrEmpty errLine.Data |> not then
        if not errorsWritten then
            if isNull streamError then
                // Open the file.
                try
                    streamError <- new StreamWriter(netErrorFile, true)
                with e ->
                    printfn "Could not open error file!"
                    printfn $"{e.Message}"

            if isNull streamError |> not then
                // Write a header to the file if this is the first
                // call to the error output handler.
                streamError.WriteLine()
                streamError.WriteLine DateTime.Now
                streamError.WriteLine "Net View error output:"

            errorsWritten <- true

        if isNull streamError |> not then
            // Write redirected errors to the file.
            streamError.WriteLine errLine.Data
            streamError.Flush()


let redirectNetCommandStreams () =
    // Get the input computer name.
    printfn "Enter the computer name for the net view command:"
    let netArguments = stdin.ReadLine().ToUpper CultureInfo.InvariantCulture
    // Default to the help command if there is not an input argument.
    let netArguments =
        if String.IsNullOrEmpty netArguments then
            "/?"
        else
            netArguments

    // Check if errors should be redirected to a file.
    errorsWritten <- false
    printfn "Enter a fully qualified path to an error log file"
    printfn "  or just press Enter to write errors to console:"
    netErrorFile <- stdin.ReadLine().ToUpper CultureInfo.InvariantCulture

    if String.IsNullOrEmpty netErrorFile |> not then
        errorRedirect <- true

    // Note that at this point, netArguments and netErrorFile
    // are set with user input.  If the user did not specify
    // an error file, then errorRedirect is set to false.

    // Initialize the process and its StartInfo properties.
    let netProcess = new Process()
    netProcess.StartInfo.FileName <- "Net.exe"

    // Build the net command argument list.
    netProcess.StartInfo.Arguments <- $"view {netArguments}"

    // Set UseShellExecute to false for redirection.
    netProcess.StartInfo.UseShellExecute <- false

    // Redirect the standard output of the net command.
    // This stream is read asynchronously using an event handler.
    netProcess.StartInfo.RedirectStandardOutput <- true
    netProcess.OutputDataReceived.AddHandler(DataReceivedEventHandler netOutputDataHandler)
    netOutput <- new StringBuilder()

    if errorRedirect then
        // Redirect the error output of the net command.
        netProcess.StartInfo.RedirectStandardError <- true
        netProcess.ErrorDataReceived.AddHandler(DataReceivedEventHandler netErrorDataHandler)
    else
        // Do not redirect the error output.
        netProcess.StartInfo.RedirectStandardError <- false

    printfn $"\nStarting process: net {netProcess.StartInfo.Arguments}"

    if errorRedirect then
        printfn $"Errors will be written to the file {netErrorFile}"

    // Start the process.
    netProcess.Start() |> ignore

    // Start the asynchronous read of the standard output stream.
    netProcess.BeginOutputReadLine()

    if errorRedirect then
        // Start the asynchronous read of the standard error stream.
        netProcess.BeginErrorReadLine()

    // Let the net command run, collecting the output.
    netProcess.WaitForExit()

    if streamError <> null then
        // Close the error file.
        streamError.Close()
    else
        // Set errorsWritten to false if the stream is not
        // open.   Either there are no errors, or the error
        // file could not be opened.
        errorsWritten <- false

    if netOutput.Length > 0 then
        // If the process wrote more than just
        // white space, write the output to the console.
        printfn $"\nPublic network shares from net view:\n{netOutput}\n"

    if errorsWritten then
        // Signal that the error file had something
        // written to it.
        let errorOutput = File.ReadAllLines netErrorFile

        if errorOutput.Length > 0 then
            printfn $"\nThe following error output was appended to {netErrorFile}."

            for errLine in errorOutput do
                printfn $"  {errLine}"

        printfn ""

    netProcess.Close()

// </Snippet2>
