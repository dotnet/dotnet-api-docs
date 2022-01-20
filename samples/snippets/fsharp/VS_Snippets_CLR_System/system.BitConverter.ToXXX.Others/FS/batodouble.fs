module batodouble

//<Snippet3>
open System

let print obj1 obj2 obj3 = printfn $"{obj1,5}{obj2,27}{obj3,27:E16}"

// Convert eight byte array elements to a double and display it.
let BAToDouble bytes index =
    let value = BitConverter.ToDouble(bytes, index)

    print index (BitConverter.ToString(bytes, index, 8)) value

// Display a byte array, using multiple lines if necessary.
let writeMultiLineByteArray (bytes: byte []) =
    let rowSize = 20

    printfn "initial byte array"
    printfn "------------------"

    let mutable iter = 0
    for i in 0 .. rowSize .. (bytes.Length - rowSize - 1) do
        printfn $"{BitConverter.ToString(bytes, iter, rowSize)}-"
        iter <- i

    printfn $"{BitConverter.ToString(bytes, iter + rowSize)}\n"

let byteArray =
    [| 0uy; 0uy; 0uy; 0uy; 0uy; 0uy; 0uy; 0uy; 240uy; 63uy
       0uy; 0uy; 0uy; 0uy; 0uy; 224uy; 111uy; 64uy; 0uy; 0uy;
       224uy; 255uy; 255uy; 255uy; 239uy; 65uy; 0uy; 0uy; 0uy; 0uy
       0uy; 0uy; 112uy; 63uy; 0uy; 0uy; 0uy; 0uy; 0uy; 0uy
       240uy; 61uy; 223uy; 136uy; 30uy; 28uy; 254uy; 116uy; 170uy; 1uy
       250uy; 89uy; 140uy; 66uy; 202uy; 192uy; 243uy; 63uy; 251uy; 89uy
       140uy; 66uy; 202uy; 192uy; 243uy; 63uy; 252uy; 89uy; 140uy; 66uy
       202uy; 192uy; 243uy; 63uy; 82uy; 211uy; 187uy; 188uy; 232uy; 126uy
       61uy; 126uy; 255uy; 255uy; 255uy; 255uy; 255uy; 255uy; 239uy; 255uy
       255uy; 255uy; 255uy; 255uy; 255uy; 239uy; 127uy; 1uy; 0uy; 0uy
       0uy; 0uy; 0uy; 0uy; 0uy; 248uy; 255uy; 0uy; 0uy; 0uy
       0uy; 0uy; 0uy; 240uy; 255uy; 0uy; 0uy; 0uy; 0uy; 0uy
       0uy; 240uy; 127uy |]

printfn "This example of the BitConverter.ToDouble(byte [], int) \nmethod generates the following output. It converts elements \nof a byte array to double values.\n"

writeMultiLineByteArray byteArray

print "index" "array elements" "double"
print "-----" "--------------" "------"

// Convert byte array elements to double values.
BAToDouble byteArray 0
BAToDouble byteArray 2
BAToDouble byteArray 10
BAToDouble byteArray 18
BAToDouble byteArray 26
BAToDouble byteArray 34
BAToDouble byteArray 42
BAToDouble byteArray 50
BAToDouble byteArray 58
BAToDouble byteArray 66
BAToDouble byteArray 74
BAToDouble byteArray 82
BAToDouble byteArray 89
BAToDouble byteArray 97
BAToDouble byteArray 99
BAToDouble byteArray 107
BAToDouble byteArray 115


// This example of the BitConverter.ToDouble(byte [], int )
// method generates the following output. It converts elements
// of a byte array to double values.

// initial byte array
// ------------------
// 00-00-00-00-00-00-00-00-F0-3F-00-00-00-00-00-E0-6F-40-00-00-
// 00-00-00-00-00-00-00-00-F0-3F-00-00-00-00-00-E0-6F-40-00-00-
// E0-FF-FF-FF-EF-41-00-00-00-00-00-00-70-3F-00-00-00-00-00-00-
// F0-3D-DF-88-1E-1C-FE-74-AA-01-FA-59-8C-42-CA-C0-F3-3F-FB-59-
// 8C-42-CA-C0-F3-3F-FC-59-8C-42-CA-C0-F3-3F-52-D3-BB-BC-E8-7E-
// 3D-7E-FF-FF-FF-FF-FF-FF-EF-FF-FF-FF-FF-FF-FF-EF-7F-01-00-00-
// 00-F0-7F
//
// index             array elements                     double
// -----             --------------                     ------
//     0    00-00-00-00-00-00-00-00    0.0000000000000000E+000
//     2    00-00-00-00-00-00-F0-3F    1.0000000000000000E+000
//    10    00-00-00-00-00-E0-6F-40    2.5500000000000000E+002
//    18    00-00-E0-FF-FF-FF-EF-41    4.2949672950000000E+009
//    26    00-00-00-00-00-00-70-3F    3.9062500000000000E-003
//    34    00-00-00-00-00-00-F0-3D    2.3283064365386963E-010
//    42    DF-88-1E-1C-FE-74-AA-01    1.2345678901234500E-300
//    50    FA-59-8C-42-CA-C0-F3-3F    1.2345678901234565E+000
//    58    FB-59-8C-42-CA-C0-F3-3F    1.2345678901234567E+000
//    66    FC-59-8C-42-CA-C0-F3-3F    1.2345678901234569E+000
//    74    52-D3-BB-BC-E8-7E-3D-7E    1.2345678901234569E+300
//    82    FF-FF-FF-FF-FF-FF-EF-FF   -1.7976931348623157E+308
//    89    FF-FF-FF-FF-FF-FF-EF-7F    1.7976931348623157E+308
//    97    01-00-00-00-00-00-00-00    4.9406564584124654E-324
//    99    00-00-00-00-00-00-F8-FF                        NaN
//   107    00-00-00-00-00-00-F0-FF                         -∞
//   115    00-00-00-00-00-00-F0-7F                          ∞
//</Snippet3>