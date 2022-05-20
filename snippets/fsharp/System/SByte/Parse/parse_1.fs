module parse_1

// <Snippet2>
open System
open System.Globalization

let provider = NumberFormatInfo.CurrentInfo
   
let callParseOperation stringValue (style: NumberStyles) =
    if stringValue = null then
        printfn "Cannot parse a null string..."
    else
        try
            let number = SByte.Parse(stringValue, style)
            printfn $"SByte.Parse('{stringValue}', {style})) = {number}" 
        with
        | :? FormatException ->
            printfn $"'{stringValue}' and {style} throw a FormatException"
        | :? OverflowException ->
            printfn $"'{stringValue}' is outside the range of a signed byte"

[<EntryPoint>]
let main _ =
    let stringValue = "   123   "
    let style = NumberStyles.None     
    callParseOperation stringValue style
    
    let stringValue = "000,000,123"
    let style = NumberStyles.Integer ||| NumberStyles.AllowThousands
    callParseOperation stringValue style
    
    let stringValue = "-100"
    let style = NumberStyles.AllowLeadingSign
    callParseOperation stringValue style
    
    let stringValue = "100-"
    let style = NumberStyles.AllowLeadingSign
    callParseOperation stringValue style
    
    let stringValue = "100-"
    let style = NumberStyles.AllowTrailingSign
    callParseOperation stringValue style
    
    let stringValue = "$100"
    let style = NumberStyles.AllowCurrencySymbol
    callParseOperation stringValue style
    
    let style = NumberStyles.Integer
    callParseOperation stringValue style
    
    let style = NumberStyles.AllowDecimalPoint
    callParseOperation "100.0" style
    
    let stringValue = "1e02"
    let style = NumberStyles.AllowExponent
    callParseOperation stringValue style
    
    let stringValue = "(100)"
    let style = NumberStyles.AllowParentheses
    callParseOperation stringValue style
    0

// The example displays the following information to the console:
//       '   123   ' and None throw a FormatException
//       SByte.Parse('000,000,123', Integer, AllowThousands)) = 123
//       SByte.Parse('-100', AllowLeadingSign)) = -100
//       '100-' and AllowLeadingSign throw a FormatException
//       SByte.Parse('100-', AllowTrailingSign)) = -100
//       SByte.Parse('$100', AllowCurrencySymbol)) = 100
//       '$100' and Integer throw a FormatException
//       SByte.Parse('100.0', AllowDecimalPoint)) = 100
//       SByte.Parse('1e02', AllowExponent)) = 100
//       SByte.Parse('(100)', AllowParentheses)) = -100
// </Snippet2>