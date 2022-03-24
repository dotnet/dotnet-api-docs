// <Snippet1>
open System.Diagnostics

type ExampleClass() =
    let sw = Stopwatch.StartNew()
    do 
        printfn "Instantiated object"

    member this.ShowDuration() =
        printfn $"This instance of {this} has been in existence for {sw.Elapsed}"

    override this.Finalize() =
        printfn "Finalizing object"
        sw.Stop()
        printfn $"This instance of {this} has been in existence for {sw.Elapsed}"

let ex = ExampleClass()
ex.ShowDuration()
// The example displays output like the following:
//    Instantiated object
//    This instance of ExampleClass has been in existence for 00:00:00.0011060
//    Finalizing object
//    This instance of ExampleClass has been in existence for 00:00:00.0036294
// </Snippet1>