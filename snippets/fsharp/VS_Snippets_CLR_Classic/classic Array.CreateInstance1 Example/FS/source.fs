// <Snippet1>
open System

let printValues (myArray: Array) =
    let mutable i = 0
    let cols = myArray.GetLength(myArray.Rank - 1)
    for item in myArray do
        if i < cols then
            i <- i + 1
        else
            printfn ""
            i <- 1;
        printf $"\t{item}"
    printfn ""

// Creates and initializes a two-dimensional Array of type string.
let my2DArray = Array.CreateInstance(typeof<string>, 2, 3)
// let my2DArray2 = Array2D.zeroCreate<string> 2 3

for i = my2DArray.GetLowerBound 0 to my2DArray.GetUpperBound 0 do
    for j = my2DArray.GetLowerBound 1 to my2DArray.GetUpperBound 1 do
        my2DArray.SetValue( $"abc{i}{j}", i, j )

// Displays the values of the Array.
printfn "The two-dimensional Array contains the following values:"
printValues my2DArray 


// This code produces the following output.
//     The two-dimensional Array contains the following values:
//         abc00    abc01    abc02
//         abc10    abc11    abc12

// </Snippet1>
