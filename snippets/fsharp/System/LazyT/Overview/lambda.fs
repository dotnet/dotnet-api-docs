module lambda

open System
open System.Threading

type LargeObject(initBy) =
    do 
        printfn $"LargeObject was created on thread id %i{initBy}."

    member _.InitializedBy = initBy
    member val Data = Array.zeroCreate<int64> 100000000

//<SnippetInitWithLambda>
let lazyLargeObject = Lazy<LargeObject>(fun () ->
    let large = LargeObject Thread.CurrentThread.ManagedThreadId
    // Perform additional initialization here.
    large)
//</SnippetInitWithLambda>

let threadProc _ =
    let large = lazyLargeObject.Value

    // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the
    //            object after creation. You must lock the object before accessing it,
    //            unless the type is thread safe. (LargeObject is not thread safe.)
    lock large (fun () ->
        large.Data[0] <- Thread.CurrentThread.ManagedThreadId
        printfn $"Initialized by thread {large.InitializedBy} last used by thread {large.Data[0]}.")

printfn """
LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject."""
stdin.ReadLine() |> ignore

// Create and start 3 threads, each of which uses LargeObject.
let threads = Array.zeroCreate<Thread> 3
for i = 0 to 2 do
    threads[i] <- Thread(ParameterizedThreadStart threadProc)
    threads[i].Start()

// Wait for all 3 threads to finish.
for t in threads do
    t.Join()

printfn "\nPress Enter to end the program"
stdin.ReadLine() |> ignore