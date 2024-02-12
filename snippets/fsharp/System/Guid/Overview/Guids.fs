//<Snippet1>
open System
open System.Runtime.InteropServices

// Guid for the interface IMyInterface.
[<Guid "F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4">]
type IMyInterface =
    abstract MyMethod: unit -> unit

// Guid for the coclass MyTestClass.
[<Guid "936DA01F-9ABD-4d9d-80C7-02AF85C822A8">]
type MyTestClass() =
    interface IMyInterface with
        member _.MyMethod() = ()

let IMyInterfaceAttribute = 
    Attribute.GetCustomAttribute(typeof<IMyInterface>, typeof<GuidAttribute>) :?> GuidAttribute

printfn $"IMyInterface Attribute: {IMyInterfaceAttribute.Value}"

// Use the string to create a guid.
let myGuid1 = Guid IMyInterfaceAttribute.Value
// Use a byte array to create a guid.
let myGuid2 = Guid(myGuid1.ToByteArray())

if myGuid1.Equals myGuid2 then
    printfn "myGuid1 equals myGuid2"
else
    printfn "myGuid1 does not equal myGuid2"

// Equality operator can also be used to determine if two guids have same value.
if myGuid1 = myGuid2 then
    printfn "myGuid1 == myGuid2"
else
    printfn "myGuid1 <> myGuid2"

// The example displays the following output:
//       IMyInterface Attribute: F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4
//       myGuid1 equals myGuid2
//       myGuid1 == myGuid2
//</Snippet1>