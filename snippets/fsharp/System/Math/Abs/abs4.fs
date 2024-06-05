module abs4

// <Snippet4>
open System

let values = 
    [ Int32.MaxValue; 16921; 0; -804128; Int32.MinValue ]

for value in values do
    try 
        // The 'abs' function may be used instead.
        printfn $"Abs({value}) = {Math.Abs(value)}"
    with :? OverflowException ->
        printfn $"Unable to calculate the absolute value of {value}."

// The example displays the following output:
//       Abs(2147483647) = 2147483647
//       Abs(16921) = 16921
//       Abs(0) = 0
//       Abs(-804128) = 804128
//       Unable to calculate the absolute value of -2147483648.
// </Snippet4>