module batobool

//<Snippet1>
open System

// Define an array of byte values.
let bytes = [| 0uy; 1uy; 2uy; 4uy; 8uy; 16uy; 32uy; 64uy; 128uy; 255uy |]

printfn "%5s%16s%10s\n" "index" "array element" "bool"

// Convert each array element to a Boolean value.
for i = 0 to bytes.Length - 1 do
    printfn $"{i,5}{bytes[i],16:X2}{BitConverter.ToBoolean(bytes, i), 10}"


// The example displays the following output:
//     index   array element      bool
//
//         0              00     False
//         1              01      True
//         2              02      True
//         3              04      True
//         4              08      True
//         5              10      True
//         6              20      True
//         7              40      True
//         8              80      True
//         9              FF      True
//</Snippet1>