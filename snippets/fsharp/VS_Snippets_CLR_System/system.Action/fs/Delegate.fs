module Delegate

// <Snippet1>
open System.Windows.Forms

type ShowValue = delegate of unit -> unit

type Name(name) =
    member _.DisplayToConsole() = 
        printfn "%s" name

    member _.DisplayToWindow() = 
        MessageBox.Show name |> ignore

let testName = Name "Koani"

let showMethod = ShowValue testName.DisplayToWindow

showMethod.Invoke()

// </Snippet1>
