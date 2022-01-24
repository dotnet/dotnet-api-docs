module Func4

// <Snippet2>
open System
open System.Globalization

let parseInt (str: string) styles format = Int32.Parse(str, styles, format)

let numericString = "-1,234"

let parser =
    Func<string, NumberStyles, IFormatProvider, int> parseInt

parser.Invoke(
    numericString,
    NumberStyles.Integer ||| NumberStyles.AllowThousands,
    CultureInfo.InvariantCulture )
|> printfn "%i"
// </Snippet2>
