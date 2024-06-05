module objdispexc

//<Snippet1>
open System
open System.IO

let ms = new MemoryStream 16
ms.Close()
try
    ms.ReadByte()
    |> ignore
with :? ObjectDisposedException as e ->
   printfn $"Caught: {e.Message}"
//</Snippet1>