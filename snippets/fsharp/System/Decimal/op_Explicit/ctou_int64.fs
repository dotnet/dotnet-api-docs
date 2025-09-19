module ctou_int64

//<Snippet1>
// Example of the explicit conversions from decimal to long and
// decimal to ulong.
let print obj1 obj2 obj3 = printfn $"{obj1,25}{obj2,22}{obj3,22}"

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

// Convert the decimal argument; catch exceptions that are thrown.
let decimalToU_Int64 (argument: decimal) =
    let int32Value: obj =
        // Convert the argument to a int64 value.
        try
            int32 argument
        with ex -> getExceptionType ex

    let uint32Value: obj =
        // Convert the argument to a uint64 value.
        try
            uint32 argument
        with ex -> getExceptionType ex

    print argument int32Value uint32Value

printfn "This example of the explicit conversions from decimal to long\nand decimal to ulong generates the following output. It displays\nseveral converted decimal values.\n"

print "decimal argument" "long/exception" "ulong/exception"
print "----------------" "--------------" "---------------"

// Convert decimal values and display the results.
decimalToU_Int64 123M
decimalToU_Int64 (new decimal(123000, 0, 0, false, 3uy))
decimalToU_Int64 123.999M
decimalToU_Int64 18446744073709551615.999M
decimalToU_Int64 18446744073709551616M
decimalToU_Int64 9223372036854775807.999M
decimalToU_Int64 9223372036854775808M
decimalToU_Int64 -0.999M
decimalToU_Int64 -1M
decimalToU_Int64 -9223372036854775808.999M
decimalToU_Int64 -9223372036854775809M


// This example of the explicit conversions from decimal to long
// and decimal to ulong generates the following output. It displays
// several converted decimal values.
//
//          decimal argument        long/exception       ulong/exception
//          ----------------        --------------       ---------------
//                       123                   123                   123
//                   123.000                   123                   123
//                   123.999                   123                   123
//  18446744073709551615.999     OverflowException  18446744073709551615
//      18446744073709551616     OverflowException     OverflowException
//   9223372036854775807.999   9223372036854775807   9223372036854775807
//       9223372036854775808     OverflowException   9223372036854775808
//                    -0.999                     0                     0
//                        -1                    -1     OverflowException
//  -9223372036854775808.999  -9223372036854775808     OverflowException
//      -9223372036854775809     OverflowException     OverflowException
//</Snippet1> 