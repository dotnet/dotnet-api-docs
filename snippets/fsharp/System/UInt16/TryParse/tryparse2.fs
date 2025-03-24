module tryparse2

// <Snippet2>
open System
open System.Globalization

let callTryParse (stringToConvert: string) (styles: NumberStyles) =
    match UInt16.TryParse(stringToConvert, styles, CultureInfo.InvariantCulture) with
    | true, number ->
        printfn $"Converted '{stringToConvert}' to {number}."
    | _ -> 
        printfn $"Attempted conversion of '{stringToConvert}' failed."

do
    let numericString = "10603"
    let styles = NumberStyles.Integer
    callTryParse numericString styles
    
    let numericString = "-10603"
    let styles = NumberStyles.None
    callTryParse numericString styles
    
    let numericString = "29103.00"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    callTryParse numericString styles
    
    let numericString = "10345.72"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    callTryParse numericString styles

    let numericString = "2210E-01"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowExponent
    callTryParse numericString styles
    
    let numericString = "9112E-01"
    callTryParse numericString styles
        
    let numericString = "312E01"
    callTryParse numericString styles
    
    let numericString = "FFC8"
    callTryParse numericString NumberStyles.HexNumber
    
    let numericString = "0x8F8C"
    callTryParse numericString NumberStyles.HexNumber
// The example displays the following output:
//       Converted '10603' to 10603.
//       Attempted conversion of '-10603' failed.
//       Converted '29103.00' to 29103.
//       Attempted conversion of '10345.72' failed.
//       Converted '2210E-01' to 221.
//       Attempted conversion of '9112E-01' failed.
//       Converted '312E01' to 3120.
//       Converted 'FFC8' to 65480.
//       Attempted conversion of '0x8F8C' failed.
// </Snippet2>