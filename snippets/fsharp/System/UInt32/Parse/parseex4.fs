module parseex4

// <Snippet4>
open System
open System.Globalization

let cultureNames = [| "en-US"; "fr-FR" |]
let styles = 
    [| NumberStyles.Integer; NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint |]
let values = 
    [| "170209"; "+170209.0"; "+170209,0"; "-103214.00"; "-103214,00"; "104561.1"; "104561,1" |]

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
                printfn $"      Converted '{value}' to {UInt32.Parse(value, style, ci)}."
            with
            | :? FormatException ->
                printfn $"      Unable to parse '{value}'."
            | :? OverflowException ->
                printfn $"      '{value}' is out of range of the UInt32 type."
// The example displays the following output:
//       Parsing strings using the English (United States) culture
//          Style: Integer
//             Converted '170209' to 170209.
//             Unable to parse '+170209.0'.
//             Unable to parse '+170209,0'.
//             Unable to parse '-103214.00'.
//             Unable to parse '-103214,00'.
//             Unable to parse '104561.1'.
//             Unable to parse '104561,1'.
//          Style: Integer, AllowDecimalPoint
//             Converted '170209' to 170209.
//             Converted '+170209.0' to 170209.
//             Unable to parse '+170209,0'.
//             '-103214.00' is out of range of the UInt32 type.
//             Unable to parse '-103214,00'.
//             '104561.1' is out of range of the UInt32 type.
//             Unable to parse '104561,1'.
//       Parsing strings using the French (France) culture
//          Style: Integer
//             Converted '170209' to 170209.
//             Unable to parse '+170209.0'.
//             Unable to parse '+170209,0'.
//             Unable to parse '-103214.00'.
//             Unable to parse '-103214,00'.
//             Unable to parse '104561.1'.
//             Unable to parse '104561,1'.
//          Style: Integer, AllowDecimalPoint
//             Converted '170209' to 170209.
//             Unable to parse '+170209.0'.
//             Converted '+170209,0' to 170209.
//             Unable to parse '-103214.00'.
//             '-103214,00' is out of range of the UInt32 type.
//             Unable to parse '104561.1'.
//             '104561,1' is out of range of the UInt32 type.
// </Snippet4>