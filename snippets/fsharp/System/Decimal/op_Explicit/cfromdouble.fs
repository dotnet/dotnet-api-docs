module cfromdouble

//<Snippet2>
// Example of the explicit conversion from double to decimal.
let print obj1 obj2 = printfn $"{obj1,25:E16}{obj2,33}"

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

// Convert the double argument; catch exceptions that are thrown.
let decimalFromDouble (argument: double) =
    // Convert the double argument to a decimal value.
    try
        decimal argument
        |> print argument
    with ex ->
        getExceptionType ex
        |> print argument


printfn "This example of the explicit conversion from double to decimal \ngenerates the following output.\n"
print "double argument" "decimal value"
print "---------------" "-------------"

// Convert double values and display the results.
decimalFromDouble 1.234567890123E-30
decimalFromDouble 1.2345678901234E-25
decimalFromDouble 1.23456789012345E-20
decimalFromDouble 1.234567890123456E-10
decimalFromDouble 1.2345678901234567
decimalFromDouble 1.23456789012345678E+12
decimalFromDouble 1.234567890123456789E+28
decimalFromDouble 1.234567890123456789E+30


// This example of the explicit conversion from double to decimal
// generates the following output.

//           double argument                    decimal value
//           ---------------                    -------------
//   1.2345678901230000E-030                                0
//   1.2345678901233999E-025   0.0000000000000000000000001235
//   1.2345678901234499E-020   0.0000000000000000000123456789
//   1.2345678901234560E-010       0.000000000123456789012346
//   1.2345678901234567E+000                 1.23456789012346
//   1.2345678901234568E+012                 1234567890123.46
//   1.2345678901234568E+028    12345678901234600000000000000
//   1.2345678901234569E+030                OverflowException
//</Snippet2> 