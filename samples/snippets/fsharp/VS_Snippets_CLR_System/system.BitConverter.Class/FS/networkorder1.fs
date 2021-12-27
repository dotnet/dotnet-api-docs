module networkorder1

// <Snippet4>
open System

let value = 12345678
let bytes = BitConverter.GetBytes value
printfn $"{BitConverter.ToString bytes}"

if BitConverter.IsLittleEndian then
    Array.Reverse bytes

printfn $"{BitConverter.ToString bytes}"
// Call method to send byte stream across machine boundaries.

// Receive byte stream from beyond machine boundaries.
printfn $"{BitConverter.ToString bytes}"
if BitConverter.IsLittleEndian then
    Array.Reverse bytes

printfn $"{BitConverter.ToString bytes}"
let result = BitConverter.ToInt32(bytes, 0)

printfn $"Original value: {value}"
printfn $"Returned value: {result}"

// The example displays the following output on a little-endian system:
//       4E-61-BC-00
//       00-BC-61-4E
//       00-BC-61-4E
//       4E-61-BC-00
//       Original value: 12345678
//       Returned value: 12345678
// </Snippet4>