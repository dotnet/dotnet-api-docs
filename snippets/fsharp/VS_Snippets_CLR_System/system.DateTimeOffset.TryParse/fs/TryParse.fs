open System
open System.Globalization

let tryParse1 () =
    // <Snippet1>
    // String with date only
    let dateString = "05/01/2008"
    match DateTimeOffset.TryParse dateString with
    | true, parsedDate ->
        printfn $"{dateString} was converted to {parsedDate}."
    | _ -> ()

    // String with time only
    let dateString = "11:36 PM"
    match DateTimeOffset.TryParse dateString with
    | true, parsedDate ->
        printfn $"{dateString} was converted to {parsedDate}."
    | _ -> ()

    // String with date and offset
    let dateString = "05/01/2008 +7:00"
    match DateTimeOffset.TryParse dateString with
    | true, parsedDate ->
        printfn $"{dateString} was converted to {parsedDate}."
    | _ -> ()

    // String with day abbreviation
    let dateString = "Thu May 01, 2008"
    match DateTimeOffset.TryParse dateString with
    | true, parsedDate ->
        printfn $"{dateString} was converted to {parsedDate}."
    | _ -> ()

    // String with date, time with AM/PM designator, and offset
    let dateString = "5/1/2008 10:00 AM -07:00"
    match DateTimeOffset.TryParse dateString with
    | true, parsedDate ->
        printfn $"{dateString} was converted to {parsedDate}."
    | _ -> ()

    // if (run on 3/29/07, the example displays the following output
    // to the console:
    //    05/01/2008 was converted to 5/1/2008 12:00:00 AM -07:00.
    //    11:36 PM was converted to 3/29/2007 11:36:00 PM -07:00.
    //    05/01/2008 +7:00 was converted to 5/1/2008 12:00:00 AM +07:00.
    //    Thu May 01, 2008 was converted to 5/1/2008 12:00:00 AM -07:00.
    //    5/1/2008 10:00 AM -07:00 was converted to 5/1/2008 10:00:00 AM -07:00.
    // </Snippet1>

let tryParse2 () =
    // <Snippet2>
    let dateString = "05/01/2008 6:00:00"
    // Assume time is local
    match DateTimeOffset.TryParse(dateString, null, DateTimeStyles.AssumeLocal) with
    | true, parsedDate ->
        printfn $"'{dateString}' was converted to {parsedDate}."
    | _ ->
        printfn $"Unable to parse '{dateString}'."

    // Assume time is UTC
    match DateTimeOffset.TryParse(dateString, null, DateTimeStyles.AssumeUniversal) with
    | true, parsedDate ->
        printfn $"'{dateString}' was converted to {parsedDate}."
    | _ ->
        printfn $"Unable to parse '{dateString}'."

    // Parse and convert to UTC
    let dateString = "05/01/2008 6:00:00AM +5:00"
    match DateTimeOffset.TryParse(dateString, null, DateTimeStyles.AdjustToUniversal) with
    | true, parsedDate ->
        printfn $"'{dateString}' was converted to {parsedDate}."
    | _ ->
        printfn $"Unable to parse '{dateString}'."

    // The example displays the following output to the console:
    //    '05/01/2008 6:00:00' was converted to 5/1/2008 6:00:00 AM -07:00.
    //    '05/01/2008 6:00:00' was converted to 5/1/2008 6:00:00 AM +00:00.
    //    '05/01/2008 6:00:00AM +5:00' was converted to 5/1/2008 1:00:00 AM +00:00.
    // </Snippet2>

tryParse1 ()
printfn ""
tryParse2 ()