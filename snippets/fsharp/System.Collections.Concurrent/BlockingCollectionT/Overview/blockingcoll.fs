//<snippet1>
open System
open System.Collections.Concurrent
open System.Threading
open System.Threading.Tasks

module AddTakeDemo =
    // Demonstrates:
    //      BlockingCollection<T>.Add()
    //      BlockingCollection<T>.Take()
    //      BlockingCollection<T>.CompleteAdding()
    let blockingCollectionAddTakeCompleteAdding () =
        task {
            use bc = new BlockingCollection<int>()
            // Spin up a Task to populate the BlockingCollection
            let t1 = 
                task {
                    bc.Add 1
                    bc.Add 2
                    bc.Add 3
                    bc.CompleteAdding()
                }

            // Spin up a Task to consume the BlockingCollection
            let t2 = 
                task {
                    try
                        // Consume consume the BlockingCollection
                        while true do 
                            printfn $"{bc.Take()}"
                    with :? InvalidOperationException ->
                        // An InvalidOperationException means that Take() was called on a completed collection
                        printfn "That's All!"
                }
            let! _ = Task.WhenAll(t1, t2)
            ()
        }

//<snippet2>
module TryTakeDemo =
    // Demonstrates:
    //      BlockingCollection<T>.Add()
    //      BlockingCollection<T>.CompleteAdding()
    //      BlockingCollection<T>.TryTake()
    //      BlockingCollection<T>.IsCompleted
    let blockingCollectionTryTake () =
        // Construct and fill our BlockingCollection
        use bc = new BlockingCollection<int>()
        let NUMITEMS = 10000;
        for i = 0 to NUMITEMS - 1 do
            bc.Add i
        bc.CompleteAdding()
        let mutable outerSum = 0

        // Delegate for consuming the BlockingCollection and adding up all items
        let action = 
            Action(fun () ->
                let mutable localItem = 0
                let mutable localSum = 0

                while bc.TryTake &localItem do
                    localSum <- localSum + localItem
                Interlocked.Add(&outerSum, localSum)
                |> ignore)

        // Launch three parallel actions to consume the BlockingCollection
        Parallel.Invoke(action, action, action)

        printfn $"Sum[0..{NUMITEMS}) = {outerSum}, should be {((NUMITEMS * (NUMITEMS - 1)) / 2)}"
        printfn $"bc.IsCompleted = {bc.IsCompleted} (should be true)"
//</snippet2>

//<snippet3>
module FromToAnyDemo =
    // Demonstrates:
    //      Bounded BlockingCollection<T>
    //      BlockingCollection<T>.TryAddToAny()
    //      BlockingCollection<T>.TryTakeFromAny()
    let blockingCollectionFromToAny () =
        let bcs = 
            [|
                new BlockingCollection<int>(5) // collection bounded to 5 items
                new BlockingCollection<int>(5) // collection bounded to 5 items
             |]
        // Should be able to add 10 items w/o blocking
        let mutable numFailures = 0;
        for i = 0 to 9 do
            if BlockingCollection<int>.TryAddToAny(bcs, i) = -1 then
                numFailures <- numFailures + 1
        printfn $"TryAddToAny: {numFailures} failures (should be 0)"

        // Should be able to retrieve 10 items
        let mutable numItems = 0
        let mutable item = 0
        while BlockingCollection<int>.TryTakeFromAny(bcs, &item) <> -1 do
            numItems <- numItems + 1
        printfn $"TryTakeFromAny: retrieved {numItems} items (should be 10)"
//</snippet3>

//<snippet4>
module ConsumingEnumerableDemo =
    // Demonstrates:
    //      BlockingCollection<T>.Add()
    //      BlockingCollection<T>.CompleteAdding()
    //      BlockingCollection<T>.GetConsumingEnumerable()
    let blockingCollectionGetConsumingEnumerable () =
        task {
            use bc = new BlockingCollection<int>()
            // Kick off a producer task
            let producerTask =
                task {
                    for i = 0 to 9 do
                        bc.Add i
                        printfn $"Producing: {i}"

                        do! Task.Delay 100 // sleep 100 ms between adds
                    // Need to do this to keep foreach below from hanging
                    bc.CompleteAdding()
                }

            // Now consume the blocking collection with foreach.
            // Use bc.GetConsumingEnumerable() instead of just bc because the
            // former will block waiting for completion and the latter will
            // simply take a snapshot of the current state of the underlying collection.
            for item in bc.GetConsumingEnumerable() do
                printfn $"Consuming: {item}"
            do! producerTask // Allow task to complete cleanup
        }
//</snippet4>

let main =
    task {
        do! AddTakeDemo.blockingCollectionAddTakeCompleteAdding ()
        TryTakeDemo.blockingCollectionTryTake ()
        FromToAnyDemo.blockingCollectionFromToAny ()
        do! ConsumingEnumerableDemo.blockingCollectionGetConsumingEnumerable ()
        printfn "Press any key to exit."
        Console.ReadKey(true) |> ignore
    }
main.Wait()
//</snippet1>