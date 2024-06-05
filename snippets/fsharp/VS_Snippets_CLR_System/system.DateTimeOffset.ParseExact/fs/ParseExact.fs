open System
open System.Globalization
open System.IO

let parseExact1 () =
    // <Snippet1>
    let provider = CultureInfo.InvariantCulture

    // Parse date-only value with invariant culture.
    let dateString = "06/15/2008"
    let format = "d"
    try
        let result = DateTimeOffset.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    // Parse date-only value without leading zero in month using "d" format.
    // Should throw a FormatException because standard short date pattern of
    // invariant culture requires two-digit month.
    let dateString = "6/15/2008"
    try
        let result = DateTimeOffset.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    // Parse date and time with custom specifier.
    let dateString = "Sun 15 Jun 2008 8:30 AM -06:00"
    let format = "ddd dd MMM yyyy h:mm tt zzz"
    try
        let result = DateTimeOffset.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    // Parse date and time with offset without offset//s minutes.
    // Should throw a FormatException because "zzz" specifier requires leading
    // zero in hours.
    let dateString = "Sun 15 Jun 2008 8:30 AM -06"
    try
        let result = DateTimeOffset.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    // The example displays the following output:
    //    06/15/2008 converts to 6/15/2008 12:00:00 AM -07:00.
    //    6/15/2008 is not in the correct format.
    //    Sun 15 Jun 2008 8:30 AM -06:00 converts to 6/15/2008 8:30:00 AM -06:00.
    //    Sun 15 Jun 2008 8:30 AM -06 is not in the correct format.
    // </Snippet1>

let parseExact2 () =
    // <Snippet2>
    let provider = CultureInfo.InvariantCulture

    // Parse date-only value with invariant culture and assume time is UTC.
    let dateString = "06/15/2008"
    let format = "d"
    try
        let result = DateTimeOffset.ParseExact(dateString, format, provider, DateTimeStyles.AssumeUniversal)
        printfn $"'{dateString}' converts to {result}."
    with :? FormatException ->
        printfn $"'{dateString}' is not in the correct format."

    // Parse date-only value with leading white space.
    // Should throw a FormatException because only trailing white space is
    // specified in method call.
    let dateString = " 06/15/2008"
    try
        let result = DateTimeOffset.ParseExact(dateString, format, provider, DateTimeStyles.AllowTrailingWhite)
        printfn $"'{dateString}' converts to {result}."
    with :? FormatException ->
        printfn $"'{dateString}' is not in the correct format."

    // Parse date and time value, and allow all white space.
    let dateString = " 06/15/   2008  15:15    -05:00"
    let format = "MM/dd/yyyy H:mm zzz"
    try
        let result = DateTimeOffset.ParseExact(dateString, format, provider, DateTimeStyles.AllowWhiteSpaces)
        printfn $"'{dateString}' converts to {result}."
    with :? FormatException ->
        printfn $"'{dateString}' is not in the correct format."

    // Parse date and time and convert to UTC.
    let dateString = "  06/15/2008 15:15:30 -05:00"
    let format = "MM/dd/yyyy H:mm:ss zzz"
    try
        let result = 
            DateTimeOffset.ParseExact(dateString, format, provider,
                                      DateTimeStyles.AllowWhiteSpaces |||
                                      DateTimeStyles.AdjustToUniversal)
        printfn $"'{dateString}' converts to {result}."
    with :? FormatException ->
        printfn $"'{dateString}' is not in the correct format."

    // The example displays the following output:
    //    '06/15/2008' converts to 6/15/2008 12:00:00 AM +00:00.
    //    ' 06/15/2008' is not in the correct format.
    //    ' 06/15/   2008  15:15    -05:00' converts to 6/15/2008 3:15:00 PM -05:00.
    //    '  06/15/2008 15:15:30 -05:00' converts to 6/15/2008 8:15:30 PM +00:00.
    // </Snippet2>

let parseExact3 () =
    // <Snippet3>
    let input = String.Empty
    let formats = 
        [| @"@M/dd/yyyy HH:m zzz"; @"MM/dd/yyyy HH:m zzz";
           @"M/d/yyyy HH:m zzz"; @"MM/d/yyyy HH:m zzz"
           @"M/dd/yy HH:m zzz"; @"MM/dd/yy HH:m zzz"
           @"M/d/yy HH:m zzz"; @"MM/d/yy HH:m zzz"
           @"M/dd/yyyy H:m zzz"; @"MM/dd/yyyy H:m zzz"
           @"M/d/yyyy H:m zzz"; @"MM/d/yyyy H:m zzz"
           @"M/dd/yy H:m zzz"; @"MM/dd/yy H:m zzz"
           @"M/d/yy H:m zzz"; @"MM/d/yy H:m zzz"
           @"M/dd/yyyy HH:mm zzz"; @"MM/dd/yyyy HH:mm zzz"
           @"M/d/yyyy HH:mm zzz"; @"MM/d/yyyy HH:mm zzz"
           @"M/dd/yy HH:mm zzz"; @"MM/dd/yy HH:mm zzz"
           @"M/d/yy HH:mm zzz"; @"MM/d/yy HH:mm zzz"
           @"M/dd/yyyy H:mm zzz"; @"MM/dd/yyyy H:mm zzz"
           @"M/d/yyyy H:mm zzz"; @"MM/d/yyyy H:mm zzz"
           @"M/dd/yy H:mm zzz"; @"MM/dd/yy H:mm zzz"
           @"M/d/yy H:mm zzz"; @"MM/d/yy H:mm zzz" |]
    let provider = CultureInfo.InvariantCulture.DateTimeFormat
    
    let mutable result = None
    let mutable tries = 0
    while tries < 3 && result.IsNone do
        printfn "Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),"
        printf "Then press Enter: "
        let input = stdin.ReadLine()
        printfn ""
        try
            result <- 
                DateTimeOffset.ParseExact(input, formats, provider, DateTimeStyles.AllowWhiteSpaces) 
                |> Some
        with :? FormatException ->
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
    // </Snippet3>

parseExact1 ()
printfn ""
parseExact2 ()
printfn ""
parseExact3 ()