module parseex3

// <Snippet3>
open System
open System.Globalization

// Define a custom culture that uses "++" as a positive sign. 
let ci = CultureInfo ""
ci.NumberFormat.PositiveSign <- "++"
// Create an array of cultures.
let cultures = [| ci; CultureInfo.InvariantCulture |]
// Create an array of strings to parse.
let values = 
    [| "++1403"; "-0"; "+0"; "+16034" 
       string Int16.MinValue; "14.0"; "18012" |]
// Parse the strings using each culture.
for culture in cultures do
    printfn $"Parsing with the '{culture.Name}' culture."
    for value in values do
        try
            let number = UInt16.Parse(value, culture)
            printfn $"   Converted '{value}' to {number}."
        with
        | :? FormatException ->
            printfn $"   The format of '{value}' is invalid."
        | :? OverflowException ->
            printfn $"   '{value}' is outside the range of a UInt16 value."
// The example displays the following output:
//       Parsing with the  culture.
//          Converted '++1403' to 1403.
//          Converted '-0' to 0.
//          The format of '+0' is invalid.
//          The format of '+16034' is invalid.
//          '-32768' is outside the range of a UInt16 value.
//          The format of '14.0' is invalid.
//          Converted '18012' to 18012.
//       Parsing with the '' culture.
//          The format of '++1403' is invalid.
//          Converted '-0' to 0.
//          Converted '+0' to 0.
//          Converted '+16034' to 16034.
//          '-32768' is outside the range of a UInt16 value.
//          The format of '14.0' is invalid.
//          Converted '18012' to 18012.
// </Snippet3>