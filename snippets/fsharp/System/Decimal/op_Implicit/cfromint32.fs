module cfromint32

//<Snippet2>
open System

// Define a list of 32-bit integer values.
let values = 
    [ Int32.MinValue; Int32.MaxValue; 0xFFFFFF; 123456789; -1000000000 ]

// Convert each value to a Decimal.
for value in values do
    let decValue: decimal = value
    printfn $"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})"

// The example displays the following output:
//    -2147483648 (Int32) --> -2147483648 (Decimal)
//    2147483647 (Int32) --> 2147483647 (Decimal)
//    16777215 (Int32) --> 16777215 (Decimal)
//    123456789 (Int32) --> 123456789 (Decimal)
//    -1000000000 (Int32) --> -1000000000 (Decimal)
//</Snippet2> 