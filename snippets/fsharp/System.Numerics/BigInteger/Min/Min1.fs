// <Snippet1>
open System
open System.Numerics

let numbers =
    [| bigint Int64.MaxValue * BigInteger.MinusOne
       BigInteger.MinusOne
       10359321239000I
       BigInteger.Pow(103988I, 2)
       BigInteger.Multiply(Int32.MaxValue, Int16.MaxValue)
       BigInteger.Add(BigInteger.Pow(Int64.MaxValue, 2), BigInteger.Pow(Int32.MaxValue, 2))
       BigInteger.Zero |]

if numbers.Length < 2 then
    printfn $"Cannot determine which is the smaller of {numbers.Length} numbers."
else
    let mutable smallest = numbers[0]

    for ctr = 1 to numbers.Length - 1 do
        smallest <- BigInteger.Min(smallest, numbers[ctr])

    printfn "The values:"

    for number in numbers do
        printfn $"{number, 55:N0}"

    printfn "\nThe smallest number of the series is:"
    printfn $"   {smallest:N0}"
// The example displays the following output:
//       The values:
//                                    -9,223,372,036,854,775,807
//                                                            -1
//                                            10,359,321,239,000
//                                                10,813,504,144
//                                            70,366,596,661,249
//            85,070,591,730,234,615,852,008,593,798,364,921,858
//                                                             0
//
//       The smallest number of the series is:
//          -9,223,372,036,854,775,807.
// </Snippet1>
