// <Snippet1>
open System

let result1 = -8.997e37f + -2.985e38f       
printfn $"{result1} (Negative Infinity: {Single.IsNegativeInfinity result1})" 
      
let result2 = -1.5935e25f * 7.948e32f
printfn $"{result2} (Negative Infinity: {Single.IsNegativeInfinity result2})" 
// The example displays the following output:
//    -Infinity (Negative Infinity: True)
//    -Infinity (Negative Infinity: True)
// </Snippet1>