module batoint64

//<Snippet3>
open System

let print obj1 obj2 obj3 = printfn $"{obj1,5}{obj2,27}{obj3,24}"

// Convert eight byte array elements to a long and display it.
let BAToInt64 bytes index =
    let value = BitConverter.ToInt64(bytes, index)

    print index (BitConverter.ToString(bytes, index, 8)) value

// Display a byte array, using multiple lines if necessary.
let writeMultiLineByteArray (bytes: byte []) =
    let rowSize = 20

    printfn "initial byte array"
    printfn "------------------"

    let mutable iter = 0
    for i in 0 .. rowSize .. (bytes.Length - rowSize - 1) do
        printfn $"{BitConverter.ToString(bytes, i, rowSize)}-"
        iter <- i
    printfn $"{BitConverter.ToString(bytes, iter + rowSize)}"

let byteArray =
    [| 0uy; 54uy; 101uy; 196uy; 255uy; 255uy; 255uy; 255uy; 0uy; 0uy
       0uy; 0uy; 0uy; 0uy; 0uy; 0uy; 128uy; 0uy; 202uy; 154uy
       59uy; 0uy; 0uy; 0uy; 0uy; 1uy; 0uy; 0uy; 0uy; 0uy
       255uy; 255uy; 255uy; 255uy; 1uy; 0uy; 0uy; 255uy; 255uy; 255uy
       255uy; 255uy; 255uy; 255uy; 127uy; 86uy; 85uy; 85uy; 85uy; 85uy
       85uy; 255uy; 255uy; 170uy; 170uy; 170uy; 170uy; 170uy; 170uy; 0uy
       0uy; 100uy; 167uy; 179uy; 182uy; 224uy; 13uy; 0uy; 0uy; 156uy
       88uy; 76uy; 73uy; 31uy; 242uy |]

printfn "This example of the BitConverter.ToInt64(byte [], int) \nmethod generates the following output. It converts elements \nof a byte array to long values.\r\n"

writeMultiLineByteArray byteArray

print "index" "array elements" "long"
print "-----" "--------------" "----"

// Convert byte array elements to long values.
BAToInt64 byteArray 8
BAToInt64 byteArray 5
BAToInt64 byteArray 34
BAToInt64 byteArray 17
BAToInt64 byteArray 0
BAToInt64 byteArray 21
BAToInt64 byteArray 26
BAToInt64 byteArray 53
BAToInt64 byteArray 45
BAToInt64 byteArray 59
BAToInt64 byteArray 67
BAToInt64 byteArray 37
BAToInt64 byteArray 9


// This example of the BitConverter.ToInt64( byte[ ], int )
// method generates the following output. It converts elements
// of a byte array to long values.
//
// initial byte array
// ------------------
// 00-36-65-C4-FF-FF-FF-FF-00-00-00-00-00-00-00-00-80-00-CA-9A-
// 3B-00-00-00-00-01-00-00-00-00-FF-FF-FF-FF-01-00-00-FF-FF-FF-
// FF-FF-FF-FF-7F-56-55-55-55-55-55-FF-FF-AA-AA-AA-AA-AA-AA-00-
// 00-64-A7-B3-B6-E0-0D-00-00-9C-58-4C-49-1F-F2
//
// index             array elements                    long
// -----             --------------                    ----
//     8    00-00-00-00-00-00-00-00                       0
//     5    FF-FF-FF-00-00-00-00-00                16777215
//    34    01-00-00-FF-FF-FF-FF-FF               -16777215
//    17    00-CA-9A-3B-00-00-00-00              1000000000
//     0    00-36-65-C4-FF-FF-FF-FF             -1000000000
//    21    00-00-00-00-01-00-00-00              4294967296
//    26    00-00-00-00-FF-FF-FF-FF             -4294967296
//    53    AA-AA-AA-AA-AA-AA-00-00         187649984473770
//    45    56-55-55-55-55-55-FF-FF        -187649984473770
//    59    00-00-64-A7-B3-B6-E0-0D     1000000000000000000
//    67    00-00-9C-58-4C-49-1F-F2    -1000000000000000000
//    37    FF-FF-FF-FF-FF-FF-FF-7F     9223372036854775807
//     9    00-00-00-00-00-00-00-80    -9223372036854775808
//</Snippet3>