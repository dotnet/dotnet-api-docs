module bytesuint16

//<Snippet3>
open System

let print obj1 obj2 = printfn $"{obj1,10}{obj2,13}"

// Convert a ushort argument to a byte array and display it.
let getBytesUInt16 (argument: uint16) =
    let byteArray = BitConverter.GetBytes argument
    
    BitConverter.ToString byteArray
    |> print argument

printfn "This example of the BitConverter.GetBytes(uint16) \nmethod generates the following output.\n"
print "ushort" "byte array"
print "------" "----------"

// Convert ushort values and display the results.
getBytesUInt16 15us
getBytesUInt16 1023us
getBytesUInt16 10000us
getBytesUInt16 UInt16.MinValue
getBytesUInt16 (uint16 Int16.MaxValue)
getBytesUInt16 UInt16.MaxValue


// This example of the BitConverter.GetBytes(uint16)
// method generates the following output.
//
//     ushort   byte array
//     ------   ----------
//         15        0F-00
//       1023        FF-03
//      10000        10-27
//          0        00-00
//      32767        FF-7F
//      65535        FF-FF
//</Snippet3>