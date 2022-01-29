module Parse2

// <Snippet2>
open System
open System.Globalization

let convert value (style: NumberStyles) =
    try
        let number = Int64.Parse(value, style)
        printfn $"converted '{value}' to {number}." 
    with
    | :? FormatException ->
        printfn $"Unable to convert '{value}'."
    | :? OverflowException ->
        printfn $"'{value}' is out of range of the Int64 type."

convert "104.0" NumberStyles.AllowDecimalPoint
convert "104.9" NumberStyles.AllowDecimalPoint
convert " 106034" NumberStyles.None
convert " $17,198,064.42" (NumberStyles.AllowCurrencySymbol ||| NumberStyles.Number)
convert " $17,198,064.00" (NumberStyles.AllowCurrencySymbol ||| NumberStyles.Number)
convert "103E06" NumberStyles.AllowExponent
convert "1200E-02" NumberStyles.AllowExponent
convert "1200E-03" NumberStyles.AllowExponent
convert "-1,345,791" NumberStyles.AllowThousands
convert "(1,345,791)" (NumberStyles.AllowThousands ||| NumberStyles.AllowParentheses)
convert "FFCA00A0" NumberStyles.HexNumber
convert "0xFFCA00A0" NumberStyles.HexNumber


// The example displays the following output to the console:
//       converted '104.0' to 104.
//       '104.9' is out of range of the Int64 type.
//       Unable to convert ' 106034'.
//       ' $17,198,064.42' is out of range of the Int64 type.
//       converted ' $17,198,064.00' to 17198064.
//       converted '103E06' to 103000000.
//       converted '1200E-02' to 12.
//       '1200E-03' is out of range of the Int64 type.
//       Unable to convert '-1,345,791'.
//       converted '(1,345,791)' to -1345791.
//       converted 'FFCA00A0' to 4291428512.
//       Unable to convert '0xFFCA00A0'.
// </Snippet2>
