module bcopy

// <Snippet2>
open System

// Display the individual bytes in the array in hexadecimal.
let displayArray (arr: 'a []) (name: string) =
    Console.WindowWidth <- 120
    printf $"%11s{name}:"
    for i = 0 to arr.Length - 1 do
        let bytes =
            match box arr with 
            | :? array<int64> ->
                BitConverter.GetBytes(box arr[i] :?> int64)
            | _ ->
                BitConverter.GetBytes(box arr[i] :?> int16)
        for byteValue in bytes do
            printf $" %02X{byteValue}"
    printfn ""

// Display the individual array element values in hexadecimal.
let inline displayArrayValues (arr: ^a []) name =
    // Get the length of one element in the array.
    let elementLength = Buffer.ByteLength arr / arr.Length
    printf $"%11s{name}:"
    for value in arr do
        printf " %0*X" (2 * elementLength) value 
    printfn ""

// These are the source and destination arrays for BlockCopy.
let src =
    [| 258s; 259s; 260s; 261s; 262s; 263s; 264s
       265s; 266s; 267s; 268s; 269s; 270s |]

let dest = 
    [| 17L; 18L; 19L; 20L |]

// Display the initial value of the arrays in memory.
printfn "Initial values of arrays:"
printfn "   Array values as Bytes:"
displayArray src "src"
displayArray dest "dest"
printfn "   Array values:"
displayArrayValues src "src"
displayArrayValues dest "dest"
printfn ""

// Copy bytes 5-10 from source to index 7 in destination and display the result.
Buffer.BlockCopy(src, 5, dest, 7, 6)
printfn "Buffer.BlockCopy(src, 5, dest, 7, 6 )"
printfn "   Array values as Bytes:"
displayArray src "src"
displayArray dest "dest"
printfn "   Array values:"
displayArrayValues src "src"
displayArrayValues dest "dest"
printfn ""

// Copy bytes 16-20 from source to index 22 in destination and display the result.
Buffer.BlockCopy(src, 16, dest, 22, 5)
printfn "Buffer.BlockCopy(src, 16, dest, 22, 5)"
printfn "   Array values as Bytes:"
displayArray src "src"
displayArray dest "dest"
printfn "   Array values:"
displayArrayValues src "src"
displayArrayValues dest "dest"
printfn ""

// Copy overlapping range of bytes 4-10 to index 5 in source.
Buffer.BlockCopy(src, 4, src, 5, 7)
printfn "Buffer.BlockCopy(src, 4, src, 5, 7)"
printfn "   Array values as Bytes:"
displayArray src "src"
displayArray dest "dest"
printfn "   Array values:"
displayArrayValues src "src"
displayArrayValues dest "dest"
printfn ""

// Copy overlapping range of bytes 16-22 to index 15 in source.
Buffer.BlockCopy(src, 16, src, 15, 7)
printfn "Buffer.BlockCopy(src, 16, src, 15, 7)"
printfn "   Array values as Bytes:"
displayArray src "src"
displayArray dest "dest"
printfn "   Array values:"
displayArrayValues src "src"
displayArrayValues dest "dest"


// The example displays the following output:
//    Initial values of arrays:
//       Array values as Bytes:
//            src: 02 01 03 01 04 01 05 01 06 01 07 01 08 01 09 01 0A 01 0B 01 0C 01 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 00 12 00 00 00 00 00 00 00 13 00 00 00 00 00 00 00 14 00 00 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0104 0105 0106 0107 0108 0109 010A 010B 010C 010D 010E
//           dest: 0000000000000011 0000000000000012 0000000000000013 0000000000000014
//
//    Buffer.BlockCopy(src, 5, dest, 7, 6 )
//       Array values as Bytes:
//            src: 02 01 03 01 04 01 05 01 06 01 07 01 08 01 09 01 0A 01 0B 01 0C 01 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 01 05 01 06 01 07 00 00 00 13 00 00 00 00 00 00 00 14 00 00 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0104 0105 0106 0107 0108 0109 010A 010B 010C 010D 010E
//           dest: 0100000000000011 0000000701060105 0000000000000013 0000000000000014
//
//    Buffer.BlockCopy(src, 16, dest, 22, 5)
//       Array values as Bytes:
//            src: 02 01 03 01 04 01 05 01 06 01 07 01 08 01 09 01 0A 01 0B 01 0C 01 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 01 05 01 06 01 07 00 00 00 13 00 00 00 00 00 0A 01 0B 01 0C 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0104 0105 0106 0107 0108 0109 010A 010B 010C 010D 010E
//           dest: 0100000000000011 0000000701060105 010A000000000013 00000000000C010B
//
//    Buffer.BlockCopy(src, 4, src, 5, 7)
//       Array values as Bytes:
//            src: 02 01 03 01 04 04 01 05 01 06 01 07 08 01 09 01 0A 01 0B 01 0C 01 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 01 05 01 06 01 07 00 00 00 13 00 00 00 00 00 0A 01 0B 01 0C 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0404 0501 0601 0701 0108 0109 010A 010B 010C 010D 010E
//           dest: 0100000000000011 0000000701060105 010A000000000013 00000000000C010B
//
//    Buffer.BlockCopy(src, 16, src, 15, 7)
//       Array values as Bytes:
//            src: 02 01 03 01 04 04 01 05 01 06 01 07 08 01 09 0A 01 0B 01 0C 01 0D 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 01 05 01 06 01 07 00 00 00 13 00 00 00 00 00 0A 01 0B 01 0C 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0404 0501 0601 0701 0108 0A09 0B01 0C01 0D01 010D 010E
//           dest: 0100000000000011 0000000701060105 010A000000000013 00000000000C010B
// </Snippet2>