module source2

// <Snippet1>
open System

let printIndexAndValues (myArray: Array) =
    for i = myArray.GetLowerBound 0 to myArray.GetUpperBound 0 do
        printfn $"\t[{i}]:\t{myArray.GetValue i}"

// Creates and initializes the source Array.
let myArrayZero = Array.zeroCreate 3
myArrayZero[0] <- "zero"
myArrayZero[1] <- "one"

// Displays the source Array.
printfn "The array with lower bound=0 contains:"
printIndexAndValues myArrayZero

// Creates and initializes the target Array.
let myArrLen = [| 4 |]
let myArrLow = [| 2 |]
let myArrayTwo = Array.CreateInstance(typeof<string>, myArrLen, myArrLow)
myArrayTwo.SetValue("two", 2)
myArrayTwo.SetValue("three", 3)
myArrayTwo.SetValue("four", 4)
myArrayTwo.SetValue("five", 5)

// Displays the target Array.
printfn "The array with lower bound=2 contains:"
printIndexAndValues myArrayTwo

// Copies from the array with lower bound=0 to the array with lower bound=2.
myArrayZero.CopyTo(myArrayTwo, 3)

// Displays the modified target Array.
printfn "\nAfter copying to the target array from index 3:"
printIndexAndValues myArrayTwo


// This code produces the following output.
//     The array with lower bound=0 contains:
//         [0]:    zero
//         [1]:    one
//         [2]:
//     The array with lower bound=2 contains:
//         [2]:    two
//         [3]:    three
//         [4]:    four
//         [5]:    five
//     
//     After copying to the target array from index 3:
//         [2]:    two
//         [3]:    zero
//         [4]:    one
//         [5]:

// </Snippet1>
