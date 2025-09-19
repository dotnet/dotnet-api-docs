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

let findMyObject (myArr: Array) (myObject: obj) =
    let myIndex = Array.BinarySearch(myArr, myObject)
    if myIndex < 0 then
        printfn $"The object to search for ({myObject}) is not found. The next larger object is at index {~~~myIndex}."
    else
        printfn $"The object to search for ({myObject}) is at index {myIndex}."

// Creates and initializes a new Array.
let myIntArray = [| 8; 2; 6; 3; 7 |]

// Do the required sort first
Array.Sort myIntArray

// Displays the values of the Array.
printfn "The int array contains the following:"
printValues myIntArray

// Locates a specific object that does not exist in the Array.
let myObjectOdd: obj = 1
findMyObject myIntArray myObjectOdd 

// Locates an object that exists in the Array.
let myObjectEven: obj = 6
findMyObject myIntArray myObjectEven
       
// This code produces the following output:
//     The int array contains the following:
//             2       3       6       7       8
//     The object to search for (1) is not found. The next larger object is at index 0.
//     The object to search for (6) is at index 2.

// </Snippet1>
