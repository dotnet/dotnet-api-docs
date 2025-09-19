module cfromuint64

// <Snippet1>
open System

// Define a list of 64-bit unsigned integer values.
let values = 
    [ UInt64.MinValue; UInt64.MaxValue; 0xFFFFFFFFFFFFuL; 123456789123456789uL; 1000000000000000uL ]

// Convert each value to a Decimal.
for value in values do
    let decValue: decimal = value
    printfn $"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})"

// The example displays the following output:
//    0 (UInt64) --> 0 (Decimal)
//    18446744073709551615 (UInt64) --> 18446744073709551615 (Decimal)
//    281474976710655 (UInt64) --> 281474976710655 (Decimal)
//    123456789123456789 (UInt64) --> 123456789123456789 (Decimal)
//    1000000000000000 (UInt64) --> 1000000000000000 (Decimal)
// </Snippet1> 