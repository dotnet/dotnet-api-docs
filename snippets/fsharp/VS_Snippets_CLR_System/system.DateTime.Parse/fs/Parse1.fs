module Parse1

// <Snippet1>
open System
open System.Globalization

[<EntryPoint>]
let main _ =
    // Assume the current culture is en-US.
    // The date is February 16, 2008, 12 hours, 15 minutes and 12 seconds.

    // Use standard en-US date and time value
    let dateString = "2/16/2008 12:15:12 PM"
    try
        let dateValue = DateTime.Parse dateString
        printfn $"'{dateString}' converted to {dateValue}."
    with :? FormatException ->
        printfn $"Unable to convert '{dateString}'."

    // Reverse month and day to conform to the fr-FR culture.
    // The date is February 16, 2008, 12 hours, 15 minutes and 12 seconds.
    let dateString = "16/02/2008 12:15:12"
    try
        let dateValue = DateTime.Parse dateString
        printfn $"'{dateString}' converted to {dateValue}."
    with :? FormatException ->
        Console.WriteLine("Unable to convert '{0}'.", dateString)

    // Call another overload of Parse to successfully convert string
    // formatted according to conventions of fr-FR culture.
    try
        let dateValue = DateTime.Parse(dateString, CultureInfo("fr-FR", false))
        printfn $"'{dateString}' converted to {dateValue}."
    with :? FormatException ->
        printfn $"Unable to convert '{dateString}'."

    // Parse string with date but no time component.
    let dateString = "2/16/2008"
    try
        let dateValue = DateTime.Parse dateString
        printfn $"'{dateString}' converted to {dateValue}."
    with :? FormatException ->
        printfn $"Unable to convert '{dateString}'."

    0

// The example displays the following output to the console:
//       '2/16/2008 12:15:12 PM' converted to 2/16/2008 12:15:12 PM.
//       Unable to convert '16/02/2008 12:15:12'.
//       '16/02/2008 12:15:12' converted to 2/16/2008 12:15:12 PM.
//       '2/16/2008' converted to 2/16/2008 12:00:00 AM.
// </Snippet1>