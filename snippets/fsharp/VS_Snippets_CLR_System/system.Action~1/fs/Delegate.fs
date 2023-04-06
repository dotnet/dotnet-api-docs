module TestCustomDelegate

// <Snippet1>
open System
open System.Windows.Forms

type DisplayMessage = delegate of message: string -> unit

let showWindowsMessage message = 
    MessageBox.Show message |> ignore

let messageTarget =
    DisplayMessage(
        if Environment.GetCommandLineArgs().Length > 1 then
            showWindowsMessage
        else
            printfn "%s"
    )

messageTarget.Invoke "Hello, World!"

// </Snippet1>
