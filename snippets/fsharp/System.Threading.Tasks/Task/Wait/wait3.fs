module wait3
// <Snippet3>
open System
open System.Threading
open System.Threading.Tasks

let ts = new CancellationTokenSource()

let t =
    Task.Run(fun () ->
        printfn "Calling Cancel..."
        ts.Cancel()
        Task.Delay(5000).Wait()
        printfn $"Task ended delay...")

try
    printfn "About to wait for the task to complete..."
    t.Wait ts.Token

with :? OperationCanceledException as e ->
    printfn $"{e.GetType().Name}: The wait has been canceled. Task status: {t.Status:G}"
    Thread.Sleep 6000
    printfn $"After sleeping, the task status:  {t.Status:G}"

ts.Dispose()


// The example displays output like the following:
//    About to wait for the task to complete...
//    Calling Cancel...
//    OperationCanceledException: The wait has been canceled. Task status: Running
//    Task ended delay...
//    After sleeping, the task status:  RanToCompletion
// </Snippet3>
