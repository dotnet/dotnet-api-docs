module ToDateTime2

// <Snippet2>
open System

let convertToDateTime (value: string) =
    try
        let convertedDate = Convert.ToDateTime value
        printfn $"'{value}' converts to {convertedDate} {convertedDate.Kind} time."
    with :?FormatException ->
        printfn $"'{value}' is not in the proper format."

[<EntryPoint>]
let main _ =
    let dateString = null

    // Convert a null string.
    convertToDateTime dateString

    // Convert an empty string.
    let dateString = String.Empty
    convertToDateTime dateString

    // Convert a non-date string.
    let dateString = "not a date"
    convertToDateTime dateString

    // Try to convert various date strings.
    let dateString = "05/01/1996"
    convertToDateTime dateString
    let dateString = "Tue Apr 28, 2009"
    convertToDateTime dateString
    let dateString = "Wed Apr 28, 2009"
    convertToDateTime dateString
    let dateString = "06 July 2008 7:32:47 AM"
    convertToDateTime dateString
    let dateString = "17:32:47.003"
    convertToDateTime dateString
    // Convert a string returned by DateTime.ToString("R").
    let dateString = "Sat, 10 May 2008 14:32:17 GMT"
    convertToDateTime dateString
    // Convert a string returned by DateTime.ToString("o").
    let dateString = "2009-05-01T07:54:59.9843750-04:00"
    convertToDateTime dateString

    0

// The example displays the following output:
//    '' converts to 1/1/0001 12:00:00 AM Unspecified time.
//    '' is not in the proper format.
//    'not a date' is not in the proper format.
//    '05/01/1996' converts to 5/1/1996 12:00:00 AM Unspecified time.
//    'Tue Apr 28, 2009' converts to 4/28/2009 12:00:00 AM Unspecified time.
//    'Wed Apr 28, 2009' is not in the proper format.
//    '06 July 2008 7:32:47 AM' converts to 7/6/2008 7:32:47 AM Unspecified time.
//    '17:32:47.003' converts to 5/30/2008 5:32:47 PM Unspecified time.
//    'Sat, 10 May 2008 14:32:17 GMT' converts to 5/10/2008 7:32:17 AM Local time.
//    '2009-05-01T07:54:59.9843750-04:00' converts to 5/1/2009 4:54:59 AM Local time.
// </Snippet2>
