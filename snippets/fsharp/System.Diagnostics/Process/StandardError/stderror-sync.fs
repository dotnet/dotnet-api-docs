module STDErrorSync

open System.Diagnostics

let p = new Process()
p.StartInfo.UseShellExecute <- false
p.StartInfo.RedirectStandardError <- true
p.StartInfo.FileName <- "Write500Lines.exe"
p.Start() |> ignore

// To avoid deadlocks, always read the output stream first and then wait.
let output = p.StandardError.ReadToEnd()
p.WaitForExit()

printfn $"\nError stream: {output}"
// The end of the output produced by the example includes the following:
//      Error stream:
//      Successfully wrote 500 lines.
