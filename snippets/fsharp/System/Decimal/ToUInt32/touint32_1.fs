// <Snippet1>
open System

let values = 
    [ 123m; Decimal(123000, 0, 0, false, 3uy)
      123.999m; 4294967295.999m; 4294967296m
      4294967296m; 2147483647.999m; 2147483648m
      -0.999m; -1m; -2147483648.999m; -2147483649m ]

for value in values do
    try
        let number = Decimal.ToUInt32 value
        printfn $"{value} --> {number}"
    with :? OverflowException as e ->
        printfn $"{e.GetType().Name}: {value}"

// The example displays the following output:
//     123 --> 123
//     123.000 --> 123
//     123.999 --> 123
//     4294967295.999 --> 4294967295
//     OverflowException: 4294967296
//     OverflowException: 4294967296
//     2147483647.999 --> 2147483647
//     2147483648 --> 2147483648
//     -0.999 --> 0
//     OverflowException: -1
//     OverflowException: -2147483648.999
//     OverflowException: -2147483649
// </Snippet1> 