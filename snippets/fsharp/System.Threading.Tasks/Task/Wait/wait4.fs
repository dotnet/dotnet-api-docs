module wait4
// <Snippet4>
open System
open System.Threading
open System.Threading.Tasks

let cancelToken (obj: obj) =
    Thread.Sleep 1500
    printfn $"Canceling the cancellation token from thread {Thread.CurrentThread.ManagedThreadId}..."

    match obj with
    | :? CancellationTokenSource as source -> source.Cancel()
    | _ -> ()

let ts = new CancellationTokenSource()
let thread = Thread(ParameterizedThreadStart cancelToken)
thread.Start ts

let t =
    Task.Run(fun () ->
        Task.Delay(5000).Wait()
        printfn "Task ended delay...")

try
    printfn $"About to wait completion of task {t.Id}"
    let result = t.Wait(1510, ts.Token)
    printfn $"Wait completed normally: {result}"
    printfn $"The task status:  {t.Status:G}"

with :? OperationCanceledException as e ->
    printfn $"{e.GetType().Name}: The wait has been canceled. Task status: {t.Status:G}"
    Thread.Sleep 4000
    printfn $"After sleeping, the task status:  {t.Status:G}"
    ts.Dispose()

// The example displays output like the following if the wait is canceled by
// the cancellation token:
//    About to wait completion of task 1
//    Canceling the cancellation token from thread 3...
//    OperationCanceledException: The wait has been canceled. Task status: Running
//    Task ended delay...
//    After sleeping, the task status:  RanToCompletion
// The example displays output like the following if the wait is canceled by
// the timeout interval expiring:
//    About to wait completion of task 1
//    Wait completed normally: False
//    The task status:  Running
//    Canceling the cancellation token from thread 3...
// </Snippet4>
