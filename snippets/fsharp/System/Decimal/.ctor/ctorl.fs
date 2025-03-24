module ctorl

//<Snippet3>
// Example of the decimal( int64 ) constructor.
open System

// Create a decimal object and display its value.
let createDecimal (value: int64) valToStr =
    let decimalNum = Decimal value

    // Format the constructor for display.
    let ctor = $"decimal( {valToStr} )"

    // Display the constructor and its value.
    printfn $"{ctor,-35}{decimalNum,22}"

printfn "This example of the decimal( int64 ) constructor\ngenerates the following output.\n"
printfn "%-35s%22s" "Constructor" "Value"
printfn "%-35s%22s" "-----------" "-----"

// Construct decimal objects from long values.
createDecimal Int64.MinValue "Int64.MinValue"
createDecimal Int64.MaxValue "Int64.MaxValue"
createDecimal 0L "0L"
createDecimal 999999999999999999L "999999999999999999L"
createDecimal 0x2000000000000000L "0x2000000000000000L"
createDecimal (int64 0xE000000000000000L) "int64 0xE000000000000000L"

// This example of the decimal( int64 ) constructor 
// generates the following output.
//
// Constructor                                         Value
// -----------                                         -----
// decimal( Int64.MinValue )            -9223372036854775808
// decimal( Int64.MaxValue )             9223372036854775807
// decimal( 0L )                                           0
// decimal( 999999999999999999L )         999999999999999999
// decimal( 0x2000000000000000L )        2305843009213693952
// decimal( int64 0xE000000000000000L )  -2305843009213693952
//</Snippet3> 