//<SnippetAll>
open System
open System.Threading

//<SnippetCtorFinalizer>
type LargeObject(initBy) =
    do
        printfn $"Constructor: Instance initializing on thread {initBy}"

    override _.Finalize() =
        printfn $"Finalizer: Instance was initialized on {initBy}"
//</SnippetCtorFinalizer>
    member _.InitializedBy = initBy
    member val Data = Array.zeroCreate<int64> 100000000 with get

// Factory function for lazy initialization.
//<SnippetFactoryFunc>
let mutable instanceCount = 0
let initLargeObject () =
    if 1 = Interlocked.Increment &instanceCount then
        raise (ApplicationException $"Lazy initialization function failed on thread {Thread.CurrentThread.ManagedThreadId}.")
    LargeObject Thread.CurrentThread.ManagedThreadId
//</SnippetFactoryFunc>

// The lazy initializer is created here. LargeObject is not created until the
// ThreadProc method executes.
//<SnippetNewLazy>
let lazyLargeObject = Lazy<LargeObject>(initLargeObject, LazyThreadSafetyMode.PublicationOnly)
//</SnippetNewLazy>

let threadProc (state: obj) =
    // Wait for the signal.
    let waitForStart = state :?> ManualResetEvent
    waitForStart.WaitOne() |> ignore

    //<SnippetValueProp>
    try
        let large = lazyLargeObject.Value

        // The following line introduces an artificial delay to exaggerate the race condition.
        Thread.Sleep 5

        // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the
        //            object after creation. You must lock the object before accessing it,
        //            unless the type is thread safe. (LargeObject is not thread safe.)
        lock large (fun () -> 
            large.Data[0] <- Thread.CurrentThread.ManagedThreadId
            printfn $"LargeObject was initialized by thread {large.InitializedBy} last used by thread {large.Data[0]}.")
    with :? ApplicationException as ex ->
        printfn $"ApplicationException: {ex.Message}"
    //</SnippetValueProp>

// Create and start 3 threads, passing the same blocking event to all of them.
let startingGate = new ManualResetEvent false
let threads = 
    [| Thread(ParameterizedThreadStart threadProc); Thread(ParameterizedThreadStart threadProc); Thread(ParameterizedThreadStart threadProc) |]
for t in threads do
    t.Start startingGate

// Give all 3 threads time to start and wait, then release them all at once.
Thread.Sleep 50
startingGate.Set() |> ignore

// Wait for all 3 threads to finish. (The order doesn't matter.)
for t in threads do
    t.Join()

printfn "\nThreads are complete. Running GC.Collect() to reclaim extra instances."

GC.Collect()

// Allow time for garbage collection, which happens asynchronously.
Thread.Sleep 100

printfn "\nNote that only one instance of LargeObject was used."
printfn "Press Enter to end the program"
stdin.ReadLine() |> ignore

// This example produces output similar to the following:
//     Constructor: Instance initializing on thread 5
//     Constructor: Instance initializing on thread 4
//     ApplicationException: Lazy initialization function failed on thread 3.
//     LargeObject was initialized by thread 5 last used by thread 5.
//     LargeObject was initialized by thread 5 last used by thread 4.
//     
//     Threads are complete. Running GC.Collect() to reclaim extra instances.
//     Finalizer: Instance was initialized on 4
//     
//     Note that only one instance of LargeObject was used.
//     Press Enter to end the program
//     
//     Finalizer: Instance was initialized on 5
//</SnippetAll>