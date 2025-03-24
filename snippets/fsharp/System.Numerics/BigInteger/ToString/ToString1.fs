module tostring1

open System
open System.Globalization
open System.Numerics

let toStringDft () =
    // <Snippet1>
    // Initialize a BigInteger value.
    let value = BigInteger.Add(UInt64.MaxValue, 1024)

    // Display value using the default ToString method.
    printfn $"{value.ToString()}"
    // Display value using some standard format specifiers.
    printfn $"""{value.ToString("G")}"""
    printfn $"""{value.ToString("C")}"""
    printfn $"""{value.ToString("D")}"""
    printfn $"""{value.ToString("F")}"""
    printfn $"""{value.ToString("N")}"""
    printfn $"""{value.ToString("X")}"""
// The example displays the following output on a system whose current
// culture is en-US:
//       18446744073709552639
//       18446744073709552639
//       $18,446,744,073,709,552,639.00
//       18446744073709552639
//       18446744073709552639.00
//       18,446,744,073,709,552,639.00
//       100000000000003FF
// </Snippet1>


let roundtripValue () =
    // <Snippet2>
    // Create number with 50+ digits and store it to two strings.
    let originalNumber = BigInteger.Pow(UInt64.MaxValue, int Byte.MaxValue)
    let generalString = originalNumber.ToString "G"
    let roundTripString = originalNumber.ToString "R"

    printfn
        $"""The original value has {originalNumber.ToString("X").Length} hexadecimal digits.
"""

    // Attempt to round-trip strings and compare them with the original.
    printfn "Parsing the string formatted with the 'G' format string."

    let generalBigInteger =
        BigInteger.Parse(generalString, NumberStyles.AllowExponent ||| NumberStyles.AllowDecimalPoint)

    if originalNumber.Equals(generalBigInteger) then
        printfn "The values are equal. No data has been lost."
    else
        printfn "The values are not equal. Data has been lost."

    printfn "Parsing the string formatted with the 'R' format string."
    let roundTripBigInteger = BigInteger.Parse roundTripString

    if originalNumber.Equals roundTripBigInteger then
        printfn "The values are equal. No data has been lost."
    else
        printfn "The values are not equal. Data has been lost."
// The example displays the following output:
//       The original value has 4080 hexadecimal digits.
//
//       Parsing the string formatted with the 'G' format string.
//       The values are not equal. Data has been lost.
//
//       Parsing the string formatted with the 'R' format string.
//       The values are equal. No data has been lost.
// </Snippet2>


let toFormattedString () =
    // <Snippet3>
    // Define a BigInteger value.
    let value = BigInteger.Parse "-903145792771643190182"

    let specifiers =
        [| "C"
           "D"
           "D25"
           "E"
           "E4"
           "e8"
           "F0"
           "G"
           "N0"
           "P"
           "R"
           "X"
           "0,0.000"
           "#,#.00#;(#,#.00#)" |]

    for specifier in specifiers do
        printfn $"{specifier}: {value.ToString specifier}"
// The example displays the following output:
//       C: ($903,145,792,771,643,190,182.00)
//       D: -903145792771643190182
//       D25: -0000903145792771643190182
//       E: -9.031457E+020
//       E4: -9.0314E+020
//       e8: -9.03145792e+020
//       F0: -903145792771643190182
//       G: -903145792771643190182
//       N0: -903,145,792,771,643,190,182
//       P: -90,314,579,277,164,319,018,200.00 %
//       R: -903145792771643190182
//       X: CF0A55968BB1A7545A
//       0,0.000: -903,145,792,771,643,190,182.000
//       #,#.00#;(#,#.00#): (903,145,792,771,643,190,182.00)
// </Snippet3>

let FormatStringWithProvider () =
    // <Snippet4>
    // Redefine the negative sign as the tilde for the invariant culture.
    let bigIntegerFormatter = NumberFormatInfo()
    bigIntegerFormatter.NegativeSign <- "~"

    let value = BigInteger.Parse "-903145792771643190182"

    let specifiers =
        [| "C"
           "D"
           "D25"
           "E"
           "E4"
           "e8"
           "F0"
           "G"
           "N0"
           "P"
           "R"
           "X"
           "0,0.000"
           "#,#.00#;(#,#.00#)" |]

    for specifier in specifiers do
        printfn $"{specifier}: {value.ToString(specifier, bigIntegerFormatter)}"

// The example displays the following output:
//    C: (☼903,145,792,771,643,190,182.00)
//    D: ~903145792771643190182
//    D25: ~0000903145792771643190182
//    E: ~9.031457E+020
//    E4: ~9.0314E+020
//    e8: ~9.03145792e+020
//    F0: ~903145792771643190182
//    G: ~903145792771643190182
//    N0: ~903,145,792,771,643,190,182
//    P: ~90,314,579,277,164,319,018,200.00 %
//    R: ~903145792771643190182
//    X: CF0A55968BB1A7545A
//    0,0.000: ~903,145,792,771,643,190,182.000
//    #,#.00#;(#,#.00#): (903,145,792,771,643,190,182.00)
// </Snippet4>

toStringDft ()
printfn "-----"
roundtripValue ()
printfn "-----"
toFormattedString ()
printfn "-----"
FormatStringWithProvider()
