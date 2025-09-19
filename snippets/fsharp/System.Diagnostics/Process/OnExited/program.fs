//<Snippet1>
open System
open System.Diagnostics

type MyProcess() =
    inherit Process()

    member this.Stop() =
        this.CloseMainWindow() |> ignore
        this.Close()
        this.OnExited()

let myProcess_HasExited (sender: obj) (e: EventArgs) = printfn "Process has exited."

let p = new MyProcess()
p.StartInfo.FileName <- "notepad.exe"
p.EnableRaisingEvents <- true
p.Exited.AddHandler(EventHandler myProcess_HasExited)
p.Start() |> ignore
p.WaitForInputIdle() |> ignore
p.Stop()

//</Snippet1>
