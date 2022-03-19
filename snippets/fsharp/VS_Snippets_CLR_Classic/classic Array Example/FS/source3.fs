module source3

// <Snippet2>
open System

let printValues (myArray: Array) =
    let mutable i = 0
    let cols = myArray.GetLength(myArray.Rank - 1)
    for item in myArray do
        if i < cols then
            i <- i + 1
        else
            printfn ""
            i <- 1;
        printf $"\t{item}"
    printfn ""

// Creates and initializes a new three-dimensional Array of type int.
let myArr = Array.CreateInstance(typeof<int>, 2, 3, 4)
for i = myArr.GetLowerBound 0 to myArr.GetUpperBound 0 do
    for j = myArr.GetLowerBound 1 to myArr.GetUpperBound 1 do
        for k = myArr.GetLowerBound 2 to myArr.GetUpperBound 2 do
            myArr.SetValue(i * 100 + j * 10 + k, i, j, k)

// Displays the properties of the Array.
printfn $"The Array has {myArr.Rank} dimension(s) and a total of {myArr.Length} elements."
printfn $"\tLength\tLower\tUpper"

for i = 0 to myArr.Rank - 1 do
    printf $"{i}:\t{myArr.GetLength i}"
    printfn $"\t{myArr.GetLowerBound i}\t{myArr.GetUpperBound i}"

// Displays the contents of the Array.
printfn "The Array contains the following values:"
printValues myArr

// This code produces the following output.
// The Array has 3 dimension(s) and a total of 24 elements.
//     Length    Lower    Upper
// 0:  2    0    1
// 1:  3    0    2
// 2:  4    0    3
//
// The Array contains the following values:
//    0      1      2      3
//    10     11     12     13
//    20     21     22     23
//    100    101    102    103
//    110    111    112    113
//    120    121    122    123
// </Snippet2>
