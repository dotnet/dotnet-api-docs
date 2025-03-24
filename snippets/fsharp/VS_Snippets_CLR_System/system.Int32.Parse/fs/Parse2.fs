module Parse2

// <Snippet2>
open System
open System.Globalization

let convert value (style: NumberStyles) =
    try
        let number = Int32.Parse(value, style)
        printfn $"Converted '{value}' to {number}."
    with 
    | :? FormatException ->
        printfn $"Unable to convert '{value}'."
    | :? OverflowException ->
        printfn $"'{value}' is out of range of the Int32 type."

convert "104.0" NumberStyles.AllowDecimalPoint
convert "104.9" NumberStyles.AllowDecimalPoint
convert " $17,198,064.42" (NumberStyles.AllowCurrencySymbol ||| NumberStyles.Number)
convert "103E06" NumberStyles.AllowExponent
convert "-1,345,791" NumberStyles.AllowThousands
convert "(1,345,791)" (NumberStyles.AllowThousands ||| NumberStyles.AllowParentheses)


// The example displays the following output to the console:
//       Converted '104.0' to 104.
//       '104.9' is out of range of the Int32 type.
//       ' $17,198,064.42' is out of range of the Int32 type.
//       Converted '103E06' to 103000000.
//       Unable to convert '-1,345,791'.
//       Converted '(1,345,791)' to -1345791.
// </Snippet2>
