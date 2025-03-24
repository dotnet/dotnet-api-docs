module cfromint16

// <Snippet3>
open System

// Define a list of 16-bit integer values.
let values = 
    [ Int16.MinValue; Int16.MaxValue; 0xFFFs; 12345s; -10000s ]

// Convert each value to a Decimal.
for value in values do
    let decValue: decimal = value
    printfn $"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})"

// The example displays the following output:
//       -32768 (Int16) --> -32768 (Decimal)
//       32767 (Int16) --> 32767 (Decimal)
//       4095 (Int16) --> 4095 (Decimal)
//       12345 (Int16) --> 12345 (Decimal)
//       -10000 (Int16) --> -10000 (Decimal)
//</Snippet3> 