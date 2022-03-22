module parseexactex1

// <Snippet4>
open System

// Define an array of all format specifiers.
let formats =
    [| "N"; "D"; "B"; "P"; "X" |]

let guid = Guid.NewGuid()

// Create an array of valid Guid string representations.
let stringGuids = 
    Array.map guid.ToString formats

// Parse the strings in the array using the "B" format specifier.
for stringGuid in stringGuids do
    try
        let newGuid = Guid.ParseExact(stringGuid, "B")
        printfn $"Successfully parsed {stringGuid}"
    with
    | :? ArgumentNullException ->
        printfn "The string to be parsed is null."
    | :? FormatException ->
        printfn $"Bad Format: {stringGuid}"

// The example displays output similar to the following:
//
//    Bad Format: eb5c8c7d187a44e68afb81e854c39457
//    Bad Format: eb5c8c7d-187a-44e6-8afb-81e854c39457
//    Successfully parsed {eb5c8c7d-187a-44e6-8afb-81e854c39457}
//    Bad Format: (eb5c8c7d-187a-44e6-8afb-81e854c39457)
//    Bad Format: {0xeb5c8c7d,0x187a,0x44e6,{0x8a,0xfb,0x81,0xe8,0x54,0xc3,0x94,0x57}}
// </Snippet4>