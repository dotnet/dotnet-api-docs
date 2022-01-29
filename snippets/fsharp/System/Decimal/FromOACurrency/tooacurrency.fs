module tooacurrency

//<Snippet1>
// Example of the Decimal.ToOACurrency method.
open System

let dataFmt obj1 obj2 = printfn $"{obj1,31}{obj2,27}"

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

// Display the Decimal.ToOACurrency parameter and the result
// or exception.
let showDecimalToOACurrency argument =
    // Catch the exception if ToOACurrency( ) throws one.
    try
        let oaCurrency = Decimal.ToOACurrency argument
        dataFmt argument oaCurrency
    with ex ->
        dataFmt argument (getExceptionType ex) 

printfn 
    """This example of the Decimal.ToOACurrency() method generates 
the following output. It displays the argument as a decimal 
and the OLE Automation Currency value as a long.
"""
dataFmt "Argument" "OA Currency or Exception" 
dataFmt "--------" "------------------------"

// Convert decimal values to OLE Automation Currency values.
showDecimalToOACurrency 0M
showDecimalToOACurrency 1M
showDecimalToOACurrency 1.0000000000000000000000000000M
showDecimalToOACurrency 100000000000000M
showDecimalToOACurrency 100000000000000.00000000000000M
showDecimalToOACurrency 10000000000000000000000000000M
showDecimalToOACurrency 0.000000000123456789M
showDecimalToOACurrency 0.123456789M
showDecimalToOACurrency 123456789M
showDecimalToOACurrency 123456789000000000M
showDecimalToOACurrency 4294967295M
showDecimalToOACurrency 18446744073709551615M
showDecimalToOACurrency -79.228162514264337593543950335M
showDecimalToOACurrency -79228162514264.337593543950335M


// This example of the Decimal.ToOACurrency() method generates
// the following output. It displays the argument as a decimal
// and the OLE Automation Currency value as a long.
//
//                        Argument   OA Currency or Exception
//                        --------   ------------------------
//                               0                          0
//                               1                      10000
//  1.0000000000000000000000000000                      10000
//                 100000000000000        1000000000000000000
//  100000000000000.00000000000000        1000000000000000000
//   10000000000000000000000000000          OverflowException
//            0.000000000123456789                          0
//                     0.123456789                       1235
//                       123456789              1234567890000
//              123456789000000000          OverflowException
//                      4294967295             42949672950000
//            18446744073709551615          OverflowException
// -79.228162514264337593543950335                    -792282
// -79228162514264.337593543950335        -792281625142643376
//</Snippet1> 