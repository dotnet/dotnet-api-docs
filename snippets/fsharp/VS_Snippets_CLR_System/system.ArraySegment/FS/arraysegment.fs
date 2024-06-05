module arraysegment

// The following code example passes an ArraySegment to a method.

// <Snippet1>
open System

// Print functions.
let printIndexAndValues (myArr: string []) =
    for i = 0 to myArr.Length - 1 do
        printfn $"   [{i}] : {myArr[i]}"
    printfn ""

let printIndexAndValuesSeg (arrSeg: ArraySegment<string>) =
    for i = arrSeg.Offset to arrSeg.Offset + arrSeg.Count - 1 do
        printfn $"   [{i}] : {arrSeg.Array[i]}"
    printfn ""

// Create and initialize a new string array.
let myArr = [| "The"; "quick"; "brown"; "fox"; "jumps"; "over"; "the"; "lazy"; "dog" |]

// Display the initial contents of the array.
printfn "The original array initially contains:"
printIndexAndValues myArr

// Define an array segment that contains the entire array.
let myArrSegAll = ArraySegment<string>(myArr)

// Display the contents of the ArraySegment.
printfn "The first array segment (with all the array's elements) contains:"
printIndexAndValuesSeg myArrSegAll

// Define an array segment that contains the middle five values of the array.
let myArrSegMid = ArraySegment<string>(myArr, 2, 5)

// Display the contents of the ArraySegment.
printfn "The second array segment (with the middle five elements) contains:"
printIndexAndValuesSeg myArrSegMid

// Modify the fourth element of the first array segment myArrSegAll.
myArrSegAll.Array[3] <- "LION"

// Display the contents of the second array segment myArrSegMid.
// Note that the value of its second element also changed.
printfn "After the first array segment is modified, the second array segment now contains:"
printIndexAndValuesSeg myArrSegMid


(*
This code produces the following output.

The original array initially contains:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog

The first array segment (with all the array's elements) contains:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog

The second array segment (with the middle five elements) contains:
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the

After the first array segment is modified, the second array segment now contains:
   [2] : brown
   [3] : LION
   [4] : jumps
   [5] : over
   [6] : the

*)

// </Snippet1>