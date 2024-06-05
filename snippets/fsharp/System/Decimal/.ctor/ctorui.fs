module ctorui

//<Snippet2>
// Example of the decimal( uint ) constructor.
open System

// Create a decimal object and display its value.
let createDecimal (value: uint) valToStr =
    let decimalNum = Decimal value

    // Format the constructor for display.
    let ctor = $"decimal( {valToStr} )"

    // Display the constructor and its value.
    printfn $"{ctor,-33}{decimalNum,16}"

printfn "This example of the decimal( uint ) constructor \ngenerates the following output.\n"
printfn "%-33s%16s" "Constructor" "Value"
printfn "%-33s%16s" "-----------" "-----" 

// Construct decimal objects from uint values.
createDecimal UInt32.MinValue "UInt32.MinValue"
createDecimal UInt32.MaxValue "UInt32.MaxValue"
createDecimal (uint Int32.MaxValue) "uint Int32.MaxValue"
createDecimal 999999999u "999999999u"
createDecimal 0x40000000u "0x40000000u"
createDecimal 0xC0000000u "0xC0000000u"


// This example of the decimal( uint ) constructor 
// generates the following output.
//
// Constructor                                 Value
// -----------                                 -----
// decimal( UInt32.MinValue )                      0
// decimal( UInt32.MaxValue )             4294967295
// decimal( uint Int32.MaxValue )         2147483647
// decimal( 999999999u )                   999999999
// decimal( 0x40000000u )                 1073741824
// decimal( 0xC0000000u )                 3221225472
//</Snippet2> 