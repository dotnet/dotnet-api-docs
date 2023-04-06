module setbyte

//<Snippet2>
open System

// Display the array contents in hexadecimal.
let inline displayArray (arr: ^a []) name =
    // Get the array element width; format the formatting string.
    let elemWidth = Buffer.ByteLength arr / arr.Length

    // Display the array elements from right to left.
    printf $"{name,5}:"
    for i = arr.Length - 1 downto 0 do
        printf " %0*X" (2 * elemWidth) arr[i]
    printfn ""

// These are the arrays to be modified with SetByte.
let shorts = Array.zeroCreate<int16> 10
let longs = Array.zeroCreate<int64> 3

printfn "This example of the Buffer.SetByte(Array, int, byte) \nmethod generates the following output.\nNote: The arrays are displayed from right to left.\n"
printfn "  Initial values of arrays:\n"

// Display the initial values of the arrays.
displayArray shorts "shorts"
displayArray longs "longs"

// Copy two regions of source array to destination array,
// and two overlapped copies from source to source.
printfn "\n  Array values after setting byte 3 = 25, \n  byte 6 = 64, byte 12 = 121, and byte 17 = 196:\n"

Buffer.SetByte(shorts, 3, 25uy)
Buffer.SetByte(shorts, 6, 64uy)
Buffer.SetByte(shorts, 12, 121uy)
Buffer.SetByte(shorts, 17, 196uy)
Buffer.SetByte(longs, 3, 25uy)
Buffer.SetByte(longs, 6, 64uy)
Buffer.SetByte(longs, 12, 121uy) 
Buffer.SetByte(longs, 17, 196uy)

// Display the arrays again.
displayArray shorts "shorts"
displayArray longs "longs"


// This example of the Buffer.SetByte( Array, int, byte )
// method generates the following output.
// Note: The arrays are displayed from right to left.
//
//   Initial values of arrays:
//
//  shorts: 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000
//   longs: 0000000000000000 0000000000000000 0000000000000000
//
//   Array values after setting byte 3 = 25,
//   byte 6 = 64, byte 12 = 121, and byte 17 = 196:
//
//  shorts: 0000 C400 0000 0079 0000 0000 0040 0000 1900 0000
//   longs: 000000000000C400 0000007900000000 0040000019000000
//</Snippet2>