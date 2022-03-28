module simple1.fs
// <Snippet12>
open System

let str = "animal"
let toFind = "n"
let index = str.IndexOf "n"
printfn $"Found '{toFind}' in '{str}' at position {index}"

// The example displays the following output:
//        Found 'n' in 'animal' at position 1
// </Snippet12>
