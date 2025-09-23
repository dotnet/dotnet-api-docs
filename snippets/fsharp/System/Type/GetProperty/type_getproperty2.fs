module type_getproperty2

// <Snippet1>
open System
open System.Reflection

type MyClass() =
    let mutable myProperty = 0
    // Declare MyProperty.
    member _.MyProperty
        with get () =
            myProperty
        and set (value) =
            myProperty <- value

try
    // Get Type object of MyClass.
    let myType = typeof<MyClass>
    // Get the PropertyInfo by passing the property name and specifying the BindingFlags.
    let myPropInfo = myType.GetProperty("MyProperty", BindingFlags.Public ||| BindingFlags.Instance)
    // Display Name property to console.
    printfn $"{myPropInfo.Name} is a property of MyClass."
with :? NullReferenceException as e ->
    printfn $"MyProperty does not exist in MyClass.{e.Message}"
// </Snippet1>