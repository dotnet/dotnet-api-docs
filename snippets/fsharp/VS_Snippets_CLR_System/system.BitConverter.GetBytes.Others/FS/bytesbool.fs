module bytesbool

//<Snippet1>
open System

// Define Boolean true and false values.
let values = [ true; false ]

// Display the value and its corresponding byte array.
printfn "%10s%16s\n" "Boolean" "Bytes"

for value in values do
    let bytes = BitConverter.GetBytes value
    
    BitConverter.ToString bytes
    |> printfn "%10b%16s" value


// The example displays the following output:
//        Boolean           Bytes
//
//           true              01
//          false              00
//</Snippet1>