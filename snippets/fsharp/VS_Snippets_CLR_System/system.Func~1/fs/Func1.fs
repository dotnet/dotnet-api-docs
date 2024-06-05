module Func1

// <Snippet2>
open System
open System.IO

type OutputTarget() =
    member _.SendToFile() =
        try
            let fn = Path.GetTempFileName()
            use sw = new StreamWriter(fn)
            sw.WriteLine "Hello, World!"
            true
        with _ ->
            false

let output = OutputTarget()
let methodCall = Func<bool> output.SendToFile
if methodCall.Invoke() then
    printfn "Success!"
else
    printfn "File write operation failed."

// </Snippet2>