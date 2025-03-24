// System.Diagnostics.Process.WorkingSet
// System.Diagnostics.Process.BasePriority
// System.Diagnostics.Process.UserProcessorTime
// System.Diagnostics.Process.PrivilegedProcessorTime
// System.Diagnostics.Process.TotalProcessorTime
// System.Diagnostics.Process.ToString
// System.Diagnostics.Process.Responding
// System.Diagnostics.Process.PriorityClass
// System.Diagnostics.Process.ExitCode

// The following example starts an instance of Notepad. The example
// then retrieves and displays various properties of the associated
// process.  The example detects when the process exits, and displays the process's exit code.

// <Snippet1>
open System.Diagnostics
open System.Threading

try
    use myProcess = Process.Start "NotePad.exe"

    while not myProcess.HasExited do
        printfn ""

        printfn $"Physical memory usage     : {myProcess.WorkingSet64}"
        printfn $"Base priority             : {myProcess.BasePriority}"
        printfn $"Priority class            : {myProcess.PriorityClass}"
        printfn $"User processor time       : {myProcess.UserProcessorTime}"
        printfn $"Privileged processor time : {myProcess.PrivilegedProcessorTime}"
        printfn $"Total processor time      : {myProcess.TotalProcessorTime}"
        printfn $"Process's Name            : {myProcess}"
        printfn "-------------------------------------"

        if myProcess.Responding then
            printfn "Status:  Responding to user interface"
            myProcess.Refresh()
        else
            printfn "Status:  Not Responding"

        Thread.Sleep 1000

    printfn ""
    printfn $"Process exit code: {myProcess.ExitCode}"
with e ->
    printfn $"The following exception was raised: {e.Message}"
// </Snippet1>
