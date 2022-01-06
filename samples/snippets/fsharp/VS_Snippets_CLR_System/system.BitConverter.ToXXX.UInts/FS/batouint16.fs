module batouint16

//<Snippet1>
open System

let print obj1 obj2 obj3 = printfn $"{obj1,5}{obj2,17}{obj3,10}"

// Convert two byte array elements to a ushort and display it.
let BAToUInt16 bytes index =
    let value = BitConverter.ToUInt16(bytes, index)

    print index (BitConverter.ToString(bytes, index, 2)) value

let byteArray =
    [| 15uy; 0uy; 0uy; 255uy; 3uy; 16uy; 39uy; 255uy; 255uy; 127uy |]

printfn "This example of the BitConverter.ToUInt16(byte [], int) \nmethod generates the following output. It converts elements \nof a byte array to ushort values.\n"
printfn "initial byte array"
printfn "------------------"
printfn $"{BitConverter.ToString byteArray}\n"
print "index" "array elements" "ushort"
print "-----" "--------------" "------"

// Convert byte array elements to ushort values.
BAToUInt16 byteArray 1
BAToUInt16 byteArray 0
BAToUInt16 byteArray 3
BAToUInt16 byteArray 5
BAToUInt16 byteArray 8
BAToUInt16 byteArray 7


// This example of the BitConverter.ToUInt16(byte [], int)
// method generates the following output. It converts elements
// of a byte array to ushort values.
//
// initial byte array
// ------------------
// 0F-00-00-FF-03-10-27-FF-FF-7F
//
// index   array elements    ushort
// -----   --------------    ------
//     1            00-00         0
//     0            0F-00        15
//     3            FF-03      1023
//     5            10-27     10000
//     8            FF-7F     32767
//     7            FF-FF     65535
//</Snippet1>