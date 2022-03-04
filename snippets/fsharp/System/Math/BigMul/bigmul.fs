module bigmul

//<snippet1>
// This example demonstrates Math.BigMul()
open System

let int1 = Int32.MaxValue
let int2 = Int32.MaxValue

let longResult = Math.BigMul(int1, int2)
printfn "Calculate the product of two Int32 values:"
printfn $"{int1} * {int2} = {longResult}"

// This example produces the following results:
// Calculate the product of two Int32 values:
// 2147483647 * 2147483647 = 4611686014132420609
//</snippet1>