module example1

//<SnippetAll>
open System
open System.Threading

type LargeObject () =
    do
        printfn $"LargeObject was created on thread id {Thread.CurrentThread.ManagedThreadId}."

    member val Data = Array.zeroCreate<int64> 100000000 with get

// The lazy initializer is created here. LargeObject is not created until the
// ThreadProc method executes.
//<SnippetNewLazy>
let lazyLargeObject = Lazy<LargeObject> false
// The following lines show how to use other constructors to achieve exactly the
// same result as the previous line:
//     let lazyLargeObject = Lazy<LargeObject>(LazyThreadSafetyMode.None)
//</SnippetNewLazy>

printfn """
LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject."""
stdin.ReadLine() |> ignore

//<SnippetValueProp>
let large = lazyLargeObject.Value
//</SnippetValueProp>

large.Data[11] <- 89

printfn "\nPress Enter to end the program"
stdin.ReadLine() |> ignore


// This example produces output similar to the following:
//     LargeObject is not created until you access the Value property of the lazy
//     initializer. Press Enter to create LargeObject.
//     
//     LargeObject was created on thread id 1.
//     
//     Press Enter to end the program
//</SnippetAll>