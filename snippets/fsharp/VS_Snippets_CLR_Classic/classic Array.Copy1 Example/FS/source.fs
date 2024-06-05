// <Snippet1>
open System

let printValues (myArr: 'a []) =
    let mutable i = 0;
    let cols = myArr.GetLength(myArr.Rank - 1)
    for item in myArr do
        if i < cols then
            i <- i + 1
        else
            printfn ""
            i <- 1
        printf $"\t{item}"
    printfn ""

 // Creates and initializes a new Array of type int.
let myIntArray = [| 1..5 |]

// Creates and initializes a new Array of type Object.
let myObjArray = Array.init 5 (fun i -> i + 26 :> obj)

// Displays the initial values of both arrays.
printfn "int array:"
printValues myIntArray 
printfn "Object array:"
printValues myObjArray

// Copies the first element from the int array to the Object array.
Array.Copy(myIntArray, myIntArray.GetLowerBound 0, myObjArray, myObjArray.GetLowerBound 0, 1)

// Copies the last two elements from the Object array to the int array.
Array.Copy(myObjArray, myObjArray.GetUpperBound 0 - 1, myIntArray, myIntArray.GetUpperBound 0 - 1, 2)

// Displays the values of the modified arrays.
printfn "int array - Last two elements should now be the same as Object array:"
printValues myIntArray 
printfn "Object array - First element should now be the same as int array:"
printValues myObjArray


// This code produces the following output.
//     int array:
//         1    2    3    4    5
//     Object array:
//         26    27    28    29    30
//     int array - Last two elements should now be the same as Object array:
//         1    2    3    29    30
//     Object array - First element should now be the same as int array:
//         1    27    28    29    30

// </Snippet1>
