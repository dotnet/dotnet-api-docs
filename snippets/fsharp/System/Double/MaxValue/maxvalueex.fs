// <Snippet1>
open System

let result1 = 7.997e307 + 9.985e307
printfn $"{result1} (Positive Infinity: {Double.IsPositiveInfinity result1})"

let result2 = 1.5935e250 * 7.948e110
printfn $"{result2} (Positive Infinity: {Double.IsPositiveInfinity result2})"

let result3 = Math.Pow(1.256e100, 1.34e20)
printfn $"{result3} (Positive Infinity: {Double.IsPositiveInfinity result3})"
// The example displays the following output:
//    Infinity (Positive Infinity: True)
//    Infinity (Positive Infinity: True)
//    Infinity (Positive Infinity: True)
// </Snippet1>