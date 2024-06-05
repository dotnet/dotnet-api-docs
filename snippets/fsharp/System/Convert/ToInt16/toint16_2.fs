module toint16_2

// <Snippet14>
open System

let hexStrings = 
    [| "8000"; "0FFF"; "f000"; "00A30"
       "D"; "-13"; "9AC61"; "GAD" |]

for hexString in hexStrings do
    try
        let number = Convert.ToInt16(hexString, 16)
        printfn $"Converted '{hexString}' to {number:N0}."
    with
    | :? FormatException ->
        printfn $"'{hexString}' is not in the correct format for a hexadecimal number."
    | :? OverflowException ->
        printfn $"'{hexString}' is outside the range of an Int16."
    | :? ArgumentException ->
        printfn $"'{hexString}' is invalid in base 16."
// The example displays the following output:
//       Converted '8000' to -32,768.
//       Converted '0FFF' to 4,095.
//       Converted 'f000' to -4,096.
//       Converted '00A30' to 2,608.
//       Converted 'D' to 13.
//       '-13' is invalid in base 16.
//       '9AC61' is outside the range of an Int16.
//       'GAD' is not in the correct format for a hexadecimal number.
// </Snippet14>