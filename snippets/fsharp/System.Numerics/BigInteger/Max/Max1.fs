// <Snippet1>
open System
open System.Numerics

let numbers =
    [| bigint Int64.MaxValue * BigInteger.MinusOne
       BigInteger.MinusOne
       10359321239000I
       BigInteger.Pow(103988I, 2)
       BigInteger.Multiply(Int32.MaxValue, Int16.MaxValue)
       BigInteger.Add(BigInteger.Pow(Int64.MaxValue, 2), BigInteger.Pow(Int32.MaxValue, 2)) |]

if numbers.Length < 2 then
    printfn $"Cannot determine which is the larger of {numbers.Length} numbers."
else
    let mutable largest = numbers[0]

    for ctr = 1 to numbers.Length - 1 do
        largest <- BigInteger.Max(largest, numbers[ctr])

    printfn "The values:"

    for number in numbers do
        printfn $"{number, 55:N0}"

    printfn "\nThe largest number of the series is:"
    printfn $"   {largest:N0}"
// The example displays the following output:
//       The values:
//                                    -9,223,372,036,854,775,807
//                                                            -1
//                                            10,359,321,239,000
//                                                10,813,504,144
//                                            70,366,596,661,249
//            85,070,591,730,234,615,852,008,593,798,364,921,858
//
//       The largest number of the series is:
//          85,070,591,730,234,615,852,008,593,798,364,921,858
// </Snippet1>
