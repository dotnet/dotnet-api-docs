module buffer

//<Snippet1>
open System

// Display the array elements from right to left in hexadecimal.
let displayArray (arr: int16 []) =
    printf "  arr:"
    for i = arr.Length - 1 downto 0 do
        printf $" {arr[i]:X4}"
    printfn ""

// This array is to be modified and displayed.
let arr = 
    [| 258s; 259s; 260s; 261s; 262s; 263s; 264s
       265s; 266s; 267s; 268s; 269s; 270s; 271s |]

printfn "This example of the Buffer class methods generates the following output.\nNote: The array is displayed from right to left.\n"
printfn "Initial values of array:\n"

// Display the initial array values and ByteLength.
displayArray arr
printfn $"\nBuffer.ByteLength(arr): {Buffer.ByteLength arr}"

// Copy a region of the array; set a byte within the array.
printfn "\nCall these methods: \n  Buffer.BlockCopy(arr, 5, arr, 16, 9),\n  Buffer.SetByte(arr, 7, 170).\n"

Buffer.BlockCopy(arr, 5, arr, 16, 9)
Buffer.SetByte(arr, 7, 170uy)

// Display the array and a byte within the array.
printfn "Final values of array:\n"
displayArray arr
printfn $"\nBuffer.GetByte(arr, 26): {Buffer.GetByte(arr, 26)}"


// This example of the Buffer class methods generates the following output.
// Note: The array is displayed from right to left.
//
// Initial values of array:
//
//   arr: 010F 010E 010D 010C 010B 010A 0109 0108 0107 0106 0105 0104 0103 0102
//
// Buffer.ByteLength(arr): 28
//
// Call these methods:
//   Buffer.BlockCopy(arr, 5, arr, 16, 9),
//   Buffer.SetByte(arr, 7, 170).
//
// Final values of array:
//
//   arr: 010F 0101 0801 0701 0601 0501 0109 0108 0107 0106 AA05 0104 0103 0102
//
// Buffer.GetByte(arr, 26): 15
//</Snippet1>