module type_getproperty1

// <Snippet1>
open System

type MyClass() =
    let mutable myProperty = 0
    // Declare MyProperty.
    member _.MyProperty
        with get () =
            myProperty
        and set (value) = 
            myProperty <- value

try
    // Get the Type object corresponding to MyClass.
    let myType = typeof<MyClass>
    // Get the PropertyInfo object by passing the property name.
    let myPropInfo = myType.GetProperty "MyProperty"
    // Display the property name.
    printfn $"The {myPropInfo.Name} property exists in MyClass."
with :? NullReferenceException as e ->
    printfn $"The property does not exist in MyClass.{e.Message}"
// </Snippet1>