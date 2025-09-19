module ToDateTime1

// <Snippet1>
open System

let convertToDateTime (value: obj) =
    try
        let convertedDate = Convert.ToDateTime value
        printfn $"'{value}' converts to {convertedDate}."
    with
    | :? FormatException ->
        printfn $"'{value}' is not in the proper format."
    | :? InvalidCastException ->
        printfn $"Conversion of the {value.GetType().Name} '{value}' is not supported"

[<EntryPoint>]
let main _ =
    // Try converting an integer.
    let number = 16352
    convertToDateTime number

    // Convert a null.
    let obj = box null
    convertToDateTime obj

    // Convert a non-date string.
    let nonDateString = "monthly"
    convertToDateTime nonDateString

    // Try to convert various date strings.
    let dateString = "05/01/1996"
    convertToDateTime dateString
    let dateString = "Tue Apr 28, 2009"
    convertToDateTime dateString
    let dateString = "06 July 2008 7:32:47 AM"
    convertToDateTime dateString
    let dateString = "17:32:47.003"
    convertToDateTime dateString

    0

// The example displays the following output:
//       Conversion of the Int32 '16352' is not supported
//       '' converts to 1/1/0001 12:00:00 AM.
//       'monthly' is not in the proper format.
//       '05/01/1996' converts to 5/1/1996 12:00:00 AM.
//       'Tue Apr 28, 2009' converts to 4/28/2009 12:00:00 AM.
//       '06 July 2008 7:32:47 AM' converts to 7/6/2008 7:32:47 AM.
//       '17:32:47.003' converts to 5/28/2008 5:32:47 PM.
// </Snippet1>