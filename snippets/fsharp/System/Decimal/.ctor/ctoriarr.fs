module ctoriarr

//<Snippet1>
// Example of the decimal(int[]) constructor.
open System

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

// Create a decimal object and display its value.
let createDecimal (bits: int[]) =
    // Format the constructor for display.
    let mutable ctor = String.Format("decimal( {{ 0x{0:X}", bits[0])

    for i = 1 to bits.Length - 1 do
        ctor <- $"{ctor}, 0x{bits[i]:X}"
    ctor <- ctor + " } )"

    let valOrExc =
        try
            // Construct the decimal value.
            let decimalNum = new decimal(bits)

            // Format the decimal value for display.
            string decimalNum
        with ex ->
            // Save the exception type if an exception was thrown.
            getExceptionType ex

    // Display the constructor and decimal value or exception.
    let ctorLen = 76 - valOrExc.Length;

    // Display the data on one line if it will fit.
    if ctorLen > ctor.Length then
        printfn $"{ctor.PadRight ctorLen}{valOrExc}"

    // Otherwise, display the data on two lines.
    else
        printfn $"{ctor}"
        printfn $"{valOrExc,76}"

printfn
    """This example of the decimal(int[]) constructor
generates the following output.
"""
printfn "%-38s%38s" "Constructor" "Value or Exception"
printfn "%-38s%38s" "-----------" "------------------"

// Construct decimal objects from integer arrays.
createDecimal [| 0; 0; 0; 0 |]
createDecimal [| 0; 0; 0 |]
createDecimal [| 0; 0; 0; 0; 0 |]
createDecimal [| 1000000000; 0; 0; 0 |]
createDecimal [| 0; 1000000000; 0; 0 |]
createDecimal [| 0; 0; 1000000000; 0 |]
createDecimal [| 0; 0; 0; 1000000000 |]
createDecimal [| -1; -1; -1; 0 |]
createDecimal [| -1; -1; -1; 0x80000000 |]
createDecimal [| -1; 0; 0; 0x100000 |]
createDecimal [| -1; 0; 0; 0x1C0000 |]
createDecimal [| -1; 0; 0; 0x1D0000 |]
createDecimal [| -1; 0; 0; 0x1C0001 |]
createDecimal [| 0xF0000; 0xF0000; 0xF0000; 0xF0000 |]


// This example of the decimal(int[]) constructor
// generates the following output.
//
// Constructor                                               Value or Exception
// -----------                                               ------------------
// decimal( { 0x0, 0x0, 0x0, 0x0 } )                                          0
// decimal( { 0x0, 0x0, 0x0 } )                               ArgumentException
// decimal( { 0x0, 0x0, 0x0, 0x0, 0x0 } )                     ArgumentException
// decimal( { 0x3B9ACA00, 0x0, 0x0, 0x0 } )                          1000000000
// decimal( { 0x0, 0x3B9ACA00, 0x0, 0x0 } )                 4294967296000000000
// decimal( { 0x0, 0x0, 0x3B9ACA00, 0x0 } )       18446744073709551616000000000
// decimal( { 0x0, 0x0, 0x0, 0x3B9ACA00 } )                   ArgumentException
// decimal( { 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0x0 } )
//                                                79228162514264337593543950335
// decimal( { 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0x80000000 } )
//                                               -79228162514264337593543950335
// decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x100000 } )             0.0000004294967295
// decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x1C0000 } ) 0.0000000000000000004294967295
// decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x1D0000 } )              ArgumentException
// decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x1C0001 } )              ArgumentException
// decimal( { 0xF0000, 0xF0000, 0xF0000, 0xF0000 } )
//                                                  18133887298.441562272235520
//</Snippet1> 