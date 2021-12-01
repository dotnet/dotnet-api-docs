module example

//<snippet1>
open System

printfn "One dimension (Rank=1):"
let numbers1 = [| 1..9 |]

for i in numbers1 do
    printf $"{i} " 
printfn "\n\nArray.Clear(numbers1, 2, 5)"

Array.Clear(numbers1, 2, 5)

for i in numbers1 do
    printf $"{i} " 

printfn "\n\nTwo dimensions (Rank=2):"

let numbers2 = array2D [ [ 1; 2; 3 ]; [ 4; 5; 6 ]; [ 7; 8; 9 ] ]

for i = 0 to 2 do
    for j = 0 to 2 do
        printfn $"{numbers2[i, j]} "
    printfn ""

printfn "\nArray.Clear(numbers2, 2, 5)"
Array.Clear(numbers2, 2, 5)

for i = 0 to 2 do
    for j = 0 to 2 do
        printfn $"{numbers2[i, j]} "
    printfn ""

printfn "Three dimensions (Rank=3):"
let numbers3 = Array3D.zeroCreate 2 2 2
numbers3[0, 0, 0] <- 1
numbers3[0, 0, 1] <- 2
numbers3[0, 1, 0] <- 3
numbers3[0, 1, 1] <- 4
numbers3[1, 0, 0] <- 5
numbers3[1, 1, 0] <- 7
numbers3[1, 0, 1] <- 6
numbers3[1, 1, 1] <- 8

for i = 0 to 1 do
    for j = 0 to 1 do
        for k = 0 to 1 do
            printf $"{numbers3[i, j, k]} "
        printfn ""
    printfn ""

printfn "Array.Clear(numbers3, 2, 5)"
Array.Clear(numbers3, 2, 5)

for i = 0 to 1 do
    for j = 0 to 1 do
        for k = 0 to 1 do
            printf $"{numbers3[i, j, k]} "
        printfn ""
    printfn ""

//  This code example produces the following output:
//
// One dimension (Rank=1):
// 1 2 3 4 5 6 7 8 9
//
// Array.Clear(numbers1, 2, 5)
// 1 2 0 0 0 0 0 8 9
//
// Two dimensions (Rank=2):
// 1 2 3
// 4 5 6
// 7 8 9
//
// Array.Clear(numbers2, 2, 5)
// 1 2 0
// 0 0 0
// 0 8 9
//
// Three dimensions (Rank=3):
// 1 2
// 3 4
//
// 5 6
// 7 8
//
// Array.Clear(numbers3, 2, 5)
// 1 2
// 0 0
//
// 0 0
// 0 8
//
//</snippet1>