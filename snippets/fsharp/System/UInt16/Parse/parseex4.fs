module parseex4

// <Snippet4>
open System
open System.Globalization

let cultureNames = [| "en-US"; "fr-FR" |]
let styles = 
    [| NumberStyles.Integer; NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint |]
let values =
    [| "1702"; "+1702.0"; "+1702,0"; "-1032.00"; "-1032,00"; "1045.1"; "1045,1" |]

// Parse strings using each culture
for cultureName in cultureNames do
    let ci = CultureInfo cultureName
    printfn $"Parsing strings using the {ci.DisplayName} culture"
    // Use each style.
    for style in styles do
        printfn $"   Style: {style}"
        // Parse each numeric string.
        for value in values do
            try
                printfn $"      Converted '{value}' to {UInt16.Parse(value, style, ci)}."
            with
            | :? FormatException ->
                printfn $"      Unable to parse '{value}'."
            | :? OverflowException ->
                printfn $"      '{value}' is out of range of the UInt16 type."
// The example displays the following output:
//       Parsing strings using the English (United States) culture
//          Style: Integer
//             Converted '1702' to 1702.
//             Unable to parse '+1702.0'.
//             Unable to parse '+1702,0'.
//             Unable to parse '-1032.00'.
//             Unable to parse '-1032,00'.
//             Unable to parse '1045.1'.
//             Unable to parse '1045,1'.
//          Style: Integer, AllowDecimalPoint
//             Converted '1702' to 1702.
//             Converted '+1702.0' to 1702.
//             Unable to parse '+1702,0'.
//             '-1032.00' is out of range of the UInt16 type.
//             Unable to parse '-1032,00'.
//             '1045.1' is out of range of the UInt16 type.
//             Unable to parse '1045,1'.
//       Parsing strings using the French (France) culture
//          Style: Integer
//             Converted '1702' to 1702.
//             Unable to parse '+1702.0'.
//             Unable to parse '+1702,0'.
//             Unable to parse '-1032.00'.
//             Unable to parse '-1032,00'.
//             Unable to parse '1045.1'.
//             Unable to parse '1045,1'.
//          Style: Integer, AllowDecimalPoint
//             Converted '1702' to 1702.
//             Unable to parse '+1702.0'.
//             Converted '+1702,0' to 1702.
//             Unable to parse '-1032.00'.
//             '-1032,00' is out of range of the UInt16 type.
//             Unable to parse '1045.1'.
//             '1045,1' is out of range of the UInt16 type.
// </Snippet4>