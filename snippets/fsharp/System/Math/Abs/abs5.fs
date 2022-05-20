module abs5

// <Snippet5>
open System

let values = 
    [ Int64.MaxValue; 109013; 0; -6871982; Int64.MinValue ]

for value in values do
    try
        // The 'abs' function may be used instead.
        printfn $"Abs({value}) = {Math.Abs value}"
    with :? OverflowException ->
        printfn $"Unable to calculate the absolute value of {value}."

// The example displays the following output:
//       Abs(9223372036854775807) = 9223372036854775807
//       Abs(109013) = 109013
//       Abs(0) = 0
//       Abs(-6871982) = 6871982
//       Unable to calculate the absolute value of -9223372036854775808.
// </Snippet5>