module type_getevent

// <Snippet1>
open System
open System.Security

try
    let myType = typeof<System.Windows.Forms.Button>
    let myEvent = myType.GetEvent "Click"
    if myEvent <> null then
        printfn $"Looking for the Click event in the Button class.\n{myEvent}"
    else
        printfn "The Click event is not available in the Button class."
with
| :? SecurityException as e ->
    printfn "An exception occurred."
    printfn $"Message :{e.Message}"
| :? ArgumentNullException as e ->
    printfn "An exception occurred."
    printfn $"Message :{e.Message}"
| e ->
    printfn $"The following exception was raised : {e.Message}"
// </Snippet1>