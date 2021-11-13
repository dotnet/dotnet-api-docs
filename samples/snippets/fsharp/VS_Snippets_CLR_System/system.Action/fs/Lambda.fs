module Lambda

// <Snippet4>
open System
open System.Windows.Forms

type Name(name) =
    member _.DisplayToConsole() = 
        printfn "%s" name

    member _.DisplayToWindow() = 
        MessageBox.Show name |> ignore

let testName = Name "Koani"

let showMethod = Action(fun () -> testName.DisplayToWindow())

showMethod.Invoke()

// </Snippet4>
