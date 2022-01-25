// <Snippet1>
open System

let printValues (myArr: Array) =
    let mutable i = 0
    let cols = myArr.GetLength(myArr.Rank - 1)
    for item in myArr do
        if i < cols then
            i <- i + 1
        else
            printfn ""
            i <- 1
        printf $"\t{item}"
    printfn ""

// Creates and initializes a one-dimensional Array of type int.
let my1DArray = Array.CreateInstance(typeof<int>, 5)
// let my1DArrayy = Array.zeroCreate<int> 5
for i = my1DArray.GetLowerBound 0 to my1DArray.GetUpperBound 0 do
    my1DArray.SetValue(i+1, i)

// Displays the values of the Array.
printfn "The one-dimensional Array contains the following values:"
printValues my1DArray


// This code produces the following output.
//     The one-dimensional Array contains the following values:
//         1    2    3    4    5

// </Snippet1>
