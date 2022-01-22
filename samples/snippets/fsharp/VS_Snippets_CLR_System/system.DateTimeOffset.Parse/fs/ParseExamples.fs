open System
open System.Globalization

let parseOverload1 () =
    // <Snippet1>
    // String with date only
    let dateString = "05/01/2008"
    let offsetDate = DateTimeOffset.Parse dateString
    printfn $"{offsetDate}"

    // String with time only
    let dateString = "11:36 PM"
    let offsetDate = DateTimeOffset.Parse dateString
    printfn $"{offsetDate}"

    // String with date and offset
    let dateString = "05/01/2008 +1:00"
    let offsetDate = DateTimeOffset.Parse dateString
    printfn $"{offsetDate}"

    // String with day abbreviation
    let dateString = "Thu May 01, 2008"
    let offsetDate = DateTimeOffset.Parse(dateString)
    printfn $"{offsetDate}"
    // </Snippet1>

let parseOverload2 () =
    // <Snippet2>
    let fmt = CultureInfo("fr-fr").DateTimeFormat
    let dateString = "03-12-07"
    let offsetDate = DateTimeOffset.Parse(dateString, fmt)
    printfn $"{dateString} returns {offsetDate}"

    let dateString = "15/09/07 08:45:00 +1:00"
    let offsetDate = DateTimeOffset.Parse(dateString, fmt)
    printfn $"{dateString} returns {offsetDate}"

    let dateString = "mar. 1 janvier 2008 1:00:00 +1:00"
    let offsetDate = DateTimeOffset.Parse(dateString, fmt)
    printfn $"{dateString} returns {offsetDate}"

    // The example displays the following output to the console:
    //    03-12-07 returns 12/3/2007 12:00:00 AM -08:00
    //    15/09/07 08:45:00 +1:00 returns 9/15/2007 8:45:00 AM +01:00
    //    mar. 1 janvier 2008 1:00:00 +1:00 returns 1/1/2008 1:00:00 AM +01:00
    // </Snippet2>

let parseOverload3 () =
    // <Snippet3>
    let dateString = "05/01/2008 6:00:00"
    // Assume time is local
    let offsetDate = DateTimeOffset.Parse(dateString, null, DateTimeStyles.AssumeLocal)
    printfn $"{offsetDate}"   // Displays 5/1/2008 6:00:00 AM -07:00

    // Assume time is UTC
    let offsetDate = DateTimeOffset.Parse(dateString, null, DateTimeStyles.AssumeUniversal)
    printfn $"{offsetDate}"   // Displays 5/1/2008 6:00:00 AM +00:00

    // Parse and convert to UTC
    let dateString = "05/01/2008 6:00:00AM +5:00"
    let offsetDate = DateTimeOffset.Parse(dateString, null, DateTimeStyles.AdjustToUniversal)
    printfn $"{offsetDate}"   // Displays 5/1/2008 1:00:00 AM +00:00
    // </Snippet3>

parseOverload1 ()
parseOverload2 ()
parseOverload3 ()