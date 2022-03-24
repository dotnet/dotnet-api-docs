module parseex3

// <Snippet3>
open System
open System.Globalization

let nf = NumberFormatInfo()
nf.NegativeSign <- "~" 

let values = [| "-103"; "+12"; "~16"; "  1"; "~255" |]
let providers: IFormatProvider[] = [| nf; CultureInfo.InvariantCulture |]

for provider in providers do
    printfn $"Conversions using {(box provider).GetType().Name}:"
    for value in values do
        try
            printfn $"   Converted '{value}' to {SByte.Parse(value, provider)}."
        with
        | :? FormatException ->
            printfn $"   Unable to parse '{value}'."
        | :? OverflowException ->
            printfn $"   '{value}' is out of range of the SByte type."

// The example displays the following output:
//       Conversions using NumberFormatInfo:
//          Unable to parse '-103'.
//          Converted '+12' to 12.
//          Converted '~16' to -16.
//          Converted '  1' to 1.
//          '~255' is out of range of the SByte type.
//       Conversions using CultureInfo:
//          Converted '-103' to -103.
//          Converted '+12' to 12.
//          Unable to parse '~16'.
//          Converted '  1' to 1.
//          Unable to parse '~255'.
// </Snippet3>
