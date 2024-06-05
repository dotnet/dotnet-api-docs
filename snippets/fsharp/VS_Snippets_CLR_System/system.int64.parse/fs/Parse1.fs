module Parse1

// <Snippet1>
open System

let convert value =
    try
        let number = Int64.Parse value
        printfn $"Converted '{value}' to {number}."
    with
    | :? FormatException ->
        printfn $"Unable to convert '{value}'."
    | :? OverflowException ->
        printfn $"'{value}' is out of range."

convert "  179042  "
convert " -2041326 "
convert " +8091522 "
convert "   1064.0   "
convert "  178.3"
convert String.Empty

decimal Int64.MaxValue + 1M
|> string
|> convert

// This example displays the following output to the console:
//       Converted '  179042  ' to 179042.
//       Converted ' -2041326 ' to -2041326.
//       Converted ' +8091522 ' to 8091522.
//       Unable to convert '   1064.0   '.
//       Unable to convert '  178.3'.
//       Unable to convert ''.
//       '92233720368547758071' is out of range.
// </Snippet1>
