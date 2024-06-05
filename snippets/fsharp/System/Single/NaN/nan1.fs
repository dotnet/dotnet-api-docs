module nan1

open System

// <Snippet1>
let zero = 0f
printfn $"{zero} / {zero} = {zero / zero}"
// The example displays the following output:
//         0 / 0 = NaN      
// </Snippet1> 

// <Snippet2>
let nan1 = Single.NaN

printfn $"{3} + {nan1} = {3f + nan1}"
printfn $"Abs({nan1}) = {abs nan1}"
// The example displays the following output:
//       3 + NaN = NaN
//       Abs(NaN) = NaN
// </Snippet2> 
Console.WriteLine()

// <Snippet3>
let result = Single.NaN
printfn $"{result} = Single.NaN: {result = Single.NaN}" 
// The example displays the following output:
//         NaN = Single.Nan: False
// </Snippet3> 