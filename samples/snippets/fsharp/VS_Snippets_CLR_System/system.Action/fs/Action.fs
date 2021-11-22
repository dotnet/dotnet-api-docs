module Action

// <Snippet2>
open System
open System.Windows.Forms

type Name(name) =
    member _.DisplayToConsole() =
        printfn "%s" name

    member _.DisplayToWindow() =
        MessageBox.Show name |> ignore

let testName = Name "Koani"

// unit -> unit functions and methods can be cast to Action.
let showMethod = Action testName.DisplayToWindow

showMethod.Invoke()

// </Snippet2>
