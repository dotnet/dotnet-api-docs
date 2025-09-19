module bytesint64

// <Snippet1>
open System

// Define a list of Int64 values.
let values = 
    [ 0L; 0xFFFFFFL; -0xFFFFFFL; 1000000000L; -1000000000L
      0x100000000L; -0x100000000L; 0xAAAAAAAAAAAAL
      -0xAAAAAAAAAAAAL; 1000000000000000000L
      -1000000000000000000L; Int64.MinValue; Int64.MaxValue ]

printfn "%22s%10s %30s" "Int64" "Endian" "Byte Array"
printfn "%22s%10s %30s" "----" "------" "----------"

for value in values do
    // Convert each Int64 value to a byte array.
    let byteArray = BitConverter.GetBytes value
    // Display the result.
    printfn $"""%22i{value}%10s{if BitConverter.IsLittleEndian then "Little" else "Big"} %30s{BitConverter.ToString byteArray}"""


// The example displays output like the following:
//                    Int64    Endian                     Byte Array
//                     ----    ------                     ----------
//                        0    Little       00-00-00-00-00-00-00-00
//                 16777215    Little       FF-FF-FF-00-00-00-00-00
//                -16777215    Little       01-00-00-FF-FF-FF-FF-FF
//               1000000000    Little       00-CA-9A-3B-00-00-00-00
//              -1000000000    Little       00-36-65-C4-FF-FF-FF-FF
//               4294967296    Little       00-00-00-00-01-00-00-00
//              -4294967296    Little       00-00-00-00-FF-FF-FF-FF
//          187649984473770    Little       AA-AA-AA-AA-AA-AA-00-00
//         -187649984473770    Little       56-55-55-55-55-55-FF-FF
//      1000000000000000000    Little       00-00-64-A7-B3-B6-E0-0D
//     -1000000000000000000    Little       00-00-9C-58-4C-49-1F-F2
//     -9223372036854775808    Little       00-00-00-00-00-00-00-80
//      9223372036854775807    Little       FF-FF-FF-FF-FF-FF-FF-7F
// </Snippet1>