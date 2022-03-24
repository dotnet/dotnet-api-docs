module ParseExact1

// <Snippet1>
open System
open System.Globalization

[<EntryPoint>]
let main _ =
    let provider = CultureInfo.InvariantCulture

    // Parse date-only value with invariant culture.
    let dateString = "06/15/2008"
    let format = "d"
    try
        let result = DateTime.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    // Parse date-only value without leading zero in month using "d" format.
    // Should throw a FormatException because standard short date pattern of
    // invariant culture requires two-digit month.
    let dateString = "6/15/2008"
    try
        let result = DateTime.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    // Parse date and time with custom specifier.
    let dateString = "Sun 15 Jun 2008 8:30 AM -06:00"
    let format = "ddd dd MMM yyyy h:mm tt zzz"
    try
        let result = DateTime.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    // Parse date and time with offset but without offset's minutes.
    // Should throw a FormatException because "zzz" specifier requires leading
    // zero in hours.
    let dateString = "Sun 15 Jun 2008 8:30 AM -06"
    try
        let result = DateTime.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    let dateString = "15/06/2008 08:30"
    let format = "g"
    let provider = CultureInfo "fr-FR"
    try
        let result = DateTime.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    // Parse a date that includes seconds and milliseconds
    // by using the French (France) and invariant cultures.
    let dateString = "18/08/2015 06:30:15.006542"
    let format = "dd/MM/yyyy HH:mm:ss.ffffff"
    try
        let result = DateTime.ParseExact(dateString, format, provider)
        printfn $"{dateString} converts to {result}."
    with :? FormatException ->
        printfn $"{dateString} is not in the correct format."

    0

// The example displays the following output:
//       06/15/2008 converts to 6/15/2008 12:00:00 AM.
//       6/15/2008 is not in the correct format.
//       Sun 15 Jun 2008 8:30 AM -06:00 converts to 6/15/2008 7:30:00 AM.
//       Sun 15 Jun 2008 8:30 AM -06 is not in the correct format.
//       15/06/2008 08:30 converts to 6/15/2008 8:30:00 AM.
//       18/08/2015 06:30:15.006542 converts to 8/18/2015 6:30:15 AM.
// </Snippet1>