// The following example demonstrates using the ForEach method.

//<Snippet1>
open System

let showSquares val' =
    printfn $"%i{val'} squared = %i{val' * val'}"

// create a three element array of integers
let intArray = [| 2..4 |]

Array.ForEach(intArray, showSquares)
// Array.iter showSquares intArray

// This code produces the following output:
//     2 squared = 4
//     3 squared = 9
//     4 squared = 16
//</Snippet1>
