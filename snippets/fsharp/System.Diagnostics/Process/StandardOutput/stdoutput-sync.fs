module STDOutputSync

open System.Diagnostics

let p = new Process()
p.StartInfo.UseShellExecute <- false
p.StartInfo.RedirectStandardOutput <- true
p.StartInfo.FileName <- "Write500Lines.exe"
p.Start() |> ignore

// To avoid deadlocks, always read the output stream first and then wait.
let output = p.StandardOutput.ReadToEnd()
p.WaitForExit()

printfn $"The last 50 characters in the output stream are:\n'{output.Substring(output.Length - 50)}'"
// The example displays the following output:
//      Successfully wrote 500 lines.
//      The last 50 characters in the output stream are:
//      'ritten: 99,80%
//      Line 500 of 500 written: 100,00%
//      '
