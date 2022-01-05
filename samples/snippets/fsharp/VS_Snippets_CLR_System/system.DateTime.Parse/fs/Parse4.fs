module Parse4

// <Snippet4>
open System
open System.Globalization

[<EntryPoint>]
let main _ =
    // Parse a date and time with no styles.
    let dateString = "03/01/2009 10:00 AM"
    let culture = CultureInfo.CreateSpecificCulture "en-US"
    let styles = DateTimeStyles.None
    try
        let result = DateTime.Parse(dateString, culture, styles)
        printfn $"{dateString} converted to {result} {result.Kind}."
    with :? FormatException ->
        printfn $"Unable to convert {dateString} to a date and time."

    // Parse the same date and time with the AssumeLocal style.
    let styles = DateTimeStyles.AssumeLocal
    try
        let result = DateTime.Parse(dateString, culture, styles)
        printfn $"{dateString} converted to {result} {result.Kind}."
    with :? FormatException ->
        printfn $"Unable to convert {dateString} to a date and time."

    // Parse a date and time that is assumed to be local.
    // This time is five hours behind UTC. The local system's time zone is
    // eight hours behind UTC.
    let dateString = "2009/03/01T10:00:00-5:00"
    let styles = DateTimeStyles.AssumeLocal
    try
        let result = DateTime.Parse(dateString, culture, styles)
        printfn $"{dateString} converted to {result} {result.Kind}."
    with :? FormatException ->
        printfn $"Unable to convert {dateString} to a date and time."

    // Attempt to convert a string in improper ISO 8601 format.
    let dateString = "03/01/2009T10:00:00-5:00"
    try
        let result = DateTime.Parse(dateString, culture, styles)
        printfn $"{dateString} converted to {result} {result.Kind}."
    with :? FormatException ->
        printfn $"Unable to convert {dateString} to a date and time."

    // Assume a date and time string formatted for the fr-FR culture is the local
    // time and convert it to UTC.
    let dateString = "2008-03-01 10:00"
    let culture = CultureInfo.CreateSpecificCulture "fr-FR"
    let styles = DateTimeStyles.AdjustToUniversal ||| DateTimeStyles.AssumeLocal
    try
        let result = DateTime.Parse(dateString, culture, styles)
        printfn $"{dateString} converted to {result} {result.Kind}."
    with :? FormatException ->
        printfn $"Unable to convert {dateString} to a date and time."

    0

// The example displays the following output to the console:
//       03/01/2009 10:00 AM converted to 3/1/2009 10:00:00 AM Unspecified.
//       03/01/2009 10:00 AM converted to 3/1/2009 10:00:00 AM Local.
//       2009/03/01T10:00:00-5:00 converted to 3/1/2009 7:00:00 AM Local.
//       Unable to convert 03/01/2009T10:00:00-5:00 to a date and time.
//       2008-03-01 10:00 converted to 3/1/2008 6:00:00 PM Utc.
// </Snippet4>