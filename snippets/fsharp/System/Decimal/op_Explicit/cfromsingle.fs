module cfromsingle

//<Snippet3>
// Example of the explicit conversion from float to decimal.
let print obj1 obj2 = printfn $"{obj1,16:E7}{obj2,33}"

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

// Convert the float argument; catch exceptions that are thrown.
let decimalFromSingle (argument: float32) =
    // Convert the float argument to a decimal value.
    try
        decimal argument
        |> print argument
    with ex ->
        getExceptionType ex
        |> print argument

printfn "This example of the explicit conversion from float to decimal \ngenerates the following output.\n"
print "float argument" "decimal value"
print "--------------" "-------------"

// Convert float values and display the results.
decimalFromSingle 1.2345E-30f
decimalFromSingle 1.2345E-26f
decimalFromSingle 1.23456E-22f
decimalFromSingle 1.23456E-12f
decimalFromSingle 1.234567f
decimalFromSingle 1.234567E+12f
decimalFromSingle 1.2345678E+28f
decimalFromSingle 1.2345678E+30f


// This example of the explicit conversion from float to decimal
// generates the following output.
//
//   float argument                    decimal value
//   --------------                    -------------
//   1.2345000E-030                                0
//   1.2345000E-026   0.0000000000000000000000000123
//   1.2345600E-022    0.000000000000000000000123456
//   1.2345600E-012              0.00000000000123456
//   1.2345671E+000                         1.234567
//   1.2345670E+012                    1234567000000
//   1.2345678E+028    12345680000000000000000000000
//   1.2345678E+030                OverflowException
//</Snippet3> 