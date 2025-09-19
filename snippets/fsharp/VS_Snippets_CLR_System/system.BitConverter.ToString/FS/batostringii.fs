module batostringii

//<Snippet2>
open System

// Display a byte array, using multiple lines if necessary.
let writeMultiLineByteArray (bytes: byte []) (name: string) =
    let rowSize = 20

    printfn $"{name}"
    printfn $"{String('-', name.Length)}"

    let mutable iter = 0
    for i in 0 .. rowSize .. (bytes.Length - rowSize - 1) do
        printfn $"{BitConverter.ToString(bytes, i, rowSize)}-"
        iter <- i
    printfn $"{BitConverter.ToString(bytes, iter + rowSize)}\n"

let arrayOne =
    [| 0uy; 0uy; 0uy; 0uy; 128uy; 63uy; 0uy; 0uy; 112uy; 65uy
       0uy; 255uy; 127uy; 71uy; 0uy; 0uy; 128uy; 59uy; 0uy; 0uy
       128uy; 47uy; 73uy; 70uy; 131uy; 5uy; 75uy; 6uy; 158uy; 63uy
       77uy; 6uy; 158uy; 63uy; 80uy; 6uy; 158uy; 63uy; 30uy; 55uy
       190uy; 121uy; 255uy; 255uy; 127uy; 255uy; 255uy; 127uy; 127uy; 1uy
       0uy; 0uy; 0uy; 192uy; 255uy; 0uy; 0uy; 128uy; 255uy; 0uy
       0uy; 128uy; 127uy |]

let arrayTwo =
    [| 255uy; 255uy; 255uy; 0uy; 0uy; 20uy; 0uy; 33uy; 0uy; 0uy
       0uy; 1uy; 0uy; 0uy; 0uy; 100uy; 167uy; 179uy; 182uy; 224uy
       13uy; 0uy; 202uy; 154uy; 59uy; 0uy; 143uy; 91uy; 0uy; 170uy
       170uy; 170uy; 170uy; 170uy; 170uy; 0uy; 0uy; 232uy; 137uy; 4uy
       35uy; 199uy; 138uy; 255uy; 232uy; 244uy; 255uy; 252uy; 205uy; 255uy
       255uy; 129uy |]

let arrayThree = 
    [| 0uy; 222uy; 0uy; 0uy; 0uy; 224uy; 111uy; 64uy; 0uy; 0uy
       224uy; 255uy; 255uy; 255uy; 239uy; 65uy; 0uy; 0uy; 131uy; 0uy
       0uy; 0uy; 112uy; 63uy; 0uy; 143uy; 0uy; 100uy; 0uy; 0uy
       240uy; 61uy; 223uy; 136uy; 30uy; 28uy; 254uy; 116uy; 170uy; 1uy
       250uy; 89uy; 140uy; 66uy; 202uy; 192uy; 243uy; 63uy; 251uy; 89uy
       140uy; 66uy; 202uy; 192uy; 243uy; 63uy; 252uy; 89uy; 140uy; 66uy
       202uy; 192uy; 243uy; 63uy; 82uy; 211uy; 187uy; 188uy; 232uy; 126uy
       255uy; 255uy; 255uy; 244uy; 255uy; 239uy; 127uy; 1uy; 0uy; 0uy
       0uy; 10uy; 17uy; 0uy; 0uy; 248uy; 255uy; 0uy; 88uy; 0uy
       91uy; 0uy; 0uy; 240uy; 255uy; 0uy; 0uy; 240uy; 157uy |]

printfn "This example of the\n  BitConverter.ToString(byte [], int) and \n  BitConverter.ToString(byte [], int, int) \nmethods generates the following output.\n"

writeMultiLineByteArray arrayOne "arrayOne"
writeMultiLineByteArray arrayTwo "arrayTwo"
writeMultiLineByteArray arrayThree "arrayThree"


// This example of the
//   BitConverter.ToString(byte [], int) and
//   BitConverter.ToString(byte [], int, int)
// methods generates the following output.
//
// arrayOne
// --------
// 00-00-00-00-80-3F-00-00-70-41-00-FF-7F-47-00-00-80-3B-00-00-
// 80-2F-49-46-83-05-4B-06-9E-3F-4D-06-9E-3F-50-06-9E-3F-1E-37-
// BE-79-FF-FF-7F-FF-FF-7F-7F-01-00-00-00-C0-FF-00-00-80-FF-00-
// 00-80-7F
//
// arrayTwo
// --------
// FF-FF-FF-00-00-14-00-21-00-00-00-01-00-00-00-64-A7-B3-B6-E0-
// 0D-00-CA-9A-3B-00-8F-5B-00-AA-AA-AA-AA-AA-AA-00-00-E8-89-04-
// 23-C7-8A-FF-E8-F4-FF-FC-CD-FF-FF-81
//
// arrayThree
// ----------
// 00-DE-00-00-00-E0-6F-40-00-00-E0-FF-FF-FF-EF-41-00-00-83-00-
// 00-00-70-3F-00-8F-00-64-00-00-F0-3D-DF-88-1E-1C-FE-74-AA-01-
// FA-59-8C-42-CA-C0-F3-3F-FB-59-8C-42-CA-C0-F3-3F-FC-59-8C-42-
// CA-C0-F3-3F-52-D3-BB-BC-E8-7E-FF-FF-FF-F4-FF-EF-7F-01-00-00-
// 00-0A-11-00-00-F8-FF-00-58-00-5B-00-00-F0-FF-00-00-F0-9D
//</Snippet2>