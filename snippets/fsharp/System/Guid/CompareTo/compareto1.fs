module compareto1

// <Snippet2>
open System
open System.Runtime.InteropServices

[<Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8")>]
type Example = class end

let guidAttr = 
    Attribute.GetCustomAttribute(typeof<Example>, typeof<GuidAttribute>) :?> GuidAttribute
    
let guidValue = 
    Guid.Parse guidAttr.Value

let values: obj[] =
    [| null; 16 
       Guid.Parse "01e75c83-c6f5-4192-b57e-7427cec5560d"
       guidValue |]

for value in values do
    try
        printfn $"{guidValue} and %A{value}: {guidValue.CompareTo value}"
    with :? ArgumentException ->
        printfn $"Cannot compare {guidValue} and %A{value}"

// The example displays the following output:
//    936da01f-9abd-4d9d-80c7-02af85c822a8 and <null>: 1
//    Cannot compare 936da01f-9abd-4d9d-80c7-02af85c822a8 and 16
//    936da01f-9abd-4d9d-80c7-02af85c822a8 and 01e75c83-c6f5-4192-b57e-7427cec5560d: 1
//    936da01f-9abd-4d9d-80c7-02af85c822a8 and 936da01f-9abd-4d9d-80c7-02af85c822a8: 0
// </Snippet2>