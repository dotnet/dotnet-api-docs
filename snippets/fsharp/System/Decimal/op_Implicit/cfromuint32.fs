module cfromuint32

// <Snippet2>
open System

// Define a list of 32-bit unsigned integer values.
let values = 
    [ UInt32.MinValue; UInt32.MaxValue; 0xFFFFFFu; 123456789u; 4000000000u ]

// Convert each value to a Decimal.
for value in values do
    let decValue: decimal = value
    printfn $"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})"

// The example displays the following output:
//       0 (UInt32) --> 0 (Decimal)
//       4294967295 (UInt32) --> 4294967295 (Decimal)
//       16777215 (UInt32) --> 16777215 (Decimal)
//       123456789 (UInt32) --> 123456789 (Decimal)
//       4000000000 (UInt32) --> 4000000000 (Decimal)
// </Snippet2> 