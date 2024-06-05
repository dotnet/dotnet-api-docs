// <Snippet2>
open System

let resizeArray (arr: Array) (newSizes: int []) =
    if newSizes.Length <> arr.Rank then
        invalidArg "newSizes" "arr must have the same number of dimensions as there are elements in newSizes"
    let temp = Array.CreateInstance(arr.GetType().GetElementType(), newSizes)
    let length = min arr.Length temp.Length
    Array.ConstrainedCopy(arr, 0, temp, 0, length)
    temp

[<EntryPoint>]
let main _ =
    let arr = Array2D.init 10 2 (fun x y -> if y = 0 then x else x * 2)

    // Make a 2-D array larger in the first dimension.
    let arr = resizeArray arr [| 12; 2 |]
    for i = 0 to arr.GetUpperBound 0 do
        printfn $"{i}: {arr.GetValue(i, 0)}, {arr.GetValue(i, 1)}"
    printfn ""

    // Make a 2-D array smaller in the first dimension.
    let arr = resizeArray arr [| 2; 2|]
    for i = 0 to arr.GetUpperBound 0 do
        printfn $"{i}: {arr.GetValue(i, 0)}, {arr.GetValue(i, 1)}"
    0

// The example displays the following output:
//       0: 0, 0
//       1: 1, 2
//       2: 2, 4
//       3: 3, 6
//       4: 4, 8
//       5: 5, 10
//       6: 6, 12
//       7: 7, 14
//       8: 8, 16
//       9: 9, 18
//       10: 0, 0
//       11: 0, 0
//
//       0: 0, 0
//       1: 1, 2
// </Snippet2>