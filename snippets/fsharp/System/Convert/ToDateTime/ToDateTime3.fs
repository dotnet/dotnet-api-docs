module ToDateTime3

// <Snippet3>
open System
open System.Globalization

printfn $"""{"Date String",-18}{"Culture",-12}{"Result"}\n"""

let cultureNames = [ "en-US"; "ru-RU"; "ja-JP" ]
let dateStrings =
    [ "01/02/09"; "2009/02/03"; "01/2009/03"
      "01/02/2009"; "21/02/09"; "01/22/09"; "01/02/23" ]
// Iterate each culture name in the array.
for cultureName in cultureNames do
    let culture = CultureInfo cultureName

    // Parse each date using the designated culture.
    for dateStr in dateStrings do
        try
            let dateTimeValue = Convert.ToDateTime(dateStr, culture)
            // Display the date and time in a fixed format.
            printfn $"""{dateStr,-18}{cultureName,-12}{dateTimeValue.ToString "yyyy-MMM-dd"}"""
        with :? FormatException as e ->
            printfn $"{dateStr,-18}{cultureName,-12}{e.GetType().Name}"
    printfn ""
// </Snippet3>