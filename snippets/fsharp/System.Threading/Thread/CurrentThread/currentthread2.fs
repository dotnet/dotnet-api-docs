// <Snippet1>
open System
open System.Threading
open System.Threading.Tasks

let lockObj = obj ()
let rndLock = obj ()

let showThreadInformation taskName =
    let thread = Thread.CurrentThread

    lock lockObj (fun () ->
        printfn
            $"{taskName} thread information\n   Background: {thread.IsBackground}\n   Thread Pool: {thread.IsThreadPoolThread}\n   Thread ID: {thread.ManagedThreadId}\n")

let rnd = Random()
showThreadInformation "Application"

let t =
    Task.Run(fun () ->
        showThreadInformation $"Main Task(Task #{Task.CurrentId})"

        let tasks =
            [| for _ = 1 to 20 do
                   Task.Factory.StartNew(fun () ->
                       showThreadInformation $"Task #{Task.CurrentId}"
                       let mutable s = 0L

                       for n = 0 to 999999 do
                           lock rndLock (fun () -> s <- s + (rnd.Next(1, 1000001) |> int64))

                       float s / 1000000.) |]

        Task.WaitAll(box tasks :?> Task[])
        let mutable grandTotal = 0.
        printfn "Means of each task: "

        for child in tasks do
            printfn $"   {child.Result}"
            grandTotal <- grandTotal + child.Result

        printfn ""
        grandTotal / 20.)

printfn $"Mean of Means: {t.Result}"

// The example displays output like the following:
//       Application thread information
//          Background: False
//          Thread Pool: False
//          Thread ID: 1
//
//       Main Task(Task #1) thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 3
//
//       Task #2 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 4
//
//       Task #4 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 10
//
//       Task #3 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 9
//
//       Task #5 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 3
//
//       Task #7 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 5
//
//       Task #6 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 7
//
//       Task #8 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 6
//
//       Task #9 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 8
//
//       Task #10 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 9
//
//       Task #11 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 10
//
//       Task #12 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 6
//
//       Task #13 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 4
//
//       Task #14 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 3
//
//       Task #15 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 7
//
//       Task #16 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 5
//
//       Task #17 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 8
//
//       Task #18 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 9
//
//       Task #19 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 10
//
//       Task #20 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 4
//
//       Task #21 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 7
//
//       Means of each task:
//          500038.740584
//          499810.422703
//          500217.558077
//          499868.534688
//          499295.505866
//          499893.475772
//          499601.454469
//          499828.532502
//          499606.183978
//          499700.276056
//          500415.894952
//          500005.874751
//          500042.237016
//          500092.764753
//          499998.798267
//          499623.054718
//          500018.784823
//          500286.865993
//          500052.68285
//          499764.363303
//
//       Mean of Means: 499908.10030605
// </Snippet1>
