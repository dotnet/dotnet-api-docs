module referenceequals4

open System

// <Snippet1>
let int1 = 3
printfn $"{Object.ReferenceEquals(int1, int1)}"
printfn $"{int1.GetType().IsValueType}"

// The example displays the following output:
//       False
//       True
// </Snippet1>