// <Snippet1>
open System


// Create a one-dimensional integer array.
let integers = [| 2..2..20 |]

// Get the upper and lower bound of the array.
let upper = integers.GetUpperBound 0
let lower = integers.GetLowerBound 0
printfn $"Elements from index {lower} to {upper}:"

// Iterate the array.
for i = lower to upper do
    if i = lower then printf "   "
    printf $"{integers[i]}"
    if i < upper then ", " else Environment.NewLine
    |> printf "%s"

printfn ""

// Create a two-dimensional integer array.
let integers2d = 
    array2D [ [ 2; 4 ]; [ 3; 9 ]; [ 4; 16 ]; [ 5; 25 ]
              [ 6; 36 ]; [ 7; 49 ]; [ 8; 64 ]; [ 9; 81 ] ]

// Get the number of dimensions.
let rank = integers2d.Rank
printfn $"Number of dimensions: {rank}"
for i = 0 to rank - 1 do
    printfn $"   Dimension {i}: from {integers2d.GetLowerBound i} to {integers2d.GetUpperBound i}"

// Iterate the 2-dimensional array and display its values.
printfn "   Values of array elements:"
for outer = integers2d.GetLowerBound 0 to integers2d.GetUpperBound 0 do

    for inner = integers2d.GetLowerBound 1 to integers2d.GetUpperBound 1 do
        printfn $"      {'\u007b'}{outer}, {inner}{'\u007d'} = {integers2d.GetValue(outer, inner)}"
   
// The example displays the following output:
//       Elements from index 0 to 9:
//          2, 4, 6, 8, 10, 12, 14, 16, 18, 20
//
//       Number of dimensions: 2
//          Dimension 0: from 0 to 7
//          Dimension 1: from 0 to 1
//          Values of array elements:
//             {0, 0} = 2
//             {0, 1} = 4
//             {1, 0} = 3
//             {1, 1} = 9
//             {2, 0} = 4
//             {2, 1} = 16
//             {3, 0} = 5
//             {3, 1} = 25
//             {4, 0} = 6
//             {4, 1} = 36
//             {5, 0} = 7
//             {5, 1} = 49
//             {6, 0} = 8
//             {6, 1} = 64
//             {7, 0} = 9
//             {7, 1} = 81
// </Snippet1>
