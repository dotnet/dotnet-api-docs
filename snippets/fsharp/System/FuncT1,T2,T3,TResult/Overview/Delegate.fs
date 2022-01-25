module Delegate

// <Snippet1>
open System
open System.Globalization

type ParseNumber<'T> = delegate of (string * NumberStyles * IFormatProvider) -> 'T

let numericString = "-1,234"
let parser = ParseNumber<int> Int32.Parse

parser.Invoke(
    numericString,
    NumberStyles.Integer ||| NumberStyles.AllowThousands,
    CultureInfo.InvariantCulture )
|> printfn "%i"
// </Snippet1>
