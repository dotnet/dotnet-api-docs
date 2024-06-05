// <Snippet1>
open System

let parseVersion (input: string) =
    try
        let ver = Version.Parse input
        printfn $"Converted '{input} to {ver}."
    with
    | :? ArgumentNullException ->
        printfn "Error: String to be parsed is null."
    | :? ArgumentOutOfRangeException ->
        printfn $"Error: Negative value in '{input}'."
    | :? ArgumentException ->
        printfn $"Error: Bad number of components in '{input}'."
    | :? FormatException ->
        printfn $"Error: Non-integer value in '{input}'."
    | :? OverflowException ->
        printfn $"Error: Number out of range in '{input}'."                  

[<EntryPoint>]
let main _ =
    let input = "4.0"
    parseVersion input
    
    let input = "4.0."
    parseVersion input
    
    let input = "1.1.2"
    parseVersion input
    
    let input = "1.1.2.01702"
    parseVersion input
    
    let input = "1.1.2.0702.119"
    parseVersion input
    
    let input =  "1.3.5.2150000000"
    parseVersion input
    0
// The example displays the following output:
//       Converted '4.0 to 4.0.
//       Error: Non-integer value in '4.0.'.
//       Converted '1.1.2 to 1.1.2.
//       Converted '1.1.2.01702 to 1.1.2.1702.
//       Error: Bad number of components in '1.1.2.0702.119'.
//       Error: Number out of range in '1.3.5.2150000000'.
// </Snippet1>