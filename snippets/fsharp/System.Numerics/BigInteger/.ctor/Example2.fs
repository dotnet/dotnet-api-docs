module example2

open System
open System.Numerics

let decimalConstructor () =
    // <Snippet4>
    let decimalValues = [ -1790.533m; -15.1514m; 18903.79m; 9180098.003m ]

    for decimalValue in decimalValues do
        let number = bigint decimalValue
        printfn $"Instantiated BigInteger value {number} from the Decimal value {decimalValue}."
    // The example displays the following output:
    //    Instantiated BigInteger value -1790 from the Decimal value -1790.533.
    //    Instantiated BigInteger value -15 from the Decimal value -15.1514.
    //    Instantiated BigInteger value 18903 from the Decimal value 18903.79.
    //    Instantiated BigInteger value 9180098 from the Decimal value 9180098.003.
    // </Snippet4>

let doubleConstructor () =
    // <Snippet5>
    // Create a BigInteger from a large double value.
    let doubleValue = -6e20
    let bigIntValue = bigint doubleValue
    printfn $"Original Double value: {doubleValue:N0}"
    printfn $"Original BigInteger value: {bigIntValue:N0}"
    // Increment and then display both values.
    let doubleValue = doubleValue + 1.
    let bigIntValue = bigIntValue + BigInteger.One
    printfn $"Incremented Double value: {doubleValue:N0}"
    printfn $"Incremented BigInteger value: {bigIntValue:N0}"
    // The example displays the following output:
    //    Original Double value: -600,000,000,000,000,000,000
    //    Original BigInteger value: -600,000,000,000,000,000,000
    //    Incremented Double value: -600,000,000,000,000,000,000
    //    Incremented BigInteger value: -599,999,999,999,999,999,999
    // </Snippet5>

let integerConstructor () =
    // <Snippet6>
    let integers = [ Int32.MinValue; -10534; -189; 0; 17; 113439; Int32.MaxValue ]

    for number in integers do
        let constructed = bigint number
        let assigned = number
        printfn $"{constructed} = {assigned}: {constructed.Equals assigned}"
    // The example displays the following output:
    //       -2147483648 = -2147483648: True
    //       -10534 = -10534: True
    //       -189 = -189: True
    //       0 = 0: True
    //       17 = 17: True
    //       113439 = 113439: True
    //       2147483647 = 2147483647: True
    // </Snippet6>

let longConstructor () =
    // <Snippet7>
    let longs = [ Int64.MinValue; -10534; -189; 0; 17; 113439; Int64.MaxValue ]

    for number in longs do
        let constructed = bigint number
        let assigned = number
        printfn $"{constructed} = {assigned}: {constructed.Equals assigned}"
    // The example displays the following output:
    //       -2147483648 = -2147483648: True
    //       -10534 = -10534: True
    //       -189 = -189: True
    //       0 = 0: True
    //       17 = 17: True
    //       113439 = 113439: True
    //       2147483647 = 2147483647: True
    // </Snippet7>

let singleConstructor () =
    // <Snippet8>
    // Create a BigInteger from a large negative Single value
    let negativeSingle = Single.MinValue
    let negativeNumber = bigint negativeSingle

    printfn $"""{negativeSingle.ToString "N0"}"""
    printfn $"""{negativeNumber.ToString "N0"}"""

    let negativeSingle = negativeSingle + 1f
    let negativeNumber = negativeNumber + 1I

    printfn $"""{negativeSingle.ToString "N0"}"""
    printfn $"""{negativeNumber.ToString "N0"}"""
    // The example displays the following output:
    //       -340,282,300,000,000,000,000,000,000,000,000,000,000
    //       -340,282,346,638,528,859,811,704,183,484,516,925,440
    //       -340,282,300,000,000,000,000,000,000,000,000,000,000
    //       -340,282,346,638,528,859,811,704,183,484,516,925,439
    // </Snippet8>

let UInt32Constructor () =
    // <Snippet9>
    let unsignedValues = [ 0u; 16704u; 199365u; UInt32.MaxValue ]

    for unsignedValue in unsignedValues do
        let constructedNumber = bigint unsignedValue
        let assignedNumber = unsignedValue

        if constructedNumber.Equals assignedNumber then
            printfn $"Both methods create a BigInteger whose value is {constructedNumber:N0}."
        else
            printfn $"{constructedNumber:N0} ≠ {assignedNumber:N0}"
    // The example displays the following output:
    //    Both methods create a BigInteger whose value is 0.
    //    Both methods create a BigInteger whose value is 16,704.
    //    Both methods create a BigInteger whose value is 199,365.
    //    Both methods create a BigInteger whose value is 4,294,967,295.
    // </Snippet9>

let UInt64Constructor () =
    // <Snippet10>
    let unsignedValue = UInt64.MaxValue
    let number = bigint unsignedValue
    printfn $"{number:N0}"
    // The example displays the following output:
    //       18,446,744,073,709,551,615
    // </Snippet10>

decimalConstructor ()
doubleConstructor ()
integerConstructor ()
longConstructor ()
singleConstructor ()
UInt32Constructor()
UInt64Constructor()
