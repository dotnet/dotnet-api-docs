// <Snippet1>
open System

type MyClass1() =
    let x = 0
    member _.MyMethod() =
        x

let myClass1 = MyClass1()

// Get the RuntimeTypeHandle from an object.
let myRTHFromObject = Type.GetTypeHandle myClass1
// Get the RuntimeTypeHandle from a type.
let myRTHFromType = typeof<MyClass1>.TypeHandle

printfn $"\nmyRTHFromObject.Value:  {myRTHFromObject.Value}"
printfn $"myRTHFromObject.GetType():  {myRTHFromObject.GetType()}"
printfn "Get the type back from the handle..."
printfn $"Type.GetTypeFromHandle(myRTHFromObject):  {Type.GetTypeFromHandle myRTHFromObject}"

printfn $"\nmyRTHFromObject.Equals(myRTHFromType):  {myRTHFromObject.Equals myRTHFromType}"

printfn $"\nmyRTHFromType.Value:  {myRTHFromType.Value}"
printfn $"myRTHFromType.GetType():  {myRTHFromType.GetType()}"
printfn "Get the type back from the handle..."
printfn $"Type.GetTypeFromHandle(myRTHFromType):  {Type.GetTypeFromHandle myRTHFromType}"

// This code example produces output similar to the following:
//     myRTHFromObject.Value:  799464
//     myRTHFromObject.GetType():  System.RuntimeTypeHandle
//     Get the type back from the handle...
//     Type.GetTypeFromHandle(myRTHFromObject):  MyClass1
//    
//     myRTHFromObject.Equals(myRTHFromType):  True
//    
//     myRTHFromType.Value:  799464
//     myRTHFromType.GetType():  System.RuntimeTypeHandle
//     Get the type back from the handle...
//     Type.GetTypeFromHandle(myRTHFromType):  MyClass1
// </Snippet1>