module tryparse2

// <Snippet2>
open System
open System.Globalization

let callTryParse (stringToConvert: string) styles =
    match SByte.TryParse(stringToConvert, styles, CultureInfo.InvariantCulture) with
    | true, number ->
        printfn $"Converted '{stringToConvert}' to {number}."
    | _ ->
        printfn $"Attempted conversion of '{stringToConvert}' failed."

[<EntryPoint>]
let main _ =
    let numericString = "106"
    let styles = NumberStyles.Integer
    callTryParse numericString styles
    
    let numericString = "-106"
    let styles = NumberStyles.None
    callTryParse numericString styles
    
    let numericString = "103.00"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    callTryParse numericString styles
    
    let numericString = "103.72"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    callTryParse numericString styles

    let numericString = "10E-01"
    let styles = NumberStyles.Integer ||| NumberStyles.AllowExponent
    callTryParse numericString styles 
    
    let numericString = "12E-01"
    callTryParse numericString styles
        
    let numericString = "12E01"
    callTryParse numericString styles 
    
    let numericString = "C8"
    callTryParse numericString NumberStyles.HexNumber
    
    let numericString = "0x8C"
    callTryParse numericString NumberStyles.HexNumber
    0

// The example displays the following output:
//       Converted '106' to 106.
//       Attempted conversion of '-106' failed.
//       Converted '103.00' to 103.
//       Attempted conversion of '103.72' failed.
//       Converted '10E-01' to 1.
//       Attempted conversion of '12E-01' failed.
//       Converted '12E01' to 120.
//       Converted 'C8' to -56.
//       Attempted conversion of '0x8C' failed.
// </Snippet2>