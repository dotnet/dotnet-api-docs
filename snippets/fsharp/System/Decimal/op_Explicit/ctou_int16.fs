module ctou_int16

//<Snippet3>
// Example of the explicit conversions from decimal to short and
// decimal to ushort.
let print obj1 obj2 obj3 =
    printfn $"{obj1, 16}{obj2, 19}{obj3, 19}"

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

// Convert the decimal argument; catch exceptions that are thrown.
let decimalToU_Int16 (argument: decimal) =
    let int16Value: obj =
        // Convert the argument to a int16 value.
        try
            int16 argument
        with ex -> getExceptionType ex

    let uint16Value: obj =
        // Convert the argument to a uint16 value.
        try
            uint16 argument
        with ex -> getExceptionType ex

    print argument int16Value uint16Value

printfn "This example of the explicit conversions from decimal to short\nand decimal to ushort generates the following output. It displays \nseveral converted decimal values.\n"
print "decimal argument" "short/exception" "ushort/exception"
print "----------------" "---------------" "----------------"

// Convert decimal values and display the results.
decimalToU_Int16 123M
decimalToU_Int16 (new decimal (123000, 0, 0, false, 3uy))
decimalToU_Int16 123.999M
decimalToU_Int16 65535.999M
decimalToU_Int16 65536M
decimalToU_Int16 32767.999M
decimalToU_Int16 32768M
decimalToU_Int16 -0.999M
decimalToU_Int16 -1M
decimalToU_Int16 -32768.999M
decimalToU_Int16 -32769M


// This example of the explicit conversions from decimal to short
// and decimal to ushort generates the following output. It displays
// several converted decimal values.
//
// decimal argument    short/exception   ushort/exception
// ----------------    ---------------   ----------------
//              123                123                123
//          123.000                123                123
//          123.999                123                123
//        65535.999  OverflowException              65535
//            65536  OverflowException  OverflowException
//        32767.999              32767              32767
//            32768  OverflowException              32768
//           -0.999                  0                  0
//               -1                 -1  OverflowException
//       -32768.999             -32768  OverflowException
//           -32769  OverflowException  OverflowException
//</Snippet3>