module compareto2

// <Snippet1>
open System

type Comparison =
    | ``Less Than`` = -1
    | Equals = 0
    | ``Greater Than`` = 1

let mainGuid = 
    Guid.Parse "01e75c83-c6f5-4192-b57e-7427cec5560d"

let guid2 = Guid(0x01e75c83, 0xc6f5s, 0x4192s, [| 0xb5uy; 0x7euy; 0x74uy; 0x27uy; 0xceuy; 0xc5uy; 0x56uy; 0x0cuy |])
let guid3 = 
    Guid.Parse("01e75c84-c6f5-4192-b57e-7427cec5560d")

printfn $"{mainGuid} {mainGuid.CompareTo guid2 |> enum<Comparison> :F} {guid2}"
printfn $"{mainGuid} {mainGuid.CompareTo guid3 |> enum<Comparison> :F} {guid3}"

// The example displays the following output:
//    01e75c83-c6f5-4192-b57e-7427cec5560d Greater Than 01e75c83-c6f5-4192-b57e-7427cec5560c
//    01e75c83-c6f5-4192-b57e-7427cec5560d Less Than 01e75c84-c6f5-4192-b57e-7427cec5560d
// </Snippet1>