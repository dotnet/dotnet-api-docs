module exception1

// <Snippet1>
open System

let number1 = 3000
let number2 = 0
try
    printfn $"{number1 / number2}"
with :? DivideByZeroException ->
    printfn $"Division of {number1} by zero."

// The example displays the following output:
//        Division of 3000 by zero.
// </Snippet1>