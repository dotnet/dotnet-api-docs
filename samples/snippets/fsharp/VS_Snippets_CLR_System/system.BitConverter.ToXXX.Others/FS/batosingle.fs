module batosingle

//<Snippet4>
open System

let print obj1 obj2 obj3 = printfn $"{obj1,5}{obj2,17}{obj3,18:E7}"

// Convert four byte array elements to a float and display it.
let BAToSingle bytes index =
    let value = BitConverter.ToSingle(bytes, index)

    print index (BitConverter.ToString(bytes, index, 4)) value

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
    [| 0uy; 0uy; 0uy; 0uy; 128uy; 63uy; 0uy; 0uy; 112uy; 65uy
       0uy; 255uy; 127uy; 71uy; 0uy; 0uy; 128uy; 59uy; 0uy; 0uy
       128uy; 47uy; 73uy; 70uy; 131uy; 5uy; 75uy; 6uy; 158uy; 63uy
       77uy; 6uy; 158uy; 63uy; 80uy; 6uy; 158uy; 63uy; 30uy; 55uy
       190uy; 121uy; 255uy; 255uy; 127uy; 255uy; 255uy; 127uy; 127uy; 1uy
       0uy; 0uy; 0uy; 192uy; 255uy; 0uy; 0uy; 128uy; 255uy; 0uy
       0uy; 128uy; 127uy |]

printfn "This example of the BitConverter.ToSingle(byte [], int) \nmethod generates the following output. It converts elements \nof a byte array to float values.\n"

writeMultiLineByteArray byteArray

print "index" "array elements" "float"
print "-----" "--------------" "-----"

// Convert byte array elements to float values.
BAToSingle byteArray 0 
BAToSingle byteArray 2 
BAToSingle byteArray 6 
BAToSingle byteArray 10 
BAToSingle byteArray 14 
BAToSingle byteArray 18 
BAToSingle byteArray 22 
BAToSingle byteArray 26 
BAToSingle byteArray 30 
BAToSingle byteArray 34 
BAToSingle byteArray 38 
BAToSingle byteArray 42 
BAToSingle byteArray 45 
BAToSingle byteArray 49 
BAToSingle byteArray 51 
BAToSingle byteArray 55 
BAToSingle byteArray 59 


// This example of the BitConverter.ToSingle( byte( ), int )
// method generates the following output. It converts elements
// of a byte array to float values.
//
// initial byte array
// ------------------
// 00-00-00-00-80-3F-00-00-70-41-00-FF-7F-47-00-00-80-3B-00-00-
// 00-00-00-00-80-3F-00-00-70-41-00-FF-7F-47-00-00-80-3B-00-00-
// 80-2F-49-46-83-05-4B-06-9E-3F-4D-06-9E-3F-50-06-9E-3F-1E-37-
// 00-80-7F
//
// index   array elements             float
// -----   --------------             -----
//     0      00-00-00-00    0.0000000E+000
//     2      00-00-80-3F    1.0000000E+000
//     6      00-00-70-41    1.5000000E+001
//    10      00-FF-7F-47    6.5535000E+004
//    14      00-00-80-3B    3.9062500E-003
//    18      00-00-80-2F    2.3283064E-010
//    22      49-46-83-05    1.2345000E-035
//    26      4B-06-9E-3F    1.2345671E+000
//    30      4D-06-9E-3F    1.2345673E+000
//    34      50-06-9E-3F    1.2345676E+000
//    38      1E-37-BE-79    1.2345679E+035
//    42      FF-FF-7F-FF   -3.4028235E+038
//    45      FF-FF-7F-7F    3.4028235E+038
//    49      01-00-00-00    1.4012985E-045
//    51      00-00-C0-FF               NaN
//    55      00-00-80-FF                -∞
//    59      00-00-80-7F                 ∞
//</Snippet4>