module abs6

// <Snippet6>
open System

let values = 
    [ SByte.MaxValue; 98y; 0y; -32y; SByte.MinValue ]

for value in values do
    try
        // The 'abs' function may be used instead.
        printfn $"Abs({value}) = {Math.Abs value}"
    with :? OverflowException ->
        printfn $"Unable to calculate the absolute value of {value}."

// The example displays the following output:
//       Abs(127) = 127
//       Abs(98) = 98
//       Abs(0) = 0
//       Abs(-32) = 32
//       Unable to calculate the absolute value of -128.
// </Snippet6>