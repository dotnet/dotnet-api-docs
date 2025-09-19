module source

// <Snippet1>
let printValues arr sep =
    for i in arr do
        printf $"{sep}{i}"
    printfn ""

// Creates and initializes two new Arrays.
let mySourceArray = 
    [| "three"
       "napping"
       "cats"
       "in"
       "the"
       "barn" |]

let myTargetArray = Array.zeroCreate 15
myTargetArray[0..8] <-
    [| "The"
       "quick"
       "brown"
       "fox"
       "jumps"
       "over"
       "the"
       "lazy"
       "dog" |]

// Displays the values of the Array.
printfn "The target Array contains the following (before and after copying):"
printValues myTargetArray ' '

// Copies the source Array to the target Array, starting at index 6.
mySourceArray.CopyTo(myTargetArray, 6)

// Displays the values of the Array.
printValues myTargetArray ' '


// This code produces the following output.
//     The target Array contains the following (before and after copying):
//      The quick brown fox jumps over the lazy dog
//      The quick brown fox jumps over three napping cats in the barn

// </Snippet1>
