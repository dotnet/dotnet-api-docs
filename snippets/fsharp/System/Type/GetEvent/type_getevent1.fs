module type_getevent1

// <Snippet1>
open System
open System.Reflection
open System.Security

try
    // Creates a bitmask based on BindingFlags.
    let myBindingFlags = BindingFlags.Instance ||| BindingFlags.Public ||| BindingFlags.NonPublic
    let myTypeBindingFlags = typeof<System.Windows.Forms.Button>
    let myEventBindingFlags = myTypeBindingFlags.GetEvent("Click", myBindingFlags)
    if myEventBindingFlags <> null then
        printfn $"Looking for the Click event in the Button class with the specified BindingFlags.\n{myEventBindingFlags}"
    else
        printfn "The Click event is not available with the Button class."
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