module op_addition1

open System

// <Snippet1>
let arr = [| 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 |]
let ptr = UIntPtr(uint arr[0])
for i = 0 to arr.Length - 1 do
    let newPtr = ptr + UIntPtr(uint i)
    printfn $"{newPtr}"
// </Snippet1>  