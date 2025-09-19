module Delegate

// <Snippet1>
open System.IO

type WriteMethod = delegate of unit -> bool

type OutputTarget() =
    member _.SendToFile() =
        try
            let fn = Path.GetTempFileName()
            use sw = new StreamWriter(fn)
            sw.WriteLine "Hello, World!"
            true
        with _ ->
            false

let output = new OutputTarget()
let methodCall = WriteMethod output.SendToFile
if methodCall.Invoke() then
    printfn "Success!"
else
    printfn "File write operation failed."

// </Snippet1>