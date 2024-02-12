module ctou_int32

//<Snippet2>
// Example of the explicit conversions from decimal to int and
// decimal to uint.
let print obj1 obj2 obj3 = printfn $"{obj1,17}{obj2,19}{obj3,19}"

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

// Convert the decimal argument; catch exceptions that are thrown.
let decimalToU_Int32 (argument: decimal) =
    let int32Value: obj =
        // Convert the argument to a int32 value.
        try
            int32 argument
        with ex -> getExceptionType ex

    let uint32Value: obj =
        // Convert the argument to a uint32 value.
        try
            uint32 argument
        with ex -> getExceptionType ex

    print argument int32Value uint32Value

printfn "This example of the explicit conversions from decimal to int\nand decimal to uint generates the following output. It displays\nseveral converted decimal values.\n"

print "decimal argument" "int/exception" "uint/exception"
print "----------------" "-------------" "--------------" 

// Convert decimal values and display the results.
decimalToU_Int32 123M
decimalToU_Int32 (new decimal(123000, 0, 0, false, 3uy))
decimalToU_Int32 123.999M
decimalToU_Int32 4294967295.999M
decimalToU_Int32 4294967296M
decimalToU_Int32 2147483647.999M
decimalToU_Int32 2147483648M
decimalToU_Int32 -0.999M
decimalToU_Int32 -1M
decimalToU_Int32 -2147483648.999M
decimalToU_Int32 -2147483649M


// This example of the explicit conversions from decimal to int
// and decimal to uint generates the following output. It displays
// several converted decimal values.
//
//  decimal argument      int/exception     uint/exception
//  ----------------      -------------     --------------
//               123                123                123
//           123.000                123                123
//           123.999                123                123
//    4294967295.999  OverflowException         4294967295
//        4294967296  OverflowException  OverflowException
//    2147483647.999         2147483647         2147483647
//        2147483648  OverflowException         2147483648
//            -0.999                  0                  0
//                -1                 -1  OverflowException
//   -2147483648.999        -2147483648  OverflowException
//       -2147483649  OverflowException  OverflowException
//</Snippet2> 