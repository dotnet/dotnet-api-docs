module ctos_byte

// <Snippet4>
open System

// Define a list of decimal values.
let values = 
    [ 78m; Decimal(78000, 0, 0, false, 3uy)
      78.999m; 255.999m; 256m; 127.999m
      128m; -0.999m; -1m; -128.999m; -129m ]

for value in values do
    try
        let byteValue = byte value
        printfn $"{value} ({value.GetType().Name}) --> {byteValue} ({byteValue.GetType().Name})"

    with :? OverflowException ->
        printfn $"OverflowException: Cannot convert {value}"

// The example displays the following output:
//       78 (Decimal) --> 78 (Byte)
//       78.000 (Decimal) --> 78 (Byte)
//       78.999 (Decimal) --> 78 (Byte)
//       255.999 (Decimal) --> 255 (Byte)
//       OverflowException: Cannot convert 256
//       127.999 (Decimal) --> 127 (Byte)
//       128 (Decimal) --> 128 (Byte)
//       -0.999 (Decimal) --> 0 (Byte)
//       OverflowException: Cannot convert -1
//       OverflowException: Cannot convert -128.999
//       OverflowException: Cannot convert -129
// </Snippet4> 