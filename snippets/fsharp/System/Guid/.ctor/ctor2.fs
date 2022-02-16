module ctor2

// <Snippet2>
open System

let g = Guid(0xA, 0xBs, 0xCs, [| 0uy..7uy |])
printfn $"{g:B}"

// The example displays the following output:
//        {0000000a-000b-000c-0001-020304050607}
// </Snippet2>