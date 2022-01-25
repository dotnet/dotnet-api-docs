// <Snippet1>
open System


let showArrayInfo (arr: Array) =
    printfn $"Length of Array:      {arr.Length,3}"
    printfn $"Number of Dimensions: {arr.Rank,3}"
    // For multidimensional arrays, show number of elements in each dimension.
    if arr.Rank > 1 then
        for dimension = 1 to arr.Rank do
            printfn $"   Dimension {dimension}: {arr.GetUpperBound(dimension - 1) + 1,3}"
    printfn ""

// Declare a single-dimensional string array
let array1d = [| "zero"; "one"; "two"; "three" |]
showArrayInfo array1d

// Declare a two-dimensional string array
let array2d = 
    array2D [ [ "zero"; "0" ]; [ "one"; "1" ]
              [ "two"; "2" ]; [ "three"; "3" ]
              [ "four"; "4" ]; [ "five"; "5" ] ]

showArrayInfo array2d

// Declare a three-dimensional integer array
let array3d = Array3D.create 2 2 3 "zero"

showArrayInfo array3d

// The example displays the following output:
//       Length of Array:        4
//       Number of Dimensions:   1
//
//       Length of Array:       12
//       Number of Dimensions:   2
//          Dimension 1:   6
//          Dimension 2:   2
//
//       Length of Array:       12
//       Number of Dimensions:   3
//          Dimension 1:   2
//          Dimension 2:   2
//          Dimension 3:   3
// </Snippet1>