module TestAction1

// <Snippet2>
open System
open System.Windows.Forms

let showWindowsMessage message = 
    MessageBox.Show message |> ignore

let messageTarget =
    Action<string>(
        if Environment.GetCommandLineArgs().Length > 1 then
            showWindowsMessage
        else
            printfn "%s"
    )

messageTarget.Invoke "Hello, World!"

// </Snippet2>
