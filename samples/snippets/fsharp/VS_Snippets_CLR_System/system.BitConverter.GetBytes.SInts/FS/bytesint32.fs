module bytesint32

//<Snippet2>
open System

// Define a list of integers.
let values = 
    [ 0; 15; -15; 0x100000;  -0x100000; 1000000000
      -1000000000; Int32.MinValue; Int32.MaxValue ]

// Convert each integer to a byte array.
printfn "%16s%10s%17s" "Integer" "Endian" "Byte Array"
printfn "%16s%10s%17s" "---" "------" "----------"
for value in values do
    let byteArray = BitConverter.GetBytes value
    printfn $"""%16i{value}%10s{if BitConverter.IsLittleEndian then "Little" else " Big"}%17s{BitConverter.ToString byteArray}"""

// This example displays output like the following:
//              Integer    Endian       Byte Array
//                  ---    ------       ----------
//                    0    Little      00-00-00-00
//                   15    Little      0F-00-00-00
//                  -15    Little      F1-FF-FF-FF
//              1048576    Little      00-00-10-00
//             -1048576    Little      00-00-F0-FF
//           1000000000    Little      00-CA-9A-3B
//          -1000000000    Little      00-36-65-C4
//          -2147483648    Little      00-00-00-80
//           2147483647    Little      FF-FF-FF-7F
//</Snippet2>