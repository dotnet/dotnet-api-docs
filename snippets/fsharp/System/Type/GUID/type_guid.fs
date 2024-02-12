// <Snippet1>	
type MyClass1() =
    member _.MyMethod1() = ()

// Get the type corresponding to the class MyClass.
let myType = typeof<MyClass1>
// Get the object of the Guid.
let myGuid = myType.GUID
printfn $"The name of the class is {myType}"
printfn $"The ClassId of MyClass is {myType.GUID}"
// </Snippet1>