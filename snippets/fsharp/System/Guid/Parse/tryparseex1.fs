module tryparseex1

// <Snippet2>
open System

let originalGuid = Guid.NewGuid()

// Create an array of string representations of the GUID.
let stringGuids =
    [| originalGuid.ToString "B"
       originalGuid.ToString "D"
       originalGuid.ToString "X" |]

// Parse each string representation.
for stringGuid in stringGuids do
    match Guid.TryParse stringGuid with
    | true, newGuid ->
        printfn $"Converted {stringGuid} to a Guid"
    | _ ->
        printfn $"Unable to convert {stringGuid} to a Guid"

// The example displays output similar to the following:
//
//    Converted {81a130d2-502f-4cf1-a376-63edeb000e9f} to a Guid
//    Converted 81a130d2-502f-4cf1-a376-63edeb000e9f to a Guid
//    Converted {0x81a130d2,0x502f,0x4cf1,{0xa3,0x76,0x63,0xed,0xeb,0x00,0x0e,0x9f}} to a Guid
// </Snippet2>