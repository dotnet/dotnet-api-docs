module explicit1

open System
open System.Numerics

let explicitFromDecimal () =
    // Explicit Decimal to BigInteger conversion
    // <Snippet1>
    let decimals = [| Decimal.MinValue; -15632.991m; 9029321.12m; Decimal.MaxValue |]

    printfn "%35s %35s\n" "Decimal" "BigInteger"

    for value in decimals do
        let number = BigInteger(value)
        printfn "%35O %35O" value number
    // The example displays the following output:
    //
    //                          Decimal                          BigInteger
    //
    //    -79228162514264337593543950335      -79228162514264337593543950335
    //                       -15632.991                              -15632
    //                       9029321.12                             9029321
    //    79228162514264337593543950335       79228162514264337593543950335
    // </Snippet1>


let explicitFromDouble () =
    // <Snippet2>
    let doubles =
        [| Double.MinValue
           -1.430955172e03
           2.410970032e05
           Double.MaxValue
           Double.PositiveInfinity
           Double.NegativeInfinity
           Double.NaN |]

    printfn "%37s %37s\n" "Double" "BigInteger"

    for value in doubles do
        try
            let number = BigInteger(value)
            printfn "%37O %37O" value number
        with :? OverflowException ->
            printfn "%37O %37s" value "OverflowException"
    // The example displays the following output:
    //                                Double                            BigInteger
    //
    //                -1.79769313486232E+308  -1.7976931348623157081452742373E+308
    //                          -1430.955172                                 -1430
    //                           241097.0032                                241097
    //                 1.79769313486232E+308   1.7976931348623157081452742373E+308
    //                              Infinity                     OverflowException
    //                             -Infinity                     OverflowException
    //                                   NaN                     OverflowException
    // </Snippet2>

let explicitFromSingle () =
    // <Snippet3>
    let singles =
        [| Single.MinValue
           -1.430955172e03f
           2.410970032e05f
           Single.MaxValue
           Single.PositiveInfinity
           Single.NegativeInfinity
           Single.NaN |]

    printfn "%37s %37s\n" "Single" "BigInteger"

    for value in singles do
        try
            let number = BigInteger(value)
            printfn "%37O %37O" value number
        with :? OverflowException ->
            printfn "%37O %37s" value "OverflowException"
    // The example displays the following output:
    //           Single                            BigInteger
    //
    //    -3.402823E+38   -3.4028234663852885981170418348E+38
    //        -1430.955                                 -1430
    //           241097                                241097
    //     3.402823E+38    3.4028234663852885981170418348E+38
    //         Infinity                     OverflowException
    //        -Infinity                     OverflowException
    //              NaN                     OverflowException
    // </Snippet3>

let doublePrecision () =
    // <Snippet4>
    // Increase a BigInteger so it exceeds Double.MaxValue.
    let number1 = bigint Double.MaxValue
    let number2 = number1 + bigint 9.999e291
    // Compare the BigInteger values for equality.
    printfn $"BigIntegers equal: {number2.Equals number1}"

    // Convert the BigInteger to a Double.
    let dbl = float number2

    // Display the two values.
    printfn $"BigInteger: {number2}"
    printfn $"Double:     {dbl}"
    // The example displays the following output:
    //       BigIntegers equal: False
    //       BigInteger: 1.7976931348623158081352742373E+308
    //       Double:     1.79769313486232E+308
    // </Snippet4>

let singlePrecision () =
    // <Snippet5>
    // Increase a BigInteger so it exceeds Single.MaxValue.
    let number1 = bigint Single.MaxValue

    let number2 = number1 + bigint 9.999e30
    // Compare the BigInteger values for equality.
    printfn $"BigIntegers equal: {number2.Equals number1}"

    // Convert the BigInteger to a Single.
    let sng = float32 number2

    // Display the two values.
    printfn $"BigInteger: {number2}"
    printfn $"Single:     {sng}"
    // The example displays the following output:
    //       BigIntegers equal: False
    //       BigInteger: 3.4028235663752885981170396038E+38
    //       Single:     3.402823E+38
    // </Snippet5>


explicitFromDecimal ()
explicitFromDouble ()
explicitFromSingle ()
doublePrecision ()
singlePrecision ()
