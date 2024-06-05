module parse1

// <Snippet2>
open System

let values = 
    [| "100"; "(100)"; "-123,456,789"; "123.45e+6" 
       "+500"; "5e2"; "3.1416"; "600."; "-.123" 
       "-Infinity"; "-1E-16"; string Double.MaxValue
       string Single.MinValue; String.Empty |]

for value in values do
    try
        let number = Single.Parse value
        printfn $"{value} -> {number}"
    with
    | :? FormatException ->
        printfn $"'{value}' is not in a valid format."
    | :? OverflowException ->
        printfn $"{value} is outside the range of a Single."
// The example displays the following output:
//       100 -> 100
//       '(100)' is not in a valid format.
//       -123,456,789 -> -1.234568E+08
//       123.45e+6 -> 1.2345E+08
//       +500 -> 500
//       5e2 -> 500
//       3.1416 -> 3.1416
//       600. -> 600
//       -.123 -> -0.123
//       -Infinity -> -Infinity
//       -1E-16 -> -1E-16
//       1.79769313486232E+308 is outside the range of a Single.
//       -3.402823E+38 -> -3.402823E+38
//       '' is not in a valid format.
// </Snippet2>