module gettype1

// <Snippet1>
open System

let n1 = 12
let n2 = 82
let n3 = 12L

printfn $"n1 and n2 are the same type: {Object.ReferenceEquals(n1.GetType(), n2.GetType())}"
printfn $"n1 and n3 are the same type: {Object.ReferenceEquals(n1.GetType(), n3.GetType())}"
// The example displays the following output:
//       n1 and n2 are the same type: True
//       n1 and n3 are the same type: False
// </Snippet1>