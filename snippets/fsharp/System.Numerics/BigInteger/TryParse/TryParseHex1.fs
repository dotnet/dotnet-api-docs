module tryparsehex1

// <Snippet1>
open System.Globalization
open System.Numerics

let hexStrings =
    [| "80"
       "E293"
       "F9A2FF"
       "FFFFFFFF"
       "080"
       "0E293"
       "0F9A2FF"
       "0FFFFFFFF"
       "0080"
       "00E293"
       "00F9A2FF"
       "00FFFFFFFF" |]

for hexString in hexStrings do
    match BigInteger.TryParse(hexString, NumberStyles.AllowHexSpecifier, null) with
    | true, number -> printfn $"Converted 0x{hexString} to {number}."
    | _ -> printfn $"Cannot convert '{hexString}' to a BigInteger."

// The example displays the following output:
//       Converted 0x80 to -128.
//       Converted 0xE293 to -7533.
//       Converted 0xF9A2FF to -417025.
//       Converted 0xFFFFFFFF to -1.
//       Converted 0x080 to 128.
//       Converted 0x0E293 to 58003.
//       Converted 0x0F9A2FF to 16360191.
//       Converted 0x0FFFFFFFF to 4294967295.
//       Converted 0x0080 to 128.
//       Converted 0x00E293 to 58003.
//       Converted 0x00F9A2FF to 16360191.
//       Converted 0x00FFFFFFFF to 4294967295.
// </Snippet1>
