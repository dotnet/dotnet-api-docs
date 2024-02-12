module tryparse21

// <Snippet2>
open System
open System.Globalization

let callTryParse (stringToConvert: string) (styles: NumberStyles) =
    match UInt32.TryParse(stringToConvert, styles, CultureInfo.InvariantCulture) with
    | true, number ->
        printfn $"Converted '{stringToConvert}' to {number}."
        printfn $"Attempted conversion of '{stringToConvert}' failed."
    | _ -> ()

do
    let numericString = "2106034"
    let styles = NumberStyles.Integer
    callTryParse numericString styles

    let numericString = "-10603"
    let styles = NumberStyles.None
    callTryParse numericString styles

    let numericString = "29103674.00"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    callTryParse numericString styles

    let numericString = "10345.72"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    callTryParse numericString styles

    let numericString = "41792210E-01"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowExponent
    callTryParse numericString styles 

    let numericString = "9112E-01"
    callTryParse numericString styles
        
    let numericString = "312E01"
    callTryParse numericString styles 

    let numericString = "FFC86DA1"
    callTryParse numericString NumberStyles.HexNumber

    let numericString = "0x8F8C"
    callTryParse numericString NumberStyles.HexNumber
   
// The example displays the following output:
//       Converted '2106034' to 2106034.
//       Attempted conversion of '-10603' failed.
//       Converted '29103674.00' to 29103674.
//       Attempted conversion of '10345.72' failed.
//       Converted '41792210E-01' to 4179221.
//       Attempted conversion of '9112E-01' failed.
//       Converted '312E01' to 3120.
//       Converted 'FFC86DA1' to 4291325345.
//       Attempted conversion of '0x8F8C' failed.
// </Snippet2>