module dbltobits

//<Snippet2>
open System

let print obj1 obj2 = 
    printfn $"{obj1,25:E16}{obj2,23:X16}"

// Reinterpret the double argument as a long.
let doubleToLongBits argument =
    let longValue = BitConverter.DoubleToInt64Bits argument

    // Display the resulting long in hexadecimal.
    print argument longValue

printfn "This example of the BitConverter.DoubleToInt64Bits(Double) \nmethod generates the following output.\n"
print "double argument" "hexadecimal value"
print "---------------" "-----------------"

// Convert double values and display the results.
doubleToLongBits 1.0
doubleToLongBits 15.0
doubleToLongBits 255.0
doubleToLongBits 4294967295.0
doubleToLongBits 0.00390625
doubleToLongBits 0.00000000023283064365386962890625
doubleToLongBits 1.234567890123E-300
doubleToLongBits 1.23456789012345E-150
doubleToLongBits 1.2345678901234565
doubleToLongBits 1.2345678901234567
doubleToLongBits 1.2345678901234569
doubleToLongBits 1.23456789012345678E+150
doubleToLongBits 1.234567890123456789E+300
doubleToLongBits Double.MinValue
doubleToLongBits Double.MaxValue
doubleToLongBits Double.Epsilon
doubleToLongBits Double.NaN
doubleToLongBits Double.NegativeInfinity
doubleToLongBits Double.PositiveInfinity


// This example of the BitConverter.DoubleToInt64Bits( double )
// method generates the following output.

//           double argument      hexadecimal value
//           ---------------      -----------------
//   1.0000000000000000E+000       3FF0000000000000
//   1.5000000000000000E+001       402E000000000000
//   2.5500000000000000E+002       406FE00000000000
//   4.2949672950000000E+009       41EFFFFFFFE00000
//   3.9062500000000000E-003       3F70000000000000
//   2.3283064365386963E-010       3DF0000000000000
//   1.2345678901230000E-300       01AA74FE1C1E7E45
//   1.2345678901234500E-150       20D02A36586DB4BB
//   1.2345678901234565E+000       3FF3C0CA428C59FA
//   1.2345678901234567E+000       3FF3C0CA428C59FB
//   1.2345678901234569E+000       3FF3C0CA428C59FC
//   1.2345678901234569E+150       5F182344CD3CDF9F
//   1.2345678901234569E+300       7E3D7EE8BCBBD352
//  -1.7976931348623157E+308       FFEFFFFFFFFFFFFF
//   1.7976931348623157E+308       7FEFFFFFFFFFFFFF
//   4.9406564584124654E-324       0000000000000001
//                       NaN       FFF8000000000000
//                        -∞       FFF0000000000000
//                         ∞       7FF0000000000000
//</Snippet2>