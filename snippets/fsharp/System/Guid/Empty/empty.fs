// <Snippet1>
open System

// Create a GUID and determine whether it consists of all zeros.
let guid1 = Guid.NewGuid()
printfn $"{guid1}"
printfn $"Empty: {guid1 = Guid.Empty}\n"

// Create a GUID with all zeros and compare it to Empty.
let bytes = Array.zeroCreate<byte> 16
let guid2 = Guid bytes
printfn $"{guid2}"
printfn $"Empty: {guid2 = Guid.Empty}"

// The example displays output like the following:
//       11c43ee8-b9d3-4e51-b73f-bd9dda66e29c
//       Empty: False
//
//       00000000-0000-0000-0000-000000000000
//       Empty: True
// </Snippet1>