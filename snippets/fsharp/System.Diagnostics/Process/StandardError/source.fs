open System.Diagnostics
let args = [||]
// <Snippet1>
use myProcess = new Process()
let myProcessStartInfo = ProcessStartInfo("net ", $"use {args[0]}")

myProcessStartInfo.UseShellExecute <- false
myProcessStartInfo.RedirectStandardError <- true
myProcess.StartInfo <- myProcessStartInfo
myProcess.Start() |> ignore

let myStreamReader = myProcess.StandardError
// Read the standard error of net.exe and write it on to console.
printfn $"{myStreamReader.ReadLine()}"
// </Snippet1>
