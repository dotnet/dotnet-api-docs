// <Snippet1>
open System

let copyArray (myArray: Array) (myArray1: Array) =
    let typeArray1 = myArray.GetType() |> string
    let typeArray2 = myArray1.GetType() |> string
    // Check whether the two arrays are of same type or not.
    if typeArray1 = typeArray2 then
        // Copy the values from one array to another.
        myArray.SetValue($"Name: {myArray1.GetValue 0}", 0)
        myArray.SetValue($"Name: {myArray1.GetValue 1}", 1)
    else
        // Throw an exception of type 'ArrayTypeMismatchException' with a message string as parameter.
        raise (ArrayTypeMismatchException "The Source and destination arrays are not of same type.")

try
    let myStringArray = [| "Jones"; "John" |]

    let myIntArray = Array.zeroCreate<int> 2

    copyArray myStringArray myIntArray

with :? ArrayTypeMismatchException as e -> 
    printfn $"The Exception is: {e}"

// </Snippet1>
