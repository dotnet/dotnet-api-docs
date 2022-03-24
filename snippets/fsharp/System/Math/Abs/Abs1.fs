module Abs1

// <Snippet1>
open System

let decimals = 
    [ Decimal.MaxValue; 12.45M; 0M
      -19.69M; Decimal.MinValue ]

for value in decimals do
    // The 'abs' function may be used instead.
    printfn $"Abs({value}) = {Math.Abs value}"

// The example displays the following output:
//       Abs(79228162514264337593543950335) = 79228162514264337593543950335
//       Abs(12.45) = 12.45
//       Abs(0) = 0
//       Abs(-19.69) = 19.69
//       Abs(-79228162514264337593543950335) = 79228162514264337593543950335
// </Snippet1>