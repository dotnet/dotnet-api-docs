// <Snippet1>
open System

let parseVersion (input: string) =
    match Version.TryParse input with
    | true, ver ->
        printfn $"Converted '{input} to {ver}."
    | _ ->
        printfn $"Unable to determine the version from '{input}'."

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
//       Unable to determine the version from '4.0.'.
//       Converted '1.1.2 to 1.1.2.
//       Converted '1.1.2.01702 to 1.1.2.1702.
//       Unable to determine the version from '1.1.2.0702.119'.
//       Unable to determine the version from '1.3.5.2150000000'.
// </Snippet1>