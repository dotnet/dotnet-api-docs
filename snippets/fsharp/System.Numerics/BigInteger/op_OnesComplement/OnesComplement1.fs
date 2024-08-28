// <Snippet1>
open System
open System.Numerics

let displayInBinary (number: bigint) =
    let bytes = number.ToByteArray()
    let mutable binaryString = ""

    for byteValue in bytes do
        let byteString = Convert.ToString(byteValue, 2).Trim()
        binaryString <- binaryString + byteString.PadLeft(8, '0')

    binaryString

let value = BigInteger.Multiply(BigInteger.One, 9)
let complement = ~~~(int64 value) |> bigint

printfn "%5O -- %s" value (displayInBinary value)
printfn "%5O -- %s\n" complement (displayInBinary complement)

let value2 = BigInteger.MinusOne * (bigint SByte.MaxValue)
let complement2 = ~~~(int64 value) |> bigint

printfn "%5O -- %s" value2 (displayInBinary value2)
printfn "%5O -- %s" complement2 (displayInBinary complement2)
// The example displays the following output:
//           9 -- 00001001
//         -10 -- 11110110
//
//        -127 -- 10000001
//         126 -- 01111110
// </Snippet1>
