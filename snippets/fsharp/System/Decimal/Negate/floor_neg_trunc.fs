//<Snippet1>
// Example of the decimal.Negate, decimal.Floor, and decimal.Truncate
// methods.
open System

let dataFmt obj1 obj2 = printfn $"{obj1,-30}{obj2,26}"

// Display decimal parameters and the method results.
let showDecimalFloorNegTrunc (argument: decimal) =
    printfn ""
    dataFmt "decimal argument" argument
    dataFmt "Decimal.Negate( argument )" (Decimal.Negate argument)
    dataFmt "decimal.Floor( argument )" (Decimal.Floor argument)
    dataFmt "decimal.Truncate( argument )" (Decimal.Truncate argument)

printfn 
    """This example of the
  decimal.Negate( decimal ),
  decimal.Floor( decimal ), and
  decimal.Truncate( decimal )
methods generates the following output."""

// Create pairs of decimal objects.
showDecimalFloorNegTrunc 0M
showDecimalFloorNegTrunc 123.456M
showDecimalFloorNegTrunc -123.456M
showDecimalFloorNegTrunc (Decimal(1230000000, 0, 0, true, 7uy))
showDecimalFloorNegTrunc -9999999999.9999999999M


// This example of the
//   decimal.Negate( decimal ),
//   decimal.Floor( decimal ), and        
//   decimal.Truncate( decimal )
// methods generates the following output.
//
// decimal argument                                       0
// Decimal.Negate( argument )                             0
// decimal.Floor( argument )                              0
// decimal.Truncate( argument )                           0
//
// decimal argument                                 123.456
// Decimal.Negate( argument )                      -123.456
// decimal.Floor( argument )                            123
// decimal.Truncate( argument )                         123
//
// decimal argument                                -123.456
// Decimal.Negate( argument )                       123.456
// decimal.Floor( argument )                           -124
// decimal.Truncate( argument )                        -123
//
// decimal argument                            -123.0000000
// Decimal.Negate( argument )                   123.0000000
// decimal.Floor( argument )                           -123
// decimal.Truncate( argument )                        -123
//
// decimal argument                  -9999999999.9999999999
// Decimal.Negate( argument )         9999999999.9999999999
// decimal.Floor( argument )                   -10000000000
// decimal.Truncate( argument )                 -9999999999
//</Snippet1> 