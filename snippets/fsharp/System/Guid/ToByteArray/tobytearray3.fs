open System

// <Snippet1>
let guid = Guid.NewGuid()
printfn $"Guid: {guid}"
let bytes = guid.ToByteArray()
for byte in bytes do
    printf $"{byte:X2} "
printfn ""

let guid2 = Guid bytes
printfn $"Guid: {guid2} (Same as First Guid: {guid2.Equals(guid)})"

// The example displays output similar to the following:
//
//    Guid: 35918bc9-196d-40ea-9779-889d79b753f0
//    C9 8B 91 35 6D 19 EA 40 97 79 88 9D 79 B7 53 F0
//    Guid: 35918bc9-196d-40ea-9779-889d79b753f0 (Same as First Guid: True)
// </Snippet1>