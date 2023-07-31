module delay4
// <Snippet4>
open System
open System.Threading
open System.Threading.Tasks

let source = new CancellationTokenSource()

let t =
    Task.Run<int>(fun () ->
        task {

            do! Task.Delay(TimeSpan.FromSeconds(1.5), source.Token)
            return 42
        })

source.Cancel()

try
    t.Wait()

with :? AggregateException as ae ->
    for e in ae.InnerExceptions do
        printfn $"{e.GetType().Name}: {e.Message}"

printf $"Task t Status: {t.Status}"

if t.Status = TaskStatus.RanToCompletion then
    printf $", Result: {t.Result}"

source.Dispose()

// The example displays output like the following:
//       TaskCanceledException: A task was canceled.
//       Task t Status: Canceled
// </Snippet4>
