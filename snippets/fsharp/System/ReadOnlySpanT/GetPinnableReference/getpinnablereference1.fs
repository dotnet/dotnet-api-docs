#nowarn "9"
#nowarn "51"
open System
open FSharp.NativeInterop

let createInt32Array () =
    [| 100; 200; 300; 400; 500 |]

[<EntryPoint>]
let main _ =
    let array = createInt32Array()

    // Create a span, pin it, and print its elements.
    let span = array.AsSpan()
    let spanPtr = &&span.GetPinnableReference()
    printfn $"Span contains {span.Length} elements:"
    for i = 0 to span.Length - 1 do
        printfn $"{NativePtr.get spanPtr i}"
    printfn ""

    // Create a read-only span, pin it, and print its elements.
    let readonlyspan: ReadOnlySpan<int> = array.AsSpan()
    let readonlyspanPtr = &&readonlyspan.GetPinnableReference()
    
    printfn $"ReadOnlySpan contains {readonlyspan.Length} elements:"
    for i = 0 to readonlyspan.Length - 1 do
        printfn $"{NativePtr.get readonlyspanPtr i}"
    printfn ""
    0

// The example displays the following output:
//       Span contains 5 elements:
//       100
//       200
//       300
//       400
//       500
//
//       ReadOnlySpan contains 5 elements:
//       100
//       200
//       300
//       400
//       500