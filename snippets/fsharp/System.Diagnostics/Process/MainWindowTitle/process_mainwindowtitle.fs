// <Snippet1>
open System.Diagnostics

try
    // Create an instance of process component.
    use myProcess = new Process()
    // Create an instance of 'myProcessStartInfo'.
    let myProcessStartInfo = ProcessStartInfo()
    myProcessStartInfo.FileName <- "notepad"
    myProcess.StartInfo <- myProcessStartInfo
    // Start process.
    myProcess.Start() |> ignore
    // Allow the process to finish starting.
    myProcess.WaitForInputIdle() |> ignore
    printfn $"Main window Title : {myProcess.MainWindowTitle}"

    myProcess.CloseMainWindow() |> ignore
with e ->
    printfn $" Message : {e.Message}"
// </Snippet1>
