module type_getproperty21

// <Snippet1>
open System

type MyPropertyClass() =
    let myPropertyArray = Array2D.zeroCreate<int> 10 10
    // Declare an indexed property.
    member _.Item
        with get (i, j) =
            myPropertyArray[i, j]
        and set (i, j) value =
            myPropertyArray[i, j] <- value

try
    let myType = typeof<MyPropertyClass>
    let myTypeArray = Array.zeroCreate<Type> 2
    // Create an instance of the Type array representing the number, order
    // and type of the parameters for the property.
    myTypeArray.SetValue(typeof<int>, 0)
    myTypeArray.SetValue(typeof<int>, 1)
    // Search for the indexed property whose parameters match the
    // specified argument types and modifiers.
    let myPropertyInfo = myType.GetProperty("Item", typeof<int>, myTypeArray, null)
    printfn $"{myType.FullName}.{myPropertyInfo.Name} has a property type of {myPropertyInfo.PropertyType}"
with ex ->
    printfn $"An exception occurred {ex.Message}"
// </Snippet1>