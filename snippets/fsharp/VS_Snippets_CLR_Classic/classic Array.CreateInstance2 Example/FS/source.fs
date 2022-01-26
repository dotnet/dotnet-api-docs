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

// Creates and initializes a three-dimensional Array of type Object.
let my3DArray = Array.CreateInstance(typeof<obj>, 2, 3, 4 )
// let my3dArray = Array3D.zeroCreate<obj> 2 3 4

for i = my3DArray.GetLowerBound 0 to my3DArray.GetUpperBound 0 do
    for j = my3DArray.GetLowerBound 1 to my3DArray.GetUpperBound 1 do
        for k = my3DArray.GetLowerBound 2 to my3DArray.GetUpperBound 2 do
            my3DArray.SetValue($"abc{i}{j}{k}", i, j, k)

// Displays the values of the Array.
printfn "The three-dimensional Array contains the following values:"
printValues my3DArray


// This code produces the following output.
//     The three-dimensional Array contains the following values:
//         abc000    abc001    abc002    abc003
//         abc010    abc011    abc012    abc013
//         abc020    abc021    abc022    abc023
//         abc100    abc101    abc102    abc103
//         abc110    abc111    abc112    abc113
//         abc120    abc121    abc122    abc123

// </Snippet1>
