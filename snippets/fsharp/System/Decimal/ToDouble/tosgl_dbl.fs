//<Snippet5>
// Example of the Decimal.ToSingle and Decimal.ToDouble methods.
open System

let formatter obj1 obj2 obj3 = printfn $"{obj1,30}{obj2,17}{obj3,23}"

// Convert the decimal argument no exceptions are thrown.
let decimalToSgl_Dbl argument =
    // Convert the argument to a float value.
    let singleValue = Decimal.ToSingle argument

    // Convert the argument to a double value.
    let doubleValue = Decimal.ToDouble argument

    formatter argument singleValue doubleValue

printfn
    """This example of the
  Decimal.ToSingle( decimal ) and
  Decimal.ToDouble( decimal )
methods generates the following output. It
displays several converted decimal values.
"""

formatter "decimal argument" "float" "double"
formatter "----------------" "-----" "------"

// Convert decimal values and display the results.
decimalToSgl_Dbl 0.0000000000000000000000000001M
decimalToSgl_Dbl 0.0000000000123456789123456789M
decimalToSgl_Dbl 123M
decimalToSgl_Dbl (Decimal(123000000, 0, 0, false, 6uy))
decimalToSgl_Dbl 123456789.123456789M
decimalToSgl_Dbl 123456789123456789123456789M
decimalToSgl_Dbl Decimal.MinValue
decimalToSgl_Dbl Decimal.MaxValue


// This example of the
//   Decimal.ToSingle( decimal ) and
//   Decimal.ToDouble( decimal )
// methods generates the following output. It
// displays several converted decimal values.
//
//               decimal argument            float                 double
//               ----------------            -----                 ------
// 0.0000000000000000000000000001            1E-28                  1E-28
// 0.0000000000123456789123456789     1.234568E-11   1.23456789123457E-11
//                            123              123                    123
//                     123.000000              123                    123
//            123456789.123456789     1.234568E+08       123456789.123457
//    123456789123456789123456789     1.234568E+26   1.23456789123457E+26
// -79228162514264337593543950335    -7.922816E+28  -7.92281625142643E+28
//  79228162514264337593543950335     7.922816E+28   7.92281625142643E+28
//</Snippet5> 