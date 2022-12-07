module arrayresize

// The following example shows how resizing affects the array.

// <Snippet1>
open System

let printIndexAndValues (myArr: string []) =
    for i = 0 to myArr.Length - 1 do
        printfn $"   [{i}] : {myArr[i]}"
    printfn ""

// Create and initialize a new string array.
let mutable myArr = 
    [| "The"; "quick"; "brown"; "fox"; "jumps"
       "over"; "the"; "lazy"; "dog" |]

// Display the values of the array.
printfn "The string array initially contains the following values:"
printIndexAndValues myArr

// Resize the array to a bigger size (five elements larger).
Array.Resize(&myArr, myArr.Length + 5)

// Display the values of the array.
printfn "After resizing to a larger size, "
printfn "the string array contains the following values:"
printIndexAndValues myArr

// Resize the array to a smaller size (four elements).
Array.Resize(&myArr, 4)

// Display the values of the array.
printfn "After resizing to a smaller size, "
printfn "the string array contains the following values:"
printIndexAndValues myArr


(*
This code produces the following output.

The string array initially contains the following values:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog

After resizing to a larger size,
the string array contains the following values:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog
   [9] :
   [10] :
   [11] :
   [12] :
   [13] :

After resizing to a smaller size,
the string array contains the following values:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox

*)
// </Snippet1>