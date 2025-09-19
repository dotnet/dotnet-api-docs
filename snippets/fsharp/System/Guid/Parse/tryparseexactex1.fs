module tryparseexactex1

// <Snippet5>
open System

// Define an array of all format specifiers.
let formats = [| "N"; "D"; "B"; "P"; "X" |]

let guid = Guid.NewGuid()

// Create an array of valid Guid string representations.
let stringGuids = 
    Array.map guid.ToString formats

// Parse the strings in the array using the "B" format specifier.
for stringGuid in stringGuids do
    match Guid.TryParseExact(stringGuid, "B") with
    | true, newGuid ->
        printfn $"Successfully parsed {stringGuid}"
    | _ ->
        printfn $"Unable to parse '{stringGuid}'"

// The example displays output similar to the following:
//
//    Unable to parse 'c0fb150f6bf344df984a3a0611ae5e4a'
//    Unable to parse 'c0fb150f-6bf3-44df-984a-3a0611ae5e4a'
//    Successfully parsed {c0fb150f-6bf3-44df-984a-3a0611ae5e4a}
//    Unable to parse '(c0fb150f-6bf3-44df-984a-3a0611ae5e4a)'
//    Unable to parse '{0xc0fb150f,0x6bf3,0x44df,{0x98,0x4a,0x3a,0x06,0x11,0xae,0x5e,0x4a}}'
// </Snippet5>