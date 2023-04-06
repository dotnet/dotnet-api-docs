module type_getproperty_types

// <Snippet1>
open System
open System.Reflection

type MyClass1() =
    let mutable myMessage = "Hello World."
    member _.MyProperty1 
        with get () =
            myMessage
        and set (value) =
            myMessage <- value

try
    let myType = typeof<MyClass1>
    // Get the PropertyInfo object representing MyProperty1.
    let myStringProperties1 = myType.GetProperty("MyProperty1", typeof<string>)
    printfn $"The name of the first property of MyClass1 is {myStringProperties1.Name}."
    printfn $"The type of the first property of MyClass1 is {myStringProperties1.PropertyType}."
with
| :? ArgumentNullException as e ->
    printfn $"ArgumentNullException :{e.Message}"
| :? AmbiguousMatchException as e ->
    printfn $"AmbiguousMatchException :{e.Message}"
| :? NullReferenceException as e ->
    printfn $"Source : {e.Source}"
    printfn $"Message : {e.Message}"
// Output:
//     The name of the first property of MyClass1 is MyProperty1.
//     The type of the first property of MyClass1 is System.String.
// </Snippet1>	