module Round12

// <Snippet12>
open System

// Define a set of Decimal values.
let values = 
    [ 1.45m; 1.55m; 123.456789m; 123.456789m
      123.456789m; -123.456m
      Decimal(1230000000, 0, 0, true, 7uy)
      Decimal(1230000000, 0, 0, true, 7uy)
      -9999999999.9999999999m
      -9999999999.9999999999m ]

// Define a set of integers to for decimals argument.
let decimals = 
    [ 1; 1; 4; 6; 8; 0; 3; 11; 9; 10 ]

printfn $"""{"Argument",26}{"Digits",8}{"Result",26}"""
printfn $"""{"--------",26}{"------",8}{"------",26}"""

for i = 0 to values.Length - 1 do
    printfn $"{values[i],26}{decimals[i],8}{Decimal.Round(values[i], decimals[i]),26}"

// The example displays the following output:
//                   Argument  Digits                    Result
//                   --------  ------                    ------
//                       1.45       1                       1.4
//                       1.55       1                       1.6
//                 123.456789       4                  123.4568
//                 123.456789       6                123.456789
//                 123.456789       8                123.456789
//                   -123.456       0                      -123
//               -123.0000000       3                  -123.000
//               -123.0000000      11              -123.0000000
//     -9999999999.9999999999       9    -10000000000.000000000
//     -9999999999.9999999999      10    -9999999999.9999999999
//</Snippet12> 