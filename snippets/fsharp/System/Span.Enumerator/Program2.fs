module Program2

open System
open System.Threading
open System.Threading.Tasks

let array = Array.zeroCreate<byte> 5

// <Snippet1>
let enumerateSpan (span: Span<byte>) =
    // Spans cannot be accessed in closures including in the F# lock function.
    // Monitor.Enter and Monitor.Exit are used here directly.
    Monitor.Enter array
    try
        for element in span do
            printfn $"{element}"
            Task.Delay(10).Wait()
    finally
        Monitor.Exit array
// The example displays the following output:
//    62
//    23
//    186
//    150
//    174
// </Snippet1>

let clearContents () =
    Task.Delay(20).Wait()
    lock array (fun () -> 
        Array.Clear(array, 0, array.Length) )

[<EntryPoint>]
let main _ =
    Random(42).NextBytes array
    let span: Span<byte> = array

    Task.Run clearContents |> ignore

    enumerateSpan span

    0