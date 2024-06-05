module Parse3

// <Snippet3>
open System
open System.Globalization

// Define cultures to be used to parse dates.
let cultures = 
    [ CultureInfo.CreateSpecificCulture "en-US"
      CultureInfo.CreateSpecificCulture "fr-FR"
      CultureInfo.CreateSpecificCulture "de-DE" ]

// Define string representations of a date to be parsed.
let dateStrings = 
    [ "01/10/2009 7:34 PM"
      "10.01.2009 19:34"
      "10-1-2009 19:34" ]

// Parse dates using each culture.
for culture in cultures do
    printfn $"Attempted conversions using {culture.Name} culture."
    for dateString in dateStrings do
        try
            let dateValue = DateTime.Parse(dateString, culture)
            printfn $"""   Converted '{dateString}' to {dateValue.ToString("f", culture)}."""
        with :? FormatException ->
            printfn $"   Unable to convert '{dateString}' for culture {culture.Name}." 
    printfn ""


// The example displays the following output to the console:
//       Attempted conversions using en-US culture.
//          Converted '01/10/2009 7:34 PM' to Saturday, January 10, 2009 7:34 PM.
//          Converted '10.01.2009 19:34' to Thursday, October 01, 2009 7:34 PM.
//          Converted '10-1-2009 19:34' to Thursday, October 01, 2009 7:34 PM.
//
//       Attempted conversions using fr-FR culture.
//          Converted '01/10/2009 7:34 PM' to jeudi 1 octobre 2009 19:34.
//          Converted '10.01.2009 19:34' to samedi 10 janvier 2009 19:34.
//          Converted '10-1-2009 19:34' to samedi 10 janvier 2009 19:34.
//
//       Attempted conversions using de-DE culture.
//          Converted '01/10/2009 7:34 PM' to Donnerstag, 1. Oktober 2009 19:34.
//          Converted '10.01.2009 19:34' to Samstag, 10. Januar 2009 19:34.
//          Converted '10-1-2009 19:34' to Samstag, 10. Januar 2009 19:34.
// </Snippet3>