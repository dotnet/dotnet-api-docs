module bytesuint32

//<Snippet2>
open System

let print obj1 obj2 = printfn $"{obj1,16}{obj2,20}"

// Convert a uint argument to a byte array and display it.
let getBytesUInt32 (argument: uint) =
    let byteArray = BitConverter.GetBytes argument
    
    BitConverter.ToString byteArray
    |> print argument

printfn "This example of the BitConverter.GetBytes(uint) \nmethod generates the following output.\n"
print "uint" "byte array"
print "----" "----------"

// Convert uint values and display the results.
getBytesUInt32 15u
getBytesUInt32 1023u
getBytesUInt32 0x100000u
getBytesUInt32 1000000000u
getBytesUInt32 UInt32.MinValue
getBytesUInt32 (uint Int32.MaxValue)
getBytesUInt32 UInt32.MaxValue


// This example of the BitConverter.GetBytes(uint)
// method generates the following output.
//
//             uint          byte array
//             ----          ----------
//               15         0F-00-00-00
//             1023         FF-03-00-00
//          1048576         00-00-10-00
//       1000000000         00-CA-9A-3B
//                0         00-00-00-00
//       2147483647         FF-FF-FF-7F
//       4294967295         FF-FF-FF-FF
//</Snippet2>