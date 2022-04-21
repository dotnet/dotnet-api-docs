// <Snippet1>
open System

// Declare a public class with the [Serializable] attribute.
[<Serializable>]
type MyTestClass() = class end

try
    let myTestClassInstance = MyTestClass()
    // Get the type of myTestClassInstance.
    let myType = myTestClassInstance.GetType()
    // Get the IsSerializable property of myTestClassInstance.
    let myBool = myType.IsSerializable
    printfn $"\nIs {myType.FullName} serializable? {myBool}."
with e ->
    printfn $"\nAn exception occurred: {e.Message}"
// </Snippet1>