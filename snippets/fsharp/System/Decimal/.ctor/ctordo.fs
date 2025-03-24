module ctordo

//<Snippet2>
// Example of the decimal( double ) constructor.
open System

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

// Create a decimal object and display its value.
let createDecimal (value: double) valToStr =
    // Format and display the constructor.
    printf "%-34s" $"decimal( {valToStr} )"

    try
        // Construct the decimal value.
        let decimalNum = Decimal value

        // Display the value if it was created successfully.
        printfn $"{decimalNum,31}"
    with ex ->
        // Display the exception type if an exception was thrown.
        printfn $"{getExceptionType ex,31}"

printfn $"This example of the decimal( double ) constructor \ngenerates the following output.\n"
printfn "%-34s%31s" "Constructor" "Value or Exception"
printfn "%-34s%31s" "-----------" "------------------"

// Construct decimal objects from double values.
createDecimal 1.23456789E+5 "1.23456789E+5"
createDecimal 1.234567890123E+15 "1.234567890123E+15"
createDecimal 1.2345678901234567E+25 "1.2345678901234567E+25"
createDecimal 1.2345678901234567E+35 "1.2345678901234567E+35"
createDecimal 1.23456789E-5 "1.23456789E-5"
createDecimal 1.234567890123E-15 "1.234567890123E-15"
createDecimal 1.2345678901234567E-25 "1.2345678901234567E-25"
createDecimal 1.2345678901234567E-35 "1.2345678901234567E-35"
createDecimal (1. / 7.) "1. / 7."


// This example of the decimal( double ) constructor
// generates the following output.
//
// Constructor                                    Value or Exception     
// -----------                                    ------------------     
// decimal( 1.23456789E+5 )                               123456.789     
// decimal( 1.234567890123E+15 )                    1234567890123000     
// decimal( 1.2345678901234567E+25 )      12345678901234600000000000     
// decimal( 1.2345678901234567E+35 )               OverflowException     
// decimal( 1.23456789E-5 )                          0.0000123456789     
// decimal( 1.234567890123E-15 )       0.000000000000001234567890123     
// decimal( 1.2345678901234567E-25 )  0.0000000000000000000000001235     
// decimal( 1.2345678901234567E-35 )                               0
//</Snippet2> 