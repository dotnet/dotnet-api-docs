module cfromuint16

//<Snippet3>
open System

// Define a list of 16-bit unsigned integer values.
let values = 
    [ UInt16.MinValue; UInt16.MaxValue; 0xFFFus; 12345us; 40000us ]

// Convert each value to a Decimal.
for value in values do
    let decValue: decimal = value
    printfn $"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})"

// The example displays the following output:
//       0 (UInt16) --> 0 (Decimal)
//       65535 (UInt16) --> 65535 (Decimal)
//       4095 (UInt16) --> 4095 (Decimal)
//       12345 (UInt16) --> 12345 (Decimal)
//       40000 (UInt16) --> 40000 (Decimal)
// </Snippet3> 