module referenceequals

open System

// <Snippet1>
let o: obj = null
let mutable p: obj = null
let q = obj ()

printfn $"{Object.ReferenceEquals(o, p)}"
p <- q
printfn $"{Object.ReferenceEquals(p, q)}"
printfn $"{Object.ReferenceEquals(o, p)}"

// This code produces the following output:
//   True
//   True
//   False
// </Snippet1>