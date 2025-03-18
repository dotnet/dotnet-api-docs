//<snippet1>
module ConcurrentBagDemo

open System.Collections.Concurrent
open System.Threading.Tasks
open System.Threading

// Demonstrates:
//      ConcurrentBag<T>.Add()
//      ConcurrentBag<T>.IsEmpty
//      ConcurrentBag<T>.TryTake()
//      ConcurrentBag<T>.TryPeek()

// Add to ConcurrentBag concurrently
let cb = ConcurrentBag<int>()

let bagAddTasks =
    [| for i = 0 to 499 do
           let numberToAdd = i
           task { cb.Add numberToAdd } :> Task |]

// Wait for all tasks to complete
Task.WaitAll bagAddTasks

// Consume the items in the bag
let mutable itemsInBag = 0

let bagConsumeTasks =
    [| while not cb.IsEmpty do
           task {
               let mutable item = 0

               if cb.TryTake &item then
                   printfn $"{item}"
                   Interlocked.Increment &itemsInBag |> ignore
           }
           :> Task |]

Task.WaitAll bagConsumeTasks

printfn $"There were {itemsInBag} items in the bag"

// Checks the bag for an item
// The bag should be empty and this should not print anything
let mutable unexpectedItem = 0

if cb.TryPeek &unexpectedItem then
    printfn "Found an item in the bag when it should be empty"
//</snippet1>
