module abs3

// <Snippet3>
open System

let values = 
    [ Int16.MaxValue; 10328s; 0s; -1476s; Int16.MinValue ]

for value in values do
    try
        // The 'abs' function may be used instead.
        printfn $"Abs({value}) = {Math.Abs value}"
    with :? OverflowException ->
        printfn $"Unable to calculate the absolute value of {value}."

// The example displays the following output:
//       Abs(32767) = 32767
//       Abs(10328) = 10328
//       Abs(0) = 0
//       Abs(-1476) = 1476
//       Unable to calculate the absolute value of -32768.
// </Snippet3>