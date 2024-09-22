module datareceivedevent
//<Snippet4>
open System
open System.Diagnostics
open System.Text

let mutable lineCount = 0
let output = StringBuilder()

let proc = new Process()
proc.StartInfo.FileName <- "ipconfig.exe"
proc.StartInfo.UseShellExecute <- false
proc.StartInfo.RedirectStandardOutput <- true

proc.OutputDataReceived.AddHandler(
    DataReceivedEventHandler(fun _ e ->
        // Prepend line numbers to each line of the output.
        if not (String.IsNullOrEmpty e.Data) then
            lineCount <- lineCount + 1
            output.Append $"\n[{lineCount}]: {e.Data}" |> ignore)
)


proc.Start() |> ignore

// Asynchronously read the standard output of the spawned process.
// This raises OutputDataReceived events for each line of output.
proc.BeginOutputReadLine()
proc.WaitForExit()

// Write the redirected output to this application's window.
printfn $"{output}"

proc.WaitForExit()
proc.Close()

printfn "\n\nPress any key to exit."
stdin.ReadLine() |> ignore
//</Snippet4>
