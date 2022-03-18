module parseex1

// <Snippet1>
open System

// Define an array of numeric strings.
let values = 
    [| "-16"; "  -3"; "+ 12"; " +12 "; "  12  "
       "+120"; "(103)"; "192"; "-160" |]
                            
// Parse each string and display the result.
for value in values do
    try
        printfn $"Converted '{value}' to the SByte value {SByte.Parse value}."
    with
    | :? FormatException ->
        printfn $"'{value}' cannot be parsed successfully by SByte type."
    | :? OverflowException ->
        printfn $"'{value}' is out of range of the SByte type."
        
// The example displays the following output:
//       Converted '-16' to the SByte value -16.
//       Converted '  -3' to the SByte value -3.
//       '+ 12' cannot be parsed successfully by SByte type.
//       Converted ' +12 ' to the SByte value 12.
//       Converted '  12  ' to the SByte value 12.
//       Converted '+120' to the SByte value 120.
//       '(103)' cannot be parsed successfully by SByte type.
//       '192' is out of range of the SByte type.
//       '-160' is out of range of the SByte type.
// </Snippet1>