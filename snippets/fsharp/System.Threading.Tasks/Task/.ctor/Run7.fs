module Run7
// <Snippet7>
open System
open System.Collections.Generic
open System.Threading
open System.Threading.Tasks

let source = new CancellationTokenSource()
let token = source.Token
let mutable completedIterations = 0

let tasks =
    [| for _ = 0 to 19 do
           Task.Run(
               (fun () ->
                   let mutable iterations = 0

                   for _ = 1 to 2000000 do
                       token.ThrowIfCancellationRequested()
                       iterations <- iterations + 1

                   Interlocked.Increment &completedIterations |> ignore

                   if completedIterations >= 10 then
                       source.Cancel()

                   iterations),
               token
           )

       |]

printfn "Waiting for the first 10 tasks to complete...\n"

try
    tasks |> Seq.cast |> Array.ofSeq |> Task.WaitAll
with :? AggregateException ->
    printfn "Status of tasks:\n"
    printfn "%10s %20s %14s" "Task Id" "Status" "Iterations"

    for t in tasks do
        if t.Status <> TaskStatus.Canceled then
            t.Result.ToString "N0"
        else
            "n/a"
        |> printfn "%10i %20O %14s" t.Id t.Status


// The example displays output like the following:
//    Waiting for the first 10 tasks to complete...
//    Status of tasks:
//
//       Task Id               Status     Iterations
//             1      RanToCompletion      2,000,000
//             2      RanToCompletion      2,000,000
//             3      RanToCompletion      2,000,000
//             4      RanToCompletion      2,000,000
//             5      RanToCompletion      2,000,000
//             6      RanToCompletion      2,000,000
//             7      RanToCompletion      2,000,000
//             8      RanToCompletion      2,000,000
//             9      RanToCompletion      2,000,000
//            10             Canceled            n/a
//            11             Canceled            n/a
//            12             Canceled            n/a
//            13             Canceled            n/a
//            14             Canceled            n/a
//            15             Canceled            n/a
//            16      RanToCompletion      2,000,000
//            17             Canceled            n/a
//            18             Canceled            n/a
//            19             Canceled            n/a
//            20             Canceled            n/a
// </Snippet7>
