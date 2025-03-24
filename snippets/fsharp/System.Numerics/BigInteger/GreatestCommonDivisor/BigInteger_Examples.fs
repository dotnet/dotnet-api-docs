open System
open System.Numerics

let createBigIntegers () =
    // <Snippet3>
    let bigIntFromDouble = BigInteger 179032.6541
    let bigIntFromInt64 = BigInteger 934157136952L
    // </Snippet3>

    // <Snippet4>
    let assignedFromLong: BigInteger = 6315489358112L

    let assignedFromDouble = BigInteger 179032.6541
    let assignedFromDecimal = BigInteger 64312.65m
    // </Snippet4>

    // <Snippet34>
    let fractionalNumber = 13456.92m
    let wholeNumber = BigInteger fractionalNumber
    printfn $"{wholeNumber}" // Displays 13456
    // </Snippet34>

    // <Snippet35>
    // Create a BigInteger from a large double value
    let impreciseNumber = -6e35
    let preciseNumber = BigInteger impreciseNumber
    printfn $"{impreciseNumber:F}"
    printfn $"{preciseNumber}"
    let impreciseNumber = impreciseNumber + 1.
    let preciseNumber = preciseNumber + 1I
    let impreciseNumber = -6e35
    let preciseNumber = BigInteger impreciseNumber
    // The example displays the following output to the console:
    //       -600000000000000000000000000000000000.00
    //       -599999999999999981180196647507853312
    //       -600000000000000000000000000000000000.00
    //       -599999999999999981180196647507853311
    // </Snippet35>

    // <Snippet36>
    // Create a BigInteger from a large negative float value
    let negativeFloat = Single.MinValue
    let negativeNumber = BigInteger negativeFloat
    printfn $"{negativeFloat:F}"
    printfn $"{negativeNumber}"
    let negativeFloat = negativeFloat + 1f
    let negativeNumber = negativeNumber + 1I
    printfn $"{negativeFloat:F}"
    printfn $"{negativeNumber}"
    // The example displays the following output to the console:
    //       -340282300000000000000000000000000000000.00
    //       -340282346638528859811704183484516925440
    //       -340282300000000000000000000000000000000.00
    //       -340282346638528859811704183484516925439
    // </Snippet36>

let createPositiveValueFromByteArray () =
    // <Snippet1>
    let byteArray = [| 5uy; 4uy; 3uy; 2uy; 1uy |]
    let newBigInt = BigInteger byteArray
    printfn $"Value of newBigInt is {newBigInt} (or 0x{newBigInt:x} hex)"
    // The code produces the following output:
    //
    //    Value of newBigInt is 4328719365 (or 0x102030405 hex)
    // </Snippet1>

let createNegativeValueFromByteArray () =
    // <Snippet2>
    let byteArray = [| 5uy; 4uy; 3uy; 2uy; 1uy |]
    let newBigInt = BigInteger byteArray
    printfn $"Value of newBigInt is {newBigInt} (or 0x{newBigInt:x} hex)"
    // </Snippet2>

let createThroughOperation () =
    // <Snippet33>
    let longValue = 987654321L
    let number = BigInteger.Pow(longValue, 3)
    printfn $"{number}" // Displays 963418328693495609108518161
    // </Snippet33>

let callCompareTo () =
    // <Snippet6>
    let bigIntegerInstance = BigInteger.Parse "3221123045552"

    let byteInteger = 16uy
    let sByteInteger = -16y
    let shortInteger = 1233s
    let uShortInteger = 1233us
    let normalInteger = -12233
    let normalUInteger = 12233u
    let longInteger = 12382222L
    let uLongInteger = 1238222uL
    let singleValue = -123.49951F
    let doubleValue = 123.49951992
    let decimalValue = 1234.556M

    printfn $"Comparison of {bigIntegerInstance} with {byteInteger}: {bigIntegerInstance.CompareTo byteInteger}"
    printfn $"Comparison of {bigIntegerInstance} with {sByteInteger}: {bigIntegerInstance.CompareTo sByteInteger}"
    printfn $"Comparison of {bigIntegerInstance} with {shortInteger}: {bigIntegerInstance.CompareTo shortInteger}"
    printfn $"Comparison of {bigIntegerInstance} with {uShortInteger}: {bigIntegerInstance.CompareTo uShortInteger}"
    printfn $"Comparison of {bigIntegerInstance} with {normalInteger}: {bigIntegerInstance.CompareTo normalInteger}"
    printfn $"Comparison of {bigIntegerInstance} with {normalUInteger}: {bigIntegerInstance.CompareTo normalUInteger}"
    printfn $"Comparison of {bigIntegerInstance} with {longInteger}: {bigIntegerInstance.CompareTo longInteger}"
    printfn $"Comparison of {bigIntegerInstance} with {uLongInteger}: {bigIntegerInstance.CompareTo uLongInteger}"

    try
        printfn $"Comparison of {bigIntegerInstance} with {singleValue}: {bigIntegerInstance.CompareTo(singleValue)}"
    with :? ArgumentException ->
        printfn $"Unable to compare {bigIntegerInstance} with a Single value of {singleValue}"

    try
        printfn $"Comparison of {bigIntegerInstance} with {doubleValue}: {bigIntegerInstance.CompareTo(doubleValue)}"
    with :? ArgumentException ->
        printfn $"Unable to compare {bigIntegerInstance} with a Double value of {doubleValue}"

    try
        printfn $"Comparison of {bigIntegerInstance} with {decimalValue}: {bigIntegerInstance.CompareTo(decimalValue)}"
    with :? ArgumentException ->
        printfn $"Unable to compare {bigIntegerInstance} with a Decimal value of {decimalValue}"
    // The code produces the following output to the console:
    //
    // Comparison of 3221123045552 with 16: 1
    // Comparison of 3221123045552 with -16: 1
    // Comparison of 3221123045552 with 1233: 1
    // Comparison of 3221123045552 with 1233: 1
    // Comparison of 3221123045552 with -12233: 1
    // Comparison of 3221123045552 with 12233: 1
    // Comparison of 3221123045552 with 12382222: 1
    // Comparison of 3221123045552 with 1238222: 1
    // Unable to compare 3221123045552 with a Single value of -123.4995
    // Unable to compare 3221123045552 with a Double value of 123.49951992
    // Unable to compare 3221123045552 with a Decimal value of 1234.556
    // </Snippet6>

let multiplyIfOverflow () =
    // <Snippet7>
    let number1 = 1234567890L
    let number2 = 9876543210L

    try

        let product: int64 = Checked.(*) number1 number2
        ()
    with :? OverflowException ->
        let product = BigInteger.Multiply(number1, number2)
        printfn $"{product}"
    // </Snippet7>

let compareDivisionResults (dividend: bigint) (divisor: bigint) =
    // <Snippet8>
    let mutable remainder = 0I
    let quotient = BigInteger.DivRem(dividend, divisor, &remainder)
    printfn $"DivRem({dividend}, {divisor}) returns {quotient} with a remainder of {remainder}"
    printfn $"Result of division: {BigInteger.Divide(dividend, divisor)}"
    printfn $"Remainder after division: {BigInteger.Remainder(dividend, divisor)}"
    // </Snippet8>

let GCD () =
    // <Snippet10>
    let n1 = BigInteger.Pow(154382190, 3)
    let n2 = BigInteger.Multiply(1643590, 166935)

    try
        printfn $"The greatest common divisor of {n1} and {n2} is {BigInteger.GreatestCommonDivisor(n1, n2)}."
    with :? ArgumentOutOfRangeException as e ->
        printfn $"Unable to calculate the greatest common divisor:"
        printfn $"   {e.ActualValue} is an invalid value for {e.ParamName}"
    // </Snippet10>

let showModPow () =
    // <Snippet15>
    let number = 10I
    let exponent = 3
    let modulus = 30I
    printfn $"({number}^{exponent}) Mod {modulus} = {BigInteger.ModPow(number, exponent, modulus)}" // Displays 10
    // </Snippet15>

let showNegationMethods () =
    // <Snippet16>
    let number = 12645002I

    printfn $"{BigInteger.Negate number}" // Displays -12645002
    printfn $"{-number}" // Displays -12645002
    printfn $"{number * BigInteger.MinusOne}" // Displays -12645002
    // </Snippet16>

let multiply () =
    // <Snippet11>
    let num1 = 1000456321I
    let num2 = 90329434I
    let result = num1 * num2
    // </Snippet11>
    ()

let add () =
    // <Snippet12>
    let num1 = 1000456321I
    let num2 = 90329434I
    let sum = num1 + num2
    // </Snippet12>
    ()

let divide () =
    // <Snippet13>
    let num1 = 100045632194I
    let num2 = 90329434I
    let quotient = num1 / num2
    // </Snippet13>
    ()

let subtract () =
    // <Snippet14>
    let num1 = 100045632194I
    let num2 = 90329434I
    let result = num1 - num2
    // </Snippet14>
    ()

let decrement () =
    // <Snippet17>
    let mutable number = 93843112I
    number <- number - 1I
    printfn $"{number}" // Displays 93843111
    // </Snippet17>

let equality () =
    // <Snippet19>
    let number1 = 945834723I
    let number2 = 345145625I
    let number3 = 945834723I
    printfn $"{number1 = number2}" // Displays False
    printfn $"{number1 = number3}" // Displays True
    // </Snippet19>

let greaterThan () =
    // <Snippet20>
    let number1 = 945834723I
    let number2 = 345145625I
    let number3 = 945834724I
    printfn $"{number1 > number2}" // Displays True
    printfn $"{number1 > number3}" // Displays False
    // </Snippet20>

let greaterThanOrEqualTo () =
    // <Snippet22>
    let number1 = 945834723I
    let number2 = 345145625I
    let number3 = 945834724I
    let number4 = 945834723I
    printfn $"{number1 >= number2}" // Displays True
    printfn $"{number1 >= number3}" // Displays False
    printfn $"{number1 >= number4}" // Displays True
    // </Snippet22>

let increment () =
    // <Snippet24>
    let mutable number = 93843112I
    number <- number + 1I
    printfn $"{number}" // Displays 93843113
    // </Snippet24>

let inequality () =
    // <Snippet26>
    let number1 = 945834723I
    let number2 = 345145625I
    let number3 = 945834723I
    printfn $"{number1 <> number2}" // Displays True
    printfn $"{number1 <> number3}" // Displays False
    // </Snippet26>

let lessThan () =
    // <Snippet27>
    let number1 = 945834723I
    let number2 = 345145625I
    let number3 = 945834724I
    printfn $"{number1 < number2}" // Displays False
    printfn $"{number1 < number3}" // Displays True
    // </Snippet27>

let lessThanOrEqualTo () =
    // <Snippet29>
    let number1 = 945834723I
    let number2 = 345145625I
    let number3 = 945834724I
    let number4 = 945834723I
    printfn $"{number1 <= number2}" // Displays False
    printfn $"{number1 <= number3}" // Displays True
    printfn $"{number1 <= number4}" // Displays True
    // </Snippet29>

let modulus () =
    // <Snippet31>
    let num1 = 100045632194I
    let num2 = 90329434I
    let remainder = num1 % num2
    printfn $"{remainder}" // Displays 50948756
    // </Snippet31>

let showExponentiation () =
    // <Snippet32>
    let numericBase = 3040506I

    for ctr in 0..10 do
        printfn $"{BigInteger.Pow(numericBase, ctr)}"
    //
    // The example produces the following output to the console:
    //
    // 1
    // 3040506
    // 9244676736036
    // 28108495083977874216
    // 85464047953805230420993296
    // 259853950587832525926412642447776
    // 790087495886008322074413197838317614656
    // 2402265771766383619317185774506591737267255936
    // 7304103492650319992835619250501939216711515276943616
    // 22208170494024253840136657344866649200046662468638726109696
    // 67524075636103707946458547477011116092637077515870858568887346176
    // </Snippet32>

// <Snippet9>
type StarDistances() =
    [<Literal>]
    let LIGHT_YEAR = 5878625373183L

    member _.CompareStarDistances() =
        let altairDistance = 17I * bigint LIGHT_YEAR
        let epsilonIndiDistance = 12I * bigint LIGHT_YEAR
        let ursaeMajoris47Distance = 46I * bigint LIGHT_YEAR
        let tauCetiDistance = 12I * bigint LIGHT_YEAR
        let procyon2Distance: int64 = 12L * LIGHT_YEAR
        let wolf424ABDistance = int64 14 * LIGHT_YEAR

        printfn "Approx. equal distances from Epsilon Indi to:"
        printfn $"   Altair: {epsilonIndiDistance.Equals altairDistance}"
        printfn $"   Ursae Majoris 47: {epsilonIndiDistance.Equals ursaeMajoris47Distance}"
        printfn $"   TauCeti: {epsilonIndiDistance.Equals tauCetiDistance}"
        printfn $"   Procyon 2: {epsilonIndiDistance.Equals procyon2Distance}"
        printfn $"   Wolf 424 AB: {epsilonIndiDistance.Equals wolf424ABDistance}"
// </Snippet9>
