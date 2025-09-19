module processstart
// <Snippet1>
open System.Diagnostics

try
    use myProcess = new Process()
    myProcess.StartInfo.UseShellExecute <- false
    // You can start any process, HelloWorld is a do-nothing example.
    myProcess.StartInfo.FileName <- @"C:\HelloWorld.exe"
    myProcess.StartInfo.CreateNoWindow <- true
    myProcess.Start() |> ignore
// This code assumes the process you are starting will terminate itself.
// Given that it is started without a window so you cannot terminate it
// on the desktop, it must terminate itself or you can do it programmatically
// from this application using the Kill method.
with e ->
    printfn $"{e.Message}"

// </Snippet1>
