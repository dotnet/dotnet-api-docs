module TryParse2

// <Snippet2>
open System
open System.Globalization

let callTryParse (stringToConvert: string) (styles: NumberStyles) =
    match Int16.TryParse(stringToConvert, styles, CultureInfo.InvariantCulture) with
    | true, number ->
        printfn $"Converted '{stringToConvert}' to {number}."
    | _ ->
        printfn $"Attempted conversion of '{stringToConvert}' failed."

[<EntryPoint>]
let main _ =
    let numericString = "10677"
    let styles = NumberStyles.Integer
    callTryParse numericString styles

    let numericString = "-30677"
    let styles = NumberStyles.None
    callTryParse numericString styles

    let numericString = "10345.00"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    callTryParse numericString styles

    let numericString = "10345.72";
    let styles = NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    callTryParse numericString styles

    let numericString = "22,593"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowThousands
    callTryParse numericString styles

    let numericString = "12E-01"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowExponent
    callTryParse numericString styles

    let numericString = "12E03"
    callTryParse numericString styles

    let numericString = "80c1"
    callTryParse numericString NumberStyles.HexNumber

    let numericString = "0x80C1"
    callTryParse numericString NumberStyles.HexNumber

    0


// The example displays the following output to the console:
//       Converted '10677' to 10677.
//       Attempted conversion of '-30677' failed.
//       Converted '10345.00' to 10345.
//       Attempted conversion of '10345.72' failed.
//       Converted '22,593' to 22593.
//       Attempted conversion of '12E-01' failed.
//       Converted '12E03' to 12000.
//       Converted '80c1' to -32575.
//       Attempted conversion of '0x80C1' failed.
// </Snippet2>