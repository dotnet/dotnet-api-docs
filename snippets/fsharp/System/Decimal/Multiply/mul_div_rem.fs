//<Snippet1>
// Example of the Decimal.Multiply, Decimal.Divide, and
// Decimal.Remainder methods.
open System

let dataFmt obj1 obj2 = printfn $"{obj1,-35}{obj2,31}"

// Display decimal parameters and their product, quotient, and remainder.
let showDecimalProQuoRem left right =
    printfn ""
    dataFmt "decimal left" left
    dataFmt "decimal right" right
    dataFmt "Decimal.Multiply( left, right )" (Decimal.Multiply(left, right))
    dataFmt "Decimal.Divide( left, right )" (Decimal.Divide(left, right))
    dataFmt "Decimal.Remainder( left, right )" (Decimal.Remainder(left, right))

printfn 
    """This example of the
  Decimal.Multiply( decimal, decimal ),
  Decimal.Divide( decimal, decimal ), and
  Decimal.Remainder( decimal, decimal )
methods generates the following output. It displays
the product, \nquotient, and remainder of several
pairs of decimal objects."""

// Create pairs of decimal objects.
showDecimalProQuoRem 1000M 7M
showDecimalProQuoRem -1000M 7M
showDecimalProQuoRem (Decimal(1230000000, 0, 0, false, 7uy)) 0.0012300M
showDecimalProQuoRem 12345678900000000M 0.0000000012345678M
showDecimalProQuoRem 123456789.0123456789M 123456789.1123456789M


// This example of the
//   Decimal.Multiply( decimal, decimal ),
//   Decimal.Divide( decimal, decimal ), and
//   Decimal.Remainder( decimal, decimal )
// methods generates the following output. It displays
// the product, \nquotient, and remainder of several  
// pairs of decimal objects.
//
// decimal left                                                  1000
// decimal right                                                    7
// Decimal.Multiply( left, right )                               7000
// Decimal.Divide( left, right )       142.85714285714285714285714286
// Decimal.Remainder( left, right )                                 6
//
// decimal left                                                 -1000
// decimal right                                                    7
// Decimal.Multiply( left, right )                              -7000
// Decimal.Divide( left, right )      -142.85714285714285714285714286
// Decimal.Remainder( left, right )                                -6
//
// decimal left                                           123.0000000
// decimal right                                            0.0012300
// Decimal.Multiply( left, right )                   0.15129000000000
// Decimal.Divide( left, right )                               100000
// Decimal.Remainder( left, right )                         0.0000000
//
// decimal left                                     12345678900000000
// decimal right                                   0.0000000012345678
// Decimal.Multiply( left, right )          15241577.6390794200000000
// Decimal.Divide( left, right )       10000000729000059778004901.796
// Decimal.Remainder( left, right )                0.0000000009832122
//
// decimal left                                  123456789.0123456789
// decimal right                                 123456789.1123456789
// Decimal.Multiply( left, right )     15241578765584515.651425087878
// Decimal.Divide( left, right )       0.9999999991899999933660999449
// Decimal.Remainder( left, right )              123456789.0123456789
//</Snippet1> 