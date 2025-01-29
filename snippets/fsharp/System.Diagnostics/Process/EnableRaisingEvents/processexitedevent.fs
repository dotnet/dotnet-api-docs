//<snippet1>
open System
open System.Diagnostics
open System.Threading.Tasks

let mutable myProcess = new Process()
let mutable eventHandled = TaskCompletionSource<bool>()

// Handle Exited event and display process information.
let myProcess_Exited (sender: obj) (e: EventArgs) =
    printfn $"Exit time    : {myProcess.ExitTime}\n"
    printfn $"Exit code    : {myProcess.ExitCode}\n"
    printfn $"Elapsed time : {round ((myProcess.ExitTime - myProcess.StartTime).TotalMilliseconds)}"
    eventHandled.TrySetResult true |> ignore

// Print a file with any known extension.
let printDoc fileName =
    task {
        eventHandled <- TaskCompletionSource<bool>()

        use myProcess = new Process()

        try
            // Start a process to print a file and raise an event when done.
            myProcess.StartInfo.FileName <- fileName
            myProcess.StartInfo.Verb <- "Print"
            myProcess.StartInfo.CreateNoWindow <- true
            myProcess.EnableRaisingEvents <- true
            myProcess.Exited.AddHandler(EventHandler myProcess_Exited)
            myProcess.Start() |> ignore
        with ex ->
            printfn $"An error occurred trying to print \"{fileName}\":\n{ex.Message}"

        // Wait for Exited event, but not more than 30 seconds.
        let! _ = Task.WhenAny(eventHandled.Task, Task.Delay(30000))
        ()
    }

[<EntryPoint>]
let main args =
    // Verify that an argument has been entered.
    if args.Length <= 0 then
        printfn "Enter a file name."
    else
        // Create the process and print the document.
        printDoc(args[0]).Wait() |> ignore

    0
//</snippet1>
