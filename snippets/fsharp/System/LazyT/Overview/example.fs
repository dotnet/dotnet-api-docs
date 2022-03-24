module example

//<SnippetAll>
open System
open System.Threading

//<SnippetLargeCtor>
type LargeObject(initBy) =
    do 
        printfn $"LargeObject was created on thread id %i{initBy}."
//</SnippetLargeCtor>
    member _.InitializedBy = initBy
    member val Data = Array.zeroCreate<int64> 100000000

//<SnippetFactoryFunc>
let initLargeObject () =
    let large = LargeObject Thread.CurrentThread.ManagedThreadId
    // Perform additional initialization here.
    large
//</SnippetFactoryFunc>

// The lazy initializer is created here. LargeObject is not created until the
// ThreadProc method executes.
//<SnippetNewLazy>
let lazyLargeObject = Lazy<LargeObject> initLargeObject

// The following lines show how to use other constructors to achieve exactly the
// same result as the previous line:
//     let lazyLargeObject = Lazy<LargeObject>(initLargeObject, true)
//     let lazyLargeObject = Lazy<LargeObject>(initLargeObject,
//                               LazyThreadSafetyMode.ExecutionAndPublication)
//</SnippetNewLazy>

let threadProc (state: obj) =
    //<SnippetValueProp>
    let large = lazyLargeObject.Value

    // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the
    //            object after creation. You must lock the object before accessing it,
    //            unless the type is thread safe. (LargeObject is not thread safe.)
    lock large (fun () ->
        large.Data[0] <- Thread.CurrentThread.ManagedThreadId
        printfn $"Initialized by thread {large.InitializedBy} last used by thread {large.Data[0]}.")
    //</SnippetValueProp>

printfn """
LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject."""
stdin.ReadLine() |> ignore

// Create and start 3 threads, each of which uses LargeObject.

let threads = Array.zeroCreate 3
for i = 0 to 2 do
    threads[i] <- Thread(ParameterizedThreadStart threadProc)
    threads[i].Start()

// Wait for all 3 threads to finish.
for t in threads do
    t.Join()

printfn "\nPress Enter to end the program"
stdin.ReadLine() |> ignore

// This example produces output similar to the following:
//     LargeObject is not created until you access the Value property of the lazy
//     initializer. Press Enter to create LargeObject.
//     
//     LargeObject was created on thread id 3.
//     Initialized by thread 3 last used by thread 3.
//     Initialized by thread 3 last used by thread 4.
//     Initialized by thread 3 last used by thread 5.
//     
//     Press Enter to end the program
//</SnippetAll>