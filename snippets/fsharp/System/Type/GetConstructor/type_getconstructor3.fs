module type_getconstructor3

// <Snippet1>
open System
open System.Reflection
open System.Security

type MyClass1(i: int) = class end

try
    let myType = typeof<MyClass1>
    let types = [| typeof<int> |]
    // Get the public instance constructor that takes an integer parameter.
    let constructorInfoObj = myType.GetConstructor(BindingFlags.Instance ||| BindingFlags.Public, null, CallingConventions.HasThis, types, null)
    if constructorInfoObj <> null then
        printfn "The constructor of MyClass1 that is a public instance method and takes an integer as a parameter is: \n{constructorInfoObj}"
    else
        printfn "The constructor of MyClass1 that is a public instance method and takes an integer as a parameter is not available."
with
| :? ArgumentNullException as e ->
    printfn $"ArgumentNullException: {e.Message}"
| :? ArgumentException as e ->
    printfn $"ArgumentException: {e.Message}"
| :? SecurityException as e ->
    printfn $"SecurityException: {e.Message}"
| e ->
    printfn $"Exception: {e.Message}"
// </Snippet1>