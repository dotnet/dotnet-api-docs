module example3

//<SnippetAll>
open System
open System.Threading

//<SnippetLargeCtor>
type LargeObject() =
    static let mutable pleaseThrow = true
    do
        if pleaseThrow then
            pleaseThrow <- false
            raise (ApplicationException "Throw only ONCE.")
        printfn $"LargeObject was created on thread id {Thread.CurrentThread.ManagedThreadId}."
//</SnippetLargeCtor>
    member val Data = Array.zeroCreate<int64> 100000000

//<SnippetFactoryFunc>
let initLargeObject () =
    LargeObject()
//</SnippetFactoryFunc>

// The lazy initializer is created here. LargeObject is not created until the
// ThreadProc method executes.
//<SnippetNewLazy>
let lazyLargeObject = Lazy<LargeObject>(initLargeObject, false)

// The following lines show how to use other constructors to achieve exactly the
// same result as the previous line:
//     let lazyLargeObject = Lazy<LargeObject>(initLargeObject, LazyThreadSafetyMode.None)
//</SnippetNewLazy>

printfn """
LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject (three tries)."""
stdin.ReadLine() |> ignore

//<SnippetValueProp>
for _ = 0 to 2 do
    try
        let large = lazyLargeObject.Value
        large.Data[11] <- 89
    with :? ApplicationException as aex ->
        printfn $"Exception: {aex.Message}"
//</SnippetValueProp>

printfn "\nPress Enter to end the program"
stdin.ReadLine() |> ignore

// This example produces output similar to the following:
//     LargeObject is not created until you access the Value property of the lazy
//     initializer. Press Enter to create LargeObject (three tries).
//     
//     Exception: Throw only ONCE.
//     Exception: Throw only ONCE.
//     Exception: Throw only ONCE.
//     
//     Press Enter to end the program
//</SnippetAll>