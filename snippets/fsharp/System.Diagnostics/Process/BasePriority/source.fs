// The following example starts an instance of Notepad. The example
// then retrieves and displays various properties of the associated
// process.  The example detects when the process exits, and displays
// the process's exit code.

// <Snippet1>
open System.Diagnostics

// Define variables to track the peak
// memory usage of the process.
let mutable peakPagedMem = 0L
let mutable peakWorkingSet = 0L
let mutable peakVirtualMem = 0L

// Start the process.
use myProcess = Process.Start "NotePad.exe"

// Display the process statistics until
// the user closes the program.
while myProcess.WaitForExit 1000 |> not do
    if not myProcess.HasExited then
        // Refresh the current process property values.
        myProcess.Refresh()

        printfn ""

        // Display current process statistics.

        printfn $"{myProcess} -"
        printfn "-------------------------------------"

        printfn $"  Physical memory usage     : {myProcess.WorkingSet64}"
        printfn $"  Base priority             : {myProcess.BasePriority}"
        printfn $"  Priority class            : {myProcess.PriorityClass}"
        printfn $"  User processor time       : {myProcess.UserProcessorTime}"
        printfn $"  Privileged processor time : {myProcess.PrivilegedProcessorTime}"
        printfn $"  Total processor time      : {myProcess.TotalProcessorTime}"
        printfn $"  Paged system memory size  : {myProcess.PagedSystemMemorySize64}"
        printfn $"  Paged memory size         : {myProcess.PagedMemorySize64}"

        // Update the values for the overall peak memory statistics.
        peakPagedMem <- myProcess.PeakPagedMemorySize64
        peakVirtualMem <- myProcess.PeakVirtualMemorySize64
        peakWorkingSet <- myProcess.PeakWorkingSet64

        if myProcess.Responding then
            printfn "Status = Running"
        else
            printfn "Status = Not Responding"

printfn ""
printfn $"  Process exit code          : {myProcess.ExitCode}"

// Display peak memory statistics for the process.
printfn $"  Peak physical memory usage : {peakWorkingSet}"
printfn $"  Peak paged memory usage    : {peakPagedMem}"
printfn $"  Peak virtual memory usage  : {peakVirtualMem}"
// </Snippet1>
