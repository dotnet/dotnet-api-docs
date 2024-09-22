module ProcessStandardOutput

open System.Diagnostics

use proc = new Process()
proc.StartInfo.FileName <- "ipconfig.exe"
proc.StartInfo.UseShellExecute <- false
proc.StartInfo.RedirectStandardOutput <- true
proc.Start() |> ignore

// Synchronously read the standard output of the spawned process.
let reader = proc.StandardOutput
let output = reader.ReadToEnd()

// Write the redirected output to this application's window.
printfn $"{output}"

proc.WaitForExit()

printfn "\n\nPress any key to exit."
stdin.ReadLine() |> ignore
