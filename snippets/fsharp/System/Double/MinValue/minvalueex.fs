// <Snippet1>
open System

let result1 = -7.997e307 + -9.985e307
printfn $"{result1} (Negative Infinity: {Double.IsNegativeInfinity result1})"

let result2 = -1.5935e250 * 7.948e110
printfn $"{result2} (Negative Infinity: {Double.IsNegativeInfinity result2})"
// The example displays the following output:
//    -Infinity (Negative Infinity: True)
//    -Infinity (Negative Infinity: True)
// </Snippet1>