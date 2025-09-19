module type_getevents2

// <Snippet1>
open System
open System.Reflection
open System.Security

try
    // Creates a bitmask based on BindingFlags.
    let myBindingFlags = BindingFlags.Instance ||| BindingFlags.Public
    let myTypeEvent = typeof<System.Windows.Forms.Button>
    let myEventsBindingFlags = myTypeEvent.GetEvents myBindingFlags
    printfn "\nThe events on the Button class with the specified BindingFlags are : "
    for flag in myEventsBindingFlags do
        printfn $"{flag}"
with
| :? SecurityException as e ->
    printfn $"SecurityException: {e.Message}"
| :? ArgumentNullException as e ->
    printfn $"ArgumentNullException: {e.Message}"
| e ->
    printfn $"Exception : {e.Message}"
// </Snippet1>