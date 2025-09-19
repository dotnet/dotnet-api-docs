module ctoriiibby

//<Snippet2>
// Example of the decimal( int, int, int, bool, byte ) constructor.
open System

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

// Create a decimal object and display its value.
let createDecimal low mid high (isNeg: bool) (scale: byte) =
    // Format the constructor for display.
    let ctor =
        $"decimal( %i{low}, %i{mid}, %i{high}, {isNeg}, {scale} )"

    let valOrExc =
        try
            // Construct the decimal value.
            let decimalNum = new decimal(low, mid, high, isNeg, scale)

            // Format and save the decimal value.
            decimalNum |> string
        with ex ->
            // Save the exception type if an exception was thrown.
            getExceptionType ex

    // Display the constructor and decimal value or exception.
    let ctorLen = 76 - valOrExc.Length

    // Display the data on one line if it will fit.
    if ctorLen > ctor.Length then
        printfn $"{ctor.PadRight ctorLen}{valOrExc}"

    // Otherwise, display the data on two lines.
    else
        printfn $"{ctor}"
        printfn $"{valOrExc,76}"

printfn 
    """This example of the decimal(int, int, int, bool, byte) 
constructor generates the following output.
"""
printfn "%-38s%38s" "Constructor" "Value or Exception"
printfn "%-38s%38s" "-----------" "------------------"

// Construct decimal objects from the component fields.
createDecimal 0 0 0 false 0uy
createDecimal 0 0 0 false 27uy
createDecimal 0 0 0 true 0uy
createDecimal 1000000000 0 0 false 0uy
createDecimal 0 1000000000 0 false 0uy
createDecimal 0 0 1000000000 false 0uy
createDecimal 1000000000 1000000000 1000000000 false 0uy
createDecimal -1 -1 -1 false 0uy
createDecimal -1 -1 -1 true 0uy
createDecimal -1 -1 -1 false 15uy
createDecimal -1 -1 -1 false 28uy
createDecimal -1 -1 -1 false 29uy
createDecimal Int32.MaxValue 0 0 false 18uy
createDecimal Int32.MaxValue 0 0 false 28uy
createDecimal Int32.MaxValue 0 0 true 28uy


// This example of the decimal(int, int, int, bool, byte)
// constructor generates the following output.
//
// Constructor                                               Value or Exception
// -----------                                               ------------------
// decimal( 0, 0, 0, False, 0 )                                               0
// decimal( 0, 0, 0, False, 27 )                                              0
// decimal( 0, 0, 0, True, 0 )                                                0
// decimal( 1000000000, 0, 0, False, 0 )                             1000000000
// decimal( 0, 1000000000, 0, False, 0 )                    4294967296000000000
// decimal( 0, 0, 1000000000, False, 0 )          18446744073709551616000000000
// decimal( 1000000000, 1000000000, 1000000000, False, 0 )
//                                                18446744078004518913000000000
// decimal( -1, -1, -1, False, 0 )                79228162514264337593543950335
// decimal( -1, -1, -1, True, 0 )                -79228162514264337593543950335
// decimal( -1, -1, -1, False, 15 )              79228162514264.337593543950335
// decimal( -1, -1, -1, False, 28 )              7.9228162514264337593543950335
// decimal( -1, -1, -1, False, 29 )                 ArgumentOutOfRangeException
// decimal( 2147483647, 0, 0, False, 18 )                  0.000000002147483647
// decimal( 2147483647, 0, 0, False, 28 )        0.0000000000000000002147483647
// decimal( 2147483647, 0, 0, True, 28 )        -0.0000000000000000002147483647
//</Snippet2> 