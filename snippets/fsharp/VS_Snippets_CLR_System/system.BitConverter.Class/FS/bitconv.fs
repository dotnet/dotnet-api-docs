module bitconv

//<Snippet1>
open System

let print: obj -> obj -> unit = printfn "%25O%30O"

let aDoubl = 0.1111111111111111111
let aSingl = 0.1111111111111111111f
let aLong = 1111111111111111111L
let anInt = 1111111111
let aShort = 11111s
let aChar = '*'
let aBool = true

printfn "This example of methods of the BitConverter class\ngenerates the following output.\n"
print "argument" "byte array"
print "--------" "----------"

// Convert values to Byte arrays and display them.
print aDoubl (BitConverter.ToString(BitConverter.GetBytes aDoubl))

print aSingl (BitConverter.ToString(BitConverter.GetBytes aSingl))

print aLong (BitConverter.ToString(BitConverter.GetBytes aLong))

print anInt (BitConverter.ToString(BitConverter.GetBytes anInt))

print aShort (BitConverter.ToString(BitConverter.GetBytes aShort))

print aChar (BitConverter.ToString(BitConverter.GetBytes aChar))

print aBool (BitConverter.ToString(BitConverter.GetBytes aBool))


// This example of methods of the BitConverter class
// generates the following output.
//
//                  argument                    byte array
//                  --------                    ----------
//         0.111111111111111       1C-C7-71-1C-C7-71-BC-3F
//                 0.1111111                   39-8E-E3-3D
//       1111111111111111111       C7-71-C4-2B-AB-75-6B-0F
//                1111111111                   C7-35-3A-42
//                     11111                         67-2B
//                         *                         2A-00
//                      True                            01
//</Snippet1>
