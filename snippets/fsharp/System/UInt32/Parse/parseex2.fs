module parseex2

// <Snippet2>
open System
open System.Globalization

let values = 
    [| " 214309 "; "1,064,181"; "(0)"; "10241+"; " + 21499 " 
       " +21499 "; "122153.00"; "1e03ff"; "91300.0e-2" |]

let whitespace =  NumberStyles.AllowLeadingWhite ||| NumberStyles.AllowTrailingWhite
let styles = 
    [| NumberStyles.None; whitespace 
       NumberStyles.AllowLeadingSign ||| NumberStyles.AllowTrailingSign ||| whitespace
       NumberStyles.AllowThousands ||| NumberStyles.AllowCurrencySymbol
       NumberStyles.AllowExponent ||| NumberStyles.AllowDecimalPoint |]

// Attempt to convert each number using each style combination.
for value in values do
    printfn $"Attempting to convert '{value}':"
    for style in styles do
        try
            let number = UInt32.Parse(value, style)
            printfn $"   {style}: {number}"
        with
        | :? FormatException ->
            printfn $"   {style}: Bad Format"
        | :? OverflowException ->
            printfn $"   {value}: Overflow"
    printfn "" 
// The example displays the following output:
//    Attempting to convert ' 214309 ':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: 214309
//       Integer, AllowTrailingSign: 214309
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '1,064,181':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: 1064181
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '(0)':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '10241+':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: 10241
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert ' + 21499 ':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert ' +21499 ':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: 21499
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '122153.00':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: 122153
//    
//    Attempting to convert '1e03ff':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '91300.0e-2':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: 913
// </Snippet2>