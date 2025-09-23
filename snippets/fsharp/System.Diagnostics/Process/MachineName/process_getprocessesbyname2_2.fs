// <Snippet1>
// <Snippet2>
open System
open System.Diagnostics

printfn "Create notepad processes on remote computer"
printf "Enter remote computer name : "
let remoteMachineName = stdin.ReadLine()

if isNull remoteMachineName then
    // Prepend a new line to prevent it from being on the same line as the prompt.
    printfn "\nYou have to enter a remote computer name."
else
    try
        // Get all notepad processess into Process array.
        let myProcesses = Process.GetProcessesByName("notepad", remoteMachineName)

        if myProcesses.Length = 0 then
            printfn "Could not find notepad processes on remote computer."

        for myProcess in myProcesses do
            printfn $"Process Name : {myProcess.ProcessName}\n"
            printfn $"Process ID   : {myProcess.Id}\n"
            printfn $"MachineName  : {myProcess.MachineName}"
    with
    | :? ArgumentException -> printfn $"The value '{remoteMachineName}' is an invalid remote computer name."
    | :? InvalidOperationException -> printfn "Unable to get process information on the remote computer."
    | :? PlatformNotSupportedException ->
        printfn "Finding notepad processes on remote computers is not supported on this operating system."
// </Snippet1>
// </Snippet2>
