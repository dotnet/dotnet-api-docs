module example2

open System
open System.Numerics

let compareToLong () =
    // <Snippet3>
    let bigIntValue = BigInteger.Parse "3221123045552"

    let byteValue = 16uy
    let sbyteValue = -16y
    let shortValue = 1233s
    let ushortValue = 1233us
    let intValue = -12233
    let uintValue = 12233u
    let longValue = 12382222L
    let ulongValue = 1238222UL

    printfn $"Comparing {bigIntValue} with {byteValue}: {bigIntValue.CompareTo byteValue}"
    printfn $"Comparing {bigIntValue} with {sbyteValue}: {bigIntValue.CompareTo sbyteValue}"
    printfn $"Comparing {bigIntValue} with {shortValue}: {bigIntValue.CompareTo shortValue}"
    printfn $"Comparing {bigIntValue} with {ushortValue}: {bigIntValue.CompareTo ushortValue}"
    printfn $"Comparing {bigIntValue} with {intValue}: {bigIntValue.CompareTo intValue}"
    printfn $"Comparing {bigIntValue} with {uintValue}: {bigIntValue.CompareTo uintValue}"
    printfn $"Comparing {bigIntValue} with {longValue}: {bigIntValue.CompareTo longValue}"
    printfn $"Comparing {bigIntValue} with {ulongValue}: {bigIntValue.CompareTo ulongValue}"
    // The example displays the following output:
    //       Comparing 3221123045552 with 16: 1
    //       Comparing 3221123045552 with -16: 1
    //       Comparing 3221123045552 with 1233: 1
    //       Comparing 3221123045552 with 1233: 1
    //       Comparing 3221123045552 with -12233: 1
    //       Comparing 3221123045552 with 12233: 1
    //       Comparing 3221123045552 with 12382222: 1
    //       Comparing 3221123045552 with 1238222: 1
    // </Snippet3>

let compareToObject () =
    // <Snippet4>
    let values =
        [| BigInteger.Pow(Int64.MaxValue, 10)
           Unchecked.defaultof<bigint>
           bigint 12.534
           Int64.MaxValue
           BigInteger.One |]

    let number = bigint UInt64.MaxValue

    for value in values do
        try
            printfn $"Comparing {number} with '{value}': {number.CompareTo value}"
        with :? ArgumentException as e ->
            printfn $"Unable to compare the {value.GetType().Name} value {value} with a BigInteger."
    // The example displays the following output:
    //    Comparing 18446744073709551615 with '4.4555084156466750133735972424E+189': -1
    //    Comparing 18446744073709551615 with '': 1
    //    Unable to compare the Double value 12.534 with a BigInteger.
    //    Unable to compare the Int64 value 9223372036854775807 with a BigInteger.
    //    Comparing 18446744073709551615 with '1': 1
    // </Snippet4>
compareToLong ()
compareToObject ()
