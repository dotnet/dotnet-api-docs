// <Snippet1>
open System

let values = 
    [ 123m; Decimal(123000, 0, 0, false, 3uy)
      123.999m; 18446744073709551615.999m
      18446744073709551616m; 9223372036854775807.999m
      9223372036854775808m; -0.999m; -1m
      -9223372036854775808.999m
      -9223372036854775809m ]

for value in values do
    try
        let number = Decimal.ToUInt64 value
        printfn $"{value} --> {number}"
    with :? OverflowException as e ->
        printfn $"{e.GetType().Name}: {value}"

// The example displays the following output:
//     123 --> 123
//     123.000 --> 123
//     123.999 --> 123
//     18446744073709551615.999 --> 18446744073709551615
//     OverflowException: 18446744073709551616
//     9223372036854775807.999 --> 9223372036854775807
//     9223372036854775808 --> 9223372036854775808
//     -0.999 --> 0
//     OverflowException: -1
//     OverflowException: -9223372036854775808.999
//     OverflowException: -9223372036854775809
// </Snippet1> 