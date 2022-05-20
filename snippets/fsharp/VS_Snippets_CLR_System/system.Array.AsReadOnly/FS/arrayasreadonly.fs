// The following example wraps an array in a read-only IList.

// <Snippet1>
open System
open System.Collections.Generic

let printIndexAndValues (myList: IList<'a>) =
    for i = 0 to myList.Count - 1 do
        printfn $"   [{i}] : {myList[i]}"
    printfn ""

// Create and initialize a new string array.
let myArr = [| "The"; "quick"; "brown"; "fox" |]

// Display the values of the array.
printfn "The string array initially contains the following values:"
printIndexAndValues myArr

// Create a read-only IList wrapper around the array.
let myList: IList<_> = Array.AsReadOnly myArr

// Display the values of the read-only IList.
printfn "The read-only IList contains the following values:"
printIndexAndValues myList

// Attempt to change a value through the wrapper.
try 
    myList[3] <- "CAT"

with :? NotSupportedException as e ->
    printfn $"{e.GetType()} - {e.Message}\n"

// Change a value in the original array.
myArr[2] <- "RED"

// Display the values of the array.
printfn "After changing the third element, the string array contains the following values:"
printIndexAndValues myArr

// Display the values of the read-only IList.
printfn "After changing the third element, the read-only IList contains the following values:"
printIndexAndValues myList


// This code produces the following output.
//     The string array initially contains the following values:
//        [0] : The
//        [1] : quick
//        [2] : brown
//        [3] : fox
//     
//     The read-only IList contains the following values:
//        [0] : The
//        [1] : quick
//        [2] : brown
//        [3] : fox
//     
//     System.NotSupportedException - Collection is read-only.
//     
//     After changing the third element, the string array contains the following values:
//        [0] : The
//        [1] : quick
//        [2] : RED
//        [3] : fox
//     
//     After changing the third element, the read-only IList contains the following values:
//        [0] : The
//        [1] : quick
//        [2] : RED
//        [3] : fox

// </Snippet1>
