module parseex2

// <Snippet2>
open System
open System.Globalization

// Parse value with no styles allowed.
let values1 = [| " 121 "; "121"; "-121" |]
let style = NumberStyles.None
printfn $"Styles: {style}"
for value in values1 do
    try
        let number = SByte.Parse(value, style)
        printfn $"   Converted '{value}' to {number}."
    with :? FormatException ->
        printfn $"   Unable to parse '{value}'."
printfn ""
            
// Parse value with trailing sign.
let style2 = NumberStyles.Integer ||| NumberStyles.AllowTrailingSign
let values2 = [| " 103+"; " 103 +"; "+103"; "(103)"; "   +103  " |]
printfn $"Styles: {style2}"
for value in values2 do
    try
        let number = SByte.Parse(value, style2)
        printfn $"   Converted '{value}' to {number}."
    with 
    | :? FormatException ->
        printfn $"   Unable to parse '{value}'."
    | :? OverflowException ->
        printfn $"   '{value}' is out of range of the SByte type."         
printfn ""
// The example displays the following output:
//       Styles: None
//          Unable to parse ' 121 '.
//          Converted '121' to 121.
//          Unable to parse '-121'.
//       
//       Styles: Integer, AllowTrailingSign
//          Converted ' 103+' to 103.
//          Converted ' 103 +' to 103.
//          Converted '+103' to 103.
//          Unable to parse '(103)'.
//          Converted '   +103  ' to 103.
// </Snippet2>