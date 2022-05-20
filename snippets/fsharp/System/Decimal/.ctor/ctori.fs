module ctori

//<Snippet1>
// Example of the decimal(int) constructor.
open System

// Create a decimal object and display its value.
let createDecimal (value: int) valToStr =
    let decimalNum = new decimal(value)

    // Format the constructor for display.
    let ctor = $"decimal( {valToStr} )"

    // Display the constructor and its value.
    printfn $"{ctor,-30}{decimalNum,16}"

printfn "This example of the decimal(int) constructor\ngenerates the following output.\n"
printfn "%-30s%16s" "Constructor" "Value"
printfn "%-30s%16s" "-----------" "-----"

// Construct decimal objects from int values.
createDecimal Int32.MinValue "Int32.MinValue"
createDecimal Int32.MaxValue "int.MaxValue"
createDecimal 0 "0"
createDecimal 999999999 "999999999"
createDecimal 0x40000000 "0x40000000"
createDecimal (int 0xC0000000) "int 0xC0000000"


// This example of the decimal(int) constructor
// generates the following output.

// Constructor                              Value
// -----------                              -----
// decimal( Int32.MinValue )          -2147483648
// decimal( Int32.MaxValue )           2147483647
// decimal( 0 )                                 0
// decimal( 999999999 )                 999999999
// decimal( 0x40000000 )               1073741824
// decimal( int 0xC0000000 )          -1073741824
//</Snippet1> 