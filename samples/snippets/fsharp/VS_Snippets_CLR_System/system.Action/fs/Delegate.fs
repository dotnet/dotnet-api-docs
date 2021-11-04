module Delegate

// <Snippet1>
open System.Windows.Forms

type ShowValue = delegate of unit -> unit

type Name(name) =
    let instanceName = name

    member _.DisplayToConsole() = 
        printfn "%s" instanceName

    member _.DisplayToWindow() = 
        MessageBox.Show instanceName |> ignore

let testName = Name "Koani"
let showMethod = ShowValue testName.DisplayToWindow
showMethod.Invoke()

// </Snippet1>
