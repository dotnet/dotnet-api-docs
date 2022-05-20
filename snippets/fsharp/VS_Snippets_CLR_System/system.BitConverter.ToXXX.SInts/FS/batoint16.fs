module batoint16

//<Snippet1>
open System

let print obj1 obj2 obj3 = printfn $"{obj1,5}{obj2,17}{obj3,10}"

// Convert two byte array elements to a short and display it.
let BAToInt16 bytes index =
    let value = BitConverter.ToInt16(bytes, index)

    print index (BitConverter.ToString(bytes, index, 2)) value

let byteArray =
    [| 15uy; 0uy; 0uy; 128uy; 16uy; 39uy; 240uy; 216uy; 241uy; 255uy; 127uy |]

printfn "This example of the BitConverter.ToInt16(byte [], int) \nmethod generates the following output. It converts elements \nof a byte array to short values.\n"
printfn "initial byte array"
printfn "------------------"
printfn $"{BitConverter.ToString byteArray}\n"
print "index" "array elements" "short"
print "-----" "--------------" "-----"

// Convert byte array elements to short values.
BAToInt16 byteArray 1
BAToInt16 byteArray 0
BAToInt16 byteArray 8
BAToInt16 byteArray 4
BAToInt16 byteArray 6
BAToInt16 byteArray 9
BAToInt16 byteArray 2


// This example of the BitConverter.ToInt16(byte [], int )
// method generates the following output. It converts elements
// of a byte array to short values.

// initial byte array
// ------------------
// 0F-00-00-80-10-27-F0-D8-F1-FF-7F

// index   array elements     short
// -----   --------------     -----
//     1            00-00         0
//     0            0F-00        15
//     8            F1-FF       -15
//     4            10-27     10000
//     6            F0-D8    -10000
//     9            FF-7F     32767
//     2            00-80    -32768
//</Snippet1>
