module TryParse

// <Snippet1>
open System

let callTryParse (stringToConvert: string) =
    match Byte.TryParse stringToConvert with
    | true, byteValue ->
        printfn $"Converted '{stringToConvert}' to {byteValue}"
    | _ ->
        printfn $"Attempted conversion of '{stringToConvert}' failed."

let byteStrings = 
    [ null; String.Empty; "1024"
      "100.1"; "100"; "+100"; "-100"
      "000000000000000100"; "00,100"
      "   20   "; "FF"; "0x1F" ]

for byteString in byteStrings do
    callTryParse byteString

// The example displays the following output to the console:
//       Attempted conversion of '' failed.
//       Attempted conversion of '' failed.
//       Attempted conversion of '1024' failed.
//       Attempted conversion of '100.1' failed.
//       Converted '100' to 100
//       Converted '+100' to 100
//       Attempted conversion of '-100' failed.
//       Converted '000000000000000100' to 100
//       Attempted conversion of '00,100' failed.
//       Converted '   20   ' to 20
//       Attempted conversion of 'FF' failed.
//       Attempted conversion of '0x1F' failed.
// </Snippet1>