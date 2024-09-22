// <Snippet1>
open System
open System.Numerics

let dividend1 = BigInteger.Pow(Int64.MaxValue, 3)
let dividend2 = dividend1 * BigInteger.MinusOne
let divisor1 = bigint Int32.MaxValue
let divisor2 = divisor1 * BigInteger.MinusOne

let remainder1 = BigInteger.Remainder(dividend1, divisor1)
let remainder2 = BigInteger.Remainder(dividend2, divisor1)

let mutable divRem1 = BigInteger.Zero
let mutable divRem2 = BigInteger.Zero

BigInteger.DivRem(dividend1, divisor1, &divRem1) |> ignore

printfn $"BigInteger.Remainder({dividend1}, {divisor1}) = {remainder1}"

printfn $"BigInteger.DivRem({dividend1}, {divisor1}) = {divRem1}"


if remainder1.Equals divRem1 then
    printfn $"The remainders are equal.\n"

BigInteger.DivRem(dividend2, divisor2, &divRem2) |> ignore

printfn $"BigInteger.Remainder({dividend2}, {divisor2}) = {remainder2}"
printfn $"BigInteger.DivRem({dividend2}, {divisor2}) = {divRem2}"

if remainder2.Equals divRem2 then
    printfn $"The remainders are equal.\n"

// The example displays the following output:
//    BigInteger.Remainder(784637716923335095224261902710254454442933591094742482943, 2147483647) = 1
//    BigInteger.DivRem(784637716923335095224261902710254454442933591094742482943, 2147483647) = 1
//    The remainders are equal.
//
//    BigInteger.Remainder(-784637716923335095224261902710254454442933591094742482943, -2147483647) = -1
//    BigInteger.DivRem(-784637716923335095224261902710254454442933591094742482943, -2147483647) = -1
//    The remainders are equal.
// </Snippet1>
