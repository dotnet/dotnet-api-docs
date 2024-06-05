module example2

//<SnippetAll>
open System
open System.Threading

//<SnippetLargeCtor>    
type LargeObject() =
    static let mutable instanceCount = 0
    let initBy = Thread.CurrentThread.ManagedThreadId
    do
        if 1 = Interlocked.Increment &instanceCount then
            raise (ApplicationException "Throw only ONCE.")
        printfn $"LargeObject was created on thread id {initBy}."
//</SnippetLargeCtor>
    member _.InitializedBy = initBy
    member val Data = Array.zeroCreate<int64> 100000000

//<SnippetFactoryFunc>
let initLargeObject () =
    LargeObject()
//</SnippetFactoryFunc>

// The lazy initializer is created here. LargeObject is not created until the
// ThreadProc method executes.
//<SnippetNewLazy>
let lazyLargeObject = Lazy<LargeObject> initLargeObject

// The following lines show how to use other constructors to achieve exactly the
// same result as the previous line:
//     let lazyLargeObject = Lazy<LargeObject>(initLargeObject, true)
//     let lazyLargeObject = Lazy<LargeObject>(initLargeObject, LazyThreadSafetyMode.ExecutionAndPublication)
//</SnippetNewLazy>

let threadProc _ =
    //<SnippetValueProp>
    try
        let large = lazyLargeObject.Value

        // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the
        //            object after creation. You must lock the object before accessing it,
        //            unless the type is thread safe. (LargeObject is not thread safe.)
        lock large (fun () -> 
            large.Data[0] <- Thread.CurrentThread.ManagedThreadId
            printfn $"Initialized by thread {large.InitializedBy} last used by thread {large.Data[0]}.")
    with :? ApplicationException as aex ->
        printfn $"Exception: {aex.Message}"
    //</SnippetValueProp>

printfn """
LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject."""
stdin.ReadLine () |> ignore

// Create and start 3 threads, each of which tries to use LargeObject.
let threads = 
    [| Thread(ParameterizedThreadStart threadProc); Thread(ParameterizedThreadStart threadProc); Thread(ParameterizedThreadStart threadProc) |]
for t in threads do
    t.Start()

// Wait for all 3 threads to finish. (The order doesn't matter.)
for t in threads do
    t.Join()

printfn "\nPress Enter to end the program"
stdin.ReadLine() |> ignore

// This example produces output similar to the following:
//     LargeObject is not created until you access the Value property of the lazy
//     initializer. Press Enter to create LargeObject.
//     
//     Exception: Throw only ONCE.
//     Exception: Throw only ONCE.
//     Exception: Throw only ONCE.
//     
//     Press Enter to end the program
//</SnippetAll>