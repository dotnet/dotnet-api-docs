module ToString_Bool1

open System

// <Snippet1>
let falseFlag = false
let trueFlag = true

printfn $"{Convert.ToString falseFlag}"
printfn $"{Convert.ToString(falseFlag).Equals Boolean.FalseString}"
printfn $"{Convert.ToString trueFlag}"
printfn $"{Convert.ToString(trueFlag).Equals(Boolean.TrueString)}"
// The example displays the following output:
//       False
//       True
//       True
//       True
// </Snippet1>