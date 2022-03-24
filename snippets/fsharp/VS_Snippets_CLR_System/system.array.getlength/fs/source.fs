// The following example demonstrates using the Array.GetLength method.

// <Snippet1>
open System

// make a single dimension array
let myArray1 = Array.zeroCreate<int> 5

// make a 3 dimensional array
let myArray2 = Array3D.zeroCreate<int> 5 3 2

// make an array container
let bossArray: Array [] = 
    [|  myArray1
        myArray2 |]

let mutable i = 0
for anArray in bossArray do
    let rank = anArray.Rank;
    if rank > 1 then
        printfn $"Lengths of {rank:d} dimension array[{i:d}]"
        // show the lengths of each dimension
        for j = 0 to rank - 1 do
            printfn $"    Length of dimension({j:d}) = {anArray.GetLength(j):d}"
    else
        printfn $"Lengths of single dimension array[{i:d}]"

    // show the total length of the entire array or all dimensions
    printfn $"    Total length of the array = {anArray.Length:d}\n"
    i <- i + 1


// This code produces the following output:
//     Lengths of single dimension array[0]
//         Total length of the array = 5
//
//     Lengths of 3 dimension array[1]
//         Length of dimension(0) = 5
//         Length of dimension(1) = 3
//         Length of dimension(2) = 2
//     Total length of the array = 30
// </Snippet1>
