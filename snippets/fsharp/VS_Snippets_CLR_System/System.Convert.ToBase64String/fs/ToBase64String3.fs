// <Snippet3>
open System

// Define a byte array.
let bytes = 
    [| for i = 0 to 99 do byte (i + 1) |]

let originalTotal = Array.sumBy int bytes

// Display summary information about the array.
printfn "The original byte array:"
printfn $"   Total elements: {bytes.Length}"
printfn $"   Length of String Representation: {BitConverter.ToString(bytes).Length}"
printfn $"   Sum of elements: {originalTotal:N0}"
printfn ""

// Convert the array to a base 64 string.
let s = Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks)
printfn $"The base 64 string:\n   {s}\n"

// Restore the byte array.
let newBytes = Convert.FromBase64String s

let newTotal = Array.sumBy int newBytes

// Display summary information about the restored array.
printfn $"   Total elements: {newBytes.Length}"
printfn $"   Length of String Representation: {BitConverter.ToString(newBytes).Length}"
printfn $"   Sum of elements: {newTotal:N0}"

// The example displays the following output:
//   The original byte array:
//      Total elements: 100
//      Length of String Representation: 299
//      Sum of elements: 5,050
//
//   The base 64 string:
//      AQIDBAUGBwgJCgsMDQ4PEBESExQVFhcYGRobHB0eHyAhIiMkJSYnKCkqKywtLi8wMTIzNDU2Nzg5
//   Ojs8PT4/QEFCQ0RFRkdISUpLTE1OT1BRUlNUVVZXWFlaW1xdXl9gYWJjZA==
//
//      Total elements: 100
//      Length of String Representation: 299
//      Sum of elements: 5,050
// </Snippet3>
