module nonzero2

// <Snippet2>
open System

let values = 
    Array.CreateInstance(typeof<int>, [| 10 |], [| 1 |])
let mutable value = 2
// Assign values.
for i = values.GetLowerBound 0 to values.GetUpperBound 0 do
    values.SetValue(value, i)
    value <- value * 2

// Display values.
for i = values.GetLowerBound 0 to values.GetUpperBound 0 do
    printf $"{values.GetValue i}    "
// The example displays the following output:
//        2    4    8    16    32    64    128    256    512    1024
// </Snippet2>