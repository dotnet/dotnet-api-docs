module Program

open System
open System.Threading.Tasks

let array = Array.zeroCreate<byte> 5

let clearContents () =
    Task.Delay(20).Wait()
    lock array (fun () -> 
        Array.Clear(array, 0, array.Length) )

let enumerateSpan (span: Span<byte>) =
    for element in span do
        printfn $"{element}"
        Task.Delay(10).Wait()

[<EntryPoint>]
let main _ =
    Random(42).NextBytes array
    printfn "%A" array
    let span: Span<byte> = array

    Task.Run clearContents |> ignore

    enumerateSpan span
    
    0

// The example displays output like the following:
//     62
//     23
//     186
//     0
//     0