// <Snippet1>
open System
open System.Globalization

[<EntryPoint>]
let main _ =
    let enUS = CultureInfo "en-US"

    // Parse date with no style flags.
    let dateString = " 5/01/2009 8:30 AM"
    match DateTime.TryParseExact(dateString, "g", enUS, DateTimeStyles.None) with
    | true, dateValue ->
        printfn $"Converted '{dateString}' to {dateValue} ({dateValue.Kind})."              
    | _ ->
        printfn $"'{dateString}' is not in an acceptable format."

    // Allow a leading space in the date string.
    match DateTime.TryParseExact(dateString, "g", enUS, DateTimeStyles.AllowLeadingWhite) with
    | true, dateValue ->
        printfn $"Converted '{dateString}' to {dateValue} ({dateValue.Kind})."
    | _ ->
        printfn $"'{dateString}' is not in an acceptable format."

    // Use custom formats with M and MM.
    let dateString = "5/01/2009 09:00"
    match DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS, DateTimeStyles.None) with
    | true, dateValue ->
        printfn $"Converted '{dateString}' to {dateValue} ({dateValue.Kind})."
    | _ ->
        printfn $"'{dateString}' is not in an acceptable format."

    // Allow a leading space in the date string.
    match DateTime.TryParseExact(dateString, "MM/dd/yyyy hh:mm", enUS, DateTimeStyles.None) with
    | true, dateValue ->
        printfn $"Converted '{dateString}' to {dateValue} ({dateValue.Kind})."
    | _ ->
        printfn $"'{dateString}' is not in an acceptable format."

    // Parse a string with time zone information.
    let dateString = "05/01/2009 01:30:42 PM -05:00"
    match DateTime.TryParseExact(dateString, "MM/dd/yyyy hh:mm:ss tt zzz", enUS, DateTimeStyles.None) with
    | true, dateValue ->
        printfn $"Converted '{dateString}' to {dateValue} ({dateValue.Kind})."
    | _ ->
        printfn $"'{dateString}' is not in an acceptable format."

    // Allow a leading space in the date string.
    match DateTime.TryParseExact(dateString, "MM/dd/yyyy hh:mm:ss tt zzz", enUS, DateTimeStyles.AdjustToUniversal) with
    | true, dateValue ->
        printfn $"Converted '{dateString}' to {dateValue} ({dateValue.Kind})."
    | _ ->
        printfn $"'{dateString}' is not in an acceptable format."

    // Parse a string representing UTC.
    let dateString = "2008-06-11T16:11:20.0904778Z"
    match DateTime.TryParseExact(dateString, "o", CultureInfo.InvariantCulture, DateTimeStyles.None) with
    | true, dateValue ->
        printfn $"Converted '{dateString}' to {dateValue} ({dateValue.Kind})."
    | _ ->
        printfn $"'{dateString}' is not in an acceptable format."

    match DateTime.TryParseExact(dateString, "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind) with
    | true, dateValue ->
        printfn $"Converted '{dateString}' to {dateValue} ({dateValue.Kind})."
    | _ ->
        printfn $"'{dateString}' is not in an acceptable format."

    0

    // The example displays the following output:
    //    ' 5/01/2009 8:30 AM' is not in an acceptable format.
    //    Converted ' 5/01/2009 8:30 AM' to 5/1/2009 8:30:00 AM (Unspecified).
    //    Converted '5/01/2009 09:00' to 5/1/2009 9:00:00 AM (Unspecified).
    //    '5/01/2009 09:00' is not in an acceptable format.
    //    Converted '05/01/2009 01:30:42 PM -05:00' to 5/1/2009 11:30:42 AM (Local).
    //    Converted '05/01/2009 01:30:42 PM -05:00' to 5/1/2009 6:30:42 PM (Utc).
    //    Converted '2008-06-11T16:11:20.0904778Z' to 6/11/2008 9:11:20 AM (Local).
    //    Converted '2008-06-11T16:11:20.0904778Z' to 6/11/2008 4:11:20 PM (Utc).
    // </Snippet1>