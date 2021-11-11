module TestLambdaExpression

// <Snippet4>
open System
open System.Windows.Forms

let showWindowsMessage message = 
    MessageBox.Show message |> ignore

let messageTarget =
    Action<string>(
        if Environment.GetCommandLineArgs().Length > 1 then
            fun s -> showWindowsMessage s
        else
            fun s -> printfn "%s" s
    )

messageTarget.Invoke "Hello, World!"

// </Snippet4>
