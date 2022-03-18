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

// Creates and initializes a multidimensional Array of type string.
let myLengthsArray = [| 3; 5 |]
let myBoundsArray = [| 2; 3 |]
let myArray = Array.CreateInstance(typeof<string>, myLengthsArray, myBoundsArray)
for i = myArray.GetLowerBound 0 to myArray.GetUpperBound 0 do
    for j = myArray.GetLowerBound 1 to myArray.GetUpperBound 1 do
        let myIndicesArray = [| i; j |]
        myArray.SetValue($"{i}{j}", myIndicesArray)

// Displays the lower bounds and the upper bounds of each dimension.
printfn "Bounds:\tLower\tUpper"
for  i = 0 to myArray.Rank - 1 do
    printfn $"{i}:\t{myArray.GetLowerBound i}\t{myArray.GetUpperBound i}"

// Displays the values of the Array.
printfn "The Array contains the following values:"
printValues myArray 


// This code produces the following output.
//     Bounds:    Lower    Upper
//     0:         2        4
//     1:         3        7
//     The Array contains the following values:
//         23    24    25    26    27
//         33    34    35    36    37
//         43    44    45    46    47

// </Snippet1>
