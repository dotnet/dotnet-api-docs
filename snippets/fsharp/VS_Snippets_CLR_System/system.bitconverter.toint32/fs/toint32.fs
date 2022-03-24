// <Snippet1>
open System

let formatBytes (bytes: byte []) =
    bytes
    |> Array.map (fun x -> $"{x:X2}")
    |> String.concat ""

// Create an Integer from a 4-byte array.
let bytes1 = [| 0xECuy; 0x00uy; 0x00uy; 0x00uy |]
let int1  = BitConverter.ToInt32(bytes1, 0)
printfn $"{formatBytes bytes1}--> 0x{int1:X4} ({int1:N0})"

// Create an Integer from the upper four bytes of a byte array.
let bytes2 = BitConverter.GetBytes(Int64.MaxValue / 2L)
let int2 = BitConverter.ToInt32(bytes2, 4)
printfn $"{formatBytes bytes2}--> 0x{int2:X4} ({int2:N0})"

// Round-trip an integer value.
let original = pown 16 3
let bytes3 = BitConverter.GetBytes original
let restored = BitConverter.ToInt32(bytes3, 0)
printfn $"0x{original:X4} ({original:N0}) --> {formatBytes bytes3} --> 0x{restored:X4} ({restored:N0})"


// The example displays the following output:
//       EC 00 00 00 --> 0x00EC (236)
//       FF FF FF FF FF FF FF 3F --> 0x3FFFFFFF (1,073,741,823)
//       0x1000 (4,096) --> 00 10 00 00  --> 0x1000 (4,096)
// </Snippet1>