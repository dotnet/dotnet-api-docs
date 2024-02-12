module example

//<SnippetAll>
open System
open System.Threading

type LargeObject() =
    let initBy = Thread.CurrentThread.ManagedThreadId
    do
        printfn $"LargeObject was created on thread id {initBy}."

    member val Data = Array.zeroCreate<int64> 100000000 with get
    member _.InitializedBy = initBy

// The lazy initializer is created here. LargeObject is not created until the
// ThreadProc method executes.
//<SnippetNewLazy>
let lazyLargeObject = Lazy<LargeObject>()

// The following lines show how to use other constructors to achieve exactly the
// same result as the previous line:
//     let lazyLargeObject = Lazy<LargeObject>(true)
//     let lazyLargeObject = Lazy<LargeObject>(LazyThreadSafetyMode.ExecutionAndPublication)
//</SnippetNewLazy>

let threadProc (state: obj) =
    // Wait for the signal.
    let waitForStart = state :?> ManualResetEvent
    waitForStart.WaitOne() |> ignore

    //<SnippetValueProp>
    let large = lazyLargeObject.Value
    //</SnippetValueProp>

    // The following line introduces an artificial delay to exaggerate the race condition.
    Thread.Sleep 5

    // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the
    //            object after creation. You must lock the object before accessing it,
    //            unless the type is thread safe. (LargeObject is not thread safe.)
    lock large (fun () -> 
        large.Data[0] <- Thread.CurrentThread.ManagedThreadId
        printfn $"Initialized by thread {large.InitializedBy} last used by thread {large.Data[0]}." )

printfn """
LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject."""
stdin.ReadLine() |> ignore

// Create and start 3 threads, passing the same blocking event to all of them.
let startingGate = new ManualResetEvent false
let threads = [| Thread(ParameterizedThreadStart threadProc); Thread(ParameterizedThreadStart threadProc); Thread(ParameterizedThreadStart threadProc) |]
for t in threads do
    t.Start startingGate

// Give all 3 threads time to start and wait, then release them all at once.
Thread.Sleep 100
startingGate.Set() |> ignore

// Wait for all 3 threads to finish. (The order doesn't matter.)
for t in threads do
    t.Join()

printfn "\nPress Enter to end the program"
stdin.ReadLine() |> ignore

// This example produces output similar to the following:
//     LargeObject is not created until you access the Value property of the lazy
//     initializer. Press Enter to create LargeObject.
//    
//     LargeObject was created on thread id 4.
//     Initialized by thread 4 last used by thread 3.
//     Initialized by thread 4 last used by thread 4.
//     Initialized by thread 4 last used by thread 5.
//    
//     Press Enter to end the program
//</SnippetAll>