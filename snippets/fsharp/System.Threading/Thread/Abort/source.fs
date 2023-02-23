// <Snippet1>
open System.Threading

let testMethod () =
    try
        while true do
            printfn "New thread running."
            Thread.Sleep 1000
    with :? ThreadAbortException as abortException ->
        printfn $"{abortException.ExceptionState :?> string}"

let newThread = Thread testMethod
newThread.Start()
Thread.Sleep 1000

// Abort newThread.
printfn "Main aborting new thread."
newThread.Abort "Information from Main."

// Wait for the thread to terminate.
newThread.Join()
printfn "New thread terminated - Main exiting."

// </Snippet1>
