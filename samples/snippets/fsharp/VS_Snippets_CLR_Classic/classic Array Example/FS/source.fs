module source

// <Snippet1>
open System

let printValues myArr =
    for i in myArr do
        printf $"\t{i}"
    printfn ""

// Creates and initializes a new integer array and a new Object array.
let myIntArray = [| 1..5 |]
let myObjArray = [| 26..30 |]

// Prints the initial values of both arrays.
printfn "Initially,"
printf "integer array:"
printValues myIntArray
printfn "Object array: "
printValues myObjArray

// Copies the first two elements from the integer array to the Object array.
Array.Copy(myIntArray, myObjArray, 2)

// Prints the values of the modified arrays.
printfn "\nAfter copying the first two elements of the integer array to the Object array,"
printf "integer array:"
printValues myIntArray
printf"Object array: "
printValues myObjArray

// Copies the last two elements from the Object array to the integer array.
Array.Copy(myObjArray, myObjArray.GetUpperBound 0 - 1, myIntArray, myIntArray.GetUpperBound 0 - 1, 2)

// Prints the values of the modified arrays.
printfn $"\nAfter copying the last two elements of the Object array to the integer array,"
printf "integer array:"
printValues myIntArray
printf "Object array: "
printValues myObjArray


// This code produces the following output.
//     Initially,
//     integer array:  1       2       3       4       5
//     Object array:   26      27      28      29      30
//     
//     After copying the first two elements of the integer array to the Object array,
//     integer array:  1       2       3       4       5
//     Object array:   1       2       28      29      30
//     
//     After copying the last two elements of the Object array to the integer array,
//     integer array:  1       2       3       29      30
//     Object array:   1       2       28      29      30

// </Snippet1>
