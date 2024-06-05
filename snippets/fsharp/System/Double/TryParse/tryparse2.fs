module tryparse2

// <Snippet3>
open System

[<EntryPoint>]
let main _ = 
    let value = string Double.MinValue
    match Double.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ ->
        printfn $"{value} is outside the range of a Double."

    let value = string Double.MaxValue
    match Double.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ ->
        printfn $"{value} is outside the range of a Double."

    0
// The example displays the following output:
//    -1.79769313486232E+308 is outside the range of the Double type.
//    1.79769313486232E+308 is outside the range of the Double type.
// </Snippet3>