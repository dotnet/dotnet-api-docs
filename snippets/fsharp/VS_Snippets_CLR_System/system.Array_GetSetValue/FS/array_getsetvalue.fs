// The following code example demonstrates how to set and get a specific value in a one-dimensional or multidimensional array.

// <Snippet1>
open System

// Creates and initializes a one-dimensional array.
let myArr1 = Array.zeroCreate<string> 5

// Sets the element at index 3.
myArr1.SetValue("three", 3)
printfn $"[3]:   {myArr1.GetValue 3}"

// Creates and initializes a two-dimensional array.
let myArr2 = Array2D.zeroCreate<string> 5 5

// Sets the element at index 1,3.
myArr2.SetValue("one-three", 1, 3)
printfn $"[1,3]:   {myArr2.GetValue(1, 3)}"

// Creates and initializes a three-dimensional array.
let myArr3 = Array3D.zeroCreate<string> 5 5 5

// Sets the element at index 1,2,3.
myArr3.SetValue("one-two-three", 1, 2, 3)
printfn $"[1,2,3]:   {myArr3.GetValue(1, 2, 3)}"

// Creates and initializes a seven-dimensional array.
let myArr7 = Array.CreateInstance(typeof<string>, 5, 5, 5, 5, 5, 5, 5)

// Sets the element at index 1,2,3,0,1,2,3.
let myIndices = [| 1; 2; 3; 0; 1; 2; 3 |]
myArr7.SetValue("one-two-three-zero-one-two-three", myIndices)
printfn $"[1,2,3,0,1,2,3]:   {myArr7.GetValue myIndices}"


// This code produces the following output.
//     [3]:   three
//     [1,3]:   one-three
//     [1,2,3]:   one-two-three
//     [1,2,3,0,1,2,3]:   one-two-three-zero-one-two-three

// </Snippet1>
