module cfromint64

//<Snippet1>
open System

// Define a list of 64-bit integer values.
let values = 
    [ Int64.MinValue; Int64.MaxValue; 0xFFFFFFFFFFFFL; 123456789123456789L; -1000000000000000L ]

// Convert each value to a Decimal.
for value in values do
    let decValue: decimal = value
    printfn $"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})"

// The example displays the following output:
//    -9223372036854775808 (Int64) --> -9223372036854775808 (Decimal)
//    9223372036854775807 (Int64) --> 9223372036854775807 (Decimal)
//    281474976710655 (Int64) --> 281474976710655 (Decimal)
//    123456789123456789 (Int64) --> 123456789123456789 (Decimal)
//    -1000000000000000 (Int64) --> -1000000000000000 (Decimal)
// </Snippet1> 