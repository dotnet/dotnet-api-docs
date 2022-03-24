module ctorul

//<Snippet4>
// Example of the decimal( uint64 ) constructor.
open System

// Create a decimal object and display its value.
let createDecimal (value: uint64) valToStr =
    let decimalNum = Decimal value

    // Format the constructor for display.
    let ctor = $"decimal( {valToStr} )"

    // Display the constructor and its value.
    printfn $"{ctor,-35}{decimalNum,22}"

printfn "This example of the decimal( uint64 ) constructor \ngenerates the following output.\n"
printfn "%-35s%22s" "Constructor" "Value"
printfn "%-35s%22s" "-----------" "-----"

// Construct decimal objects from ulong values.
createDecimal UInt64.MinValue "UInt64.MinValue"
createDecimal UInt64.MaxValue "UInt64.MaxValue"
createDecimal (uint64 Int64.MaxValue) "int64 Int64.MaxValue"
createDecimal 999999999999999999uL "999999999999999999uL"
createDecimal 0x2000000000000000uL "0x2000000000000000uL"
createDecimal 0xE000000000000000uL "0xE000000000000000uL"


// This example of the decimal( uint64 ) constructor 
// generates the following output.
//
// Constructor                                         Value
// -----------                                         -----
// decimal( UInt64.MinValue )                              0
// decimal( UInt64.MaxValue )           18446744073709551615
// decimal( int64 Int64.MaxValue )       9223372036854775807
// decimal( 999999999999999999uL )        999999999999999999
// decimal( 0x2000000000000000uL )       2305843009213693952
// decimal( 0xE000000000000000uL )      16140901064495857664
//</Snippet4> 