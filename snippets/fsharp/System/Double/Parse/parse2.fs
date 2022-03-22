// <Snippet3>
open System

[<EntryPoint>]
let main _ =
    let value = string Double.MinValue
    try
        printfn $"{Double.Parse value}"
    with :? OverflowException ->
        printfn $"{value} is outside the range of the Double type."

    let value = string Double.MaxValue
    try
        printfn $"{Double.Parse value}"
    with :? OverflowException ->
        printfn $"{value} is outside the range of the Double type."

    // Format without the default precision.
    let value = Double.MinValue.ToString "G17"
    try
        printfn $"{Double.Parse value}"
    with :? OverflowException ->
        printfn $"{value} is outside the range of the Double type."

    0
// The example displays the following output:
//    -1.79769313486232E+308 is outside the range of the Double type.
//    1.79769313486232E+308 is outside the range of the Double type.
//    -1.79769313486232E+308
// </Snippet3>