// <Snippet1>
open System

let copyArray (myArray: Array) (myArray1: Array) =
    try
        // Copies the value of one array into another array.
        myArray.SetValue(myArray1.GetValue 0, 0)
        myArray.SetValue(myArray1.GetValue 1, 1)

    with e ->
        // Throw an exception of with a message and innerexception.
        raise (ArrayTypeMismatchException("The Source and destination arrays are of not same type.", e))

try
    let myStringArray = [| "Jones"; "John" |]
    let myIntArray = Array.zeroCreate<int> 2
    copyArray myStringArray myIntArray

with :? ArrayTypeMismatchException as e ->
    printfn $"The Exception Message is : {e.Message}"
    printfn $"The Inner exception is: {e.InnerException}"

// </Snippet1>
