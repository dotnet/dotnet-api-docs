module nmakeasync
// System.Diagnostics
//
// Requires .NET Framework version 1.2 or higher.

// Define the namespaces used by this sample.
open System
open System.Text
open System.IO
open System.Diagnostics
open System.Threading

// <Snippet3>
// Define static variables shared by class methods.
let mutable buildLogStream = Unchecked.defaultof<StreamWriter>
let logMutex = new Mutex()
let mutable maxLogLines = 25
let mutable currentLogLines = 0

let logToFile logPrefix logText echoToConsole =
    // Write the specified line to the log file stream.
    let logString = StringBuilder()

    if String.IsNullOrEmpty logPrefix |> not then
        logString.AppendFormat $"{logPrefix}> " |> ignore

    if String.IsNullOrEmpty logPrefix |> not then
        logString.AppendFormat $"{logPrefix}> " |> ignore

    if String.IsNullOrEmpty logText |> not then
        logString.Append logText |> ignore

    if isNull buildLogStream |> not then
        buildLogStream.WriteLine $"[{DateTime.Now}] {logString}"
        buildLogStream.Flush()

    if echoToConsole then
        printfn $"{logString}"

let nMakeOutputDataHandler (sendingProcess: obj) (outLine: DataReceivedEventArgs) =
    // Collect the output, displaying it to the screen and
    // logging it to the output file.  Cancel the read
    // operation when the maximum line limit is reached.
    if String.IsNullOrEmpty outLine.Data |> not then
        logMutex.WaitOne() |> ignore

        currentLogLines <- currentLogLines + 1

        if currentLogLines > maxLogLines then
            // Display the line to the console.
            // Skip writing the line to the log file.
            Console.WriteLine("StdOut: {0}", outLine.Data)
        elif currentLogLines = maxLogLines then
            logToFile "StdOut" "<Max build log limit reached!>" true

            // Stop reading the output streams.
            match sendingProcess with
            | :? Process as p ->
                p.CancelOutputRead()
                p.CancelErrorRead()
            | _ -> ()
        else
            // Write the line to the log file.
            logToFile "StdOut" outLine.Data true

        logMutex.ReleaseMutex()

let nMakeErrorDataHandler (sendingProcess: obj) (errLine: DataReceivedEventArgs) =
    // Collect error output, displaying it to the screen and
    // logging it to the output file.  Cancel the error output
    // read operation when the maximum line limit is reached.
    if String.IsNullOrEmpty errLine.Data |> not then
        logMutex.WaitOne() |> ignore

        currentLogLines <- currentLogLines + 1

        if currentLogLines > maxLogLines then
            // Display the error line to the console.
            // Skip writing the line to the log file.
            printfn $"StdErr: {errLine.Data}"
        elif currentLogLines = maxLogLines then
            logToFile "StdErr" "<Max build log limit reached!>" true

            // Stop reading the output streams
            match sendingProcess with
            | :? Process as p ->
                p.CancelErrorRead()
                p.CancelOutputRead()
            | _ -> ()
        else
            // Write the line to the log file.
            logToFile "StdErr" errLine.Data true

        logMutex.ReleaseMutex()

let redirectNMakeCommandStreams () =
    // Get the input nmake command-line arguments.
    printfn "Enter the NMake command line arguments (@commandfile or /f makefile, etc):"
    let nmakeArguments = stdin.ReadLine()

    printfn "Enter max line limit for log file (default is 25):"
    let inputText = Console.ReadLine()

    if String.IsNullOrEmpty inputText |> not then
        if Int32.TryParse(inputText, &maxLogLines) |> not then
            maxLogLines <- 25

    printfn $"Output beyond {maxLogLines} lines will be ignored."

    // Initialize the process and its StartInfo properties.
    let nmakeProcess = new Process()
    nmakeProcess.StartInfo.FileName <- "NMake.exe"

    // Build the nmake command argument list.
    if String.IsNullOrEmpty nmakeArguments |> not then
        nmakeProcess.StartInfo.Arguments <- nmakeArguments

    // Set UseShellExecute to false for redirection.
    nmakeProcess.StartInfo.UseShellExecute <- false

    // Redirect the standard output of the nmake command.
    // Read the stream asynchronously using an event handler.
    nmakeProcess.StartInfo.RedirectStandardOutput <- true
    nmakeProcess.OutputDataReceived.AddHandler(DataReceivedEventHandler nMakeOutputDataHandler)

    // Redirect the error output of the nmake command.
    nmakeProcess.StartInfo.RedirectStandardError <- true
    nmakeProcess.ErrorDataReceived.AddHandler(DataReceivedEventHandler nMakeErrorDataHandler)

    logMutex.WaitOne() |> ignore

    currentLogLines <- 0

    // Write a header to the log file.
    let buildLogFile = "NmakeCmd.Txt"

    try
        buildLogStream <- new StreamWriter(buildLogFile, true)
    with e ->
        printfn $"Could not open output file {buildLogFile}"
        printfn $"Exception = {e}"
        printfn $"{e.Message}"

        buildLogStream <- null

    if isNull buildLogStream |> not then
        printfn $"Nmake output logged to {buildLogFile}"

        buildLogStream.WriteLine()
        buildLogStream.WriteLine DateTime.Now

        if String.IsNullOrEmpty nmakeArguments |> not then
            buildLogStream.Write $"Command line = NMake {nmakeArguments}"
        else
            buildLogStream.Write "Command line = Nmake"

        buildLogStream.WriteLine()
        buildLogStream.Flush()

        logMutex.ReleaseMutex()

        // Start the process.
        Console.WriteLine("\n\nStarting Nmake command...\n")
        nmakeProcess.Start() |> ignore

        // Start the asynchronous read of the error stream.
        nmakeProcess.BeginErrorReadLine()

        // Start the asynchronous read of the output stream.
        nmakeProcess.BeginOutputReadLine()

        // Let the nmake command run, collecting the output.
        nmakeProcess.WaitForExit()

        nmakeProcess.Close()
        buildLogStream.Close()
        logMutex.Dispose()
// </Snippet3>
