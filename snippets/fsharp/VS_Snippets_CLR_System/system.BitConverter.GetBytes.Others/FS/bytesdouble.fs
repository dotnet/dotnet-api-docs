module bytesdouble

//<Snippet4>
open System

let print obj1 obj2 = printfn $"{obj1,25:E16}{obj2,30}"

// Convert a double argument to a byte array and display it.
let getBytesDouble (argument: float) =
    let byteArray = BitConverter.GetBytes argument
    
    BitConverter.ToString byteArray
    |> print argument

printfn "This example of the BitConverter.GetBytes(double) \nmethod generates the following output.\n"
print "double" "byte array"
print "------" "----------"

// Convert double values and display the results.
getBytesDouble 0.0
getBytesDouble 1.0
getBytesDouble 255.0
getBytesDouble 4294967295.0
getBytesDouble 0.00390625
getBytesDouble 0.00000000023283064365386962890625
getBytesDouble 1.23456789012345E-300
getBytesDouble 1.2345678901234565
getBytesDouble 1.2345678901234567
getBytesDouble 1.2345678901234569
getBytesDouble 1.23456789012345678E+300
getBytesDouble Double.MinValue
getBytesDouble Double.MaxValue
getBytesDouble Double.Epsilon
getBytesDouble Double.NaN
getBytesDouble Double.NegativeInfinity
getBytesDouble Double.PositiveInfinity


// This example of the BitConverter.GetBytes(double)
// method generates the following output.
//
//                    double                    byte array
//                    ------                    ----------
//   0.0000000000000000E+000       00-00-00-00-00-00-00-00
//   1.0000000000000000E+000       00-00-00-00-00-00-F0-3F
//   2.5500000000000000E+002       00-00-00-00-00-E0-6F-40
//   4.2949672950000000E+009       00-00-E0-FF-FF-FF-EF-41
//   3.9062500000000000E-003       00-00-00-00-00-00-70-3F
//   2.3283064365386963E-010       00-00-00-00-00-00-F0-3D
//   1.2345678901234500E-300       DF-88-1E-1C-FE-74-AA-01
//   1.2345678901234565E+000       FA-59-8C-42-CA-C0-F3-3F
//   1.2345678901234567E+000       FB-59-8C-42-CA-C0-F3-3F
//   1.2345678901234569E+000       FC-59-8C-42-CA-C0-F3-3F
//   1.2345678901234569E+300       52-D3-BB-BC-E8-7E-3D-7E
//  -1.7976931348623157E+308       FF-FF-FF-FF-FF-FF-EF-FF
//   1.7976931348623157E+308       FF-FF-FF-FF-FF-FF-EF-7F
//   4.9406564584124654E-324       01-00-00-00-00-00-00-00
//                       NaN       00-00-00-00-00-00-F8-FF
//                 -Infinity       00-00-00-00-00-00-F0-FF
//                  Infinity       00-00-00-00-00-00-F0-7F
//</Snippet4>