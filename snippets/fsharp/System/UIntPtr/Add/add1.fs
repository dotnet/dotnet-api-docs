// <Snippet1>
open System

let arr = [| 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 |]
let ptr = UIntPtr(uint arr[0])
for i = 0 to arr.Length - 1 do
    let newPtr = UIntPtr.Add(ptr, i)
    printf $"{newPtr}   "
// The example displays the following output:
//       1   2   3   4   5   6   7   8   9   10
// </Snippet1>