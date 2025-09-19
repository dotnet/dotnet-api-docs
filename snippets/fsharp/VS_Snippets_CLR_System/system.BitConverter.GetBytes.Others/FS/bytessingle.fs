module bytessingle

//<Snippet3>
open System

let print obj1 obj2 = printfn $"{obj1,16:E7}{obj2,20}"

// Convert a float argument to a byte array and display it.
let getBytesSingle (argument: float32) =
    let byteArray = BitConverter.GetBytes argument
    
    BitConverter.ToString byteArray
    |> print argument

printfn "This example of the BitConverter.GetBytes(float32) \nmethod generates the following output.\n"
print "float32" "byte array"
print "-----" "----------"

// Convert float values and display the results.
getBytesSingle 0.0F
getBytesSingle 1.0F
getBytesSingle 15.0F
getBytesSingle 65535.0F
getBytesSingle 0.00390625F
getBytesSingle 0.00000000023283064365386962890625F
getBytesSingle 1.2345E-35F
getBytesSingle 1.2345671F
getBytesSingle 1.2345673F
getBytesSingle 1.2345677F
getBytesSingle 1.23456789E+35F
getBytesSingle Single.MinValue
getBytesSingle Single.MaxValue
getBytesSingle Single.Epsilon
getBytesSingle Single.NaN
getBytesSingle Single.NegativeInfinity
getBytesSingle Single.PositiveInfinity


// This example of the BitConverter.GetBytes(float32)
// method generates the following output.
//
//          float32          byte array
//            -----          ----------
//   0.0000000E+000         00-00-00-00
//   1.0000000E+000         00-00-80-3F
//   1.5000000E+001         00-00-70-41
//   6.5535000E+004         00-FF-7F-47
//   3.9062500E-003         00-00-80-3B
//   2.3283064E-010         00-00-80-2F
//   1.2345000E-035         49-46-83-05
//   1.2345671E+000         4B-06-9E-3F
//   1.2345673E+000         4D-06-9E-3F
//   1.2345676E+000         50-06-9E-3F
//   1.2345679E+035         1E-37-BE-79
//  -3.4028235E+038         FF-FF-7F-FF
//   3.4028235E+038         FF-FF-7F-7F
//   1.4012985E-045         01-00-00-00
//              NaN         00-00-C0-FF
//        -Infinity         00-00-80-FF
//         Infinity         00-00-80-7F
//</Snippet3>
