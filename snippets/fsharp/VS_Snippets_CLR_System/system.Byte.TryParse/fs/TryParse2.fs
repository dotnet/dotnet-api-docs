module TryParse2

// <Snippet2>
open System
open System.Globalization

let callTryParse (stringToConvert: string) (styles: NumberStyles) =
    match Byte.TryParse(stringToConvert, styles, null) with
    | true, byteValue ->
        printfn $"Converted '{stringToConvert}' to {byteValue}"
    | _ ->
        printfn $"Attempted conversion of '{stringToConvert}' failed."
                        
[<EntryPoint>]
let main _ =
    let byteString = "1024"
    let styles = NumberStyles.Integer
    callTryParse byteString styles

    let byteString = "100.1"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    callTryParse byteString styles

    let byteString = "100.0"
    callTryParse byteString styles

    let byteString = "+100"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowLeadingSign ||| NumberStyles.AllowTrailingSign
    callTryParse byteString styles

    let byteString = "-100"
    callTryParse byteString styles

    let byteString = "000000000000000100"
    callTryParse byteString styles

    let byteString = "00,100"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowThousands
    callTryParse byteString styles

    let byteString = "2E+3   "
    let styles = NumberStyles.Integer ||| NumberStyles.AllowExponent
    callTryParse byteString styles

    let byteString = "FF"
    let styles = NumberStyles.HexNumber
    callTryParse byteString styles

    let byteString = "0x1F"
    callTryParse byteString styles

    0

// The example displays the following output to the console:
//       Attempted conversion of '1024' failed.
//       Attempted conversion of '100.1' failed.
//       Converted '100.0' to 100
//       Converted '+100' to 100
//       Attempted conversion of '-100' failed.
//       Converted '000000000000000100' to 100
//       Converted '00,100' to 100
//       Attempted conversion of '2E+3   ' failed.
//       Converted 'FF' to 255
//       Attempted conversion of '0x1F' failed.
// </Snippet2>