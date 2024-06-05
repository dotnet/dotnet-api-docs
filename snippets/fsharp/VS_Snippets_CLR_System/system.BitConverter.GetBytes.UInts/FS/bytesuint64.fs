module bytesuint64

//<Snippet1>
open System

let print obj1 obj2 = printfn $"{obj1,22}{obj2,30}";

// Convert a ulong argument to a byte array and display it.
let getBytesUInt64 (argument: uint64) =
    let byteArray = BitConverter.GetBytes argument
    
    BitConverter.ToString byteArray
    |> print argument

printfn "This example of the BitConverter.GetBytes(uint64) \nmethod generates the following output.\n"
print "ulong" "byte array"
print "-----" "----------"

// Convert ulong values and display the results.
getBytesUInt64 0xFFFFFFuL
getBytesUInt64 1000000000uL
getBytesUInt64 0x100000000uL
getBytesUInt64 0xAAAAAAAAAAAAuL
getBytesUInt64 1000000000000000000uL
getBytesUInt64 10000000000000000000uL
getBytesUInt64 UInt64.MinValue
getBytesUInt64 (uint64 Int64.MaxValue)
getBytesUInt64 UInt64.MaxValue


// This example of the BitConverter.GetBytes( ulong )
// method generates the following output.
//
//                  ulong                    byte array
//                  -----                    ----------
//               16777215       FF-FF-FF-00-00-00-00-00
//             1000000000       00-CA-9A-3B-00-00-00-00
//             4294967296       00-00-00-00-01-00-00-00
//        187649984473770       AA-AA-AA-AA-AA-AA-00-00
//    1000000000000000000       00-00-64-A7-B3-B6-E0-0D
//   10000000000000000000       00-00-E8-89-04-23-C7-8A
//                      0       00-00-00-00-00-00-00-00
//    9223372036854775807       FF-FF-FF-FF-FF-FF-FF-7F
//   18446744073709551615       FF-FF-FF-FF-FF-FF-FF-FF
//</Snippet1>