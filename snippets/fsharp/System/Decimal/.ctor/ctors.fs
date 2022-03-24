module ctors

//<Snippet1>
// Example of the decimal( float ) constructor.
open System

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.'  + 1)

// Create a decimal object and display its value.
let createDecimal (value: float32) valToStr =
    // Format and display the constructor.
    printf "%-27s" $"decimal( {valToStr} )"

    try
        // Construct the decimal value.
        let decimalNum = Decimal value

        // Display the value if it was created successfully.
        printfn $"{decimalNum,31}"
    with ex ->
        // Display the exception type if an exception was thrown.
        printfn $"{getExceptionType ex,31}"


printfn "This example of the decimal( float ) constructor \ngenerates the following output.\n"
printfn $"""{"Constructor",-27}{"Value or Exception",31}"""
printfn $"""{"-----------",-27}{"------------------",31}"""

// Construct decimal objects from float values.
createDecimal 1.2345E+5f "1.2345E+5F"
createDecimal 1.234567E+15f "1.234567E+15F"
createDecimal 1.23456789E+25f "1.23456789E+25F"
createDecimal 1.23456789E+35f "1.23456789E+35F"
createDecimal 1.2345E-5f "1.2345E-5F"
createDecimal 1.234567E-15f "1.234567E-15F"
createDecimal 1.23456789E-25f "1.23456789E-25F"
createDecimal 1.23456789E-35f "1.23456789E-35F"
createDecimal (1f / 7f) "1.0F / 7.0F"


// This example of the decimal( float ) constructor
// generates the following output.

// Constructor                             Value or Exception
// -----------                             ------------------
// decimal( 1.2345E+5F )                               123450
// decimal( 1.234567E+15F )                  1234567000000000
// decimal( 1.23456789E+25F )      12345680000000000000000000
// decimal( 1.23456789E+35F )               OverflowException
// decimal( 1.2345E-5F )                          0.000012345
// decimal( 1.234567E-15F )           0.000000000000001234567
// decimal( 1.23456789E-25F )  0.0000000000000000000000001235
// decimal( 1.23456789E-35F )                               0
// decimal( 1.0F / 7.0F )                           0.1428571
//</Snippet1> 