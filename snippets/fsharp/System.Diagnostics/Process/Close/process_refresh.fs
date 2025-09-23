// System.Diagnostics.Process.Refresh
// System.Diagnostics.Process.HasExited
// System.Diagnostics.Process.Close
// System.Diagnostics.Process.CloseMainWindow

// The following example starts an instance of Notepad. It then
// retrieves the physical memory usage of the associated process at
// 2 second intervals for a maximum of 10 seconds. The example detects
// whether the process exits before 10 seconds have elapsed.
// The example closes the process if it is still running after
// 10 seconds.

// <Snippet1>
open System.ComponentModel
open System.Diagnostics
open System.IO
open System.Threading


try
    use myProcess = Process.Start "Notepad.exe"
    // Display physical memory usage 5 times at intervals of 2 seconds.
    let mutable i = 0

    while i < 5 && not myProcess.HasExited do
        // Discard cached information about the process.
        myProcess.Refresh()
        // Print working set to console.
        printfn $"Physical Memory Usage: {myProcess.WorkingSet64}"
        // Wait 2 seconds.
        Thread.Sleep 2000
        i <- i + 1
    // Close process by sending a close message to its main window.
    myProcess.CloseMainWindow() |> ignore
    // Free resources associated with process.
    myProcess.Close()
with
| :? Win32Exception
| :? FileNotFoundException as e ->
    printfn "The following exception was raised: "
    printfn $"{e.Message}"
// </Snippet1>
