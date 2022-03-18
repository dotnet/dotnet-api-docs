open System
open System.Globalization

let toString1 () =
    // <Snippet1>
    // Show output for UTC time
    let thisDate = DateTimeOffset.UtcNow
    printfn $"{thisDate.ToString()}"  // Displays 3/28/2007 7:13:50 PM +00:00

    // Show output for local time
    let thisDate = DateTimeOffset.Now
    printfn $"{thisDate.ToString()}"  // Displays 3/28/2007 12:13:50 PM -07:00

    // Show output for arbitrary time offset
    let thisDate = thisDate.ToOffset(TimeSpan(-5, 0, 0))
    printfn $"{thisDate.ToString()}"  // Displays 3/28/2007 2:13:50 PM -05:00
    // </Snippet1>

let toString2 () =
    // <Snippet2>
    let cultures = 
        [| CultureInfo.InvariantCulture
           CultureInfo "en-us"
           CultureInfo "fr-fr"
           CultureInfo "de-DE"
           CultureInfo "es-ES" |]

    let thisDate = DateTimeOffset(2007, 5, 1, 9, 0, 0, TimeSpan.Zero)

    for culture in cultures do
        let cultureName = 
            if String.IsNullOrEmpty culture.Name then
                culture.NativeName
            else
                culture.Name
        printfn $"In {cultureName}, {thisDate.ToString culture}"

    // The example produces the following output:
    //    In Invariant Language (Invariant Country), 05/01/2007 09:00:00 +00:00
    //    In en-US, 5/1/2007 9:00:00 AM +00:00
    //    In fr-FR, 01/05/2007 09:00:00 +00:00
    //    In de-DE, 01.05.2007 09:00:00 +00:00
    //    In es-ES, 01/05/2007 9:00:00 +00:00
    // </Snippet2>

let toString3 () =
    // <Snippet3>
    let outputDate = DateTimeOffset(2007, 10, 31, 21, 0, 0, TimeSpan(-8, 0, 0))

    // Output date using each standard date/time format specifier
    let specifier = "d"
    // Displays   d: 10/31/2007
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "D"
    // Displays   D: Wednesday, October 31, 2007
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "t"
    // Displays   t: 9:00 PM
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "T"
    // Displays   T: 9:00:00 PM
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "f"
    // Displays   f: Wednesday, October 31, 2007 9:00 PM
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "F"
    // Displays   F: Wednesday, October 31, 2007 9:00:00 PM
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "g"
    // Displays   g: 10/31/2007 9:00 PM
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "G"
    // Displays   G: 10/31/2007 9:00:00 PM
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "M"           // 'm' is identical
    // Displays   M: October 31
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "R"           // 'r' is identical
    // Displays   R: Thu, 01 Nov 2007 05:00:00 GMT
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "s"
    // Displays   s: 2007-10-31T21:00:00
    printfn $"{specifier}: {outputDate.ToString specifier}"

    let specifier = "u"
    // Displays   u: 2007-11-01 05:00:00Z
    printfn $"{specifier}: {outputDate.ToString specifier}"

    // Specifier is not supported
    let specifier = "U"
    try
        printfn $"{specifier}: {outputDate.ToString specifier}"
    with :? FormatException ->
        printfn $"{specifier}: Not supported."

    let specifier = "Y"         // 'y' is identical
    // Displays   Y: October, 2007
    printfn $"{specifier}: {outputDate.ToString specifier}"
    // </Snippet3>

let toString4 () =
    // <Snippet4>
    let outputDate = DateTimeOffset(2007, 11, 1, 9, 0, 0, TimeSpan(-7, 0, 0))
    let format = "dddd, MMM dd yyyy HH:mm:ss zzz"

    // Output date and time using custom format specification
    printfn $"{outputDate.ToString(format, null)}"
    printfn $"{outputDate.ToString(format, CultureInfo.InvariantCulture)}"
    printfn $"""{outputDate.ToString(format, CultureInfo "fr-FR")}"""
    printfn $"""{outputDate.ToString(format, CultureInfo "es-ES")}"""

    // The example displays the following output to the console:
    //    Thursday, Nov 01 2007 09:00:00 -07:00
    //    Thursday, Nov 01 2007 09:00:00 -07:00
    //    jeudi, nov. 01 2007 09:00:00 -07:00
    //    jueves, nov 01 2007 09:00:00 -07:00
    // </Snippet4>

toString1 ()
printfn ""
toString2 ()
printfn ""
toString3 ()
printfn ""
toString4 ()