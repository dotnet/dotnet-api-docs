module batostring

//<Snippet1>
open System

// Display a byte array with a name.
let writeByteArray (bytes: byte[]) (name: string) =
    printfn $"{name}"
    printfn $"{String('-', name.Length)}"
    printfn $"{BitConverter.ToString bytes}\n"

let arrayOne = 
    [| 0uy; 1uy; 2uy; 4uy; 8uy; 16uy; 32uy; 64uy; 128uy; 255uy |]

let arrayTwo = 
    [| 32uy; 0uy; 0uy; 42uy; 0uy; 65uy; 0uy; 125uy; 0uy
       197uy; 0uy; 168uy; 3uy; 41uy; 4uy; 172uy; 32uy |]

let arrayThree =
    [| 15uy; 0uy; 0uy; 128uy; 16uy; 39uy; 240uy; 216uy; 241uy; 255uy; 127uy |]

let arrayFour =
    [| 15uy; 0uy; 0uy; 0uy; 0uy; 16uy; 0uy; 255uy; 3uy; 0uy; 0uy; 202uy
       154uy;  59uy; 255uy; 255uy; 255uy; 255uy; 127uy |]

printfn "This example of the BitConverter.ToString(byte []) \nmethod generates the following output.\n"

writeByteArray arrayOne "arrayOne"
writeByteArray arrayTwo "arrayTwo"
writeByteArray arrayThree "arrayThree"
writeByteArray arrayFour "arrayFour"


// This example of the BitConverter.ToString( byte[ ] )
// method generates the following output.
//
// arrayOne
// --------
// 00-01-02-04-08-10-20-40-80-FF
//
// arrayTwo
// --------
// 20-00-00-2A-00-41-00-7D-00-C5-00-A8-03-29-04-AC-20
//
// arrayThree
// ----------
// 0F-00-00-80-10-27-F0-D8-F1-FF-7F
//
// arrayFour
// ---------
// 0F-00-00-00-00-10-00-FF-03-00-00-CA-9A-3B-FF-FF-FF-FF-7F
//</Snippet1>