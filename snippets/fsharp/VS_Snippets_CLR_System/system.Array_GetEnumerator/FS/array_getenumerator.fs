// The following example shows how to use GetEnumerator to list the elements of an array.

// <Snippet1>
// Creates and initializes a new Array.
let myArr = Array.zeroCreate 10
myArr[0..8] <- 
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
let mutable i = 0
let myEnumerator = myArr.GetEnumerator()
printfn "The Array contains the following values:"

while myEnumerator.MoveNext() && myEnumerator.Current <> null do
      printfn $"[{i}] {myEnumerator.Current}" 
      i <- i + 1


// This code produces the following output.
//     The Array contains the following values:
//     [0] The
//     [1] quick
//     [2] brown
//     [3] fox
//     [4] jumps
//     [5] over
//     [6] the
//     [7] lazy
//     [8] dog
// </Snippet1>
