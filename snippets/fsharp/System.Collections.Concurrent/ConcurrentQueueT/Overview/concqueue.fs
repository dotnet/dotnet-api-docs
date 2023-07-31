//<snippet1>
open System
open System.Collections.Concurrent
open System.Threading
open System.Threading.Tasks

// Demonstrates:
// ConcurrentQueue<T>.Enqueue()
// ConcurrentQueue<T>.TryPeek()
// ConcurrentQueue<T>.TryDequeue()

// Construct a ConcurrentQueue.
let cq = ConcurrentQueue<int>()

// Populate the queue.
for i = 0 to 9999 do
    cq.Enqueue i

// Peek at the first element.
let mutable result = 0

if cq.TryPeek &result |> not then
    printfn "CQ: TryPeek failed when it should have succeeded"
elif result <> 0 then
    printfn $"CQ: Expected TryPeek result of 0, got {result}"

let mutable outerSum = 0
// An action to consume the ConcurrentQueue.
let action =
    Action(fun () ->
        let mutable localSum = 0
        let mutable localValue = 0

        while cq.TryDequeue &localValue do
            localSum <- localSum + localValue

        Interlocked.Add(&outerSum, localSum) |> ignore)

// Start 4 concurrent consuming actions.
Parallel.Invoke(action, action, action, action)

printfn $"outerSum = {outerSum}, should be 49995000"
//</snippet1>
