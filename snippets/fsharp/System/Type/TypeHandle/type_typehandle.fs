// <Snippet1>	
open System

type MyClass() =
    let myField = 10

let displayTypeHandle (myTypeHandle: RuntimeTypeHandle) =
    // Get the type from the handle.
    let myType = Type.GetTypeFromHandle myTypeHandle
    // Display the type.
    printfn $"\nDisplaying the type from the handle:\n"
    printfn $"The type is {myType}."

let myClass = MyClass()

// Get the type of MyClass.
let myClassType = myClass.GetType()

// Get the runtime handle of MyClass.
let myClassHandle = myClassType.TypeHandle

displayTypeHandle myClassHandle
// </Snippet1>