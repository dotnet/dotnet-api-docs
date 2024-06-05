module batochar

//<Snippet2>
open System

let print obj1 obj2 obj3 = printfn $"{obj1,5}{obj2,17}{obj3,8}"

// Convert two byte array elements to a char and display it.
let BAToChar bytes index =
    let value = BitConverter.ToChar(bytes, index)

    print index (BitConverter.ToString(bytes, index, 2)) value

let byteArray = 
    [| 32uy; 0uy; 0uy; 42uy; 0uy; 65uy; 0uy; 125uy; 0uy
       197uy; 0uy; 168uy; 3uy; 41uy; 4uy; 172uy; 32uy |]

printfn "This example of the BitConverter.ToChar(byte [], int) \nmethod generates the following output. It converts \nelements of a byte array to char values.\n"
printfn "initial byte array"
printfn "------------------"
printfn $"{BitConverter.ToString byteArray}\n"

print "index" "array elements" "char"
print "-----" "--------------" "----"

// Convert byte array elements to char values.
BAToChar byteArray 0
BAToChar byteArray 1
BAToChar byteArray 3
BAToChar byteArray 5
BAToChar byteArray 7
BAToChar byteArray 9
BAToChar byteArray 11
BAToChar byteArray 13
BAToChar byteArray 15


// This example of the BitConverter.ToChar(byte [], int)
// method generates the following output. It converts
// elements of a byte array to char values.
//
// initial byte array
// ------------------
// 20-00-00-2A-00-41-00-7D-00-C5-00-A8-03-29-04-AC-20
//
// index   array elements    char
// -----   --------------    ----
//     0            20-00
//     1            00-00
//     3            2A-00       *
//     5            41-00       A
//     7            7D-00       }
//     9            C5-00       Å
//    11            A8-03       Ψ
//    13            29-04       Щ
//    15            AC-20       €
//</Snippet2>