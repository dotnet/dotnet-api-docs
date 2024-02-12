// <Snippet1>
open System

let result1 = 1.867e38f + 2.385e38f
printfn $"{result1} (Positive Infinity: {Single.IsPositiveInfinity result1})" 
      
let result2 = 1.5935e25f * 7.948e20f
printfn $"{result2} (Positive Infinity: {Single.IsPositiveInfinity result2})" 
// The example displays the following output:
//    Infinity (Positive Infinity: True)
//    Infinity (Positive Infinity: True)
// </Snippet1>