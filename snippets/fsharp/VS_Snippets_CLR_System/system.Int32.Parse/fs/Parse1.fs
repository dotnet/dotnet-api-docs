module Parse1

// <Snippet1>
open System

let values =
    [ "+13230"; "-0"; "1,390,146"; "$190,235,421,127"
      "0xFA1B"; "163042"; "-10"; "007"; "2147483647"
      "2147483648"; "16e07"; "134985.0"; "-12034"
      "-2147483648"; "-2147483649" ]

for value in values do
    try
        let number = Int32.Parse value
        printfn $"{value} --> {number}"
    with 
    | :? FormatException ->
        printfn $"{value}: Bad Format"
    | :? OverflowException ->
        printfn $"{value}: Overflow"
    

// The example displays the following output:
//       +13230 --> 13230
//       -0 --> 0
//       1,390,146: Bad Format
//       $190,235,421,127: Bad Format
//       0xFA1B: Bad Format
//       163042 --> 163042
//       -10 --> -10
//       007 --> 7
//       2147483647 --> 2147483647
//       2147483648: Overflow
//       16e07: Bad Format
//       134985.0: Bad Format
//       -12034 --> -12034
//       -2147483648 --> -2147483648
//       -2147483649: Overflow
// </Snippet1>
