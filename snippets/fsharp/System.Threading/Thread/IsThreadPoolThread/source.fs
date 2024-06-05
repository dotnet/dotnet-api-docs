// <Snippet1>
open System.Threading

// <Snippet2>
let threadMethod () =
    printfn
        $"""ThreadOne, executing ThreadMethod, is {if Thread.CurrentThread.IsThreadPoolThread then
                                                       ""
                                                   else
                                                       "not "}from the thread pool."""
// </Snippet2>

let workMethod stateInfo =
    printfn
        $"""ThreadTwo, executing WorkMethod, is {if Thread.CurrentThread.IsThreadPoolThread then
                                                     ""
                                                 else
                                                     "not "}from the thread pool."""

    // Signal that this thread is finished.
    (unbox<AutoResetEvent> stateInfo).Set() |> ignore

let autoEvent = new AutoResetEvent false

let regularThread = Thread threadMethod
regularThread.Start()
ThreadPool.QueueUserWorkItem(workMethod, autoEvent) |> ignore

// Wait for foreground thread to end.
regularThread.Join()

// Wait for background thread to end.
autoEvent.WaitOne() |> ignore
// </Snippet1>
