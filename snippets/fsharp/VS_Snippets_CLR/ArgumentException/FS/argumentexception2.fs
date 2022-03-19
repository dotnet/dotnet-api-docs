module argumentexception2
// <Snippet3>
open System

let divideByTwo num =
    // If num is an odd number, throw an ArgumentException.
    if num % 2 = 1 then
        invalidArg "num" $"{num} is not an even number"

    // num is even, return half of its value.
    num / 2;

// Define some integers for a division operation.
let values = [ 10; 7 ]
for value in values do
    try 
        printfn $"{value} divided by 2 is {divideByTwo value}"
    with
    | :? ArgumentException as e ->
        printfn $"{e.GetType().Name}: {e.Message}"
    
    printfn ""

// This example displays the following output:
//     10 divided by 2 is 5
//
//     ArgumentException: 7 is not an even number (Parameter 'num')
//</snippet3>
