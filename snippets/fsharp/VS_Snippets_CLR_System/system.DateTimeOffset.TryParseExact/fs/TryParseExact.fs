open System
open System.Globalization
open System.IO

let tryParseExact1 () =
    // <Snippet1>
    let provider = CultureInfo.InvariantCulture

    // Parse date-only value with invariant culture and assume time is UTC.
    let dateString = "06/15/2008"
    let format = "d"
    match DateTimeOffset.TryParseExact(dateString, format, provider, DateTimeStyles.AssumeUniversal) with
    | true, result ->
        printfn $"'{dateString}' converts to {result}."
    | _ ->
        printfn $"'{dateString}' is not in the correct format."

    // Parse date-only value with leading white space.
    // Should return False because only trailing white space is
    // specified in method call.
    let dateString = " 06/15/2008"
    match DateTimeOffset.TryParseExact(dateString, format, provider, DateTimeStyles.AllowTrailingWhite) with
    | true, result ->
        printfn $"'{dateString}' converts to {result}."
    | _ ->
        printfn $"'{dateString}' is not in the correct format."

    // Parse date and time value, and allow all white space.
    let dateString = " 06/15/   2008  15:15    -05:00"
    let format = "MM/dd/yyyy H:mm zzz"
    match DateTimeOffset.TryParseExact(dateString, format, provider, DateTimeStyles.AllowWhiteSpaces) with
    | true, result ->
        printfn $"'{dateString}' converts to {result}."
    | _ ->
        printfn $"'{dateString}' is not in the correct format."

    // Parse date and time and convert to UTC.
    let dateString = "  06/15/2008 15:15:30 -05:00"
    let format = "MM/dd/yyyy H:mm:ss zzz"
    match DateTimeOffset.TryParseExact(dateString, format, provider, DateTimeStyles.AllowWhiteSpaces ||| DateTimeStyles.AdjustToUniversal) with
    | true, result ->
        printfn $"'{dateString}' converts to {result}."
    | _ ->
        printfn $"'{dateString}' is not in the correct format."

    // The example displays the following output:
    //    '06/15/2008' converts to 6/15/2008 12:00:00 AM +00:00.
    //    ' 06/15/2008' is not in the correct format.
    //    ' 06/15/   2008  15:15    -05:00' converts to 6/15/2008 3:15:00 PM -05:00.
    //    '  06/15/2008 15:15:30 -05:00' converts to 6/15/2008 8:15:30 PM +00:00.
    // </Snippet1>

let tryParseExact2 () =
    // <Snippet2>
    let mutable result = None    
    let mutable tries = 0
    let mutable input = ""

    let formats = 
        [| "M/dd/yyyy HH:m zzz"; "MM/dd/yyyy HH:m zzz"
           "M/d/yyyy HH:m zzz"; "MM/d/yyyy HH:m zzz"
           "M/dd/yy HH:m zzz"; "MM/dd/yy HH:m zzz"
           "M/d/yy HH:m zzz"; "MM/d/yy HH:m zzz"
           "M/dd/yyyy H:m zzz"; "MM/dd/yyyy H:m zzz"
           "M/d/yyyy H:m zzz"; "MM/d/yyyy H:m zzz"
           "M/dd/yy H:m zzz"; "MM/dd/yy H:m zzz"
           "M/d/yy H:m zzz"; "MM/d/yy H:m zzz"
           "M/dd/yyyy HH:mm zzz"; "MM/dd/yyyy HH:mm zzz"
           "M/d/yyyy HH:mm zzz"; "MM/d/yyyy HH:mm zzz"
           "M/dd/yy HH:mm zzz"; "MM/dd/yy HH:mm zzz"
           "M/d/yy HH:mm zzz"; "MM/d/yy HH:mm zzz"
           "M/dd/yyyy H:mm zzz"; "MM/dd/yyyy H:mm zzz"
           "M/d/yyyy H:mm zzz"; "MM/d/yyyy H:mm zzz"
           "M/dd/yy H:mm zzz"; "MM/dd/yy H:mm zzz"
           "M/d/yy H:mm zzz"; "MM/d/yy H:mm zzz" |]
    let provider = CultureInfo.InvariantCulture.DateTimeFormat

    while tries < 3 && result.IsNone do
        printfn "Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),"
        printf "Then press Enter: "
        input <- stdin.ReadLine()
        printfn ""
        match DateTimeOffset.TryParseExact(input, formats, provider, DateTimeStyles.AllowWhiteSpaces) with
        | true, dto ->
            result <- Some dto
        | _ ->
            printfn $"Unable to parse {input}."
        tries <- tries + 1

    match result with
    | Some result ->
        printfn $"{input} was converted to {result}"
    | None ->
        printfn $"Exiting application without parsing {input}"

    // Some successful sample interactions with the user might appear as follows:
    //    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
    //    Then press Enter: 12/08/2007 6:54 -6:00
    //
    //    12/08/2007 6:54 -6:00 was converted to 12/8/2007 6:54:00 AM -06:00
    //
    //    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
    //    Then press Enter: 12/8/2007 06:54 -06:00
    //
    //    12/8/2007 06:54 -06:00 was converted to 12/8/2007 6:54:00 AM -06:00
    //
    //    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
    //    Then press Enter: 12/5/07 6:54 -6:00
    //
    //    12/5/07 6:54 -6:00 was converted to 12/5/2007 6:54:00 AM -06:00
    // </Snippet2>

tryParseExact1 ()
printfn ""
tryParseExact2 ()