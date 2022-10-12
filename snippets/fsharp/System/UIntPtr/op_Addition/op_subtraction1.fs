module op_subtraction

open System

// <Snippet2>
let arr = [| 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 |]
let ptr = UIntPtr(uint arr[arr.GetUpperBound 0])
for i = 0 to arr.GetUpperBound 0 do
    let newPtr = ptr - UIntPtr(uint i)
    printf $"{newPtr}   "
// </Snippet2>