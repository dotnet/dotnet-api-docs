module STDOutputAsync

open System.Diagnostics

let p = new Process()
p.StartInfo.UseShellExecute <- false
p.StartInfo.RedirectStandardOutput <- true
let mutable eOut = ""
p.StartInfo.RedirectStandardError <- true
p.ErrorDataReceived.AddHandler(DataReceivedEventHandler(fun sender e -> eOut <- eOut + e.Data))

p.StartInfo.FileName <- "Write500Lines.exe"
p.Start() |> ignore

// To avoid deadlocks, use an asynchronous read operation on at least one of the streams.
p.BeginErrorReadLine()
let output = p.StandardOutput.ReadToEnd()
p.WaitForExit()

printfn $"The last 50 characters in the output stream are:\n'{output.Substring(output.Length - 50)}'"
printfn $"\nError stream: {eOut}"
// The example displays the following output:
//      The last 50 characters in the output stream are:
//      'ritten: 99,80%
//      Line 500 of 500 written: 100,00%
//      '
//
//      Error stream: Successfully wrote 500 lines.
