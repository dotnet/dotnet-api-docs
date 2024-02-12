module cfromsbyte

//<Snippet4>
open System

// Define a list of 8-bit signed integer values.
let values = 
    [ SByte.MinValue; SByte.MaxValue; 0x3Fy; 123y; -100y ]

// Convert each value to a Decimal.
for value in values do
    let decValue: decimal = value
    printfn $"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})"

// The example displays the following output:
//    -128 (SByte) --> -128 (Decimal)
//    127 (SByte) --> 127 (Decimal)
//    63 (SByte) --> 63 (Decimal)
//    123 (SByte) --> 123 (Decimal)
//    -100 (SByte) --> -100 (Decimal)
// </Snippet4> 