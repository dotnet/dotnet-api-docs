module type_getproperty3

// <Snippet1>
open System

type MyClass1() =
    let myArray = array2D [[1; 2]; [3; 4]]
    // Declare an indexed property.
    member _.Item
        with get (i, j) =
            myArray[i, j]
        and set (i, j) value =
            myArray[i, j] <- value
try
    // Get the Type object.
    let myType = typeof<MyClass1>
    let myTypeArr = Array.zeroCreate<Type> 2
    // Create an instance of a Type array.
    myTypeArr.SetValue(typeof<int>, 0)
    myTypeArr.SetValue(typeof<int>, 1)
    // Get the PropertyInfo object for the indexed property Item, which has two integer parameters.
    let myPropInfo = myType.GetProperty("Item", myTypeArr)
    // Display the property.
    printfn $"The {myPropInfo} property exists in MyClass1."
with :? NullReferenceException as e ->
    printfn "An exception occurred."
    printfn $"Source : {e.Source}" 
    printfn $"Message : {e.Message}" 
// </Snippet1>