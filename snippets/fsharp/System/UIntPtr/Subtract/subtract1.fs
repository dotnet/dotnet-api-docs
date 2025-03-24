// <Snippet1>
open System

let arr = [| 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 |]
let ptr = UIntPtr(uint arr[arr.GetUpperBound 0])
for i = 0 to arr.GetUpperBound 0 do
    let newPtr = UIntPtr.Subtract(ptr, i)
    printf $"{newPtr}   "
// The example displays the following output:
//       10   9   8   7   6   5   4   3   2   1
// </Snippet1>