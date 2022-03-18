module nonzero1

// <Snippet1>
open System

let values = 
    Array.CreateInstance(typeof<int>, [| 10 |], [| 1 |])
let mutable value = 2
// Assign values.
for i = 0 to values.Length - 1 do
    values.SetValue(value, i)
    value <- value * 2

// Display values.
for i = 0 to values.Length - 1 do
    printf $"{values.GetValue i}    "

// The example displays the following output:
//    Unhandled Exception:
//    System.IndexOutOfRangeException: Index was outside the bounds of the array.
//       at System.Array.InternalGetReference(Void* elemRef, Int32 rank, Int32* pIndices)
//       at System.Array.SetValue(Object value, Int32 index)
//       at <StartupCode$fs>.main@()
// </Snippet1>