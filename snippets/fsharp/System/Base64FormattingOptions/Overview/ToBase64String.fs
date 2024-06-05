module ToBase64String

// <Snippet2>
open System

let displayArray (arr: 'a[]) =
    printfn "The array:"
    printf "{ "
    for i = 0 to arr.GetUpperBound(0) - 1 do
        printf $"{arr[i]}, "
        if (i + 1) % 10 = 0 then
            printf "\n  "
    printfn $"{arr[arr.GetUpperBound 0]} }}\n"

// Define an array of 20 elements and display it.
let arr = Array.zeroCreate<int> 20
let mutable value = 1
for i = 0 to arr.GetUpperBound 0 do
    arr[i] <- value
    value <- value * 2 + 1
displayArray arr

// Convert the array of integers to a byte array.
let bytes = Array.zeroCreate<byte> (arr.Length * 4)
for i = 0 to arr.Length - 1 do
    Array.Copy(BitConverter.GetBytes(arr[i]), 0, bytes, i * 4, 4)

// Encode the byte array using Base64 encoding
let base64 = Convert.ToBase64String bytes
printfn "The encoded string: "
printfn $"{base64}\n"

// Convert the string back to a byte array.
let newBytes = Convert.FromBase64String base64

// Convert the byte array back to an integer array.
let newArr = Array.zeroCreate<int> (newBytes.Length / 4)
for i = 0 to newBytes.Length / 4 - 1 do
    newArr[i] <- BitConverter.ToInt32(newBytes, i * 4)

displayArray newArr

// The example displays the following output:
// The array:
// { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023,
//   2047, 4095, 8191, 16383, 32767, 65535, 131071, 262143, 524287, 1048575 }
//
// The encoded string:
// AQAAAAMAAAAHAAAADwAAAB8AAAA/AAAAfwAAAP8AAAD/AQAA/wMAAP8HAAD/DwAA/x8AAP8/AAD/fwAA//8AAP//AQD//wMA//8HAP//DwA=
//
// The array:
// { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023,
//   2047, 4095, 8191, 16383, 32767, 65535, 131071, 262143, 524287, 1048575 }
// </Snippet2>