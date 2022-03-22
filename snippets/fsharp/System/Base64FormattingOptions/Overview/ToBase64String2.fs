module ToBase64String2

// <Snippet1>
open System

// Define a byte array.
let bytes = [| 2uy; 4uy; 6uy; 8uy; 10uy; 12uy; 14uy; 16uy; 18uy; 20uy |]
printfn $"The byte array:\n   {BitConverter.ToString bytes}\n"

// Convert the array to a base 64 string.
let s = Convert.ToBase64String bytes
printfn $"The base 64 string:\n   {s}\n"

// Restore the byte array.
let newBytes = Convert.FromBase64String s
printfn $"The restored byte array:\n   {BitConverter.ToString newBytes}\n"

// The example displays the following output:
//     The byte array:
//        02-04-06-08-0A-0C-0E-10-12-14
//
//     The base 64 string:
//        AgQGCAoMDhASFA==
//
//     The restored byte array:
//        02-04-06-08-0A-0C-0E-10-12-14
// </Snippet1>