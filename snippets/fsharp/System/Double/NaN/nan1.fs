module nan1

open System

// <Snippet1>
let zero = 0.0
printfn $"{zero} / {zero} = {zero / zero}"
// The example displays the following output:
//         0 / 0 = NaN
// </Snippet1>

// <Snippet2>
let nan1 = Double.NaN

printfn $"{3} + {nan1} = {3. + nan1}"
printfn $"abs({nan1}) = {abs nan1}"
// The example displays the following output:
//       3 + NaN = NaN
//       abs NaN = NaN
// </Snippet2>

// <Snippet3>
let result = Double.NaN
printfn $"{result} = Double.Nan: {result = Double.NaN}"
// The example displays the following output:
//         NaN = Double.Nan: False
// </Snippet3>