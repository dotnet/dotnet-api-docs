module bitstodbl

//<Snippet1>
open System

let print obj1 obj2 = 
    printfn $"{obj1,20}{obj2,27:E16}"

// Reinterpret the long argument as a double.
let longBitsToDouble argument =
    let doubleValue = BitConverter.Int64BitsToDouble argument

    // Display the argument in hexadecimal.
    print (String.Format("0x{0:X16}", argument)) doubleValue

printfn "This example of the BitConverter.Int64BitsToDouble(Int64) \nmethod generates the following output.\n"
print "long argument" "double value"
print "-------------" "------------"

// Convert long values and display the results.
longBitsToDouble 0
longBitsToDouble 0x3FF0000000000000L
longBitsToDouble 0x402E000000000000L
longBitsToDouble 0x406FE00000000000L
longBitsToDouble 0x41EFFFFFFFE00000L
longBitsToDouble 0x3F70000000000000L
longBitsToDouble 0x3DF0000000000000L
longBitsToDouble 0x0000000000000001L
longBitsToDouble 0x000000000000FFFFL
longBitsToDouble 0x0000FFFFFFFFFFFFL
longBitsToDouble 0xFFFFFFFFFFFFFFFFL
longBitsToDouble 0xFFF0000000000000L
longBitsToDouble 0x7FF0000000000000L
longBitsToDouble 0xFFEFFFFFFFFFFFFFL
longBitsToDouble 0x7FEFFFFFFFFFFFFFL
longBitsToDouble Int64.MinValue
longBitsToDouble Int64.MaxValue


// This example of the BitConverter.Int64BitsToDouble( long )
// method generates the following output.

//        long argument               double value
//        -------------               ------------
//   0x0000000000000000    0.0000000000000000E+000
//   0x3FF0000000000000    1.0000000000000000E+000
//   0x402E000000000000    1.5000000000000000E+001
//   0x406FE00000000000    2.5500000000000000E+002
//   0x41EFFFFFFFE00000    4.2949672950000000E+009
//   0x3F70000000000000    3.9062500000000000E-003
//   0x3DF0000000000000    2.3283064365386963E-010
//   0x0000000000000001    4.9406564584124654E-324
//   0x000000000000FFFF    3.2378592100206092E-319
//   0x0000FFFFFFFFFFFF    1.3906711615669959E-309
//   0xFFFFFFFFFFFFFFFF                        NaN
//   0xFFF0000000000000                         -∞
//   0x7FF0000000000000                          ∞
//   0xFFEFFFFFFFFFFFFF   -1.7976931348623157E+308
//   0x7FEFFFFFFFFFFFFF    1.7976931348623157E+308
//   0x8000000000000000    0.0000000000000000E+000
//   0x7FFFFFFFFFFFFFFF                        NaN
//</Snippet1>
