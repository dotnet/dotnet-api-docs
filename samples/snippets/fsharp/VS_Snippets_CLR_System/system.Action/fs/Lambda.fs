module Lambda

// <Snippet4>
open System
open System.Windows.Forms

type Name(name) =
    let instanceName = name

    member _.DisplayToConsole() = 
        printfn "%s" instanceName

    member _.DisplayToWindow() = 
        MessageBox.Show instanceName |> ignore

let testName = Name "Koani"

let showMethod = Action(fun () -> testName.DisplayToWindow())

showMethod.Invoke()

// </Snippet4>
