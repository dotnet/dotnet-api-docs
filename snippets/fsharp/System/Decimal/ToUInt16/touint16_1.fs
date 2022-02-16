// <Snippet1>
open System

let values = 
    [ 123m; Decimal(123000, 0, 0, false, 3uy)
      123.999m; 65535.999m; 65536m;
      32767.999m; 32768m; -0.999m;
      -1m; -32768.999m; -32769m ]

for value in values do
    try
        let number = Decimal.ToUInt16 value
        printfn $"{value} --> {number}" 
    with :? OverflowException as e ->
        printfn $"{e.GetType().Name}: {value}"

// The example displays the following output:
//     123 --> 123
//     123.000 --> 123
//     123.999 --> 123
//     65535.999 --> 65535
//     OverflowException: 65536
//     32767.999 --> 32767
//     32768 --> 32768
//     -0.999 --> 0
//     OverflowException: -1
//     OverflowException: -32768.999
//     OverflowException: -32769
// </Snippet1> 