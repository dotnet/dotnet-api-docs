module whenall1
// <Snippet1>
open System
open System.Threading.Tasks

let tasks =
    [| for i = 1 to 10 do
           let delayInterval = 18 * i

           task {
               let mutable total = 0L
               do! Task.Delay delayInterval
               let rnd = Random()

               for _ = 1 to 1000 do
                   total <- total + (rnd.Next(0, 1000) |> int64)

               return total
           } |]

let continuation = Task.WhenAll tasks

try
    continuation.Wait()

with :? AggregateException ->
    ()

if continuation.Status = TaskStatus.RanToCompletion then
    for result in continuation.Result do
        printfn $"Mean: {float result / 1000.:N2}, n = 1,000"

    let grandTotal = continuation.Result |> Array.sum

    printfn $"\nMean of Means: {float grandTotal / 10000.:N2}, n = 10,000"

// Display information on faulted tasks.
else
    for t in tasks do
        printfn $"Task {t.Id}: {t.Status}"

// The example displays output like the following:
//       Mean: 506.34, n = 1,000
//       Mean: 504.69, n = 1,000
//       Mean: 489.32, n = 1,000
//       Mean: 505.96, n = 1,000
//       Mean: 515.31, n = 1,000
//       Mean: 499.94, n = 1,000
//       Mean: 496.92, n = 1,000
//       Mean: 508.58, n = 1,000
//       Mean: 494.88, n = 1,000
//       Mean: 493.53, n = 1,000
//
//       Mean of Means: 501.55, n = 10,000
// </Snippet1>
