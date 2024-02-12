module type_getconstructor

// <Snippet1>
type MyClass1() =
    new (i: int) = MyClass1()

try
    let myType = typeof<MyClass1>
    let types = [| typeof<int> |]
    // Get the constructor that takes an integer as a parameter.
    let constructorInfoObj = myType.GetConstructor types
    if constructorInfoObj <> null then
        printfn "The constructor of MyClass1 that takes an integer as a parameter is: \n{constructorInfoObj}"
    else
        printfn "The constructor of MyClass1 that takes an integer as a parameter is not available."
with e ->
    printfn "Exception caught."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
// </Snippet1>