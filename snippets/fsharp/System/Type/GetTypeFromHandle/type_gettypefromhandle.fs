open System

type MyClass1() = class end
// <Snippet1>
let myClass1 = MyClass1()
// Get the type referenced by the specified type handle.
let myClass1Type = Type.GetTypeFromHandle(Type.GetTypeHandle myClass1)
printfn $"The Names of the Attributes: {myClass1Type.Attributes}"
// </Snippet1>