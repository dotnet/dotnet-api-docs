module source.fs
open System

// <Snippet1>
let myString = "abc"
let test1 = myString.Substring(2, 1).Equals "c" // This is true.
printfn $"{test1}"
let test2 = String.IsNullOrEmpty(myString.Substring(3, 0)) // This is true.
printfn $"{test2}"
try
    let str3 = myString.Substring(3, 1) // This throws ArgumentOutOfRangeException.
    printfn $"{str3}"
with :? ArgumentOutOfRangeException as e ->
    printfn $"{e.Message}"

// The example displays the following output:
//       True
//       True
//       Index and length must refer to a location within the string.
//       Parameter name: length
// </Snippet1>
