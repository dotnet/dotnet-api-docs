module batouint64

//<Snippet3>
open System

let print obj1 obj2 obj3 = printfn $"{obj1,5}{obj2,27}{obj3,24}"

// Convert eight byte array elements to a ulong and display it.
let BAToUInt64 bytes index =
    let value = BitConverter.ToUInt64(bytes, index)

    print index (BitConverter.ToString(bytes, index, 8)) value

// Display a byte array, using multiple lines if necessary.
let writeMultiLineByteArray (bytes: byte []) =
    let rowSize = 20

    printfn "initial byte array"
    printfn "------------------"

    let mutable iter = 0
    for i in 0 .. rowSize .. bytes.Length - rowSize - 1 do
        printfn $"{BitConverter.ToString(bytes, i, rowSize)}-"
        iter <- i

    printfn $"{BitConverter.ToString(bytes, iter + rowSize)}\n"

let byteArray =
    [| 255uy; 255uy; 255uy; 0uy; 0uy; 0uy; 0uy; 0uy; 0uy; 0uy
       0uy; 1uy; 0uy; 0uy; 0uy; 100uy; 167uy; 179uy; 182uy; 224uy
       13uy; 0uy; 202uy; 154uy; 59uy; 0uy; 0uy; 0uy; 0uy; 170uy
       170uy; 170uy; 170uy; 170uy; 170uy; 0uy; 0uy; 232uy; 137uy; 4uy
       35uy; 199uy; 138uy; 255uy; 255uy; 255uy; 255uy; 255uy; 255uy; 255uy
       255uy; 127uy |]

printfn "This example of the BitConverter.ToUInt64(byte [], int) \nmethod generates the following output. It converts elements \nof a byte array to ulong values.\n"

writeMultiLineByteArray byteArray 

print "index" "array elements" "ulong"
print "-----" "--------------" "------"

// Convert byte array elements to ulong values.
BAToUInt64 byteArray 3
BAToUInt64 byteArray 0
BAToUInt64 byteArray 21
BAToUInt64 byteArray 7
BAToUInt64 byteArray 29
BAToUInt64 byteArray 13
BAToUInt64 byteArray 35
BAToUInt64 byteArray 44
BAToUInt64 byteArray 43


// This example of the BitConverter.ToUInt64( byte[ ], int )
// method generates the following output. It converts elements
// of a byte array to ulong values.
//
// initial byte array
// ------------------
// FF-FF-FF-00-00-00-00-00-00-00-00-01-00-00-00-64-A7-B3-B6-E0-
// 0D-00-CA-9A-3B-00-00-00-00-AA-AA-AA-AA-AA-AA-00-00-E8-89-04-
// 23-C7-8A-FF-FF-FF-FF-FF-FF-FF-FF-7F
//
// index             array elements                   ulong
// -----             --------------                  ------
//     3    00-00-00-00-00-00-00-00                       0
//     0    FF-FF-FF-00-00-00-00-00                16777215
//    21    00-CA-9A-3B-00-00-00-00              1000000000
//     7    00-00-00-00-01-00-00-00              4294967296
//    29    AA-AA-AA-AA-AA-AA-00-00         187649984473770
//    13    00-00-64-A7-B3-B6-E0-0D     1000000000000000000
//    35    00-00-E8-89-04-23-C7-8A    10000000000000000000
//    44    FF-FF-FF-FF-FF-FF-FF-7F     9223372036854775807
//    43    FF-FF-FF-FF-FF-FF-FF-FF    18446744073709551615
//</Snippet3>